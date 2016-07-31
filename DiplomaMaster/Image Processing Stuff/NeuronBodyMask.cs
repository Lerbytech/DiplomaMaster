using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;

namespace DiplomaMaster
{
  [Serializable]
  public struct NeuronBodyMask
  {
    public Rectangle Field; // {get; private set; }
    public Image<Gray, Byte> BodyMask; // {get; private set; }
    public Point Center;
    public NeuronBodyMask(Rectangle F, Image<Gray, Byte> Im, Point C)
    {
      Field = new Rectangle(F.X, F.Y, F.Width, F.Height);
      BodyMask = Im.Clone();
      Center = C;
    }
  }
}
