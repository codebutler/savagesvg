using System;
using System.Xml;
using SharpVectors.Dom.Events;
using NUnit.Framework;
using SharpVectors.Dom;
		
		[TestFixture]
		public class ElementTests
		{
			Document doc;
			int increment;
			
			[SetUp]
			public void SetUp()
			{
				if (doc == null)
				{
					doc = new Document();
					doc.LoadXml("<?xml version='1.0'?><doc><e1><e1a/><e1b/></e1><e2><e2a/><e2b/></e2></doc>");
				}
			}
			
			public void OnMouseMove(
				IEvent @event)
			{
				increment++;
			}
			
			[Test]
			public void TestConstructor()
			{
				increment = 0;
				IEventTarget eventTarget = (IEventTarget)doc.DocumentElement;
				
				// Add first event listener
				eventTarget.AddEventListener("mousemove", new EventListener(OnMouseMove), false);
				eventTarget.DispatchEvent(new Event("uievent", "mousemove", true, false));
				Assert.AreEqual(1, increment);
				
				// Add second event listener
        // "If multiple identical EventListeners are registered on the same EventTarget with the same 
        //  parameters the duplicate instances are discarded. They do not cause the EventListener to 
        //  be called twice and since they are discarded they do not need to be removed with the removeEventListener method."
				eventTarget.AddEventListener("mousemove", new EventListener(OnMouseMove), false);
				eventTarget.DispatchEvent(new Event("uievent", "mousemove", true, false));
				Assert.AreEqual(2, increment);
				
				// Remove first event listener
				eventTarget.RemoveEventListener("mousemove", new EventListener(OnMouseMove), false);
				eventTarget.DispatchEvent(new Event("uievent", "mousemove", true, false));
				Assert.AreEqual(2, increment);
				
				// Remove second event listener
        // "Calling removeEventListener with arguments which do not identify any currently registered EventListener on the EventTarget has no effect."
				eventTarget.RemoveEventListener("mousemove", new EventListener(OnMouseMove), false);
				eventTarget.DispatchEvent(new Event("uievent", "mousemove", true, false));
				Assert.AreEqual(2, increment);
			}
		}
		
