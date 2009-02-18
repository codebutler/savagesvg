using System;
using SharpVectors.Dom.Stylesheets;
using SharpVectors.Dom.Svg.Rendering;
using System.Xml;

namespace SharpVectors.Dom.Svg
{
	public interface ISvgWindow
	{
		IStyleSheet DefaultStyleSheet{get;}
		ISvgDocument Document{get;}
		long InnerHeight{get;}
		long InnerWidth{get;}
		string Src{get;set;}
    XmlDocumentFragment ParseXML (string source, XmlDocument document);
		string PrintNode (XmlNode node);
    void Alert(string message);
    ISvgRenderer Renderer { get; }
    /*void GetURL (string uri, EventListener callback);	*/
    /*void PostURL (string uri, string data, EventListener callback, string mimeType, string contentEncoding);*/
  }
}
