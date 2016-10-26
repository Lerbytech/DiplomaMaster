using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace DiplomaMaster.DenoisingMethods
{
    public class CDenoise_SigmaReject2 : IDenoiseStrategy
    {
        Image<Gray, byte> IDenoiseStrategy.DenoiseImage(Image<Gray, byte> input)
        {
            return ImgProcTools.Denoise.SigmaReject2(input);
        }

        void IDenoiseStrategy.PrepareDenoiseMethod(Image<Gray, byte> input)
        {
            ImgProcTools.Denoise.PrepareDenoiseFunctions(input.Width, input.Height);
        }
    }
}
