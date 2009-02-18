using System;


namespace SharpVectors.Scripting
{

	/// <summary>
	/// IScriptableAbstractView
	/// </summary>
	public interface IScriptableAbstractView
	{
		IScriptableDocumentView document { get; }
	}

	/// <summary>
	/// IScriptableDocumentView
	/// </summary>
	public interface IScriptableDocumentView
	{
		IScriptableAbstractView defaultView { get; }
	}

}
  