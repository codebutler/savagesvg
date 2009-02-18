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
		/// Implementation wrapper for IScriptableElementTimeControl
		/// </summary>
		public class ScriptableElementTimeControl : ScriptableObject, IScriptableElementTimeControl
		{
			public ScriptableElementTimeControl(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableElementTimeControl
			public void beginElement()
			{
				throw new NotImplementedException(); //((IElementTimeControl)baseObject).BeginElement();
			}

			public void beginElementAt(float offset)
			{
				throw new NotImplementedException(); //((IElementTimeControl)baseObject).BeginElementAt(offset);
			}

			public void endElement()
			{
				throw new NotImplementedException(); //((IElementTimeControl)baseObject).EndElement();
			}

			public void endElementAt(float offset)
			{
				throw new NotImplementedException(); //((IElementTimeControl)baseObject).EndElementAt(offset);
			}
			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableTimeEvent
		/// </summary>
		public class ScriptableTimeEvent : ScriptableEvent, IScriptableTimeEvent
		{
			public ScriptableTimeEvent(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableTimeEvent
			public void initTimeEvent(string typeArg, IScriptableAbstractView viewArg, long detailArg)
			{
				throw new NotImplementedException(); //((ITimeEvent)baseObject).InitTimeEvent(typeArg, ((IAbstractView)((ScriptableAbstractView)viewArg).baseObject), detailArg);
			}
			#endregion

			#region Properties - IScriptableTimeEvent
			public IScriptableAbstractView view
			{
        get { throw new NotImplementedException(); }//object result = ((ITimeEvent)baseObject).View; return (result != null) ? (IScriptableAbstractView)ScriptableObject.CreateWrapper(result) : null; }
			}

			public long detail
			{
        get { throw new NotImplementedException(); }//return ((ITimeEvent)baseObject).Detail;  }
			}

			#endregion
		}

}
  
