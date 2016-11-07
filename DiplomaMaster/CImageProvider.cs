using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.Util.TypeEnum;

namespace DiplomaMaster
{
  public static class CImageProvider
  {
    public static string PathToDirectory
    {
      get;
      private set;
    }

    public static int TotalNumberOfImages
    {
      get;
      private set;
    }

    private static string[] FullPathsToFiles;
    private static string FileExtension = ".Png";

    public static Image<Gray, Byte> IMG;

    public static System.Drawing.Size ImageSize;

    private static int CurrImgIndex;
    //---------------------------------------------------
    //---------------------------------------------------

    public static void InitImageProvider(StructMainFormParams Params)
    {
      string inputDir;
      if (Params.doUseCleanFiles)
        throw new Exception("Not implemented yet!");
      else inputDir = Params.PathToLoadFolder;

      if (!Directory.Exists(inputDir))
        throw new Exception("InitImageProvider: input directory not exists");

      //считать файлы из диска
      FullPathsToFiles = GetFiles(inputDir);

      //Проверить имена полученных файлов
      /*
      if (!CheckFiles(FullPathsToFiles))
        throw new Exception("InitImageProvider: check files found error");
        */
      // отсортировать и проверить на ошибки полученные имена файлов
      OrderFiles(FullPathsToFiles);

      CurrImgIndex = 0;
      IMG = new Image<Gray, byte>( FullPathsToFiles[ CurrImgIndex ] );
    }

    /// <summary>
    /// Получить новое изображение. Если его нет, возвращает null.
    /// </summary>
    /// <returns> изображение Image<Gray, Byte> или null</returns>
    public static Image<Gray, Byte> GetImage()
    {
      CurrImgIndex++;
      if (CurrImgIndex < TotalNumberOfImages)
        IMG = new Image<Gray, byte>(FullPathsToFiles[CurrImgIndex]);
      else IMG = null;

      return IMG;
    }

    /// <summary>
    /// Получить изображение по его номеру. Если такого изображения нет, возвращает null.
    /// </summary>
    /// <returns> изображение Image<Gray, Byte> или null</returns>
    public static Image<Gray, Byte> GetImage(int id)
    {
      if (id >= 0 && id < TotalNumberOfImages)
      {
        CurrImgIndex = id;
        IMG = new Image<Gray, byte>(FullPathsToFiles[CurrImgIndex]);
      }
      else
      {
        //CurrImgIndex = 0;
        IMG = null;
      }

      return IMG;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static Image<Bgr, Byte> GetSampleImage()
    {
      return GetImage(10).Convert<Bgr, Byte>(); 
    }

    /// <summary>
    /// Считывает файлы из папки, присваивает значения переменным
    /// </summary>
    /// <param name="DirectoryPath">Полный путь к папке с файлами</param>
    /// <returns>Неупорядоченный массив с полными путями к файлам</returns>
    private static string []GetFiles(string DirectoryPath)
    {
      string[] FileEntries = Directory.EnumerateFiles(DirectoryPath).ToArray();

      PathToDirectory = DirectoryPath;
      TotalNumberOfImages = FileEntries.Length;
      return FileEntries;
    }

    /// <summary>
    /// Упорядочивает файлы, так как GetFiles возвращает неверный порядок.
    /// Проверяет на предмет ошибок в названиях (разные стили названий, 
    /// 
    /// </summary>
    /// <param name="FileEntries"></param>
    private static void OrderFiles(string[] FileEntries)
    {
      SortedDictionary<int, List<string>> LineLengthsDict = new SortedDictionary<int, List<string>>();

      int L = 0;
      for (int i = 0; i < FileEntries.Length; i++)
      {
        L = FileEntries[i].Length;
        if (!LineLengthsDict.ContainsKey(L))
          LineLengthsDict.Add(L, new List<string>());

        LineLengthsDict[L].Add(FileEntries[i]);
      }

      List<string> res = new List<string>();

      foreach (var I in LineLengthsDict)
        res.AddRange(I.Value);
      FullPathsToFiles = res.ToArray();
      
       /*
      List<List<string>> Data = new List<List<string>>();

      L = PathToDirectory.Length + FileExtension.Length;

      for (int i = 0; i < FileEntries.Length; i++)
      {
        if (FileEntries[i].Length > Data.Count + L)
        {
          Data.Add(new List<string>());
        }
        Data[FileEntries[i].Length - Data.Count - L].Add(FileEntries[i]);
      }

      List<string> Final = new List<string>();
      foreach (var I in Data)
        Final.AddRange(I);
         */
      //FullPathsToFiles = Final.ToArray();
    }

    private static bool CheckFiles(string[] DirtyFileNames)
    {
      bool isOk = true;

      //проверка на однородность стиля названий
      /*
      for (int i = 0; i < DirtyFileNames.Length; i++)
      {
        if ( !DirtyFileNames[i].Substring(PathToDirectory.Length).Contains('_'))
          return false;
      }
        */
      //проверка на однородность расширений
      for (int i = 0; i < DirtyFileNames.Length; i++)
      {
        if (!DirtyFileNames[i].Contains(FileExtension))
          return false;
      }

      //проверка на равенство размеров
      
      int Width_0 = 0;
      int Height_0 = 0;
      const int wOff = 16;  // нужные поля для быстрого метода поиска размера изображения
      const int hOff = 20;
      byte[] buff = new byte[32];

      var d = File.OpenRead(DirtyFileNames[0]); // считываем для 0 изображения
      d.Read(buff, 0, 32);

      int W = BitConverter.ToInt32(new[] { buff[wOff + 3], buff[wOff + 2], buff[wOff + 1], buff[wOff + 0], }, 0);
      int H = BitConverter.ToInt32(new[] { buff[hOff + 3], buff[hOff + 2], buff[hOff + 1], buff[hOff + 0], }, 0);

      Width_0 = W;
      Height_0 = H;
      for (int i = 0; i < DirtyFileNames.Length; i++)
      {
        d = File.OpenRead(DirtyFileNames[i]); // считываем для 0 изображения
        d.Read(buff, 0, 32);
        W = BitConverter.ToInt32(new[] { buff[wOff + 3], buff[wOff + 2], buff[wOff + 1], buff[wOff + 0], }, 0);
        H = BitConverter.ToInt32(new[] { buff[hOff + 3], buff[hOff + 2], buff[hOff + 1], buff[hOff + 0], }, 0);

        if (W != Width_0 || H != Height_0)
          return false;
      }
   
      return true;
    }

  }
}
