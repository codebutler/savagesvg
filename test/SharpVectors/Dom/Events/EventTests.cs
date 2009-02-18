using System;
using NUnit.Framework;
using SharpVectors.Dom.Events;
using SharpVectors.Dom.Svg;

namespace SharpVectors.UnitTests.Events
{
	[TestFixture]
	public class EventTests
	{
		SvgDocument doc;
		SvgRectElement rect;
		SvgGElement g;
		int eventStatus = 0;

		[SetUp]
		public void SetUp()
		{
			if(doc == null)
			{
				SvgWindow wnd = new SvgWindow(100, 100, null);
				doc = new SvgDocument(wnd);
				doc.Load("events_01.svg");
				rect = (SvgRectElement)doc.SelectSingleNode("//*[local-name()='rect']");
				g = (SvgGElement)doc.SelectSingleNode("//*[local-name()='g']");
			}
			eventStatus = 0;
		}

		[Test]
		public void EventTarget()
		{
      IEventTarget targ = rect as IEventTarget;
			Assert.IsNotNull(targ);
		}

		[Test]
		public void TestConstructor()
		{
			Event e = new Event("mousemove", true, false);
			Assert.AreEqual("mousemove", e.Type);
			Assert.AreEqual(true, e.Bubbles);
			Assert.AreEqual(false, e.Cancelable);

			e = new Event("dummy", false, true);
			Assert.AreEqual("dummy", e.Type);
			Assert.AreEqual(false, e.Bubbles);
			Assert.AreEqual(true, e.Cancelable);
		}

		[Test]
		public void TestConstructorEmptyType()
		{
			Event e = new Event("", true, false);
		}
		
		[Test]
		public void TestConstructorNullType()
		{
			Event e = new Event(null, true, false);
		}

		private void PropagateHandlerAtTarget(IEvent e)
		{
			Assert.AreSame(rect, e.CurrentTarget);
			Assert.AreEqual(rect, e.Target);
			Assert.AreEqual(EventPhase.AtTarget, e.EventPhase);
			eventStatus = 1;
		}

		private void PropagateHandlerAtG(IEvent e)
		{
			Assert.AreSame(g, e.CurrentTarget);
			Assert.AreEqual(rect, e.Target);
			if(e.EventPhase == EventPhase.CapturingPhase || 
				(e.EventPhase == EventPhase.BubblingPhase && eventStatus == 1))
			{
			}
			else
			{
				Assert.Fail();
			}
			eventStatus = 2;
		}

		[Test]
		public void TestPropagate1()
		{
			((IEventTarget)rect).AddEventListener("mousemove", new EventListener(PropagateHandlerAtTarget), false);
			((IEventTarget)rect).DispatchEvent(new Event("mousemove", true, true));
			Assert.AreEqual(1, eventStatus);
			((IEventTarget)rect).RemoveEventListener("mousemove", new EventListener(PropagateHandlerAtTarget), false);
		}

		[Test]
		public void TestPropagate2()
		{
			((IEventTarget)g).AddEventListener("mousemove", new EventListener(PropagateHandlerAtG), false);
			((IEventTarget)rect).AddEventListener("mousemove", new EventListener(PropagateHandlerAtTarget), false);
			((IEventTarget)rect).DispatchEvent(new Event("mousemove", true, true));
			Assert.AreEqual(2, eventStatus);
			((IEventTarget)rect).RemoveEventListener("mousemove", new EventListener(PropagateHandlerAtTarget), false);
			((IEventTarget)g).RemoveEventListener("mousemove", new EventListener(PropagateHandlerAtG), false);
		}

		[Test]
		public void TestMouseMove()
		{
			((IEventTarget)rect).AddEventListener("mousemove", new EventListener(PropagateHandlerAtTarget), false);
			((IEventTarget)rect).DispatchEvent(new Event("mousemove", true, true));
			Assert.AreEqual(1, eventStatus);
			((IEventTarget)rect).RemoveEventListener("mousemove", new EventListener(PropagateHandlerAtTarget), false);
		}

		[Test]
		public void TestMouseDown()
		{
			((IEventTarget)rect).AddEventListener("mousedown", new EventListener(PropagateHandlerAtTarget), false);
			((IEventTarget)rect).DispatchEvent(new Event("mousedown", true, true));
			Assert.AreEqual(1, eventStatus);
			((IEventTarget)rect).AddEventListener("mousedown", new EventListener(PropagateHandlerAtTarget), false);
		}

		[Test]
		public void TestMouseUp()
		{
			((IEventTarget)rect).AddEventListener("mouseup", new EventListener(PropagateHandlerAtTarget), false);
			((IEventTarget)rect).DispatchEvent(new Event("mouseup", true, true));
			Assert.AreEqual(1, eventStatus);
			((IEventTarget)rect).RemoveEventListener("mouseup", new EventListener(PropagateHandlerAtTarget), false);
		}
		
		[Test]
		public void TestMouseOver()
		{
			((IEventTarget)rect).AddEventListener("mouseover", new EventListener(PropagateHandlerAtTarget), false);
			((IEventTarget)rect).DispatchEvent(new Event("mouseover", true, true));
			Assert.AreEqual(1, eventStatus);
			((IEventTarget)rect).RemoveEventListener("mouseover", new EventListener(PropagateHandlerAtTarget), false);
		}

		[Test]
		public void TestMouseOut()
		{
			((IEventTarget)rect).AddEventListener("mouseout", new EventListener(PropagateHandlerAtTarget), false);
			((IEventTarget)rect).DispatchEvent(new Event("mouseout", true, true));
			Assert.AreEqual(1, eventStatus);
			((IEventTarget)rect).RemoveEventListener("mouseout", new EventListener(PropagateHandlerAtTarget), false);
		}
	}
}
