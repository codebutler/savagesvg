using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Reflection;
using System.Xml;
using SharpVectors.Collections;
using SharpVectors.Dom;
using SharpVectors.Dom.Css;
using SharpVectors.Dom.Events;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Svg.Rendering;
using SharpVectors.Xml;
using NUnit.Framework;

    [TestFixture]
    public class GdiRenderer_Tests
    {
    /*
        public class SvgControl
                    : Control
        {
            private static readonly string UserAgentCssFileName = "useragent.css";
            private static readonly string UserCssFileName = "user.css";

            public readonly SvgWindow Window;
            public readonly GdiRenderer Renderer;

            public SvgControl()
            {
                Width = 100;
                Height = 100;
                Renderer = new GdiRenderer();
                Window = new SvgWindow(this, Renderer);
            }

            public void Render()
            {
                if (Window != null)
                {
                    Renderer.Render(Window.Document as SvgDocument);
                }
            }

            /// <summary>
            /// Loads the default user and agent stylesheets into the current SvgDocument
            /// </summary>
            protected virtual void SetupStyleSheets()
            {
                CssXmlDocument cssDocument = (CssXmlDocument)Window.Document;
                string appRootPath = SharpVectors.ApplicationContext.ExecutableDirectory.FullName;
                Uri userAgentCssPath = new Uri(appRootPath + "\\" + UserAgentCssFileName);
                Uri userCssPath = new Uri(appRootPath + "\\" + UserCssFileName);

                if (System.IO.File.Exists(userAgentCssPath.AbsolutePath))
                {
                    cssDocument.SetUserAgentStyleSheet(userAgentCssPath.AbsoluteUri);
                }

                if (System.IO.File.Exists(userCssPath.AbsolutePath))
                {
                    cssDocument.SetUserStyleSheet(userCssPath.AbsoluteUri);
                }
            }

            public string Src
            {
                get
                {
                    return Window.Src;
                }
                set
                {
                    if (value != null && value.Length > 0)
                    {
                        Window.Src = value;
                        SetupStyleSheets();

                        Render();
                    }
                }
            }
        }

			#region Mouse Event tests

        public class DispatchMouseEvents_SvgControl
                    : SvgControl
        {
            public int EventCount = 0;

            // click handler for 'startButton' rect element.
            public void EventListener(
                IEvent @event)
            {
                EventCount++;

                IEventTarget startButton = (IEventTarget)
                                           ((XmlDocument)Window.Document).GetElementById("startButton");

                startButton.RemoveEventListener("click", new EventListener(EventListener), false);
            }
        }
*/
        [Test]
        public void DispatchMouseEvents_1()
        {/*
            DispatchMouseEvents_SvgControl svgControl = new DispatchMouseEvents_SvgControl();
            string unitTestDir = System.IO.Directory.GetCurrentDirectory() + "\\" + "interactive_test_01.svg";
            svgControl.Src = unitTestDir;

            // Get start rect and add a UI listener
            IEventTarget startButton = (IEventTarget)
                                       svgControl.Window.Document.GetElementById("startButton");
            IEventTarget buttonRect = (IEventTarget)
                                      svgControl.Window.Document.GetElementById("buttonRect");

            startButton.AddEventListener("mousedown", new EventListener(svgControl.EventListener), false);

            Assert.AreEqual(0, svgControl.EventCount);

            svgControl.Renderer.OnMouseEvent("mousedown",
                                             new MouseEventArgs(MouseButtons.Left, 1, 20, 20, 0));

            Assert.AreEqual(1, svgControl.EventCount);

            svgControl.Renderer.OnMouseEvent("mousedown",
                                             new MouseEventArgs(MouseButtons.Left, 1, 5, 5, 0));

            Assert.AreEqual(1, svgControl.EventCount);*/
            throw new NotImplementedException();
        }

    }

