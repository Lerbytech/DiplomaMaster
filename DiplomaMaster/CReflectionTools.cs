using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;


namespace DiplomaMaster
{
  public static class CReflectionTools
  {
    public static Dictionary<string, string> GetStrategyNamesFromNamespace(string Namespace, string StrategyClassNamePrefix)
    {
      //Хитрый способ получить название классов через reflection
      //DenoiseMethodsNamespace = "DiplomaMaster.DenoisingMethods"

      string DenoiseMethodsNamespace = Namespace;
      //получим список всех классов в этом namespace
      var q = from t in Assembly.GetExecutingAssembly().GetTypes()
              where t.Namespace == DenoiseMethodsNamespace && t.IsClass
              select t;
      //немного костыль - кастуем var в словарь, который нам так и так нужен
      Dictionary<string, string> strategyNames = new Dictionary<string, string>();
      q.ToList().ForEach(t => strategyNames.Add(ParseMethodNameFromClassName(t.Name, StrategyClassNamePrefix), t.Name ));

      return strategyNames;
    }

    //Функция для парсинга человеческого названия метода из названия класса
    // Отбрасывает префикс, растаскивает сначала по заглавным буквам, потом по цифрам
    // Пример: CDenoise_SigmaReject2 -> SigmaReject2 -> [] = { Sigma, Reject2} -> Sigma Reject2 -> [] = { Sigma Reject, 2} -> Sigma Reject 2
    private static string ParseMethodNameFromClassName(string className, string classNamePrefix)
    {
      string tmp;
      string[] SplitCamelCaseString;

      tmp = className;
      tmp = tmp.Replace(classNamePrefix, String.Empty);

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
