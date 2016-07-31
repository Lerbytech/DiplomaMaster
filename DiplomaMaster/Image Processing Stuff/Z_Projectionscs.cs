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
  public static class Z_Projections
  {
    public static Image<Gray, Byte> ZP_Min(List<Image<Gray, Byte>> input)
    {
      Image<Gray, Byte> result = input[0].Clone();
      int width = result.Cols;
      int height = result.Rows;
      byte [,,]data;
      byte [,,]res_data = result.Data;
      foreach (var Img in input)
      {
        data = Img.Data;
        for (int x = 0; x < width; x++)
          for (int y = 0; y < height; y++)
          {
            if (res_data[y, x, 0] > data[y, x, 0]) res_data[y, x, 0] = data[y, x, 0];
          }
      }

      return result;
    }

    public static Image<Gray, Byte> ZP_Max(List<Image<Gray, Byte>> input)
    {
      Image<Gray, Byte> result = input[0].Clone();
      int width = result.Cols;
      int height = result.Rows;
      byte[, ,] data;
      byte[, ,] res_data = result.Data;
      foreach (var Img in input)
      {
        data = Img.Data;
        for (int x = 0; x < width; x++)
          for (int y = 0; y < height; y++)
          {
            if (res_data[y, x, 0] < data[y, x, 0]) res_data[y, x, 0] = data[y, x, 0];
          }
      }

      return result;
    }

  }
}
