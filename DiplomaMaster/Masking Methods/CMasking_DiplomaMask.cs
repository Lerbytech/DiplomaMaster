using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace DiplomaMaster.MaskingMethods
{
  public class CMasking_DiplomaMask : IMaskingStrategy
  {
    public Image<Gray, byte> GenerateMask(Image<Gray, byte> input)
    {
      Image<Gray, byte> TMP = new Image<Gray, byte>(input.Size); // with small pixels
      Image<Gray, byte> TMP2 = new Image<Gray, byte>(input.Size); //NO SMALL pixels

      TMP = input.Clone();
      TMP2 = input.Clone();
      CvInvoke.CLAHE(input, 100, new System.Drawing.Size(8, 8), TMP);

      double MaxEl = 154;
      TMP = TMP.ThresholdToZero(new Gray(MaxEl));
      TMP._EqualizeHist();

      Image<Gray, Byte> NoiseMask = TMP.ThresholdBinary(new Gray(10), new Gray(255));

      NoiseMask = NoiseMask.Erode(1);
      NoiseMask = NoiseMask.Dilate(1);

      TMP2 = TMP.Copy(NoiseMask);

      return TMP2;
    }
  }
}
