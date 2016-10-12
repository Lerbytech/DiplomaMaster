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
  public static class ControllerUnit
  {
    // Поля
    private static CImageParser Processor1;
    private static DenoisingMethod denoisingMethod1;
    private static NeuronParserMethod neuronParserMethod1;
    private static StructMainFormParams CurrentParams;

    private static Dictionary<int, double> Intenisites;

    // Методы
    public static List<string> GetListOfDenoiseModes() { return CDenoiseMaster.GetListOfMethods(); }
    public static List<string> GetListOfMaskingModes() { return CMaskingMaster.GetListOfMethods(); }
    
    //

    public static void Initialize(StructMainFormParams Params)
    {
      CImageProvider.InitImageProvider(Params.PathToLoadFolder);

      SetMaskingMethod(Params.MaskingModes[Params.CurMaskingMode]);
      SetDenoisingMethod(Params.DenoiseModes[Params.CurMaskingMode]);

      //Processor1 = new CImageParser(,,);x
    }

    // Переделать чтобы считывалось через ImageProvider
    public static Image<Bgr, Byte> GetSampleImage(string path)
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
  
    public static void FormUpdated(StructMainFormParams NewParams) 
    {

    }

    public static void SetMaskingMethod(string method_name) 
    {
      CMaskingMaster.SetMethod(method_name);
    }

    public static void SetDenoisingMethod(string method_name) 
    {
      CDenoiseMaster.SetMethod(method_name);
    }

    #region masks

    public static int TestMask(string path)
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

    private static bool isMaskSizeGood(Image<Gray, Byte> newMask)
    {
      System.Drawing.Size s = CImageProvider.ImageSize;
      if (s != newMask.Size)
        return false;
      else return true;
    }

    private static void SetMask(Image<Gray, Byte> inputImg)
    {
      Processor1.SetMask(inputImg);
    }

    public static Image<Gray, Byte> GetMask()
    {
      return Processor1.GetMask();
    }

    #endregion
   
    public static void StartProcessing()
    {

    }

    public static void PauseProcessing()
    {
    }

    public static void KillProcessing()
    {

    }

    public static void AdjustProcessing()
    {

    }

    private static void Loop()
    {
      Image<Gray, Byte> IMG = CImageProvider.GetImage();
      if (IMG == null) ; //поднять ивент о бяде или конце работы

      Intenisites = Processor1.ProcessImage(IMG); // получаем словарь с данными интенсивностей нейронов


      
      //IMG = DM.Process(IMG);
      
      //CImageParser Parser = new CImageParser();
      //Parser.SetMode(CMaskingMaster.mode());
      ///Dictionary<int, double> Intenisites = Parser.ProcessImage(IMG);

    //  NeuronProvider.AddValues(Intenisites);
    }

    public void Export(StructMainFormParams P, string path)
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

    public StructMainFormParams Import(string path)
    {
      List<string> s = File.ReadAllLines(path).ToList();
      StructMainFormParams res = new StructMainFormParams();
      

      for (int i = 0; i < s.Count; i++)
      {


      }
      return null;

    }
  }
}
