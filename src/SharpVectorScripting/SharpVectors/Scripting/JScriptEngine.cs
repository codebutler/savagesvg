using System;
using System.Reflection;
using System.Text;
using Microsoft.Vsa;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;

namespace SharpVectors.Scripting
{
  public class JScriptEngine : VsaScriptEngine
  {
    #region Fields
    private static int counter = 0;
    #endregion

    #region Constructors
    public JScriptEngine(object scriptGlobal) : base(scriptGlobal)
    {
      engine = new Microsoft.JScript.Vsa.VsaEngine();
      engine.RootMoniker = "sharpvectors://jsengine/" + counter++;
      engine.Site = this;
      engine.InitNew();
      engine.RootNamespace = "SharpVectors.Scripting";
      engine.GenerateDebugInfo = false;
      engine.RevokeCache();
      engine.SetOption("Fast", false);
      
      items = engine.Items;
      Assembly asm = typeof(SharpVectors.Scripting.JScriptEngine).Assembly;
      IVsaReferenceItem refItem = (IVsaReferenceItem)items.CreateItem(asm.Location, VsaItemType.Reference, VsaItemFlag.None);
      refItem.AssemblyName = asm.Location;
    }
            
    #endregion

    #region Public Methods
        
    public override void Initialise()
    {
      // Get the Items
      items = engine.Items;      
      // Load the preamble code
      string preamble = @"
        var document = window.document;
		    function setTimeout(script : String, delay : ulong) : String { return window.setTimeout(script, delay); }
		    function clearTimeout(token : String) : void  { window.clearTimeout(token); }
		    function setInterval(script : String, delay : ulong) : String { return window.setInterval(script, delay); }
		    function clearInterval(token : String) : void { window.clearInterval(token); }
		    function getSrc() : String { return window.getSrc(); }
		    function printNode(node : Object) : String { return window.printNode(node); }
		    function parseXML(xml : String, owner : Object) : Object { return window.parseXML(xml, owner); }
        function alert(msg : String) : void { window.alert(msg); }
        function browserEval(src : String, evt : Object) : String { return eval( src, 'unsafe'); }
        window.registerEval(browserEval);
      ";
      IVsaCodeItem codeItem = (IVsaCodeItem)items.CreateItem("Preamble", VsaItemType.Code, VsaItemFlag.None);
      codeItem.SourceText = preamble;
 
      // Add the global "window" item
      IVsaGlobalItem  globalItem = (IVsaGlobalItem) items.CreateItem("window", VsaItemType.AppGlobal, VsaItemFlag.None);
      globalItem.TypeString = "SharpVectors.Scripting.IScriptableSvgWindow";
      globalItem.ExposeMembers = true;
    }

    public override void Close() 
    {
      engine.Close();
    }

    public override void Execute(string code)
    {
      try
      {
        if (engine.IsRunning)
        {
          engine.Reset();
        }

        // Load the script code
        IVsaCodeItem codeItem = (IVsaCodeItem) items.CreateItem("Script", VsaItemType.Code, VsaItemFlag.None);
        codeItem.SourceText = code;

        // compile and run
        if (engine.Compile()) 
        {
          engine.Run();
        }
      }
      catch (Exception e)
      {
        //XXX: AAAHHH 
        // MessageBox.Show(e.Message + "\n" + e.StackTrace + "\n" + e.ToString());
        Console.WriteLine(e.Message + "\n" + e.StackTrace + "\n" + e.ToString());
      }
    }

    private ScriptFunction evaluateFunction = null;
    public ScriptFunction EvaluateFunction 
    {
      get 
      {
        return evaluateFunction;
      }
      set 
      {
        evaluateFunction = value;
      }
    }

    public object Evaluate(string code, object @event) 
    {
      if (evaluateFunction == null) 
        return null;
      Object[] args = new Object[2];
      args[0] = code;
      args[1] = ScriptableObject.CreateWrapper(@event);        
      return evaluateFunction.Invoke(evaluateFunction.GetParent(), args);        
    }
    #endregion

    #region Private Methods
    private void showTypeInfo() 
    {
      if ( engine.IsRunning ) 
      {
        // show types
        System.Type[] types = engine.Assembly.GetTypes();
        StringBuilder typeNames = new StringBuilder();
        foreach ( Type type in types )
        {
          typeNames.Append(type.FullName);
          typeNames.Append("\n");
          MethodInfo[] methods = type.GetMethods();
          foreach ( MethodInfo method in methods ) 
          {
            typeNames.Append("    ");
            typeNames.Append(method.Name);
            typeNames.Append("(");
            foreach ( ParameterInfo param in method.GetParameters() ) 
            {
              typeNames.Append(" ");
              typeNames.Append(param.ParameterType.Name);
            }
            typeNames.Append(" )\n");
          }
        }
 //XXX:       MessageBox.Show(typeNames.ToString());
 Console.WriteLine(typeNames.ToString());
      }
    }
    #endregion
  }
}
