using System;
using System.Reflection;
using Microsoft.Vsa;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;


using SharpVectors.Dom;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Events;

namespace SharpVectors.Scripting
{
	/// <summary>
	/// Summary description for ScriptEventMonitor.
	/// </summary>
	public class ScriptEventMonitor
	{
    private IAttribute att = null;
    private VsaScriptEngine engine = null;
    private ISvgWindow window = null;

		public ScriptEventMonitor(VsaScriptEngine engine, IAttribute att, ISvgWindow window)
		{
      this.att = att;
      this.engine = engine;
      this.window = window;
		}
   
    public void EventHandler(
      IEvent @event)
    {
      try 
      {
        int handle = window.Document.RootElement.SuspendRedraw(60000);
        ((JScriptEngine)engine).Evaluate(att.Value, @event);
        window.Document.RootElement.UnsuspendRedraw(handle);
        System.GC.Collect();
        System.GC.WaitForPendingFinalizers();
      } 
      catch (Exception e) 
      {
  //XXX: FOO      System.Windows.Forms.MessageBox.Show(e.Message + "\n" + e.StackTrace + "\n" + e.ToString());
  Console.WriteLine (e.Message + "\n" + e.StackTrace + "\n" + e.ToString());
      }
    }
	}
}
