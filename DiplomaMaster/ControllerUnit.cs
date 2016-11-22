using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Emgu.CV;
using Emgu.CV.Structure;

namespace DiplomaMaster                                                                                                                                                                                                                  
{
  public class CControllerUnit
  {
    // Поля
    private CImageParserMaster ImageParser;
    private CMaskingMaster MaskingMaster;
    private CDenoiseMaster DenoiseMaster;
    private CNeuronProvider NeuronProvider;
  
    private StructMainFormParams CurrentParams;
    private Dictionary<int, double> Intenisites;

    private Image<Gray, Byte> curImage;
    private Image<Gray, Byte> maskImage;

    public delegate void NewImageProcessingHandler(Image<Gray, Byte> img);
    public event NewImageProcessingHandler onNewImage;

    public CControllerUnit()
    {
      ImageParser = new CImageParserMaster();
      DenoiseMaster = new CDenoiseMaster();
      MaskingMaster = new CMaskingMaster();
      NeuronProvider = new CNeuronProvider();
    }

    #region функции для общения с формой
    public List<string> GetListOfDenoiseModes()
    {
      return DenoiseMaster.GetListOfMethods();
    }

    public List<string> GetListOfMaskingModes()
    {
      return MaskingMaster.GetListOfMethods();
    }

    #endregion

    public int GetTotalNumberOfImages()
    {
      return CImageProvider.TotalNumberOfImages;
    }

    public void Initialize(StructMainFormParams Params)
    {
      CImageProvider.InitImageProvider(Params);
      curImage = GetSampleImage(Params.PathToLoadFolder).Convert<Gray, Byte>();

      MaskingMaster.SetMethod(Params.MaskingModes[Params.CurMaskingMode]);
      DenoiseMaster.SetMethod(Params.DenoiseModes[Params.CurDenoiseMode], curImage);
      NeuronProvider.PrepareExport(Params);
      CurrentParams = Params;
    }

    // Переделать чтобы считывалось через ImageProvider
    public Image<Bgr, Byte> GetSampleImage(string path)
    {
      if (CImageProvider.TotalNumberOfImages != 0)
        return CImageProvider.GetSampleImage();

      string[] files = Directory.GetFiles(path);
      if (files.Length == 0) throw new Exception("GetSampleImage: input_path некорректен либо в папке не содержится файлов");
                                                                                                                                                                                                                                                                                          
      Image<Bgr, Byte> tmp = new Image<Bgr, byte>(1, 1, new Bgr(0, 0, 0));
      try
      {
        tmp = new Image<Bgr, byte>(files[0]);
        curImage = tmp.Convert<Gray, Byte>();
      }          
      catch (Exception) { return null; }
      
      return tmp;
    }
  
    public void FormUpdated(StructMainFormParams NewParams) 
    {

    }

    public void SetMaskingMethod(string method_name) 
    {
      MaskingMaster.SetMethod(method_name);
    }

    public void SetDenoisingMethod(string method_name) 
    {
      DenoiseMaster.SetMethod(method_name, curImage);
    }

    #region masks

    public  int TestMask(string path)
    {
      Image<Gray, Byte> Mask;
      try {
        Mask = new Image<Gray, byte>(path);
      }
      catch (Exception ex) { return 0; }

      if (Mask == null) return 0;
      if (!isMaskSizeGood(Mask)) return 1;
      else
      {
        SetMask(Mask);
        return 2;
      }

    }

    private  bool isMaskSizeGood(Image<Gray, Byte> newMask)
    {
      System.Drawing.Size s = CImageProvider.ImageSize;
      if (s != newMask.Size)
        return false;
      else return true;
    }

    private  void SetMask(Image<Gray, Byte> inputImg)
    {
      //ImageParser.SetMask(inputImg);
    }

    public  Image<Gray, Byte> GetMask(Image<Gray, Byte> sourceImg)
    {
      return MaskingMaster.GetMaskImage(sourceImg);
    }

