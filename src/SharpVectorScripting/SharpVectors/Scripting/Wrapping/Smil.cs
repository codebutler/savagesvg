using System;


namespace SharpVectors.Scripting
{

	/// <summary>
	/// IScriptableElementTimeControl
	/// </summary>
	public interface IScriptableElementTimeControl
	{
		void beginElement();
		void beginElementAt(float offset);
		void endElement();
		void endElementAt(float offset);
	}

	/// <summary>
	/// IScriptableTimeEvent
	/// </summary>
	public interface IScriptableTimeEvent : IScriptableEvent
	{
		void initTimeEvent(string typeArg, IScriptableAbstractView viewArg, long detailArg);
		IScriptableAbstractView view { get; }
		long detail { get; }
	}

}
  