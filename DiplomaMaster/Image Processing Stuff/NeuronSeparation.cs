using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.Util.TypeEnum;

namespace DiplomaMaster
{
  public static class NeuronSeparation
  {
    public static class Converter
    {
      public static VectorOfVectorOfPoint ListOfVOPtoVVOP(List<VectorOfPoint> input)
      {
        VectorOfVectorOfPoint res = new VectorOfVectorOfPoint();
        foreach (var I in input) res.Push(I);

        return res;
      }

      public static List<VectorOfPoint> VVOPToListOfVOP(VectorOfVectorOfPoint input)
      {
        List<VectorOfPoint> res = new List<VectorOfPoint>();
        for (int i = 0; i < input.Size; i++)
          res.Add(input[i]);
        return res;
      }
    }

    public static class Calculations
    {
      public static List<VectorOfPoint> SeparateSmallContours(List<VectorOfPoint> input, out List<VectorOfPoint> smallContours, out List<VectorOfPoint> rejectedContours, int thresholdsize)
      {
        smallContours = new List<VectorOfPoint>();
        rejectedContours = new List<VectorOfPoint>();
        List<VectorOfPoint> bigContours = new List<VectorOfPoint>();

        for (int i = 0; i < input.Count; i++)
        {
          if (CvInvoke.IsContourConvex(input[i])) rejectedContours.Add(input[i]);
          else if (CvInvoke.ContourArea(input[i], false) > thresholdsize) bigContours.Add(input[i]);
          else smallContours.Add(input[i]);
        }

        return bigContours;
      }

      public static List<Point> FindQuadroPoints(VectorOfPoint Input)
      {
        VectorOfVectorOfPoint drawable = new VectorOfVectorOfPoint();
        Image<Gray, Byte> img = new Image<Gray, Byte>(184, 140, new Gray(255));
        drawable.Push(Input);
        CvInvoke.DrawContours(img, drawable, -1, new MCvScalar(0), 1, LineType.EightConnected);

        //поиск точек с четыремя соседями. небольшая оптимизация подсчета благодаря ВB
        Rectangle BB = CvInvoke.BoundingRectangle(Input);
        List<Point> quadro = new List<Point>();
        for (int y = BB.Y; y < BB.Y + BB.Height; y++)
        {
          for (int x = BB.X; x < BB.X + BB.Width; x++)

            if ((img[y - 1, x].Intensity == 0) && (img[y + 1, x].Intensity == 0)
             && (img[y, x - 1].Intensity == 0) && (img[y, x + 1].Intensity == 0))
            {
              quadro.Add(new Point(x, y));
            }
        }

        return quadro;
      }

      public static List<Point> FindSelfIntersections(VectorOfPoint input)
      {
        List<Point> result = new List<Point>();

        //VectorOfVectorOfPoint tmp = new VectorOfVectorOfPoint();
        //tmp.Push(input);
        //Image<Gray, Byte> img = new Image<Gray, byte>(184, 140, new Gray(0));
        //CvInvoke.DrawContours(img, tmp, -1, new MCvScalar(255), 1, LineType.EightConnected);

        for (int i = 0; i < input.Size; i++)
        {
          for (int j = i + 1; j < input.Size; j++)
          {
            if (input[i] == input[j]) result.Add(input[i]);
          }
        }


        //tmp = new VectorOfVectorOfPoint();
        //tmp.Push(input);
        //img = new Image<Gray, byte>(184, 140, new Gray(0));
        //CvInvoke.DrawContours(img, tmp, -1, new MCvScalar(255), 1, LineType.EightConnected);

        /*
        img = new Image<Gray, byte>(184, 140, new Gray(0));
        for (int i = 0 ; i < input.Size; i++)
          img.Draw(new Point[] { input[i] }, new Gray(255 - i ), 1);
        */
        return result;
      }

