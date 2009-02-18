using System;


namespace SharpVectors.Scripting
{  
  /// <summary>
	/// IScriptableSvgWindow
	/// </summary>
	public interface IScriptableSvgWindow
	{
		string setTimeout(object scriptOrClosure, ulong delay);
		void clearTimeout(string token);
		string setInterval(object scriptOrClosure, ulong delay);
		void clearInterval(string token);
		void alert(string message);
		void setSrc(string newURL);
		string getSrc();
		string printNode(IScriptableNode node);
		IScriptableNode parseXML(string xml, IScriptableDocument owner);
		IScriptableSvgDocument document { get; }
		IScriptableSvgDocument svgDocument { get; }
    IScriptableStyleSheet defaultStyleSheet{get;}
    long innerWidth { get; }
		long innerHeight { get; }
    void registerEval(object closure);   
  }

}
  