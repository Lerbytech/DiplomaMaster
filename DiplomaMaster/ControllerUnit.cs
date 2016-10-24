using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.Util.TypeEnum;

namespace DiplomaMaster
{
  public class CControllerUnit
  {
    // Поля
    private CImageParser ImageParser;
    private CMaskingMaster MaskingMaster;
    private CDenoiseMaster DenoiseMaster;
      
    private StructMainFormParams CurrentParams;
    private Dictionary<int, double> Intenisites;
    


    public CControllerUnit()
    {
      ImageParser = new CImageParser();
      DenoiseMaster = new CDenoiseMaster();
      MaskingMaster = new CMaskingMaster();
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

    public void Initialize(StructMainFormParams Params)
    {
      CImageProvider.InitImageProvider(Params.PathToLoadFolder);

      //SetMaskingMethod(Params.MaskingModes[Params.CurMaskingMode]);
      //SetDenoisingMethod(Params.DenoiseModes[Params.CurMaskingMode]);
    }

    // Переделать чтобы считывалось через ImageProvider
    public Image<Bgr, Byte> GetSampleImage(string path)
    {
      string[] files = Directory.GetFiles(path);
      if (files.Length == 0) throw new Exception("GetSampleImage: input_path некорректен либо в папке не содержится файлов");

      Image<Bgr, Byte> tmp = new Image<Bgr, byte>(1, 1, new Bgr(0, 0, 0));
      try
      {
        tmp = new Image<Bgr, byte>(files[0]);
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
      DenoiseMaster.SetMethod(method_name);
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

    public  Image<Gray, Byte> GetMask()
    {
      //return ImageParser.GetMask();
      return null;
    }

    #endregion
   
    public  void StartProcessing()
    {

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
      Image<Gray, Byte> IMG = CImageProvider.GetImage();
      if (IMG == null) ; //поднять ивент о бяде или конце работы

      Intenisites = ImageParser.ProcessImage(IMG); // получаем словарь с данными интенсивностей нейронов      
      //IMG = DM.Process(IMG);
      
      //CImageParser Parser = new CImageParser();
      //Parser.SetMode(CMaskingMaster.mode());
      ///Dictionary<int, double> Intenisites = Parser.ProcessImage(IMG);

    //  NeuronProvider.AddValues(Intenisites);
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
