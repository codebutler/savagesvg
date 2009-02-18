using System;
using System.Reflection;
using System.Collections;
using Microsoft.Vsa;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;


using SharpVectors.Dom;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Events;

namespace SharpVectors.Scripting
{
  /// <summary>
  /// Summary description for ClosureEventMonitor.
  /// </summary>
  public class ClosureEventMonitor
  {
    private Closure closure = null;

    private static Hashtable monitorMap = new Hashtable();
    
    public static ClosureEventMonitor CreateMonitor(Closure clo) 
    {
      ClosureEventMonitor mon = (ClosureEventMonitor)monitorMap[clo];
      if (mon == null) 
      {
        mon = new ClosureEventMonitor(clo);
        monitorMap[clo] = mon;
      }
      return mon;
    }

    public static ClosureEventMonitor Find(Closure clo) 
    {
      return (ClosureEventMonitor)monitorMap[clo];
    }


    public static void Clear() 
    {
      monitorMap.Clear();
    }

    public ClosureEventMonitor(Closure closure)
    {
      this.closure = closure;
    }
   
    public void EventHandler(
      IEvent @event)
    {
      VsaEngine vsa = (Microsoft.JScript.Vsa.VsaEngine)closure.engine;
      try 
      {        
        //int handle = window.Document.RootElement.SuspendRedraw(60000);
        Object[] args = new Object[1];
        args[0] = ScriptableObject.CreateWrapper(@event);        
        GlobalScope scope = vsa.GetMainScope();
        closure.Invoke(closure.GetParent(), args);        
        //window.Document.RootElement.UnsuspendRedraw(handle);
      } 
      catch (Exception e) 
      {
       //XXX: Do something about this! System.Windows.Forms.MessageBox.Show(e.Message + "\n" + e.StackTrace + "\n" + e.ToString());
      	Console.WriteLine ("AAHHH!!!! " + e.ToString());
      }
    }
  }
}