      public static List<Point> FindPointsWith3Neighbours(VectorOfPoint input)
      {
        List<Point> result = new List<Point>();
        VectorOfVectorOfPoint tmp = new VectorOfVectorOfPoint();
        Image<Gray, Byte> img = new Image<Gray, byte>(184, 140, new Gray(0));
        tmp.Push(input);
        CvInvoke.DrawContours(img, tmp, -1, new MCvScalar(255), 1, LineType.EightConnected);

        for (int i = 0; i < input.Size; i++)
        {
          int x = 0;
          int y = 0;
          for (int k = 0; k < input.Size; k++)
          {
            x = input[i].X;
            y = input[i].Y;

            if ((img[y, x - 1].Intensity != 0) && (img[y, x + 1].Intensity != 0) && (img[y - 1, x].Intensity != 0))
            { img.Draw(new Point[] { new Point(x, y) }, new Gray(128), 1); result.Add(new Point(x, y)); continue; }
            if ((img[y, x - 1].Intensity != 0) && (img[y, x + 1].Intensity != 0) && (img[y + 1, x].Intensity != 0))
            { img.Draw(new Point[] { new Point(x, y) }, new Gray(128), 1); result.Add(new Point(x, y)); continue; }
            if ((img[y - 1, x].Intensity != 0) && (img[y + 1, x].Intensity != 0) && (img[y, x - 1].Intensity != 0))
            { img.Draw(new Point[] { new Point(x, y) }, new Gray(128), 1); result.Add(new Point(x, y)); continue; }
            if ((img[y - 1, x].Intensity != 0) && (img[y + 1, x].Intensity != 0) && (img[y, x + 1].Intensity != 0))
            { img.Draw(new Point[] { new Point(x, y) }, new Gray(128), 1); result.Add(new Point(x, y)); continue; }
          }
        }
        return result;
      }

      public static List<Point> FindPointsByDiagonal(VectorOfPoint input)
      {
        List<Point> result = new List<Point>();
        VectorOfVectorOfPoint tmp = new VectorOfVectorOfPoint();
        tmp.Push(input);
        Image<Gray, Byte> img = new Image<Gray, byte>(184, 140, new Gray(0));
        CvInvoke.DrawContours(img, tmp, -1, new MCvScalar(255), 1, LineType.EightConnected);
        int x = 0;
        int y = 0;
        Byte[, ,] data = img.Data;

        for (int i = 0; i < input.Size; i++)
        {
          x = input[i].X;
          y = input[i].Y;
          // 0100
          // 1*00
          // 0111

          if ((data[y - 1, x - 1, 0] == 0) && (data[y - 1, x, 0] != 0) && (data[y - 1, x + 1, 0] == 0) && (data[y - 1, x + 2, 0] == 0) &&
               (data[y, x - 1, 0] != 0) && (data[y, x, 0] != 0) && (data[y, x + 1, 0] == 0) && (data[y, x + 2, 0] == 0) &&
               (data[y + 1, x - 1, 0] == 0) && (data[y + 1, x, 0] == 0) && (data[y + 1, x + 1, 0] != 0) && (data[y + 1, x + 2, 0] != 0)
              )
          { img.Draw(new Point[] { new Point(x, y) }, new Gray(128), 1); result.Add(new Point(x, y)); continue; }

          /*
          if ((img[y, x - 1].Intensity != 0) && (img[y, x + 1].Intensity != 0) && (img[y - 1, x].Intensity != 0))
          { img.Draw(new Point[] { new Point(x, y) }, new Gray(128), 1); result.Add(new Point(x, y)); continue; }
          if ((img[y, x - 1].Intensity != 0) && (img[y, x + 1].Intensity != 0) && (img[y + 1, x].Intensity != 0))
          { img.Draw(new Point[] { new Point(x, y) }, new Gray(128), 1); result.Add(new Point(x, y)); continue; }
          if ((img[y - 1, x].Intensity != 0) && (img[y + 1, x].Intensity != 0) && (img[y, x - 1].Intensity != 0))
          { img.Draw(new Point[] { new Point(x, y) }, new Gray(128), 1); result.Add(new Point(x, y)); continue; }
          if ((img[y - 1, x].Intensity != 0) && (img[y + 1, x].Intensity != 0) && (img[y, x + 1].Intensity != 0))
          { img.Draw(new Point[] { new Point(x, y) }, new Gray(128), 1); result.Add(new Point(x, y)); continue; }
          */
        }
        return result;
      }


    }

