using System;

namespace SharpVectors.Scripting
{
  public abstract class ScriptEngine
  {
    #region Fields
    protected object scriptGlobal;
    #endregion

    #region Constructor
    protected ScriptEngine(object scriptGlobal)
    {
      this.scriptGlobal = (new ScriptableSvgWindow(scriptGlobal, this)) as IScriptableSvgWindow;
    }
    #endregion

    public abstract void Execute(string code);
    public abstract void Initialise();
    public abstract void Close();
  }
}
