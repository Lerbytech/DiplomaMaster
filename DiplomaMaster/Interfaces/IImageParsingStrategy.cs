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
  public interface IImageParsingStrategy
  {
    void PrepareImageParsingMethod(Image<Gray, Byte> Mask);

    Dictionary<int, double> ApplyMask(Image<Gray, Byte> newImage);

  }
}
