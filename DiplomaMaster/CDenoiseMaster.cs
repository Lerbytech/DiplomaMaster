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
    private IDenoiseStrategy strategy;
    Dictionary<string, string> strategyNames;

    public CDenoiseMaster()
    {
      strategy = null;
      strategyNames = CReflectionTools.GetStrategyNamesFromNamespace("DiplomaMaster.DenoisingMethods", "CDenoise_");
    }

    // возвращает список нормальных названий методов
    public List<string> GetListOfMethods()
    {
        return strategyNames.Keys.ToList();
    }

    public void SetMethod(string MethodName, Image<Gray,Byte> sample_img)
    {
        if (!strategyNames.ContainsKey(MethodName))
            throw new Exception("SetMethod: method name incorrect!");
        else
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes()
                .First(t => t.Name == strategyNames[MethodName]);
            strategy = (IDenoiseStrategy)Activator.CreateInstance(type);

            strategy.PrepareDenoiseMethod(sample_img);
        }
    }

    public Image<Gray, byte> Process(Image<Gray, byte> Input)
    {      
      return  strategy.DenoiseImage(Input);
        
    }
  }
}
