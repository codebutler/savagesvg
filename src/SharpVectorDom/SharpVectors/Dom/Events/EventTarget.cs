using System;
using System.Collections;
using System.Xml;

using SharpVectors.Dom.Events;
using SharpVectors.Dom.Svg;


namespace SharpVectors.Dom.Events
{
	/// <summary>
	/// Summary description for EventTarget.
	/// </summary>
	public struct EventTarget
		: IEventTargetSupport
	{
		#region Private Fields
		
		private IEventTargetSupport eventTarget;
		
		private EventListenerMap captureMap;
		private EventListenerMap bubbleMap;
    private ArrayList ancestors;
		
		#endregion
		
		#region Constructors
		
		public EventTarget(
			IEventTargetSupport eventTarget)
		{
			this.eventTarget = eventTarget;
			captureMap = new EventListenerMap();
			bubbleMap = new EventListenerMap();
      ancestors = new ArrayList();
		}
		
		#endregion
		
		#region IEventTarget interface
		
		#region Methods
		
		#region DOM Level 2
		
		public void AddEventListener(
			string type,
			EventListener listener,
			bool useCapture)
		{
			if (useCapture)
			{
				captureMap.AddEventListener(null, type, null, listener);
			}
			else
			{
				bubbleMap.AddEventListener(null, type, null, listener);
			}
		}
		
		public void RemoveEventListener(
			string type,
			EventListener listener,
			bool useCapture)
		{
			if (useCapture)
			{
				captureMap.RemoveEventListener(null, type, listener);
			}
			else
			{
				bubbleMap.RemoveEventListener(null, type, listener);
			}
		}
		
		public bool DispatchEvent(
			IEvent @event)
		{
			if (@event.Type == null || @event.Type == "")
			{
				throw new EventException(EventExceptionCode.UnspecifiedEventTypeErr);
			}
			try
			{
        // The actual target may be an SvgElement or an SvgElementInstance from 
        // a conceptual tree <see href="http://www.w3.org/TR/SVG/struct.html#UseElement"/>
				XmlNode currNode = null;		
		    ISvgElementInstance currInstance = null;
        
        if (this.eventTarget is ISvgElementInstance)
          currInstance = (ISvgElementInstance)this.eventTarget;
        else
          currNode = (XmlNode)this.eventTarget;
        
        // We can't use an XPath ancestor axe because we must account for 
        // conceptual nodes
        ancestors.Clear();
        
        // Buid the ancestors from the conceptual tree
        if (currInstance != null) 
        {
          while (currInstance.ParentNode != null) 
          {
            currInstance = currInstance.ParentNode;
            ancestors.Add(currInstance);
          }
          currNode = (XmlNode)currInstance.CorrespondingUseElement;
          ancestors.Add(currNode);
        } 
          
        // Build actual ancestors
        while (currNode != null && currNode.ParentNode != null) 
        {
          currNode = currNode.ParentNode;
          ancestors.Add(currNode);
        }
        

        Event realEvent = (Event)@event;        
        realEvent.eventTarget = this.eventTarget;
				
				if (!realEvent.stopped)
				{
					realEvent.eventPhase = EventPhase.CapturingPhase;

					for (int i = ancestors.Count-1; i >= 0; i--)
					{
						if (realEvent.stopped)
						{
							break;
						}
						
						IEventTarget ancestor = ancestors[i] as IEventTarget;
						
						if (ancestor != null)
						{
							realEvent.currentTarget = ancestor;
							
							if (ancestor is IEventTargetSupport)
							{
								((IEventTargetSupport)ancestor).FireEvent(realEvent);
							}
						}
					}
				}
				
        if (!realEvent.stopped)
				{
          realEvent.eventPhase = EventPhase.AtTarget;
					realEvent.currentTarget = this.eventTarget;
					this.eventTarget.FireEvent(realEvent);
				}
        
				if (!realEvent.stopped)
				{
					realEvent.eventPhase = EventPhase.BubblingPhase;
					
					for (int i = 0; i < ancestors.Count; i++)
					{
						if (realEvent.stopped)
						{
							break;
						}
						
						IEventTarget ancestor = ancestors[i] as IEventTarget;
						
						if (ancestor != null)
						{
							realEvent.currentTarget = ancestor;
							((IEventTargetSupport)ancestor).FireEvent(realEvent);
						}
					}
				}
				
				return realEvent.stopped;
			}
			catch (InvalidCastException)
			{
				throw new DomException(DomExceptionType.WrongDocumentErr);
			}
		}
		
		#endregion
		
		#region DOM Level 3 Experimental
		
		public void AddEventListenerNs(
			string namespaceUri,
			string type,
			EventListener listener,
			bool useCapture,
			object evtGroup)
		{
			if (useCapture)
			{
				captureMap.AddEventListener(namespaceUri, type, evtGroup, listener);
			}
			else
			{
				bubbleMap.AddEventListener(namespaceUri, type, evtGroup, listener);
			}
		}
		
		public void RemoveEventListenerNs(
			string namespaceUri,
			string type,
			EventListener listener,
			bool useCapture)
		{
			if (useCapture)
			{
				captureMap.RemoveEventListener(namespaceUri, type, listener);
			}
			else
			{
				bubbleMap.RemoveEventListener(namespaceUri, type, listener);
			}
		}
		
		public bool WillTriggerNs(
			string namespaceUri,
			string type)
		{
			XmlNode node = (XmlNode)this.eventTarget;
			XmlNodeList ancestors = node.SelectNodes("ancestor::node()");
			
			for (int i = 0; i < ancestors.Count; i++)
			{
				IEventTarget ancestor = ancestors[i] as IEventTarget;
				
				if (ancestor.HasEventListenerNs(namespaceUri, type))
				{
					return true;
				}
			}
			
			return false;
		}
		
		public bool HasEventListenerNs(
			string namespaceUri,
			string eventType)
		{
			return captureMap.HasEventListenerNs(namespaceUri, eventType) ||
				bubbleMap.HasEventListenerNs(namespaceUri, eventType);
		}
		
		#endregion
		
		#endregion
		
		#region NON-DOM
		
		public void FireEvent(
			IEvent @event)
		{
			switch (@event.EventPhase)
			{
				case EventPhase.AtTarget:
				case EventPhase.BubblingPhase:
          bubbleMap.Lock();
					bubbleMap.FireEvent(@event);
					bubbleMap.Unlock();
					break;
				case EventPhase.CapturingPhase:
          captureMap.Lock();
					captureMap.FireEvent(@event);
					captureMap.Unlock();
					break;
			}
		}
		
		public event EventListener OnMouseMove
		{
			add
			{
				throw new NotImplementedException();
			}
			remove
			{
				throw new NotImplementedException();
			}
		}
		
		#endregion
		
		#endregion
	}
}
