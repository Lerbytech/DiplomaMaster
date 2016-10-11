using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.Util.TypeEnum;
using ZedGraph;

namespace DiplomaMaster
{
  
  public partial class Form1 : Form
  {
    #region private vars
    private Image<Bgr, Byte> _BigImage;
    private Image<Gray, Byte> _MaskImage;
    private Image<Bgr, Byte> _AugImage;

    private StructMainFormParams MainFormParameters;
    #endregion

    public delegate void FormUpdatedHandler(StructMainFormParams newParams);
    public event FormUpdatedHandler onFormUpdated;

    public Image<Gray, Byte> MaskImage
    {
      get { return _MaskImage; }
      private set
      {
        _MaskImage = value;
        MaskImageBox.Image = value.Resize(MaskImageBox.Width, MaskImageBox.Height, Inter.Nearest);
      }
    }
    public Image<Bgr, Byte> BigImage
    {
      get { return _BigImage; }
      private set
      {
        _BigImage = value;
        BigImageBox.Image = value.Resize(BigImageBox.Width, BigImageBox.Height, Inter.Nearest);
      }
    }
    public Image<Bgr, Byte> AugImage
    {
      get { return _AugImage; }
      private set
      {
        _AugImage = value;
        AugImageBox.Image = value.Resize(AugImageBox.Width, AugImageBox.Height, Inter.Nearest);
      }
    }

    public string input_path
    {
      get { return MainFormParameters.PathToLoadFolder; }
      private set
      {
        MainFormParameters.PathToLoadFolder = value;
        DrawSampleImage();
      }
    }
    public string save_path
    {
      get { return MainFormParameters.PathToSaveFolder; }
      private set
      {
        MainFormParameters.PathToSaveFolder = value;
        if (MainFormParameters.PathToSaveFolder != String.Empty && MainFormParameters.PathToSaveFolder != null)
          ControllerUnit.Initialize(MainFormParameters);
        else TB_SavePath.Text = String.Empty;
      }
    }

    //-------------------------------------------
    //-------------------------------------------
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      MainFormParameters = new StructMainFormParams();
      MainFormParameters.MaskingModes = ControllerUnit.GetListOfMaskingModes();
      MainFormParameters.DenoiseModes = ControllerUnit.GetListOfDenoiseModes();

      FillDenoiseOptions();
      FillMaskingOptions();
      //onFormUpdated += ControllerUnit.FormUpdated(MainFormParameters);
    }

    #region заполнение формы при загрузке

    private void FillDenoiseOptions()
    {
      if (MainFormParameters.DenoiseModes.Count == 0)
        throw new Exception("FillDenoiseOptions: список опций пуст");
      else
      {
        foreach (var I in MainFormParameters.DenoiseModes)
          CB_DenoiseMode.Items.Add(I);

        CB_DenoiseMode.SelectedIndex = 0;
        MainFormParameters.CurDenoiseMode = 0;
      }
    }

    private void FillMaskingOptions()
    {
      if (MainFormParameters.MaskingModes.Count == 0)
        throw new Exception("FillMaskingOptions: список опций пуст");
      else
      {
        foreach (var I in MainFormParameters.MaskingModes)
          CB_MaskingMode.Items.Add(I);

        CB_MaskingMode.SelectedIndex = 0;
        MainFormParameters.CurMaskingMode = 0;
      }
    }

    private void DrawSampleImage()
    {
      Image<Bgr, Byte> tmp = new Image<Bgr, byte>(1, 1, new Bgr(0,0,0));
      try
      {
        tmp = ControllerUnit.GetSampleImage(input_path);
      }
      catch (Exception ex) { MessageBox.Show(ex.Message); }
      if ( tmp == null) MessageBox.Show("DrawSampleImage: не удается отобразить изображение"); 

      BigImage = tmp;
    }
    #endregion

