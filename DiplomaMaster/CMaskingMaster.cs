﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;


using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.Util.TypeEnum;

namespace DiplomaMaster
{
  public class CMaskingMaster 
  {
    private IMaskingStrategy strategy = null;
    Dictionary<string, string> strategyNames = new Dictionary<string, string>();

    private Image<Gray, Byte> MaskImage;
    private List<NeuronBodyMask> NeuronBodyMasks;


    public CMaskingMaster()
    {
      strategyNames = CReflectionTools.GetStrategyNamesFromNamespace("DiplomaMaster.MaskingMethods", "CMasking_");

      MaskImage = new Image<Gray, byte>(1, 1, new Gray(0));
      NeuronBodyMasks = new List<NeuronBodyMask>();
    }

    // возвращает список нормальных названий методов
    public List<string> GetListOfMethods()
    {
      return strategyNames.Keys.ToList();
    }

    public  void SetMethod(string MethodName)
    {
      if (!strategyNames.ContainsKey(MethodName))
        throw new Exception("SetMethod: method name incorrect!");
      else
      {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type type = assembly.GetTypes()
            .First(t => t.Name == strategyNames[MethodName]);
        strategy = (IMaskingStrategy)Activator.CreateInstance(type);
      }                                                                                    
    }

    public  Image<Gray, byte> Process(Image<Gray, byte> Input)
    {
      MaskImage = strategy.GenerateMask(Input);
      SplitMaskToMany();

      return strategy.GenerateMask(Input);
    }

    public List<NeuronBodyMask> GetListOfNeuronBodyMasks()
    {
      return NeuronBodyMasks;
    }

    public Image<Gray, Byte> GetMaskImage()
    {
      return MaskImage;
    }

    private void SplitMaskToMany()
    {
      Image<Gray, Byte> TMP = ImgProcTools.BinarizationMethods.BinByDistanceTransform(MaskImage);

      VectorOfVectorOfPoint AllContours = ImgProcTools.EdgeDetection.SimplestEdgeDetection(TMP);

      List<VectorOfPoint> smallContours = new List<VectorOfPoint>();
      List<VectorOfPoint> rejectedContours = new List<VectorOfPoint>();

      //!!
      int Threshold = 100; // длина контура в пикселях
      //!!

      List<VectorOfPoint> BigContours = NeuronSeparation.Calculations.SeparateSmallContours(NeuronSeparation.Converter.VVOPToListOfVOP(AllContours), out smallContours, out rejectedContours, Threshold);

      NeuronBodyMasks = NeuronSeparation.Masks.GetNeuronBodyMasks(BigContours);
    }
  }
}
