using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.Util.TypeEnum;


namespace DiplomaMaster
{
  public static class ImgProcTools
  {/*
    public static class DeNoising
    {
      public static Image<Gray, Byte> SigmaReject(Image<Gray, Byte>[] input)
      {
        return null;
      }

      public static Image<Gray, Byte> SigmaReject2(Image<Gray, Byte>[] input)
      {
        return null;
      }
    }*/

    public static class Denoise
    {
      private static List<Image<Gray, Byte>> arr;
      private static int WIDTH;
      private static int HEIGHT;
      private static byte[, ,] arr_Data0;
      private static byte[, ,] arr_Data1;
      private static byte[, ,] arr_Data2;
      private static byte[, ,] arr_Data3;

      public static Image<Gray, Byte> SigmaReject2(Image<Gray, Byte> Q)
      {
        arr.RemoveAt(0);
        arr.Add(Q);

        //if (arr.Length == 1) return arr[0];
        // WIDTH = arr[0].Width;
        //HEIGHT = arr[0].Height;

        arr_Data0 = arr[0].Data; // rows cols channels
        arr_Data1 = arr[1].Data;
        arr_Data2 = arr[2].Data;
        arr_Data3 = arr[3].Data;

        double[] tmp_pixels = new double[4];

        double avr = 0;
        double deviation = 0;

        for (int i = 0; i < HEIGHT; i++) //row
          for (int j = 0; j < WIDTH; j++) //col
          {
            // STEP 1
            tmp_pixels[0] = arr_Data0[i, j, 0];
            tmp_pixels[1] = arr_Data1[i, j, 0];
            tmp_pixels[2] = arr_Data2[i, j, 0];
            tmp_pixels[3] = arr_Data3[i, j, 0];

            avr = Average(tmp_pixels);
            deviation = FindDeviation(tmp_pixels, avr);
            RejectPixels(ref tmp_pixels, avr, deviation);
            avr = Average(tmp_pixels);
            //result[i, j] = new Gray(avr);

            //STEP 2
            deviation = FindDeviation(tmp_pixels, avr);
            RejectPixels(ref tmp_pixels, avr, deviation);
            avr = Average(tmp_pixels);
            arr_Data0[i, j, 0] = (byte)avr;
          }

        return arr[0];
      }
      public static void PrepareDenoiseFunctions(int width, int height)
      {
        WIDTH = width;
        HEIGHT = height;
        Image<Gray, Byte> tmp = new Image<Gray, byte>(WIDTH, HEIGHT, new Gray(0));
        arr = new List<Image<Gray, byte>>();
        for (int i = 0; i < 4; i++) arr.Add(tmp);
      }


      public static void PrepareDenoiseFunctions(Image<Gray, byte> exampleImage)
      {
        WIDTH = exampleImage.Width;
        HEIGHT = exampleImage.Height;
        arr = new List<Image<Gray, byte>>();
        for (int i = 0; i < 4; i++) arr.Add(exampleImage);
      }

      private static double Average(double[] arr)
      {
        double avr = 0.0;
        double n_avr = 0;
        for (int i = 0; i < arr.Length; i++)
        {
          if (arr[i] < 0) continue;
          avr += arr[i];
          n_avr = n_avr + 1;
        }
        if (avr == 0) return avr;
        else return avr / n_avr;
      }
      private static void RejectPixels(ref double[] arr, double avr, double dev)
      {
        for (int i = 0; i < arr.Length; i++)
        {
          if (arr[i] < 0) continue;
          if (Math.Abs(arr[i] - avr) > dev) arr[i] = -1;
        }
      }
      private static double FindDeviation(double[] arr, double avr)
      {
        double result = 0;
        double n = 0;
        for (int i = 0; i < arr.Length; i++)
        {
          if (arr[i] < 0) continue;
          else
          {
            result = result + (avr - arr[i]) * (avr - arr[i]);
            n = n + 1;
          }
        }
        if (result == 0) return 0;
        return Math.Sqrt(result / n);
      }
    } 


    public static class BinarizationMethods
    {
      public static Image<Gray, Byte> SISThreshold(Image<Gray, Byte> src)
      {
        Image<Gray, Byte> result = src.Clone();
        result._ThresholdBinary(new Gray(CalculateSISThreshold(src)), new Gray(255));
        return result;
      }

      private static float CalculateSISThreshold(Image<Gray, Byte> src)
      {
        float T = 0;
        byte[, ,] D = src.Data;
        int W = src.Width;
        int H = src.Height;
        float dx = 0;
        float dy = 0;
        float weight = 0;
        float weightT = 0;

        for (int x = 1; x < W - 1; x++)
          for (int y = 1; y < H - 1; y++)
          {
            dx = D[y, x + 1, 0] - D[y, x - 1, 0];
            dy = D[y + 1, x, 0] - D[y - 1, x, 0];
            weight = (dx > dy) ? dx : dy;
            weightT += weight;
            T += weight * D[y, x, 0];
          }
        return (weightT == 0) ? (byte)0 : (byte)(T / weightT);
      }

      public static Image<Gray, Byte> BinByDistanceTransform(Image<Gray, Byte> src)
      {

        Image<Gray, float> dist = new Image<Gray, float>(src.Size);
        Image<Gray, float> labels = new Image<Gray, float>(src.Size);
        CvInvoke.DistanceTransform(src, dist, labels, DistType.L1, 5);

        dist = dist.ThresholdBinary(new Gray(0), new Gray(255));
        return dist.Convert<Gray, Byte>();
      }
    }

    public static class EdgeDetection
    {
      public static VectorOfVectorOfPoint SimplestEdgeDetection(Image<Gray, Byte> src)
      {
        Image<Gray, Byte> victim = src.Copy();
        VectorOfVectorOfPoint res = new VectorOfVectorOfPoint();
        CvInvoke.FindContours(victim, res, null, RetrType.List, ChainApproxMethod.ChainApproxNone);
        return res;
      }
    }

    public static class Permutations
    {
      public static Image<Gray, Byte> CreateBlackFrameForImage(Image<Gray, Byte> src, int shift)
      {
        Image<Gray, Byte> result = new Image<Gray, byte>(src.Width + shift * 2, src.Height + shift * 2, new Gray(0));
        CvInvoke.cvSetImageROI(result, new Rectangle(shift - 1, shift - 1, src.Width, src.Height));
        try { src.CopyTo(result); }
        catch (Exception) { }
        CvInvoke.cvResetImageROI(result);

        return result;
      }
      public static Image<Gray, Byte> RemoveBlackFrameFromImage(Image<Gray, Byte> src, int shift)
      {

        CvInvoke.cvSetImageROI(src, new Rectangle(shift - 1, shift - 1, src.Width - shift * 2, src.Height - shift * 2));
        Image<Gray, Byte> result = src.Copy();
        CvInvoke.cvResetImageROI(src);

        return result;
      }
    }
  }
}