    public Image<Gray, Byte> GetMask()
    {
      return MaskingMaster.GetMaskImage();
    }
    #endregion
   
    public  void StartProcessing()
    {
      int N = CImageProvider.TotalNumberOfImages;
      curImage = CImageProvider.GetImage(0);
      maskImage = MaskingMaster.Process(curImage);
      ImageParser.PrepareImageParsingMethod(maskImage);
      //Image<Gray, Byte> medianImage = new Image<Gray, byte>(@"");
      for (int i = 0; i < N; i++)
      {
         Loop();
        //curImage.Save(CurrentParams.PathToSaveFolder + i.ToString() + ".Png");
        onNewImage(curImage);
        
      }

      MaskingMaster.GetMaskImage().Save(CurrentParams.PathToSaveFolder + "\\MaskImage.png");
      List<NeuronBodyMask> NBML = MaskingMaster.GetListOfNeuronBodyMasks();
      for (int i = 0; i < NBML.Count; i++)
        NBML[i].BodyMask.Save(CurrentParams.PathToSaveFolder + "\\mask_" + i.ToString() + ".Png");
     
      NeuronProvider.FinishSaving();
    }

    public  void PauseProcessing()
    {
    }

    public  void KillProcessing()
    {

    }

    public  void AdjustProcessing()
    {

    }

    private  void Loop()
    {
      //int dt = 0;
      //curImage = CImageProvider.GetImage(out dt);
      curImage = CImageProvider.GetImage();
      if (curImage == null) ; //поднять ивент о бяде или конце работы

      curImage = DenoiseMaster.Process(curImage);
      
      Intenisites = ImageParser.ApplyMask(curImage); // получаем словарь с данными интенсивностей нейронов      
      //NeuronProvider.AddValues(Intenisites, dt);
      NeuronProvider.AddValues(Intenisites);
    }

    private void Loop(Image<Gray, Byte> backgroundImage)
    {
      //int dt = 0;
      //curImage = CImageProvider.GetImage(out dt);
      curImage = CImageProvider.GetImage();
      if (curImage == null) ; //поднять ивент о бяде или конце работы

      curImage = DenoiseMaster.Process(curImage);

      curImage = curImage - backgroundImage;

      Intenisites = ImageParser.ApplyMask(curImage); // получаем словарь с данными интенсивностей нейронов      
      //NeuronProvider.AddValues(Intenisites, dt);
      NeuronProvider.AddValues(Intenisites);
    }

    public  void Export(StructMainFormParams P, string path)
    {
      StreamWriter sw = new StreamWriter(path);
      sw.WriteLine("Путь к папке загрузки:" + P.PathToLoadFolder.ToString());
      sw.WriteLine("Путь к папке сохранения:" + P.PathToSaveFolder.ToString());
      sw.WriteLine("Перезаписывать файлы? " + P.doOverwriteFiles.ToString());
      sw.WriteLine("Использовать \"чистые\" файлы? " + P.doUseCleanFiles.ToString());
      sw.WriteLine("Перерасчитывать маски? " + P.doRecalculateMasks.ToString());
      sw.WriteLine("Частота перерасчета: " + P.RecalculationRate.ToString());
      
      sw.WriteLine("Режимы шумоподавления:");
      foreach (var I in P.DenoiseModes) sw.WriteLine(">" + I.ToString());
      sw.WriteLine("Выбранный режим: " + P.CurDenoiseMode.ToString());

      sw.WriteLine("Режимы наложения масок: ");
      foreach( var I in P.MaskingModes) sw.WriteLine(">" + I.ToString());
      sw.WriteLine("Выбранный режим: " + P.CurMaskingMode.ToString());
    }

    public  StructMainFormParams Import(string path)
    {
      List<string> s = File.ReadAllLines(path).ToList();
      StructMainFormParams res = new StructMainFormParams();
      

      for (int i = 0; i < s.Count; i++)
      {


      }
      return new StructMainFormParams();
    }
  }
}
