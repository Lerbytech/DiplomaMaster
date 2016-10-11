using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;

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
    private static string FileExtension = ".png";

    public static Image<Gray, Byte> IMG;
    public static System.Drawing.Size ImageSize;

    private static int CurrImgIndex;
    //---------------------------------------------------
    //---------------------------------------------------


    public static void InitImageProvider(string inputDir)
    {
      if (!Directory.Exists(inputDir))
        throw new Exception("InitImageProvider: input directory not exists");

      
      // считать файлы из диска
      FullPathsToFiles = GetFiles(inputDir);

      // отсортировать 
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
        CurrImgIndex = 0;
        IMG = null;
      }

      return IMG;

    }

    /// <summary>
    /// Считывает файлы из папки, присваивает значения переменным
    /// </summary>
    /// <param name="DirectoryPath">Полный путь к папке с файлами</param>
    /// <returns>Неупорядоченный массив с полными путями к файлам</returns>
    private static string []GetFiles(string DirectoryPath)
    {
      string[] FileEntries = Directory.GetFiles(DirectoryPath, FileExtension);

      // Проверки файлов
      
      // 1 - проверка на размеры изображений - они должны быть равны
      // TODO!


      PathToDirectory = DirectoryPath;
      TotalNumberOfImages = FileEntries.Length;
      return FileEntries;
    }

    /// <summary>
    /// Упорядочивает файлы, так как GetFiles возвращает неверный порядок
    /// 
    /// </summary>
    /// <param name="FileEntries"></param>
    private static void OrderFiles(string[] FileEntries)
    {
      List<List<string>> Data = new List<List<string>>();

      int L = PathToDirectory.Length + FileExtension.Length;

      for (int i = 0; i < FileExtension.Length; i++)
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

      FullPathsToFiles = Final.ToArray();
    }
  }
}
