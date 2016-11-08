using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace DiplomaMaster.ImageParsingMethods
{
  class CImageParsing_DiplomaStyle : IImageParsingStrategy
  {
    private List<NeuronBodyMask> Masks;


    public void PrepareImageParsingMethod(Image<Gray, byte> Mask)
    {
      Image<Gray, Byte> TMP = ImgProcTools.BinarizationMethods.BinByDistanceTransform(Mask);
      
      VectorOfVectorOfPoint AllContours = ImgProcTools.EdgeDetection.SimplestEdgeDetection(TMP);
    
      List<VectorOfPoint> smallContours = new List<VectorOfPoint>();
      List<VectorOfPoint> rejectedContours = new List<VectorOfPoint>();
      List<VectorOfPoint> BigContours = NeuronSeparation.Calculations.SeparateSmallContours(NeuronSeparation.Converter.VVOPToListOfVOP(AllContours), out smallContours, out rejectedContours, 100);

      Masks = new List<NeuronBodyMask>();
      Masks = NeuronSeparation.Masks.GetNeuronBodyMasks(BigContours);
    }

    public Dictionary<int, double> ApplyMask(Image<Gray, byte> newImage)
    {
      Dictionary<int, double> res = new Dictionary<int, double>();
      Image<Gray, Byte> SignalImg = newImage; // Masks[0].BodyMask.CopyBlank();
      Image<Gray, Byte> biggerImg = Masks[0].BodyMask.CopyBlank();
      
      for (int i = 0; i < Masks.Count; i++)
      {
        try
        {
          //CvInvoke.cvSetImageROI(biggerImg , new Rectangle(5,5,172,130));
          CvInvoke.cvSetImageROI(biggerImg, new Rectangle(5, 5, 172, 130));
          newImage.CopyTo(biggerImg);
          CvInvoke.cvResetImageROI(biggerImg);

          SignalImg = biggerImg.Copy(Masks[i].BodyMask);// -MinImg;
          res.Add(i, CvInvoke.Sum(SignalImg).V0);
        }
        catch (Exception ex) { }
      }

      return res;
    }
  }
}
