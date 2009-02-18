using System;
using System.Reflection;
using System.Collections;
using System.Timers;
using Microsoft.Vsa;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;


using SharpVectors.Dom;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Events;

namespace SharpVectors.Scripting
{
  /// <summary>
  /// Summary description for ScriptTimerMonitor.
  /// </summary>
  public class ScriptTimerMonitor
  {
    private static ArrayList timerMonitors = new ArrayList();
    
    private object scriptOrClosure = null;
    private VsaScriptEngine engine = null;
    private ISvgWindow window = null;
    private Timer timer = null;

    public ScriptTimerMonitor(VsaScriptEngine engine, ISvgWindow window, object scriptOrClosure, ulong delay, bool isInterval)
    {
      if (delay == 0)
        delay = 1;
      this.engine = engine;
      this.window = window;
      this.scriptOrClosure = scriptOrClosure;
      this.timer = new Timer(delay);
      this.timer.AutoReset = isInterval;
      this.timer.Elapsed += new ElapsedEventHandler(this.EventHandler);
      this.timer.Enabled = true;
    }

    public static string CreateMonitor(VsaScriptEngine engine, ISvgWindow window, object scriptOrClosure, ulong delay, bool isInterval) 
    {
      ScriptTimerMonitor stm = new ScriptTimerMonitor(engine, window, scriptOrClosure, delay, isInterval);
      timerMonitors.Add(stm);
      return ""+stm.timer.GetHashCode();
    }

    public static void ClearMonitor(string token) 
    {
      ScriptTimerMonitor monToClear = null;
      foreach (ScriptTimerMonitor stm in timerMonitors) 
      {
        if (""+stm.timer.GetHashCode() == token) 
        {
          monToClear = stm;
          break;
        }
      }
      if (monToClear != null) 
      {
        monToClear.timer.Enabled = false;
        monToClear.timer = null;
        timerMonitors.Remove(monToClear);
      }
    }

    public static void Reset() 
    {
      foreach (ScriptTimerMonitor stm in timerMonitors) 
      {
        stm.timer.Enabled = false;
        stm.timer = null;
      }
      timerMonitors.Clear();
    }
   
    public void EventHandler(object source, ElapsedEventArgs args)
    {
      VsaEngine vsa = (Microsoft.JScript.Vsa.VsaEngine)engine.Engine;
      try 
      {
        int handle = window.Document.RootElement.SuspendRedraw(60000);
        if (scriptOrClosure is Closure) 
        {
          Closure closure = (Closure)scriptOrClosure;
          Object[] closureArgs = new Object[0];
          GlobalScope scope = vsa.GetMainScope();
          closure.Invoke(closure.GetParent(), closureArgs);        
        } 
        else 
          ((JScriptEngine)engine).Evaluate(scriptOrClosure.ToString(), null);
        window.Document.RootElement.UnsuspendRedraw(handle);
      } 
      catch (Exception e) 
      {
 //XXX:       System.Windows.Forms.MessageBox.Show(scriptOrClosure.ToString() + "\n\n" + e.Message + "\n" + e.StackTrace + "\n" + e.ToString());
 Console.Error.WriteLine(scriptOrClosure.ToString() + "\n\n" + e.Message + "\n" + e.StackTrace + "\n" + e.ToString());
      }

      // Clear this if we can
      if (! timer.AutoReset) 
      {
        ClearMonitor(""+timer.GetHashCode());
      }
    }
  }
}
