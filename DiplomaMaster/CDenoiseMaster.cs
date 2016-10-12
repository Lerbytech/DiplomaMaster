using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.Util.TypeEnum;

namespace DiplomaMaster
{
  public static class CDenoiseMaster //: IModedImageProcessingMethod<Image<Gray, Byte>>
  {


    public static List<string> GetListOfMethods()
    {
      MethodInfo[] methodInfos = typeof(CDenoiseMaster).GetMethods(BindingFlags.NonPublic |
                                                      BindingFlags.Static);

      Array.Sort(methodInfos,
        delegate(MethodInfo methodInfo1, MethodInfo methodInfo2)
        { return methodInfo1.Name.CompareTo(methodInfo2.Name); });

      List<string> output = new List<string>();
      foreach (MethodInfo methodInfo in methodInfos)
      {
        output.Add(methodInfo.Name);
      }
      output.RemoveAt(0);

      return output;
    }

    public static void SetMethod(string MethodName)
    {
      //throw new NotImplementedException();
    }

    public static Image<Gray, byte> Process(Image<Gray, byte> Input)
    {
      throw new NotImplementedException();
    }

    private static Image<Gray, Byte> SimpleDenoise()
    {
      return null;
    }

  }
}
