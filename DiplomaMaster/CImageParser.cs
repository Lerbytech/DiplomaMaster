using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.Util.TypeEnum;

namespace DiplomaMaster
{
  /*
  public delegate Image<Gray, Byte> DenoisingMethod(Image<Gray, Byte> Img);
  public delegate List<Image<Gray, Byte>> NeuronParserMethod(Image<Gray, Byte> Img);
  */

  public class CImageParser : IImageParsingStrategy
  {
    private Image<Gray, Byte> oldMask;
    private Image<Gray, Byte> []Masks;

    private IImageParsingStrategy strategy = null;
    Dictionary<string, string> strategyNames = new Dictionary<string, string>();

    public CImageParser()
    {
      //Хитрый способ получить название классов через reflection

      string DenoiseMethodsNamespace = "DiplomaMaster.DenoisingMethods";

      //получим список всех классов в этом namespace
      var q = from t in Assembly.GetExecutingAssembly().GetTypes()
              where t.Namespace == DenoiseMethodsNamespace && t.IsClass
              select t;
      //немного костыль - кастуем var в словарь, который нам так и так нужен
      strategyNames = new Dictionary<string, string>();
      q.ToList().ForEach(t => strategyNames.Add(t.Name, ParseMethodNameFromClassName(t.Name)));

    }

    //Методы
    public Dictionary<int, double> ProcessImage(Image<Gray, byte> inputIMG)
    { 
      Dictionary<int, double> res = new Dictionary<int, double>();
      
      //res =  parse method(tmpImage);

      return res;
    }

    public void PrepareImageParsingMethod(Image<Gray, byte> Mask)
    {
      throw new NotImplementedException();
    }

    public Dictionary<int, double> ApplyMask(Image<Gray, byte> newImage)
    {
      throw new NotImplementedException();
    }

    public List<string> GetListOfMethods()
    {
      return strategyNames.Values.ToList();
    }

    private string ParseMethodNameFromClassName(string className)
    {
      string tmp;
      string[] SplitCamelCaseString;

      tmp = className;
      tmp = tmp.Replace("CParsing_", String.Empty);

      //разбиваем по заглавным буквам
      SplitCamelCaseString = Regex.Split(tmp, @"(?<!^)(?=[A-Z])");
      tmp = String.Empty;
      for (int i = 0; i < SplitCamelCaseString.Length; i++)
        tmp += SplitCamelCaseString[i] + " ";
      tmp = tmp.TrimEnd(new char[] { ' ' });

      //разбиваем по цифрам
      SplitCamelCaseString = Regex.Split(tmp, @"(?<=[a-zA-Z])(?=\d)");

      tmp = String.Empty;
      for (int i = 0; i < SplitCamelCaseString.Length; i++)
        tmp += SplitCamelCaseString[i] + " ";
      tmp = tmp.TrimEnd(new char[] { ' ' });
      return tmp;
    }
  }
}
