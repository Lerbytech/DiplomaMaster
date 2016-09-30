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
  public abstract class CAbstractModedImageProcessingMethod<T>
  {
    public  abstract List<string> GetListOfMethods();
    public abstract void SetMethod(string MethodName);

    public abstract T Process(T Input);
  }
}
