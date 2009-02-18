using System;
using SharpVectors.Dom;
using SharpVectors.Dom.Css;
using SharpVectors.Dom.Events;
using SharpVectors.Dom.Stylesheets;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Views;
using SharpVectors.Scripting;
using System.Xml;

using Microsoft.JScript;

namespace SharpVectors.Scripting
{

		/// <summary>
		/// Implementation wrapper for IScriptableSvgWindow
		/// </summary>
		public class ScriptableSvgWindow : ScriptableObject, IScriptableSvgWindow
		{
			public ScriptableSvgWindow(object baseObject, ScriptEngine engine) : base (baseObject) { this.Engine = engine; }

      public ScriptEngine Engine;

			#region Methods - IScriptableSvgWindow
			public string setTimeout(object scriptOrClosure, ulong delay)
			{
				return ScriptTimerMonitor.CreateMonitor((VsaScriptEngine)Engine, (ISvgWindow)baseObject, scriptOrClosure, delay, false);
			}

			public void clearTimeout(string token)
			{
        ScriptTimerMonitor.ClearMonitor(token);
      }

			public string setInterval(object scriptOrClosure, ulong delay)
			{
        return ScriptTimerMonitor.CreateMonitor((VsaScriptEngine)Engine, (ISvgWindow)baseObject, scriptOrClosure, delay, true);
      }

			public void clearInterval(string token)
			{
				ScriptTimerMonitor.ClearMonitor(token);
			}

			public void alert(string message)
			{
				((ISvgWindow)baseObject).Alert(message);
			}

			public void setSrc(string newURL)
			{
				((ISvgWindow)baseObject).Src = newURL;
			}

			public string getSrc()
			{
				return ((ISvgWindow)baseObject).Src;
			}

			public string printNode(IScriptableNode node)
			{
				return ((ISvgWindow)baseObject).PrintNode(((XmlNode)((ScriptableNode)node).baseObject));
			}

			public IScriptableNode parseXML(string xml, IScriptableDocument owner)
			{
				object result = ((ISvgWindow)baseObject).ParseXML(xml, ((XmlDocument)((ScriptableDocument)owner).baseObject));
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}

      public void registerEval(object scriptFunction) 
      {
        JScriptEngine js = ((JScriptEngine)Engine);
        js.EvaluateFunction = (ScriptFunction)scriptFunction;
      }

      #endregion

			#region Properties - IScriptableWindow
			public IScriptableSvgDocument document
			{
				get { object result = ((ISvgWindow)baseObject).Document; return (result != null) ? (IScriptableSvgDocument)ScriptableObject.CreateWrapper(result) : null; }
			}

      public IScriptableSvgDocument svgDocument
      {
        get { object result = ((ISvgWindow)baseObject).Document; return (result != null) ? (IScriptableSvgDocument)ScriptableObject.CreateWrapper(result) : null; }
      }

      public IScriptableStyleSheet defaultStyleSheet
      {
        get { object result = ((ISvgWindow)baseObject).DefaultStyleSheet; return (result != null) ? (IScriptableStyleSheet)ScriptableObject.CreateWrapper(result) : null; }
      }
			
			public long innerWidth
			{
				get { return ((ISvgWindow)baseObject).InnerWidth;  }
			}

			public long innerHeight
			{
				get { return ((ISvgWindow)baseObject).InnerHeight;  }
			}

			#endregion
		}

}
  
