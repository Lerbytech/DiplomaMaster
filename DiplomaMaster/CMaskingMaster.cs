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
    }

    // возвращает список нормальных названий методов
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
      return strategy.GenerateMask(Input);
    }
  }
}
