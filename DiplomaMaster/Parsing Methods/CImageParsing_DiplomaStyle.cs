﻿using System;
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
    Dictionary<int, double> res;
    Image<Gray, Byte> SignalImg;
    Image<Gray, Byte> biggerImg;

    public void PrepareImageParsingMethod(Image<Gray, byte> Mask)
    {
      Image<Gray, Byte> TMP = ImgProcTools.BinarizationMethods.BinByDistanceTransform(Mask);
      
      VectorOfVectorOfPoint AllContours = ImgProcTools.EdgeDetection.SimplestEdgeDetection(TMP);

      int threshold = 0;
      List<VectorOfPoint> smallContours = new List<VectorOfPoint>();
      List<VectorOfPoint> rejectedContours = new List<VectorOfPoint>();
      List<VectorOfPoint> BigContours = NeuronSeparation.Calculations.SeparateSmallContours(NeuronSeparation.Converter.VVOPToListOfVOP(AllContours),
                                                                                            out smallContours, out rejectedContours, threshold);

      Masks = new List<NeuronBodyMask>();
      Masks = NeuronSeparation.Masks.GenerateNeuronBodyMasks(BigContours);
      res = new Dictionary<int, double>();
    }

    public Dictionary<int, double> ApplyMask(Image<Gray, byte> newImage)
    {
      res.Clear();

      int k = 0;
      byte[, ,] SignalData = newImage.Data;
      byte[, ,] masksData;
      
      int H = newImage.Height + 5;
      int W = newImage.Width + 5;
      // x_0 = 5
      // y_0 = 5;

      double cap = 0;

      //Image<Gray, Byte> maskk = Masks[0].BodyMask;
      for (int n = 0; n < Masks.Count; n++)
      {
        masksData = Masks[n].BodyMask.Data;
        //maskk = Masks[n].BodyMask;
        cap = 0;

        for (int y = 5; y < H; y++)
          for (int x = 5; x < W; x++)
          {
            if (masksData[y, x, 0] == 255) 
              cap += SignalData[y - 5, x - 5, 0];
          }

        res.Add(n, cap);
      }

      return res;
    }
  }
}
