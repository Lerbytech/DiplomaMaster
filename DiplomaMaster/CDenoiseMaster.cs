using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.Util.TypeEnum;

namespace DiplomaMaster
{
  public class CDenoiseMaster : IModedImageProcessingMethod<Image<Gray, Byte>>
  {
    public static List<string> GetListOfMethods()
    {
      throw new NotImplementedException();
    }

    public static void SetMethod(string MethodName)
    {
      throw new NotImplementedException();
    }

    public static Image<Gray, byte> Process(Image<Gray, byte> Input)
    {
      throw new NotImplementedException();
    }

  }
}
