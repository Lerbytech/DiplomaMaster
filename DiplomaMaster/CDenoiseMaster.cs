using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Emgu.CV;
using Emgu.CV.Structure;

namespace DiplomaMaster
{
  public class CDenoiseMaster
  {
    private IDenoiseStrategy strategy = null;
    Dictionary<string, string> strategyNames = new Dictionary<string, string>();

    public CDenoiseMaster()
    {
      strategyNames = CReflectionTools.GetStrategyNamesFromNamespace("DiplomaMaster.DenoisingMethods", "CDenoise_");
    }

    // возвращает список нормальных названий методов
    public List<string> GetListOfMethods()
    {
        return strategyNames.Keys.ToList();
    }

    public void SetMethod(string MethodName)
    {
        if (!strategyNames.ContainsKey(MethodName))
            throw new Exception("SetMethod: method name incorrect!");
        else
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes()
                .First(t => t.Name == strategyNames[MethodName]);
            strategy = (IDenoiseStrategy)Activator.CreateInstance(type);
        }
    }

    public Image<Gray, byte> Process(Image<Gray, byte> Input)
    {
        return  strategy.DenoiseImage(Input);
    }
  }
}
