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
  public interface IDenoiseStrategy
  {
    Image<Gray, Byte> DenoiseImage(Image<Gray, Byte> input);
    void PrepareDenoiseMethod(Image<Gray, Byte> input);
  }
}
