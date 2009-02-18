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
		/// Implementation wrapper for IScriptableEventTarget
		/// </summary>
		public class ScriptableEventTarget : ScriptableObject, IScriptableEventTarget
		{
			public ScriptableEventTarget(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

			public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableEventListener
		/// </summary>
		public class ScriptableEventListener : ScriptableObject, IScriptableEventListener
		{
			public ScriptableEventListener(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableEventListener
			public void handleEvent(IScriptableEvent evt)
			{
				throw new NotImplementedException(); //((IEventListener)baseObject).HandleEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableEvent
		/// </summary>
		public class ScriptableEvent : ScriptableObject, IScriptableEvent
		{
			const ushort CAPTURING_PHASE                = 1;
			const ushort AT_TARGET                      = 2;
			const ushort BUBBLING_PHASE                 = 3;

			public ScriptableEvent(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableEvent
			public void stopPropagation()
			{
				((IEvent)baseObject).StopPropagation();
			}

			public void preventDefault()
			{
				((IEvent)baseObject).PreventDefault();
			}

			public void initEvent(string eventTypeArg, bool canBubbleArg, bool cancelableArg)
			{
				((IEvent)baseObject).InitEvent(eventTypeArg, canBubbleArg, cancelableArg);
			}
			#endregion

			#region Properties - IScriptableEvent
			public string type
			{
				get { return ((IEvent)baseObject).Type;  }
			}

			public IScriptableEventTarget target
			{
				get { object result = ((IEvent)baseObject).Target; return (result != null) ? (IScriptableEventTarget)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableEventTarget currentTarget
			{
				get { object result = ((IEvent)baseObject).CurrentTarget; return (result != null) ? (IScriptableEventTarget)ScriptableObject.CreateWrapper(result) : null; }
			}

			public ushort eventPhase
			{
				get { return (ushort)((IEvent)baseObject).EventPhase;  }
			}

			public bool bubbles
			{
				get { return ((IEvent)baseObject).Bubbles;  }
			}

			public bool cancelable
			{
				get { return ((IEvent)baseObject).Cancelable;  }
			}

			public IScriptableDomTimeStamp timeStamp
			{
				get { object result = ((IEvent)baseObject).TimeStamp; return (result != null) ? (IScriptableDomTimeStamp)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableDocumentEvent
		/// </summary>
		public class ScriptableDocumentEvent : ScriptableObject, IScriptableDocumentEvent
		{
			public ScriptableDocumentEvent(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableDocumentEvent
			public IScriptableEvent createEvent(string eventType)
			{
				object result = ((IDocumentEvent)baseObject).CreateEvent(eventType);
				return (result != null) ? (IScriptableEvent)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableUiEvent
		/// </summary>
		public class ScriptableUiEvent : ScriptableEvent, IScriptableUiEvent
		{
			public ScriptableUiEvent(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableUiEvent
			public void initUIEvent(string typeArg, bool canBubbleArg, bool cancelableArg, IScriptableAbstractView viewArg, long detailArg)
			{
				((IUiEvent)baseObject).InitUiEvent(typeArg, canBubbleArg, cancelableArg, ((IAbstractView)((ScriptableAbstractView)viewArg).baseObject), detailArg);
			}
			#endregion

			#region Properties - IScriptableUiEvent
			public IScriptableAbstractView view
			{
				get { object result = ((IUiEvent)baseObject).View; return (result != null) ? (IScriptableAbstractView)ScriptableObject.CreateWrapper(result) : null; }
			}

			public long detail
			{
				get { return ((IUiEvent)baseObject).Detail;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableMouseEvent
		/// </summary>
		public class ScriptableMouseEvent : ScriptableUiEvent, IScriptableMouseEvent
		{
			public ScriptableMouseEvent(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableMouseEvent
			public void initMouseEvent(string typeArg, bool canBubbleArg, bool cancelableArg, IScriptableAbstractView viewArg, long detailArg, long screenXArg, long screenYArg, long clientXArg, long clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, ushort buttonArg, IScriptableEventTarget relatedTargetArg)
			{
				((IMouseEvent)baseObject).InitMouseEvent(typeArg, canBubbleArg, cancelableArg, ((IAbstractView)((ScriptableAbstractView)viewArg).baseObject), detailArg, screenXArg, screenYArg, clientXArg, clientYArg, ctrlKeyArg, altKeyArg, shiftKeyArg, metaKeyArg, buttonArg, ((IEventTarget)((ScriptableEventTarget)relatedTargetArg).baseObject));
			}
			#endregion

			#region Properties - IScriptableMouseEvent
			public long screenX
			{
				get { return ((IMouseEvent)baseObject).ScreenX;  }
			}

			public long screenY
			{
				get { return ((IMouseEvent)baseObject).ScreenY;  }
			}

			public long clientX
			{
				get { return ((IMouseEvent)baseObject).ClientX;  }
			}

			public long clientY
			{
				get { return ((IMouseEvent)baseObject).ClientY;  }
			}

			public bool ctrlKey
			{
				get { return ((IMouseEvent)baseObject).CtrlKey;  }
			}

			public bool shiftKey
			{
				get { return ((IMouseEvent)baseObject).ShiftKey;  }
			}

			public bool altKey
			{
				get { return ((IMouseEvent)baseObject).AltKey;  }
			}

			public bool metaKey
			{
				get { return ((IMouseEvent)baseObject).MetaKey;  }
			}

			public ushort button
			{
				get { return ((IMouseEvent)baseObject).Button;  }
			}

			public IScriptableEventTarget relatedTarget
			{
				get { object result = ((IMouseEvent)baseObject).RelatedTarget; return (result != null) ? (IScriptableEventTarget)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableMutationEvent
		/// </summary>
		public class ScriptableMutationEvent : ScriptableEvent, IScriptableMutationEvent
		{
			const ushort MODIFICATION                   = 1;
			const ushort ADDITION                       = 2;
			const ushort REMOVAL                        = 3;

			public ScriptableMutationEvent(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableMutationEvent
			public void initMutationEvent(string typeArg, bool canBubbleArg, bool cancelableArg, IScriptableNode relatedNodeArg, string prevValueArg, string newValueArg, string attrNameArg, ushort attrChangeArg)
			{
				((IMutationEvent)baseObject).InitMutationEvent(typeArg, canBubbleArg, cancelableArg, ((INode)((ScriptableNode)relatedNodeArg).baseObject), prevValueArg, newValueArg, attrNameArg, (AttrChangeType)attrChangeArg);
			}
			#endregion

			#region Properties - IScriptableMutationEvent
			public IScriptableNode relatedNode
			{
				get { object result = ((IMutationEvent)baseObject).RelatedNode; return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null; }
			}

			public string prevValue
			{
				get { return ((IMutationEvent)baseObject).PrevValue;  }
			}

			public string newValue
			{
				get { return ((IMutationEvent)baseObject).NewValue;  }
			}

			public string attrName
			{
				get { return ((IMutationEvent)baseObject).AttrName;  }
			}

			public ushort attrChange
			{
				get { return (ushort)((IMutationEvent)baseObject).AttrChange;  }
			}

			#endregion
		}

}
  
