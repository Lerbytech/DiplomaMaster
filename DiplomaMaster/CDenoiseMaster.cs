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
  public class CDenoiseMaster
  {
    private IDenoiseStrategy strategy = null;
    Dictionary<string, string> strategyNames = new Dictionary<string, string>();

    public CDenoiseMaster()
    {
      //Хитрый способ получить название классов через reflection
      strategyNames = CReflectionTools.GetStrategyNamesFromNamespace("DiplomaMaster.DenoisingMethods", "CDenoise_");
    }

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
            
        //switch (MethodName)
        //{
        //    case "Sigma Reject 2":
        //        {
        //            strategy = new DenoisingMethos.CDenoise_SigmaReject2();
        //            break;
        //        }
        //}
    }

    public Image<Gray, byte> Process(Image<Gray, byte> Input)
    {
        return  strategy.DenoiseImage(Input);
        //throw new NotImplementedException();
    }

    private  Image<Gray, Byte> SimpleDenoise()
    {
        return null;
    }

    }
}
