using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiplomaMaster
{
  public struct StructMainFormParams
  {
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
