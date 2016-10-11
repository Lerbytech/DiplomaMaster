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
  public delegate Image<Gray, Byte> DenoisingMethod(Image<Gray, Byte> Img);
  public delegate List<Image<Gray, Byte>> NeuronParserMethod(Image<Gray, Byte> Img);

  public class CImageParser
  {
    //Поля
    private DenoisingMethod _denoisingMethod;
    private NeuronParserMethod _neuronParserMethod;
    private Image<Gray, Byte> tmpImage;
    private Image<Gray, Byte> Mask;

    //Методы
    public CImageParser(Dictionary<string, object> Parameters, 
                        DenoisingMethod denoiseMethod,
                        NeuronParserMethod parsingMethod)
    {
      //Подготовить поля класса
      AdjustFields(Parameters);

      //Настроить захват данных
      Image<Gray, Byte> tmpIMG = CImageProvider.GetImage(0);
      ImgProcTools.Denoise.PrepareDenoiseFunctions(tmpIMG.Width, tmpIMG.Height);

      //------------------
      _denoisingMethod = denoiseMethod;
      _neuronParserMethod = parsingMethod;
    }

    public Image<Gray, Byte> GetMask()
    {
      return Mask;
    }

    public void SetMask(Image<Gray, Byte> input)
    {
      Mask = input;
    }

    public Dictionary<int, double> ProcessImage(Image<Gray, byte> inputIMG)
    {
      Dictionary<int, double> res = new Dictionary<int, double>();
      tmpImage = _denoisingMethod.Invoke(inputIMG);

      


      return res;
    }

    private void AdjustFields(Dictionary<string, object> P)
    {
      
    }
  }
}
