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

    // Методы
    public static List<string> GetListOfDenoiseModes() { return CDenoiseMaster.GetListOfMethods(); }
    public static List<string> GetListOfMaskingModes() { return CMaskingMaster.GetListOfMethods(); }
    
    public static void Initialize(string ImportPath, string ExportPath) 
    {
      //Processor1 = new CImageParser(,,);
    }

    // Переделать чтобы считывалось через ImageProvider
    public static Image<Gray, Byte> GetSampleImage(string path)
    {
      string[] files = Directory.GetFiles(path);
      if (files.Length == 0) throw new Exception("GetSampleImage: input_path некорректен либо в папке не содержится файлов");

      Image<Gray, Byte> tmp = new Image<Gray, byte>(1, 1, new Gray(0));
      try
      {
        tmp = new Image<Gray, byte>(files[0]);
      }
      catch (Exception) { return null; }

      return tmp;
    }
    
    public static void FormUpdated(StructMainFormParams NewParams) 
    {

    }

    public static void SetMask(Image<Gray, Byte> newMask) 
    {
      
    }
    public static bool CheckMaskSize(Image<Gray, Byte> newMask) 
    {
      return false;
    }
      
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

      Dictionary<int, double> Intenisites = Processor1.ProcessImage(IMG);

      
      //IMG = DM.Process(IMG);
      
      //CImageParser Parser = new CImageParser();
      //Parser.SetMode(CMaskingMaster.mode());
      ///Dictionary<int, double> Intenisites = Parser.ProcessImage(IMG);

    //  NeuronProvider.AddValues(Intenisites);
    }
  }
}
