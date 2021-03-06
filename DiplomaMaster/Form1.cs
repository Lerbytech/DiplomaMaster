﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ZedGraph;

namespace DiplomaMaster
{
  
  public partial class Form1 : Form
  {
    #region private vars
    private Image<Bgr, Byte> _BigImage;
    private Image<Gray, Byte> _MaskImage;
    private Image<Bgr, Byte> _AugImage;
    private Image<Gray, Byte> _smallImage;

    private StructMainFormParams MainFormParameters;
    private CControllerUnit ControllerUnit;

    #endregion

    public delegate void FormUpdatedHandler(StructMainFormParams newParams);
    public event FormUpdatedHandler onFormUpdated;

    public Image<Gray, Byte> SmallImage
    {
      get { return _smallImage; }
      private set
      {
        _smallImage = value;
        BigImage = value.Convert<Bgr, Byte>();
        MainFormParameters.sampleImage = value.Clone();
      }
    }

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
        TB_SavePath.Text = value;
        DrawMaskImage();
        DrawAugmentatedImage();
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
      ControllerUnit = new CControllerUnit();
      MainFormParameters.MaskingModes = ControllerUnit.GetListOfMaskingModes();
      MainFormParameters.DenoiseModes = ControllerUnit.GetListOfDenoiseModes();

      FillMaskingOptions();
      FillDenoiseOptions();

      ControllerUnit.onNewImage += UpdateImageBox;
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

    private void DrawMaskImage()
    {
      MaskImage = ControllerUnit.GetMask(SmallImage);
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
      
      SmallImage = tmp.Convert<Gray, Byte>();      
      BigImage = tmp;
    }

    private void DrawAugmentatedImage()
    {
      Image<Bgr, Byte> res = BigImage.Clone();
      res[1] = res[1] + MaskImage.ThresholdBinary(new Gray(1), new Gray(100));
      AugImage = res;
    }
    #endregion

    public void UpdateImageBox(Image<Gray, Byte> newImage)
    {
      ProgressBar.Value += 1;
      
      Application.DoEvents();
    }

    //-------------------------
    private void BTN_StartProcessing_Click(object sender, EventArgs e)
    {
      ControllerUnit.Initialize(MainFormParameters);
      ProgressBar.Maximum = ControllerUnit.GetTotalNumberOfImages();
      ControllerUnit.StartProcessing();

      MessageBox.Show("Работа завершена!");
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

      //-----
      /*
      string pathDir = @"C:\Users\Admin\Desktop\Антон\59 vanb\Source\Debug_2nd experiment work2";
      string[] filenames = Directory.GetFiles(pathDir);

      OrderFiles(ref filenames);
      string destDir = @"C:\Users\Admin\Desktop\Антон\59 vanb\Splitted\Debug_2nd experiment work2 Chunk 2\";
      string ss = String.Empty;

      for (int i = 120524; i < filenames.Length; i++)
      {

        ss = filenames[i].Substring(filenames[i].LastIndexOf("\\") + 1);
        ss = destDir + ss;
        File.Copy(filenames[i], ss);

      }
        */

      //-----

      MessageBox.Show("NOT IMPLEMENTED YET!!");
    }


    private void OrderFiles(ref string[] FileEntries)
    {
      SortedDictionary<int, List<string>> LineLengthsDict = new SortedDictionary<int, List<string>>();

      int L = 0;
      for (int i = 0; i < FileEntries.Length; i++)
      {
        L = FileEntries[i].Length;
        if (!LineLengthsDict.ContainsKey(L))
          LineLengthsDict.Add(L, new List<string>());

        LineLengthsDict[L].Add(FileEntries[i]);
      }

      List<string> res = new List<string>();

      foreach (var I in LineLengthsDict)
        res.AddRange(I.Value);
      //FullPathsToFiles = res.ToArray();

      FileEntries = res.ToArray();
      /*
     List<List<string>> Data = new List<List<string>>();

     L = PathToDirectory.Length + FileExtension.Length;

     for (int i = 0; i < FileEntries.Length; i++)
     {
       if (FileEntries[i].Length > Data.Count + L)
       {
         Data.Add(new List<string>());
       }
       Data[FileEntries[i].Length - Data.Count - L].Add(FileEntries[i]);
     }

     List<string> Final = new List<string>();
     foreach (var I in Data)
       Final.AddRange(I);
        */
      //FullPathsToFiles = Final.ToArray();
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

      save_path = tmp;
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
        //ControllerUnit.Export(MainFormParameters, saveFileDialog1.FileName);
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

    private void CB_RecalcMasks_CheckedChanged(object sender, EventArgs e)
    {
      if (CB_RecalcMasks.Checked)
      {
        TB_RecalcMasksRate.Enabled = true;
        MainFormParameters.RecalculationRate = -1;
      }
      else
      {
        TB_RecalcMasksRate.Text = String.Empty;
        TB_RecalcMasksRate.Enabled = false;
        MainFormParameters.RecalculationRate = -1;
      }
    }

    private void CB_OverwriteFiles_CheckedChanged(object sender, EventArgs e)
    {
      if (CB_OverwriteFiles.Checked)
        MainFormParameters.doOverwriteFiles = true;
      else MainFormParameters.doOverwriteFiles = false;
    }

    private void CB_UseCleanFiles_CheckedChanged(object sender, EventArgs e)
    {
      if (CB_UseCleanFiles.Checked)
        MainFormParameters.doUseCleanFiles = true;
      else MainFormParameters.doUseCleanFiles = false;
    }
    #endregion

    #region Селекторы
   

    private void CB_MaskingMode_SelectedIndexChanged(object sender, EventArgs e)
    {
      ControllerUnit.SetMaskingMethod(CB_MaskingMode.SelectedItem.ToString());
    }

    private void CB_DenoiseMode_SelectedIndexChanged(object sender, EventArgs e)
    {
      ControllerUnit.SetDenoisingMethod(CB_DenoiseMode.SelectedItem.ToString());
    }
    #endregion

    private void TB_RecalcMasksRate_TextChanged(object sender, EventArgs e)
    {
      int val = 0;
      if (Int32.TryParse(TB_RecalcMasksRate.Text, out val))
        MainFormParameters.RecalculationRate = val;
      else
      {
        TB_RecalcMasksRate.Text = String.Empty;
        MainFormParameters.RecalculationRate = -1;
      }

    }

    private void CB_UseDenoiseOnly_CheckedChanged(object sender, EventArgs e)
    {
      if (CB_UseDenoiseOnly.Checked)
        MainFormParameters.doUseDenoiseOnly = true;
      else MainFormParameters.doUseDenoiseOnly = false;
    }
  }
}
