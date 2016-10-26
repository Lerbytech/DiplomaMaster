using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiplomaMaster.ImageParsingMethods
{
  class CImageParsing_Class1 : IImageParsingStrategy
  {
    public void PrepareImageParsingMethod(Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Mask)
    {
      throw new NotImplementedException();
    }

    public Dictionary<int, double> ApplyMask(Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> newImage)
    {
      throw new NotImplementedException();
    }
  }
}
