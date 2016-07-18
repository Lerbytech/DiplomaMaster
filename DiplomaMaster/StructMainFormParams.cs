using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiplomaMaster
{
  public enum MainFormMode
  {
    NewExperiment,
    ExistingExperiment
  };

  public struct StructMainFormParams
  {
    //private MainFormMode _workmode = MainFormMode.NewExperiment;

    public MainFormMode WorkMode;
      /*
    {
      public get
      {
        return _workmode;
      }
      public set
      {
        if (value == MainFormMode.NewExperiment)
        {
          doOverwriteFiles = true;
          doUseCleanFiles = false;
        }
        else
        {
          doOverwriteFiles = false;
          doUseCleanFiles = true;
        }
        _workmode = value;
      }
    }*/
    public string PathToLoadFolder;
    public string PathToSaveFolder;
    public bool doOverwriteFiles;
    public bool doUseCleanFiles;
    public bool doRecalculateMasks;
    public int RecalculationRate;
    public List<string> DenoiseModes;
    public int CurDenoiseMode;
    public List<string> MaskingModes;
    public int CurMaskingMode;

    public void SetDefaultParams()
    {
      WorkMode = MainFormMode.NewExperiment;
      PathToLoadFolder = String.Empty;
      PathToSaveFolder = String.Empty;
      doOverwriteFiles = true;
      doUseCleanFiles = false;
      doRecalculateMasks = false;
      RecalculationRate = -1;
      DenoiseModes = new List<string>();
      CurDenoiseMode = 0;
      MaskingModes = new List<string>();
      CurMaskingMode = 0;
    }
  }
}
