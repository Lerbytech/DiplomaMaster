using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;


using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.Util.TypeEnum;

namespace DiplomaMaster
{
  public class CMaskingMaster 
  {
    private IMaskingStrategy strategy = null;
    Dictionary<string, string> strategyNames = new Dictionary<string, string>();

    public CMaskingMaster()
    {
      strategyNames = CReflectionTools.GetStrategyNamesFromNamespace("DiplomaMaster.MaskingMethods", "CMasking_");
      /*
      //Хитрый способ получить название классов через reflection
      string DenoiseMethodsNamespace = "DiplomaMaster.MaskingMethods";

      //получим список всех классов в этом namespace
      var q = from t in Assembly.GetExecutingAssembly().GetTypes()
              where t.Namespace == DenoiseMethodsNamespace && t.IsClass
              select t;
      //немного костыль - кастуем var в словарь, который нам так и так нужен
      strategyNames = new Dictionary<string, string>();
      q.ToList().ForEach(t => strategyNames.Add(t.Name, ParseMethodNameFromClassName(t.Name)));
      */
    }


    public List<string> GetListOfMethods()
    {
      return strategyNames.Keys.ToList();
    }

    public  void SetMethod(string MethodName)
    {
      if (!strategyNames.ContainsKey(MethodName))
        throw new Exception("SetMethod: method name incorrect!");
      else
      {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type type = assembly.GetTypes()
            .First(t => t.Name == strategyNames[MethodName]);
        strategy = (IMaskingStrategy)Activator.CreateInstance(type);
      }


    }

    public  Image<Gray, byte> Process(Image<Gray, byte> Input)
    {
      throw new NotImplementedException();
    }

    private  Image<Gray, Byte> LoadedMask()
    {
      return null;
    }

    //преобразуем имена - разбиваем по заглавным буквам и отдеяем цифры в отдельные слова
    //CDenoise_SigmaReject2 превращается в Sigma Reject 2
    private string ParseMethodNameFromClassName(string className)
    {
      string tmp;
      string[] SplitCamelCaseString;

      tmp = className;
      tmp = tmp.Replace("CMasking_", String.Empty);

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
