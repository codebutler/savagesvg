using System;
using Microsoft.Vsa;

namespace SharpVectors.Scripting
{

  public abstract class VsaScriptEngine : ScriptEngine, IVsaSite
  {
    #region Fields
    protected IVsaEngine engine;
    protected IVsaItems items;
    #endregion

    #region Constructor
    protected VsaScriptEngine(object scriptGlobal) : base(scriptGlobal) {}
    #endregion

    #region VsaSite interface
    void IVsaSite.GetCompiledState(out Byte[] pe, out Byte[] debugInfo)
    {
      pe = debugInfo = null;
    }

    object IVsaSite.GetEventSourceInstance(string itemName, string eventSourceName)
    {
      return this.scriptGlobal;
    }

    object IVsaSite.GetGlobalInstance(string name)
    {
      object result;

      switch (name) 
      {
        case "window":
          result = this.scriptGlobal;
          break;
        default:
          Console.WriteLine("GlobalInstance not found: " + name);
          result = null;
          break;
      }

      return result;
    }

    void IVsaSite.Notify(string notify, object info)
    {
    }

    bool IVsaSite.OnCompilerError(IVsaError e)
    {
      Console.WriteLine(
        String.Format("Error of severity {0} on line {1}: {2}", e.Severity, e.Line, e.Description));

      //((IScriptableSvgWindow)scriptGlobal).alert(String.Format("Compilation Error of severity {0} on line {1}: {2}", e.Severity, e.Line, e.Description));
      // Continue to report errors
      return true;
    }

    public IVsaEngine Engine 
    {
      get 
      {
        return engine;
      }
    }
    #endregion
  }
}
