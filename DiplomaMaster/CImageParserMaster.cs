using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;

using Emgu.CV;
using Emgu.CV.Structure;

namespace DiplomaMaster
{

  public class CImageParserMaster : IImageParsingStrategy
  {
    private Image<Gray, Byte> oldMask;
    private Image<Gray, Byte> []Masks;

    private IImageParsingStrategy strategy = null;
    Dictionary<string, string> strategyNames = new Dictionary<string, string>();

    public CImageParserMaster()
    {
      strategyNames = CReflectionTools.GetStrategyNamesFromNamespace("DiplomaMaster.ImageParsingMethods", "CImageParsing_");
      if ( strategyNames.Count == 0)
        throw new Exception("ERROR: No parsing strategies found!");
      
      //костыль
      SetMethod(strategyNames.Keys.ToList()[0]);
    
    }
    public List<string> GetListOfMethods()
    {
      return strategyNames.Values.ToList();
    }

    //Метод private так как это внутренняя субрутина
    private void SetMethod(string MethodName)
    {
      if (!strategyNames.ContainsKey(MethodName))
        throw new Exception("SetMethod: method name incorrect!");
      else
      {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type type = assembly.GetTypes()
            .First(t => t.Name == strategyNames[MethodName]);
        strategy = (IImageParsingStrategy)Activator.CreateInstance(type);
      }
    }

    public void PrepareImageParsingMethod(Image<Gray, byte> Mask)
    {
      throw new NotImplementedException();
    }

    public Dictionary<int, double> ApplyMask(Image<Gray, byte> newImage)
    {
      throw new NotImplementedException();
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