    public static class Split
    {
      public static List<VectorOfPoint> SepByQuadroPoints(VectorOfPoint Input)
      {
        //создать изображение для удобства и нарисовать контуры
        List<VectorOfPoint> result = new List<VectorOfPoint>();
        Image<Gray, Byte> img = new Image<Gray, Byte>(184, 140, new Gray(255));
        result.Add(Input);
        CvInvoke.DrawContours(img, NeuronSeparation.Converter.ListOfVOPtoVVOP(result), -1, new MCvScalar(0), 1, LineType.EightConnected);
        result = new List<VectorOfPoint>();

        //
        List<Point> quadro = NeuronSeparation.Calculations.FindQuadroPoints(Input);
        if (quadro.Count == 0) return new List<VectorOfPoint>();

        //ищем точки близкие к квадроточкам.это будет начало и конец половины чанка. 
        // в списке четые точки по порядку: 1Z / 2A / и A/Z вторых половинок
        List<Point>[] contourCloseTocurQPoint = new List<Point>[quadro.Count];
        for (int k = 0; k < quadro.Count; k++) contourCloseTocurQPoint[k] = new List<Point>();

        for (int i = 0; i < Input.Size; i++)
        {
          for (int k = 0; k < quadro.Count; k++)
          {
            if ((Math.Abs(Input[i].X - quadro[k].X) + Math.Abs(Input[i].Y - quadro[k].Y)) == 1) contourCloseTocurQPoint[k].Add(Input[i]);
          }
        }
        // AZ-точки половинок чанков. идут по порядку от 1 до последнего
        List<Point> chunksAZ = new List<Point>();
        chunksAZ.Add(Input[0]);

        for (int i = 0; i < contourCloseTocurQPoint.Length; i++)
        {
          chunksAZ.Add(contourCloseTocurQPoint[i][1]);
        }

        for (int i = contourCloseTocurQPoint.Length - 1; i >= 0; i--)
        {
          chunksAZ.Add(contourCloseTocurQPoint[i][3]);
        }


        //заполняем половинки
        //переход от квадроточек к точкам контура. чанк - это цельный контур, полученный из исходного
        VectorOfPoint[] chunks = new VectorOfPoint[quadro.Count + 1];
        for (int k = 0; k < quadro.Count + 1; k++) chunks[k] = new VectorOfPoint();

        VectorOfPoint curChunk = new VectorOfPoint();
        int curAZPoint = 1;
        int curChunkId = 0;
        chunks[curChunkId].Push(new Point[] { Input[0] });
        bool flag = false;
        for (int i = 1; i < Input.Size; i++)
        {
          if (Input[i] == chunksAZ[curAZPoint])
          {
            if (curAZPoint != chunksAZ.Count - 1) curAZPoint++;

            if (curChunkId == quadro.Count) flag = true;
            if (flag) curChunkId--;
            else curChunkId++;
          }
          chunks[curChunkId].Push(new Point[] { Input[i] });
        }

        for (int i = 0; i < chunks.Length; i++)
          result.Add(chunks[i]);

        return result;
      }
      public static List<VectorOfPoint> SepSelfIntersectionPoints(VectorOfPoint Input)
      {
        //создать изображение для удобства и нарисовать контуры
        List<VectorOfPoint> result = new List<VectorOfPoint>();
        Image<Gray, Byte> img = new Image<Gray, Byte>(184, 140, new Gray(255));
        result.Add(Input);
        CvInvoke.DrawContours(img, NeuronSeparation.Converter.ListOfVOPtoVVOP(result), -1, new MCvScalar(0), -1, LineType.EightConnected);
        result = new List<VectorOfPoint>();

        //
        List<Point> selfPoints = NeuronSeparation.Calculations.FindSelfIntersections(Input);
        if (selfPoints.Count == 0) return new List<VectorOfPoint>();

        int i = 0;

        for (i = 0; i < selfPoints.Count; i++)
        {
          img.Draw(new Point[] { selfPoints[i] }, new Gray(128), 1);
        }


        // AZ-точки половинок чанков. идут по порядку от 1 до последнего
        List<Point> chunksAZ = new List<Point>();
        //chunksAZ.Add(Input[0]);

        for (i = 0; i < Input.Size; i++)
        {
          if (selfPoints.Contains(Input[i]))
          {
            //
            i++;
            chunksAZ.Add(Input[i]);
          }

        }

        //заполняем половинки
        //переход от точек к точкам контура. чанк - это цельный контур, полученный из исходного
        VectorOfPoint[] chunks = new VectorOfPoint[chunksAZ.Count];
        for (int k = 0; k < chunksAZ.Count; k++) chunks[k] = new VectorOfPoint();

        VectorOfPoint curChunk = new VectorOfPoint();

        int curAZPoint = 0;
        int curChunkId = 0;
        //chunks[curChunkId].Push(new Point[] { Input[0] });
        bool flag = false;
        for (i = 0; i < Input.Size; i++)
        {
          if (Input[i] == chunksAZ[curAZPoint])
          {
            //curChunkId++;
            if (curAZPoint != chunksAZ.Count - 1) curAZPoint++;

            if (curChunkId == chunks.Length - 1) flag = true;
            if (flag) curChunkId--;
            else curChunkId++;
          }
          chunks[curChunkId].Push(new Point[] { Input[i] });
        }

        for (i = 0; i < chunks.Length; i++)
          result.Add(chunks[i]);

        result = new List<VectorOfPoint>();
        //img = new Image<Gray, Byte>(184, 140, new Gray(255));
        result.Add(chunks[0]);
        CvInvoke.DrawContours(img, NeuronSeparation.Converter.ListOfVOPtoVVOP(result), -1, new MCvScalar(100), 1, LineType.EightConnected);
        result = new List<VectorOfPoint>();
        result.Add(chunks[1]);
        CvInvoke.DrawContours(img, NeuronSeparation.Converter.ListOfVOPtoVVOP(result), -1, new MCvScalar(150), 1, LineType.EightConnected);

        return result;
      }
      public static List<VectorOfPoint> SepByQuadroPoints(List<VectorOfPoint> Input)
      {
        List<VectorOfPoint> result = new List<VectorOfPoint>();
        //List<Point> Q = new List<Point>();
        List<VectorOfPoint> tmp = new List<VectorOfPoint>();
        for (int i = 0; i < Input.Count; i++)
        {
          //Q = NeuronSeparation.Calculations.FindQuadroPoints(Input[i]);
          tmp = NeuronSeparation.Split.SepByQuadroPoints(Input[i]);

          if (tmp.Count != 0) result.AddRange(tmp);
          else result.Add(Input[i]);
        }
        return result;
      }
    }