    //-------------------------
    private void BTN_StartProcessing_Click(object sender, EventArgs e)
    {
      #region Check input path and save path

      bool is_all_paths_correct = true;
      
      bool FIRST = false;

      
        if (!Directory.Exists(TB_DataPath.Text)) is_all_paths_correct = false;
        // Check save path
        if (TB_SavePath.Text.IndexOfAny(Path.GetInvalidPathChars()) != -1) is_all_paths_correct = false;
        if (!is_all_paths_correct) throw new Exception("Invalid paths!");
        else
        {
          input_path = TB_DataPath.Text;
          save_path = TB_SavePath.Text;
        }
      
      #endregion

      
        #region Create output directories
        if (Directory.Exists(save_path)) Directory.Delete(save_path);
        Directory.CreateDirectory(save_path);
        Directory.CreateDirectory(save_path + @"\Raw\");
        Directory.CreateDirectory(save_path + @"\Z-Project Gray\");
        Directory.CreateDirectory(save_path + @"\Z-Project Color\");
        Directory.CreateDirectory(save_path + @"\Sigma Rejection\");
        Directory.CreateDirectory(save_path + @"\Binary Masks\");

        Directory.CreateDirectory(save_path + @"\Neurons Data\");
        Directory.CreateDirectory(save_path + @"\Neurons Data\Images\");
        Directory.CreateDirectory(save_path + @"\Neurons Data\AvgImages\");
        Directory.CreateDirectory(save_path + @"\Neurons Data\RawImages\");
        Directory.CreateDirectory(save_path + @"\Neurons Data\AvgRawImages\");

        Directory.CreateDirectory(save_path + @"\Plots\");
        Directory.CreateDirectory(save_path + @"\Plots\Images\");
        Directory.CreateDirectory(save_path + @"\Plots\AvgImages\");
        Directory.CreateDirectory(save_path + @"\Plots\RawImages\");
        Directory.CreateDirectory(save_path + @"\Plots\AvgRawImages\");

        #endregion
      
      // Read all input images and sort them
      List<Image<Gray, Byte>> RawImages = GetImages(GetFiles(input_path));
      for (int i = 0; i < RawImages.Count; i++) RawImages[i].Save(save_path + @"\Raw\" + i.ToString() + ".png");

      
        #region Z-Projections
        //Find Z-Projections
        Image<Gray, Byte> ZP_MinImg = Z_Projections.ZP_Min(RawImages);
        Image<Gray, Byte> ZP_MaxImg = Z_Projections.ZP_Max(RawImages);
        //Save Z-Projections
        ZP_MinImg.Save((save_path + @"\Z-Project Gray\" + "Min.png"));
        ZP_MaxImg.Save((save_path + @"\Z-Project Gray\" + "Max.png"));
        #endregion
      
      #region Sigma-Rejections
      //List<Image<Gray, Byte>> Images = GetImages(GetFiles(input_path));
      List<Image<Gray, Byte>> Images = new List<Image<Gray, byte>>();
      //Images.AddRange(RawImages);

        ImgProcTools.Denoise.PrepareDenoiseFunctions(RawImages[0].Width, RawImages[0].Height);
        //Save sigma Rejections
        for (int i = 0; i < RawImages.Count; i++)
        {
          Images.Add(ImgProcTools.Denoise.SigmaReject2(RawImages[i]));
          Images[i].Save(save_path + @"\Sigma Rejection\" + i.ToString() + ".png");
        }
     
   
      #endregion 

      #region Make init mask
      Image<Gray, byte> TMP = new Image<Gray, byte>(Images[10].Size); // with small pixels
      Image<Gray, byte> TMP2 = new Image<Gray, byte>(Images[10].Size); //NO SMALL pixels
      TMP = Images[10].Clone();
      TMP2 = Images[10].Clone();
      CvInvoke.CLAHE(Images[10], 100, new System.Drawing.Size(8, 8), TMP);
      
      double MaxEl = 154;
      TMP = TMP.ThresholdToZero(new Gray(MaxEl));
      TMP._EqualizeHist();
      
      //TMP.Save(@"C:\Users\Админ\Desktop\TMP.png");
      
      Image<Gray, Byte> NoiseMask = TMP.ThresholdBinary(new Gray(10),  new Gray(255));
      
      NoiseMask = NoiseMask.Erode(1);
      NoiseMask = NoiseMask.Dilate(1);
      
      TMP2 = TMP.Copy(NoiseMask);
      

      TMP2.Save(save_path + "\\InitMask.png");
      #endregion

      #region generate bin masks
     // save_path = @"C:\Users\Admin\Desktop\Антон\EXPERIMENTS\Processed\Processed\2CH_65 part 1";
      
      TMP = ImgProcTools.BinarizationMethods.BinByDistanceTransform(new Image<Gray, Byte>(save_path + "\\InitMask2.png"));
      
      VectorOfVectorOfPoint AllContours = ImgProcTools.EdgeDetection.SimplestEdgeDetection(TMP);
    
      List<VectorOfPoint> smallContours = new List<VectorOfPoint>();
      List<VectorOfPoint> rejectedContours = new List<VectorOfPoint>();
      List<VectorOfPoint> BigContours = NeuronSeparation.Calculations.SeparateSmallContours(NeuronSeparation.Converter.VVOPToListOfVOP(AllContours), out smallContours, out rejectedContours, 100);

      List<NeuronBodyMask> NBM = new List<NeuronBodyMask>();
      NBM = NeuronSeparation.Masks.GetNeuronBodyMasks(BigContours);
      #endregion

      #region save all masks
      Image<Gray, Byte> SignalImg = NBM[0].BodyMask.CopyBlank();
      CvInvoke.cvSetImageROI(SignalImg, new Rectangle( 5, 5, 172, 130));
      //CvInvoke.cvResetImageROI(SignalImg);
      try
      {
        ZP_MaxImg.CopyTo(SignalImg);
        ZP_MaxImg = SignalImg.Clone();
        CvInvoke.cvResetImageROI(ZP_MaxImg);
        Images[10].CopyTo(SignalImg);
      }
      catch (Exception ex) { }
      CvInvoke.cvResetImageROI(SignalImg);

      Image<Bgr, Byte> BGRImg; // = new Image<Bgr, byte>(Images[0].Bitmap);
      for (int i = 0; i < NBM.Count; i++)
      {
        //Pure Mask
        NBM[i].BodyMask.Save(save_path + @"\Binary Masks\" + i.ToString() + ".png");
        //Signal
        try
        {
          SignalImg = ZP_MaxImg.Copy(NBM[i].BodyMask);
          //ZP_MaxImg.Copy(NBM[i].BodyMask).CopyTo(SignalImg);
        }
        catch (Exception ex) { }
        SignalImg.Save(save_path + @"\Binary Masks\Signal_" + i.ToString() + ".png");
        //Borders
        /*
        BGRImg = new Image<Bgr,byte>(ZP_MaxImg.Bitmap);
        try
        {
          CvInvoke.DrawContours(BGRImg, BigContours[i], 0, new MCvScalar(0, 255, 0), 1, Emgu.CV.CvEnum.LineType.EightConnected);
        }
        catch (Exception ex) { }
        BGRImg.Save(save_path + @"\Binary Masks\ColorSignal_" + i.ToString() + ".png");
         * */
      }
      #endregion

      try
      {
        
        List<List<double>> Intensities = GetiIntensities(Images, NBM);
        SaveIntensities(Intensities, save_path + @"\Neurons Data\Images\");
        //PlotGraphics(Intensities, save_path + @"\Plots\Images\");

        for (int i = 0; i < Intensities.Count; i++)
          Intensities[i] = WindowAVG(Intensities[i], 20);
        SaveIntensities(Intensities, save_path + @"\Neurons Data\AvgImages\");
        //PlotGraphics(Intensities, save_path + @"\Plots\AvgImages\");
        //
        Intensities = GetiIntensities(RawImages, NBM);
        SaveIntensities(Intensities, save_path + @"\Neurons Data\RawImages\");
//        PlotGraphics(Intensities, save_path + @"\Plots\RawImages\");

        for (int i = 0; i < Intensities.Count; i++)
          Intensities[i] = WindowAVG(Intensities[i], 20);
        SaveIntensities(Intensities, save_path + @"\Neurons Data\AvgRawImages\");
  //      PlotGraphics(Intensities, save_path + @"\Plots\AvgRawImages\");
      }
      catch (Exception ex) { }

      int b = 5;


      
    }

    public List<List<double>> GetiIntensities(List<Image<Gray, Byte>> IMGS, List<NeuronBodyMask> Masks)
    { 
      
      Image<Gray, Byte> SignalImg = Masks[0].BodyMask.CopyBlank();
      CvInvoke.cvSetImageROI(SignalImg, new Rectangle(5, 5, 172, 130));
      Image<Gray, Byte> MinImg = Z_Projections.ZP_Avg(IMGS);
      //Image<Gray, Byte> MinImg = new Image<Gray, byte>(@"C:\Users\Админ\Desktop\НИР\EXPERIMENTS\Separated\M-Movie013\Z-Project Gray\MIN_M-Movie0013.tif");
      
      try
      {
        
        //MinImg = new Image<Gray, byte>(@"C:\Users\Админ\Desktop\НИР\EXPERIMENTS\Separated\M-Movie013\Z-Project Gray\MIN_M-Movie0013.tif");
        MinImg.CopyTo(SignalImg);
        MinImg = SignalImg;
        CvInvoke.cvResetImageROI(MinImg);
         
      }
      catch (Exception ex) { }

      List<List<double>> Intensities = new List<List<double>>();
      for (int i = 0; i < Masks.Count; i++)
      {
        Intensities.Add(new List<double>());
        Intensities[i] = new List<double>();
      }

      //SignalImg = Images[0].CopyBlank();
      Image<Gray, Byte> biggerImg = Masks[0].BodyMask.CopyBlank();
      CvInvoke.cvResetImageROI(SignalImg);

      for (int i = 0; i < IMGS.Count; i++)
      {
        for (int j = 0; j < Masks.Count; j++)
        {
          try
          {
            //CvInvoke.cvSetImageROI(biggerImg , new Rectangle(5,5,172,130));
            CvInvoke.cvSetImageROI(biggerImg, new Rectangle(5, 5, 172, 130));
            IMGS[i].CopyTo(biggerImg);
            CvInvoke.cvResetImageROI(biggerImg);

            SignalImg = biggerImg.Copy(Masks[j].BodyMask) - MinImg;
            Intensities[j].Add(CvInvoke.Sum(SignalImg).V0);
          }
          catch (Exception ex) { }

        }
      }

      return Intensities;
    }
    
    public void SaveIntensities(List< List< double>> Input, string Path)
    {
      for (int i = 0; i < Input.Count; i++)
      {
        using (System.IO.StreamWriter file =
             new System.IO.StreamWriter(Path + "Neuron_" + i.ToString() + ".txt"))
        {
          foreach (double Val in Input[i])
          {
            file.WriteLine(((int)Val).ToString());

          }
        }
      }
    }
    /*
    public void PlotGraphics(List<List<double>> inputIntens, string path)
    {
      List<double> Y = new List<double>();
      List<double> X = new List<double>();
      for (int i = 0; i < inputIntens[0].Count; i++) X.Add(i);

      for (int i = 0; i < inputIntens.Count; i++)
      { 
        Y = inputIntens[i];

        GraphPane pane1 = zedGraphControl.GraphPane;
        pane1.XAxis.Scale.Max = X.Count + 50;
        pane1.CurveList.Clear();
        pane1.XAxis.Title.Text = "Номер кадра";
        pane1.YAxis.Title.Text = "Интенсивность ";
        pane1.Title.Text = "Нейрон №" + i.ToString();

        PointPairList list1 = new PointPairList(X.ToArray(), Y.ToArray());
        LineItem myCurve1 = pane1.AddCurve("", list1, Color.Black, SymbolType.None);
        zedGraphControl.AxisChange();
        zedGraphControl.Invalidate();

        Image bp1 = zedGraphControl.GetImage();
        //bp1.Save(save_path + @"\Plots\" + "Neuron_" + i.ToString() + ".png");
        bp1.Save(path + "Neuron_" + i.ToString() + ".png");
      }
      

    }
    */
    public List<string> GetFiles(string path)
    {
      List<string> allfiles = Directory.GetFiles(path).ToList<string>();
      return allfiles;
      /*
      int path_len = path.Length;
      int exten_lem = 4;

      List<string> res = new List<string>();

      for (int i = 0; i < allfiles.Count; i++) if (allfiles[i].Length == (path_len + exten_lem + 1)) res.Add(allfiles[i]);
      for (int i = 0; i < allfiles.Count; i++) if (allfiles[i].Length == (path_len + exten_lem + 2)) res.Add(allfiles[i]);
      for (int i = 0; i < allfiles.Count; i++) if (allfiles[i].Length == (path_len + exten_lem + 3)) res.Add(allfiles[i]);
      for (int i = 0; i < allfiles.Count; i++) if (allfiles[i].Length == (path_len + exten_lem + 4)) res.Add(allfiles[i]);
      for (int i = 0; i < allfiles.Count; i++) if (allfiles[i].Length == (path_len + exten_lem + 5)) res.Add(allfiles[i]);
      for (int i = 0; i < allfiles.Count; i++) if (allfiles[i].Length == (path_len + exten_lem + 6)) res.Add(allfiles[i]);
      for (int i = 0; i < allfiles.Count; i++) if (allfiles[i].Length == (path_len + exten_lem + 7)) res.Add(allfiles[i]);
      for (int i = 0; i < allfiles.Count; i++) if (allfiles[i].Length == (path_len + exten_lem + 8)) res.Add(allfiles[i]);
      for (int i = 0; i < allfiles.Count; i++) if (allfiles[i].Length == (path_len + exten_lem + 9)) res.Add(allfiles[i]);
      for (int i = 0; i < allfiles.Count; i++) if (allfiles[i].Length == (path_len + exten_lem + 10)) res.Add(allfiles[i]);
      
      return res;*/
    }

    public List<Image<Gray, Byte>> GetImages(List<string> input)
    {
      Image<Gray, Byte> tmp = new Image<Gray, byte>(1, 1);
      List<Image<Gray, Byte>> res = new List<Image<Gray, byte>>();
      foreach (var value in input)
      {
        tmp = new Image<Gray, byte>(value);
        res.Add(tmp);
      }

      return res;
    }

    public List<double> WindowAVG(List<double> input, int window)
    {
      double dec = 1 / (double)window;
      double cap;
      List<double> res = new List<double>();

      for (int i = 0; i < input.Count - window; i++)
      {
        cap = 0;
        for (int j = i; j < i + window; j++)
          cap += input[j];
        res.Add(cap * dec);
      }

      return res;
    }
    //---------------------

    #region Кнопки

    private void BTN_EditMask_Click(object sender, EventArgs e)
    {
      MessageBox.Show("NOT IMPLEMENTED YET!!");
    }

    private void BTN_LoadMask_Click(object sender, EventArgs e)
    {
      // Логика открытия файла

      OpenFileDialog Dialog = new OpenFileDialog();
      if (Directory.Exists(@"C:\Users\Admin\Desktop\Антон"))
        Dialog.InitialDirectory = @"C:\Users\Admin\Desktop\Антон";
      else Dialog.InitialDirectory = "C:\\";

      Dialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
      Dialog.FilterIndex = 2;
      Dialog.RestoreDirectory = true;

      string tmp = String.Empty;
      if (Dialog.ShowDialog() == DialogResult.OK)
        tmp = Dialog.FileName;

      // проверяем что выбрали
      int res = ControllerUnit.TestMask(tmp);

      switch (res)
      {
        case 0: MessageBox.Show("ERROR! Функция загрузки маски вернула null!"); break;
        case 1: MessageBox.Show("Изображение содержащее маску имеет неверный размер!"); break;
        case 2: MaskImage = ControllerUnit.GetMask(); break;
      }
    }

    private void BTN_ExportMask_Click(object sender, EventArgs e)
    {
      MessageBox.Show("NOT IMPLEMENTED YET!!");
    }

    private void BTN_SeeAllMasks_Click(object sender, EventArgs e)
    {
      MessageBox.Show("NOT IMPLEMENTED YET!!");
    }

    private void BTN_ChooseExportFolder_Click(object sender, EventArgs e)
    {
      string tmp = String.Empty;
      DialogResult result = folderBrowserDialog.ShowDialog();

      if (result == DialogResult.OK)
        tmp = folderBrowserDialog.SelectedPath;

      //MainFormParameters.PathToSaveFolder = tmp;
      save_path = tmp;
      TB_SavePath.Text = tmp;
    }

    private void BTN_ImportParametrs_Click(object sender, EventArgs e)
    {
      MessageBox.Show("NOT IMPLEMENTED YET!!");
    }

    private void BTN_ExportParametrs_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog1 = new SaveFileDialog();
      saveFileDialog1.Filter = ".txt";
      saveFileDialog1.Title = "Save parameters to file";
      saveFileDialog1.ShowDialog();

      if (saveFileDialog1.FileName != "")
      {

        ControllerUnit.Export(MainFormParameters, saveFileDialog1.FileName);
      }

      MessageBox.Show("NOT IMPLEMENTED YET!!");
    }

    private void BTN_ChooseInputFolder_Click(object sender, EventArgs e)
    {
      //преднастройка диалога
      OpenFileDialog Dialog = new OpenFileDialog();
      if (Directory.Exists(@"C:\Users\Admin\Desktop\Антон"))
        Dialog.InitialDirectory = @"C:\Users\Admin\Desktop\Антон";
      else Dialog.InitialDirectory = "C:\\";
      Dialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
      Dialog.FilterIndex = 2;
      Dialog.RestoreDirectory = true;

      //название папки
      string tmp = String.Empty;
      if (Dialog.ShowDialog() == DialogResult.OK)
        tmp = new FileInfo(Dialog.FileName).DirectoryName;

      //настраиваем по полученным данным поля
      //MainFormParameters.PathToLoadFolder = tmp;
      input_path = tmp;
      TB_DataPath.Text = tmp;
    }
    #endregion

    #region чекбоксы

    private void CB_RewriteMasks_CheckedChanged(object sender, EventArgs e)
    {
      MessageBox.Show("NOT IMPLEMENTED YET!!");
    }

    private void CB_OverwriteFiles_CheckedChanged(object sender, EventArgs e)
    {
      MessageBox.Show("NOT IMPLEMENTED YET!!");
    }

    private void CB_UseCleanFiles_CheckedChanged(object sender, EventArgs e)
    {
      MessageBox.Show("NOT IMPLEMENTED YET!!");
    }

    private void CB_MaskingMode_SelectedIndexChanged(object sender, EventArgs e)
    {
      ControllerUnit.SetMaskingMethod(CB_MaskingMode.SelectedText);
    }

    private void CB_DenoiseMode_SelectedIndexChanged(object sender, EventArgs e)
    {
      ControllerUnit.SetDenoisingMethod(CB_DenoiseMode.SelectedText);
    }

    #endregion



  }
}
