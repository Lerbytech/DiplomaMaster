using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DiplomaMaster
{
  public class CNeuronProvider : IDisposable
  {
    Dictionary<int, List<double>> NeuronIntensities;
    Dictionary<int, StreamWriter> outputFiles;
    string pathToExportDirectory;
    bool disposed = false;
     
    public CNeuronProvider()
    {
      NeuronIntensities = new Dictionary<int, List<double>>();
      outputFiles = new Dictionary<int, StreamWriter>();
    }

    public void PrepareExport(StructMainFormParams Params)
    {
      pathToExportDirectory = Params.PathToSaveFolder;
    }

    /// <summary>
    /// Добавляет новый набор значений интенсивностей нейронов
    /// </summary>
    /// <param name="newIntensities">словарь с новыми значениями интенсивностей нейронов</param>
    public void AddValues(Dictionary<int, double> newIntensities)
    {
      foreach (var I in newIntensities)
      {
        if (NeuronIntensities.ContainsKey(I.Key))
        {
          if (NeuronIntensities[I.Key].Count == 0)
          {
            NeuronIntensities[I.Key] = new List<double>();
            

          }
          NeuronIntensities[I.Key].Add(I.Value);
        }
        else
          NeuronIntensities.Add(I.Key, new List<double>() { I.Value });
      }

      foreach (var I in NeuronIntensities)
      {
        outputFiles[I.Key].WriteLine(I.Value);
      }
    }


    #region Хитрости чтобы файлы точно сохранились

    ~CNeuronProvider()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
      // This object will be cleaned up by the Dispose method.
      // Therefore, you should call GC.SupressFinalize to
      // take this object off the finalization queue
      // and prevent finalization code for this object
      // from executing a second time.
      GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
      // Check to see if Dispose has already been called.
      if (!this.disposed)
      {
        // If disposing equals true, dispose all managed
        // and unmanaged resources.
        if (disposing)
        {
          // Dispose managed resources.
        }

        //Disposing unmanage resources
        foreach (var I in outputFiles)
          I.Close();

        // Note disposing has been done.
        disposed = true;
      }
    }

    #endregion
  }
}