    public static class Masks
    {
      public static List<NeuronBodyMask> GenerateNeuronBodyMasks(List<VectorOfPoint> input)
      {
        List<NeuronBodyMask> result = new List<NeuronBodyMask>();
        NeuronBodyMask tmp_mask = new NeuronBodyMask();

        Rectangle R = new Rectangle();
        Image<Gray, Byte> maskImg = new Image<Gray, Byte>(1, 1, new Gray(0));
        Point C = new Point();

        VectorOfVectorOfPoint tmp_vvop = new VectorOfVectorOfPoint();
        MCvMoments moments = new MCvMoments();

        for (int i = 0; i < input.Count; i++)
        {
          R = CvInvoke.BoundingRectangle(input[i]);
          maskImg = new Image<Gray, byte>(184, 140, new Gray(0));

          tmp_vvop = new VectorOfVectorOfPoint();
          tmp_vvop.Push(input[i]);
          CvInvoke.DrawContours(maskImg, tmp_vvop, -1, new MCvScalar(255), -1, LineType.EightConnected);


          moments = CvInvoke.Moments(input[i]);
          C = new Point((int)(moments.M10 / moments.M00), (int)(moments.M01 / moments.M00));
          //maskImg.Draw(new Point[] { C }, new Gray(100), 1);
          tmp_mask = new NeuronBodyMask(R, maskImg, C);
          result.Add(tmp_mask);
        }

        return result;
      }

