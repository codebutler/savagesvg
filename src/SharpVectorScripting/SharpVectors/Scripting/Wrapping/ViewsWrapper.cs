using System;
using SharpVectors.Dom;
using SharpVectors.Dom.Css;
using SharpVectors.Dom.Events;
using SharpVectors.Dom.Stylesheets;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Views;


namespace SharpVectors.Scripting
{

		/// <summary>
		/// Implementation wrapper for IScriptableAbstractView
		/// </summary>
		public class ScriptableAbstractView : ScriptableObject, IScriptableAbstractView
		{
			public ScriptableAbstractView(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableAbstractView
			public IScriptableDocumentView document
			{
				get { object result = ((IAbstractView)baseObject).Document; return (result != null) ? (IScriptableDocumentView)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableDocumentView
		/// </summary>
		public class ScriptableDocumentView : ScriptableObject, IScriptableDocumentView
		{
			public ScriptableDocumentView(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableDocumentView
			public IScriptableAbstractView defaultView
			{
				get { object result = ((IDocumentView)baseObject).DefaultView; return (result != null) ? (IScriptableAbstractView)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

}
  
