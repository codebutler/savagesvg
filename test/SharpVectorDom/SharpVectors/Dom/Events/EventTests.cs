using System;
using System.Collections;
using System.IO;
using SharpVectors.Dom.Events;
using NUnit.Framework;
using SharpVectors.Dom;
    
		[TestFixture]
		public class EventTests
		{
      public class EventMonitor
      {
        public int AtEvents = 0;
        public int BubbledEvents = 0;
        public int CapturedEvents = 0;
        public int Events = 0;
				
        public void EventHandler(
          IEvent @event)
        {
          switch (@event.EventPhase)
          {
            case EventPhase.AtTarget:
              AtEvents++;
              break;
            case EventPhase.BubblingPhase:
              BubbledEvents++;
              break;
            case EventPhase.CapturingPhase:
              CapturedEvents++;
              break;
          }
					
          Events++;
        }
      }
      
			
			public class ListenerRemover
			{
				public ArrayList events;
				public ArrayList listeners;
				
				public ListenerRemover(
					ArrayList events,
					ArrayList listeners)
				{
					this.events = events;
					this.listeners = listeners;
				}
				
				public void EventHandler(
					IEvent @event)
				{
					IEventTarget target = @event.CurrentTarget;
					
					events.Add(@event);
					
					foreach (ListenerRemover listener in listeners)
					{
						target.RemoveEventListener("foo", new EventListener(listener.EventHandler), false);
					}
				}
			}
			
			public IDocument LoadDocument(
				string uri)
			{
				Document document = new Document();
				
				document.Load(new FileInfo(uri).FullName);
				
				return document;
			}
			
			[Test]
			public void TestConstructor()
			{
				Event e = new Event("mousemove", true, false);
				Assert.AreEqual(null, e.NamespaceUri);
				Assert.AreEqual("mousemove", e.Type);
				Assert.AreEqual(true, e.Bubbles);
				Assert.AreEqual(false, e.Cancelable);
				
				e = new Event("dummy", false, true);
				Assert.AreEqual(null, e.NamespaceUri);
				Assert.AreEqual("dummy", e.Type);
				Assert.AreEqual(false, e.Bubbles);
				Assert.AreEqual(true, e.Cancelable);
			}
			
			[Test]
			public void TestConstructorNs()
			{
				Event e = new Event("uievents", "mousemove", true, false);
				Assert.AreEqual("uievents", e.NamespaceUri);
				Assert.AreEqual("mousemove", e.Type);
				Assert.AreEqual(true, e.Bubbles);
				Assert.AreEqual(false, e.Cancelable);
				
				e = new Event("namespace", "dummy", false, true);
				Assert.AreEqual("namespace", e.NamespaceUri);
				Assert.AreEqual("dummy", e.Type);
				Assert.AreEqual(false, e.Bubbles);
				Assert.AreEqual(true, e.Cancelable);
			}
			
			[Test]
			public void TestConstructorEmptyType()
			{
				Event e = new Event("", true, false);
				
        Assert.AreEqual(null, e.NamespaceUri);
				Assert.AreEqual("", e.Type);
				Assert.AreEqual(true, e.Bubbles);
				Assert.AreEqual(false, e.Cancelable);
			}
			
			[Test]
			public void TestConstructorEmptyTypeNs()
			{
				Event e = new Event("namespaceUri", "", true, false);
				
				Assert.AreEqual("namespaceUri", e.NamespaceUri);
				Assert.AreEqual("", e.Type);
				Assert.AreEqual(true, e.Bubbles);
				Assert.AreEqual(false, e.Cancelable);
			}
			
			[Test]
			public void TestConstructorNullType()
			{
				Event e = new Event("namespaceUri", null, true, false);
				
				Assert.AreEqual("namespaceUri", e.NamespaceUri);
				Assert.AreEqual(null, e.Type);
				Assert.AreEqual(true, e.Bubbles);
				Assert.AreEqual(false, e.Cancelable);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="createEvent01">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-DocumentEvent-createEvent"/>
			/// An object implementing the Event interface is created by using 
			/// DocumentEvent.createEvent method with eventType equals "Events".
			/// </test>
			[Test]
			public void W3CTS_CreateEvent01()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("MutationEvents");
				Assert.IsNotNull(@event);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="createEvent02">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-DocumentEvent-createEvent"/>
			/// An object implementing the Event interface is created by using 
			/// DocumentEvent.createEvent method with eventType equals "MutationEvents".
			/// Only applicable if implementation supports MutationEvents.
			/// </test>
			[Test]
			public void W3CTS_CreateEvent02()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("Events");
				Assert.IsNotNull(@event);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="createEvent03">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-DocumentEvent-createEvent"/>
			/// An object implementing the Event interface is created by using 
			/// DocumentEvent.createEvent method with eventType equals "UIEvents".
			/// Only applicable if implementation supports the "UIEvents" feature.
			/// </test>
			[Test]
			public void W3CTS_CreateEvent03()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("UIEvent");        
				Assert.IsNotNull(@event);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="createEvent04">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-DocumentEvent-createEvent"/>
			/// An object implementing the Event interface is created by using 
			/// DocumentEvent.createEvent method with eventType equals "MouseEvent".
			/// Only applicable if implementation supports the "MouseEvent" feature.
			/// </test>
			[Test]
			public void W3CTS_CreateEvent04()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("MouseEvent");
				Assert.IsNotNull(@event);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="createEvent05">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-DocumentEvent-createEvent"/>
			/// An object implementing the Event interface is created by using 
			/// DocumentEvent.createEvent method with eventType equals "HTMLEvents".
			/// Only applicable if implementation supports the "HTMLEvents" feature.
			/// </test>
			[Test]
			public void W3CTS_CreateEvent05()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("HTMLEvents");
				Assert.IsNotNull(@event);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="DocumentEventCast01">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-DocumentEvent"/>
			/// A document is created using implementation.createDocument and 
			/// cast to a DocumentEvent interface.
			/// </test>
			[Test]
			public void W3CTS_DocumentEventCast01()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IDocumentEvent documentEvent = (IDocumentEvent)document;
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="EventTargetCast01">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-DocumentEvent"/>
			/// A document is created using implementation.createDocument and 
			/// cast to a EventTarget interface.
			/// </test>
			[Test]
			public void W3CTS_EventTargetCast01()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IDocumentEvent documentEvent = (IDocumentEvent)document;
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="dispatchEvent01">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-EventTarget-dispatchEvent"/>
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Core/core.html#ID-17189187"/>
			/// A null reference is passed to EventTarget.dispatchEvent().  Should raise implementation
			/// specific exception per file:///D:/apache-xml/2001/DOM-Test-Suite/lib/specs/Level-2/Core/core.html#ID-17189187
			/// </test>
			[Test]
			public void W3CTS_DispatchEvent01()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = null;
				
				try
				{
					((IEventTarget)document).DispatchEvent(@event);
				}
				catch (NullReferenceException)
				{
					return;
				}
				
				Assert.IsTrue(false);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="dispatchEvent02">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-EventTarget-dispatchEvent"/>
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#xpointer(id('Events-EventTarget-dispatchEvent')/raises/exception[@name='EventException']/descr/p[substring-before(.,':')='UNSPECIFIED_EVENT_TYPE_ERR'])"/>
			/// An created but not initialized event is passed to EventTarget.dispatchEvent().  Should raise 
			/// UNSPECIFIED_EVENT_TYPE_ERR EventException.
			/// </test>
			[Test]
			public void W3CTS_DispatchEvent02()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("Events");
				
				try
				{
					((IEventTarget)document).DispatchEvent(@event);
				}
				catch (EventException e)
				{
					Assert.IsTrue(e.Code == EventExceptionCode.UnspecifiedEventTypeErr);
					
					return;
				}
				
				Assert.IsTrue(false);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="dispatchEvent03">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-EventTarget-dispatchEvent"/>
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#xpointer(id('Events-EventTarget-dispatchEvent')/raises/exception[@name='EventException']/descr/p[substring-before(.,':')='UNSPECIFIED_EVENT_TYPE_ERR'])"/>
			/// An created but not initialized event is passed to EventTarget.dispatchEvent().  Should raise 
			/// UNSPECIFIED_EVENT_TYPE_ERR EventException.
			/// </test>
			[Test]
			public void W3CTS_DispatchEvent03()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("MutationEvents");
				
				try
				{
					((IEventTarget)document).DispatchEvent(@event);
				}
				catch (EventException e)
				{
					Assert.IsTrue(e.Code == EventExceptionCode.UnspecifiedEventTypeErr);
					
					return;
				}
				
				Assert.IsTrue(false);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="dispatchEvent04">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-EventTarget-dispatchEvent"/>
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#xpointer(id('Events-EventTarget-dispatchEvent')/raises/exception[@name='EventException']/descr/p[substring-before(.,':')='UNSPECIFIED_EVENT_TYPE_ERR'])"/>
			/// An created but not initialized event is passed to EventTarget.dispatchEvent().  Should raise 
			/// UNSPECIFIED_EVENT_TYPE_ERR EventException.
			/// </test>
			[Test]
			public void W3CTS_DispatchEvent04()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("UIEvents");
				
				try
				{
					((IEventTarget)document).DispatchEvent(@event);
				}
				catch (EventException e)
				{
					Assert.IsTrue(e.Code == EventExceptionCode.UnspecifiedEventTypeErr);
					
					return;
				}
				
				Assert.IsTrue(false);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="dispatchEvent05">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-EventTarget-dispatchEvent"/>
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#xpointer(id('Events-EventTarget-dispatchEvent')/raises/exception[@name='EventException']/descr/p[substring-before(.,':')='UNSPECIFIED_EVENT_TYPE_ERR'])"/>
			/// An created but not initialized event is passed to EventTarget.dispatchEvent().  Should raise 
			/// UNSPECIFIED_EVENT_TYPE_ERR EventException.
			/// </test>
			[Test]
			public void W3CTS_DispatchEvent05()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("MouseEvents");
				
				try
				{
					((IEventTarget)document).DispatchEvent(@event);
				}
				catch (EventException e)
				{
					Assert.IsTrue(e.Code == EventExceptionCode.UnspecifiedEventTypeErr);
					
					return;
				}
				
				Assert.IsTrue(false);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="dispatchEvent06">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-EventTarget-dispatchEvent"/>
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#xpointer(id('Events-EventTarget-dispatchEvent')/raises/exception[@name='EventException']/descr/p[substring-before(.,':')='UNSPECIFIED_EVENT_TYPE_ERR'])"/>
			/// An created but not initialized event is passed to EventTarget.dispatchEvent().  Should raise 
			/// UNSPECIFIED_EVENT_TYPE_ERR EventException.
			/// </test>
			[Test]
			public void W3CTS_DispatchEvent06()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("HTMLEvents");
				
				try
				{
					((IEventTarget)document).DispatchEvent(@event);
				}
				catch (EventException e)
				{
					Assert.IsTrue(e.Code == EventExceptionCode.UnspecifiedEventTypeErr);
					
					return;
				}
				
				Assert.IsTrue(false);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="dispatchEvent07">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-EventTarget-dispatchEvent"/>
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#xpointer(id('Events-EventTarget-dispatchEvent')/raises/exception[@name='EventException']/descr/p[substring-before(.,':')='UNSPECIFIED_EVENT_TYPE_ERR'])"/>
			/// An Event initialized with a empty name is passed to EventTarget.dispatchEvent().  Should raise 
			/// UNSPECIFIED_EVENT_TYPE_ERR EventException.
			/// </test>
			[Test]
			public void W3CTS_DispatchEvent07()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("Events");
				@event.InitEvent("", false, false);
				
				try
				{
					((IEventTarget)document).DispatchEvent(@event);
				}
				catch (EventException e)
				{
					Assert.IsTrue(e.Code == EventExceptionCode.UnspecifiedEventTypeErr);
					
					return;
				}
				
				Assert.IsTrue(false, "Didn't fail as expected");
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="dispatchEvent08">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-EventTarget-dispatchEvent"/>
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#xpointer(id('Events-EventTarget-dispatchEvent')/raises/exception[@name='EventException']/descr/p[substring-before(.,':')='UNSPECIFIED_EVENT_TYPE_ERR'])"/>
			/// An EventListener registered on the target node with capture false, should
			/// recieve any event fired on that node.
			/// </test>
			[Test]
			public void W3CTS_DispatchEvent08()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("Events");
				EventMonitor eventMonitor = new EventMonitor();
				@event.InitEvent("foo", true, false);
				
				((IEventTarget)document).AddEventListener("foo", new EventListener(eventMonitor.EventHandler), false);
        ((IEventTarget)document).DispatchEvent(@event);
				Assert.AreEqual(1, eventMonitor.AtEvents);
				Assert.AreEqual(0, eventMonitor.BubbledEvents);
				Assert.AreEqual(0, eventMonitor.CapturedEvents);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="dispatchEvent09">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-EventTarget-dispatchEvent"/>
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#xpointer(id('Events-EventTarget-dispatchEvent')/raises/exception[@name='EventException']/descr/p[substring-before(.,':')='UNSPECIFIED_EVENT_TYPE_ERR'])"/>
			/// An event is dispatched to the document with a capture listener attached.
			/// A capturing EventListener will not be triggered by events dispatched directly
			/// to the EventTarget upon which it is registered.
			/// </test>
			[Test]
			public void W3CTS_DispatchEvent09()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("Events");
				EventMonitor eventMonitor = new EventMonitor();
				@event.InitEvent("foo", true, false);
				
				((IEventTarget)document).AddEventListener("foo", new EventListener(eventMonitor.EventHandler), true);
				((IEventTarget)document).DispatchEvent(@event);
        Assert.AreEqual(eventMonitor.AtEvents, 0);
				Assert.AreEqual(eventMonitor.BubbledEvents, 0);
				Assert.AreEqual(eventMonitor.CapturedEvents, 0);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="dispatchEvent10">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-EventTarget-dispatchEvent"/>
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#xpointer(id('Events-EventTarget-dispatchEvent')/raises/exception[@name='EventException']/descr/p[substring-before(.,':')='UNSPECIFIED_EVENT_TYPE_ERR'])"/>
			/// The same monitor is registered twice and an event is dispatched.  The monitor should
			/// recieve only one handleEvent call.
			/// </test>
			[Test]
			public void W3CTS_DispatchEvent10()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("Events");
				EventMonitor eventMonitor = new EventMonitor();
				@event.InitEvent("foo", true, false);
				
				((IEventTarget)document).AddEventListener("foo", new EventListener(eventMonitor.EventHandler), false);
				((IEventTarget)document).AddEventListener("foo", new EventListener(eventMonitor.EventHandler), false);
				((IEventTarget)document).DispatchEvent(@event);
				Assert.AreEqual(eventMonitor.AtEvents, 1);
				Assert.AreEqual(eventMonitor.BubbledEvents, 0);
				Assert.AreEqual(eventMonitor.CapturedEvents, 0);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="dispatchEvent11">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-EventTarget-dispatchEvent"/>
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#xpointer(id('Events-EventTarget-dispatchEvent')/raises/exception[@name='EventException']/descr/p[substring-before(.,':')='UNSPECIFIED_EVENT_TYPE_ERR'])"/>
			/// The same monitor is registered twice, removed once, and an event is dispatched.
			/// The monitor should recieve only no handleEvent calls.
			/// </test>
			[Test]
			public void W3CTS_DispatchEvent11()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("Events");
				EventMonitor eventMonitor = new EventMonitor();
				@event.InitEvent("foo", true, false);
				
				((IEventTarget)document).AddEventListener("foo", new EventListener(eventMonitor.EventHandler), false);
				((IEventTarget)document).AddEventListener("foo", new EventListener(eventMonitor.EventHandler), false);
				((IEventTarget)document).RemoveEventListener("foo", new EventListener(eventMonitor.EventHandler), false);
				((IEventTarget)document).DispatchEvent(@event);
				Assert.AreEqual(eventMonitor.AtEvents, 0);
				Assert.AreEqual(eventMonitor.BubbledEvents, 0);
				Assert.AreEqual(eventMonitor.CapturedEvents, 0);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="dispatchEvent12">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-EventTarget-dispatchEvent"/>
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#xpointer(id('Events-EventTarget-dispatchEvent')/raises/exception[@name='EventException']/descr/p[substring-before(.,':')='UNSPECIFIED_EVENT_TYPE_ERR'])"/>
			/// A monitor is added, multiple calls to removeEventListener
			/// are mde with similar but not identical arguments, and an event is dispatched.
			/// The monitor should recieve handleEvent calls.
			/// </test>
			[Test]
			public void W3CTS_DispatchEvent12()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("Events");
				EventMonitor eventMonitor = new EventMonitor();
				EventMonitor otherMonitor = new EventMonitor();
				@event.InitEvent("foo", true, false);
				
				((IEventTarget)document).AddEventListener("foo", new EventListener(eventMonitor.EventHandler), false);
				((IEventTarget)document).RemoveEventListener("foo", new EventListener(eventMonitor.EventHandler), true);
				((IEventTarget)document).RemoveEventListener("food", new EventListener(eventMonitor.EventHandler), false);
				((IEventTarget)document).RemoveEventListener("foo", new EventListener(otherMonitor.EventHandler), true);
				((IEventTarget)document).DispatchEvent(@event);
				Assert.AreEqual(eventMonitor.Events, 1);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="dispatchEvent13">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-EventTarget-dispatchEvent"/>
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#xpointer(id('Events-EventTarget-dispatchEvent')/raises/exception[@name='EventException']/descr/p[substring-before(.,':')='UNSPECIFIED_EVENT_TYPE_ERR'])"/>
			/// Two listeners are registered on the same target, each of which will remove both itself and 
			/// the other on the first event.  Only one should see the event since event listeners
			/// can never be invoked after being removed.
			/// </test>
			[Test]
			public void W3CTS_DispatchEvent13()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("Events");
				EventMonitor eventMonitor = new EventMonitor();
				EventMonitor otherMonitor = new EventMonitor();
				@event.InitEvent("foo", true, false);
				ArrayList listeners = new ArrayList();
				ArrayList events = new ArrayList();
				
				ListenerRemover listenerRemover1 = new ListenerRemover(events, listeners);
				ListenerRemover listenerRemover2 = new ListenerRemover(events, listeners);
				
				listeners.Add(listenerRemover1);
				listeners.Add(listenerRemover2);
				
				((IEventTarget)document).AddEventListener("foo", new EventListener(listenerRemover1.EventHandler), false);
				((IEventTarget)document).AddEventListener("foo", new EventListener(listenerRemover2.EventHandler), false);
				((IEventTarget)document).DispatchEvent(@event);
				
				Assert.AreEqual(events.Count, 1);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="initEvent01">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-Event-initEvent"/>
			/// The Event.initEvent method is called for event returned by DocumentEvent.createEvent("events")
			/// and the state is checked to see if it reflects the parameters.
			/// </test>
			[Test]
			public void W3CTS_InitEvent01()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("Events");
				Assert.IsTrue(@event != null);
				@event.InitEvent("rotate", true, false);
				Assert.AreEqual("rotate", @event.Type);
				Assert.AreEqual(true, @event.Bubbles);
				Assert.AreEqual(false, @event.Cancelable);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="initEvent02">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-Event-initEvent"/>
			/// The IEvent.InitEvent method is called for event returned by IDocumentEvent.CreateEvent("events")
			/// and the state is checked to see if it reflects the parameters.
			/// </test>
			[Test]
			public void W3CTS_InitEvent02()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("Events");
				Assert.IsTrue(@event != null);
				@event.InitEvent("rotate", false, true);
				Assert.AreEqual(false, @event.Bubbles);
				Assert.AreEqual(true, @event.Cancelable);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="initEvent03">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-Event-initEvent"/>
			/// The IEvent.InitEvent method is called for event returned by IDocumentEvent.CreateEvent("events")
			/// and the state is checked to see if it reflects the parameters.  InitEvent may be 
			/// called multiple times and the last time is definitive.
			/// </test>
			[Test]
			public void W3CTS_InitEvent03()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("Events");
				Assert.IsTrue(@event != null);
				@event.InitEvent("rotate", true, true);
				Assert.AreEqual("rotate", @event.Type);
				Assert.AreEqual(true, @event.Bubbles);
				Assert.AreEqual(true, @event.Cancelable);
				@event.InitEvent("shear", false, false);
				Assert.AreEqual("shear", @event.Type);
				Assert.AreEqual(false, @event.Bubbles);
				Assert.AreEqual(false, @event.Cancelable);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="initEvent04">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-Event-initEvent"/>
			/// The IEvent.InitEvent method is called for event returned by 
			/// IDocumentEvent.CreateEvent("MutationEvents")
			/// and the state is checked to see if it reflects the parameters.
			/// </test>
			[Test]
			public void W3CTS_InitEvent04()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("MutationEvents");
				Assert.IsTrue(@event != null);
				@event.InitEvent("rotate", true, false);
				Assert.AreEqual("rotate", @event.Type);
				Assert.AreEqual(true, @event.Bubbles);
				Assert.AreEqual(false, @event.Cancelable);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="initEvent05">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-Event-initEvent"/>
			/// The IEvent.InitEvent method is called for event returned by 
			/// IDocumentEvent.CreateEvent("MutationEvents")
			/// and the state is checked to see if it reflects the parameters.
			/// </test>
			[Test]
			public void W3CTS_InitEvent05()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("MutationEvents");
				Assert.IsTrue(@event != null);
				@event.InitEvent("rotate", false, true);
				Assert.AreEqual("rotate", @event.Type);
				Assert.AreEqual(false, @event.Bubbles);
				Assert.AreEqual(true, @event.Cancelable);
			}
			
			/// <test xmlns="http://www.w3.org/2001/DOM-Test-Suite/Level-2" name="initEvent06">
			/// <subject resource="http://www.w3.org/TR/DOM-Level-2-Events/events#Events-Event-initEvent"/>
			/// The IEvent.InitEvent method is called for event returned by 
			/// IDocumentEvent.CreateEvent("MutationEvents")
			/// and the state is checked to see if it reflects the parameters.  InitEvent may be 
			/// called multiple times and the last time is definitive.
			/// </test>
			[Test]
			public void W3CTS_InitEvent06()
			{
				IDocument document = LoadDocument("hc_staff.xml");
				IEvent @event = ((IDocumentEvent)document).CreateEvent("MutationEvents");
				Assert.IsTrue(@event != null);
				@event.InitEvent("rotate", true, true);
				Assert.AreEqual("rotate", @event.Type);
				Assert.AreEqual(true, @event.Bubbles);
				Assert.AreEqual(true, @event.Cancelable);
				@event.InitEvent("shear", false, false);
				Assert.AreEqual("shear", @event.Type);
				Assert.AreEqual(false, @event.Bubbles);
				Assert.AreEqual(false, @event.Cancelable);
			}
		}
		
