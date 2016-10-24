using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using Emgu.CV;
using Emgu.CV.Structure;

namespace DiplomaMaster
{

  public class CImageParser : IImageParsingStrategy
  {
    private Image<Gray, Byte> oldMask;
    private Image<Gray, Byte> []Masks;

    private IImageParsingStrategy strategy = null;
    Dictionary<string, string> strategyNames = new Dictionary<string, string>();

    public CImageParser()
    {
      strategyNames = CReflectionTools.GetStrategyNamesFromNamespace("DiplomaMaster.ImageParsingMethods", "CImageParsing_");
    }

    //подготовка к работе - 1)разбиения маски на подмаски. 2) вызов методов подготовки отдельных классов
    //

    public void PrepareParsing(Image<Gray, Byte> inputMask)
    {

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