      public static List<Image<Gray, Byte>> GetBigMasks(List<NeuronBodyMask> input)
      {
        List<Image<Gray, Byte>> result = new List<Image<Gray, Byte>>();
        for (int i = 0; i < input.Count; i++)
          result.Add(input[i].BodyMask);

        return result;
      }

      public static List<Image<Gray, Byte>> GetMergedMasks(List<NeuronBodyMask> input)
      {
        List<Image<Gray, Byte>> result = new List<Image<Gray, Byte>>();
        //
        if (input.Count == 2)
        {
          if (input[0].Field.IntersectsWith(input[1].Field))
          {
            result.Add(input[0].BodyMask);
            result.Add(input[1].BodyMask);
          }
          else result.Add(input[0].BodyMask + input[1].BodyMask);
        }


        Image<Bgr, Byte> img = new Image<Bgr, byte>(184, 140, new Bgr(0, 0, 0));
        for (int i = 0; i < input.Count; i++)
        {
          try
          {
            img[0] = img[0] + input[i].BodyMask;
            img[1] = img[1] + input[i].BodyMask;
            img[2] = img[2] + input[i].BodyMask;
          }
          catch (Exception) { }
        }
        /*
        for (int i = 0; i < input.Count; i++)
        {
          img.Draw(input[i].Field, new Bgr(200, 0, 200), 1);
        }
         * */
        //CvInvoke.DrawContours(img, NeuronSeparation.Converter.ListOfVOPtoVVOP(input), -1, new MCvScalar(255, 255, 255), 1, LineType.EightConnected);

        //

        List<NeuronBodyMask> src = input.ToList();

        List<List<NeuronBodyMask>> res = new List<List<NeuronBodyMask>>();
        List<NeuronBodyMask> Accumulator = new List<NeuronBodyMask>();
        /*
        List<int> delIndexes = new List<int>();
        bool isInAcc = true;


        for (int i = 0; i < src.Count; i++)
        {
          Accumulator.Add(src[0]);
          delIndexes.Add(0);
          for (int j = 1; j < src.Count; j++)
          {
            if (!src[i].Field.IntersectsWith(src[j].Field))
            {
              Accumulator.Add(src[j]);
              delIndexes.Add(j);
            }
          }
          /*
          for (int k = 0; k < delIndexes.Count; k++)
            src.RemoveAt(delIndexes[k]);
          
          res.Add(Accumulator);
          Accumulator = new List<NeuronBodyMask>();
          delIndexes = new List<int>();
          i = 0;
         }
        */

        //
        //
        Image<Gray, Byte> source = img[0];
        Image<Gray, Byte> TMPImg = source.CopyBlank();
        List<MCvScalar> III = new List<MCvScalar>();
        Stopwatch timer = new Stopwatch();
        timer.Start();

        for (int i = 0; i < input.Count; i++)
        {
          TMPImg = source.Copy(input[i].BodyMask);
          result.Add(TMPImg);
          //CvInvoke.cvSetImageROI(TMPImg, input[i].Field);
          III.Add(CvInvoke.Sum(TMPImg));
          //CvInvoke.cvResetImageROI(TMPImg);
        }
        timer.Stop();
        long L = timer.ElapsedMilliseconds;
        timer.Reset();
        L = L + 0;



        /*
        Image<Gray, Byte> tmpImg = new Image<Gray, Byte>(input[0].BodyMask.Width, input[0].BodyMask.Height, new Gray(0));
        for (int k = 0; k < res.Count; k++)
          for (int kk = 0; kk < res[k].Count; kk++)
          {
            img.Draw(res[k][kk].Field, new Bgr(255, 0, 0), 1);
          }
        */

        return result;
      }
    }
  }
}
