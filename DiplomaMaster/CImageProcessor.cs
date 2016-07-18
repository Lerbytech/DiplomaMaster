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
  public class CImageProcessor
  {
    private int DenoiseQueueLength = 4;



    //--------------------------------------------
    //--------------------------------------------
    public CImageProcessor(Dictionary<string, object> Parameters)
    {
      //Подготовить поля класса
      AdjustFields(Parameters);

      //Подготовить ввод данных
      CImageProvider.InitImageProvider((string)Parameters["PathToDirectory"]);

      //Подготовить вывод данных
      
      //Настроить захват данных
      Image<Gray, Byte> tmpIMG = CImageProvider.GetImage(0);
      ImgProcTools.Denoise.PrepareDenoiseFunctions(tmpIMG.Width, tmpIMG.Height);
    }

    public void ProcessImage()
    {


    }

    private void AdjustFields(Dictionary<string, object> P)
    {
      /*
        вкл/выключить шумоподавление / выбрать режим
        куда сохранять и откуда брать картинки
        выбрать режим поиска нейронов
      */
  
    }
  }
}
