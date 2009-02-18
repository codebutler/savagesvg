using System;


namespace SharpVectors.Scripting
{

	/// <summary>
	/// IScriptableEventTarget
	/// </summary>
	public interface IScriptableEventTarget
	{
		void addEventListener(string type, object listener, bool useCapture);
		void removeEventListener(string type, object listener, bool useCapture);
		bool dispatchEvent(IScriptableEvent evt);
	}

	/// <summary>
	/// IScriptableEventListener
	/// </summary>
	public interface IScriptableEventListener
	{
		void handleEvent(IScriptableEvent evt);
	}

	/// <summary>
	/// IScriptableEvent
	/// </summary>
	public interface IScriptableEvent
	{
		void stopPropagation();
		void preventDefault();
		void initEvent(string eventTypeArg, bool canBubbleArg, bool cancelableArg);
		string type { get; }
		IScriptableEventTarget target { get; }
		IScriptableEventTarget currentTarget { get; }
		ushort eventPhase { get; }
		bool bubbles { get; }
		bool cancelable { get; }
		IScriptableDomTimeStamp timeStamp { get; }
	}

	/// <summary>
	/// IScriptableDocumentEvent
	/// </summary>
	public interface IScriptableDocumentEvent
	{
		IScriptableEvent createEvent(string eventType);
	}

	/// <summary>
	/// IScriptableUiEvent
	/// </summary>
	public interface IScriptableUiEvent : IScriptableEvent
	{
		void initUIEvent(string typeArg, bool canBubbleArg, bool cancelableArg, IScriptableAbstractView viewArg, long detailArg);
		IScriptableAbstractView view { get; }
		long detail { get; }
	}

	/// <summary>
	/// IScriptableMouseEvent
	/// </summary>
	public interface IScriptableMouseEvent : IScriptableUiEvent
	{
		void initMouseEvent(string typeArg, bool canBubbleArg, bool cancelableArg, IScriptableAbstractView viewArg, long detailArg, long screenXArg, long screenYArg, long clientXArg, long clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, ushort buttonArg, IScriptableEventTarget relatedTargetArg);
		long screenX { get; }
		long screenY { get; }
		long clientX { get; }
		long clientY { get; }
		bool ctrlKey { get; }
		bool shiftKey { get; }
		bool altKey { get; }
		bool metaKey { get; }
		ushort button { get; }
		IScriptableEventTarget relatedTarget { get; }
	}

	/// <summary>
	/// IScriptableMutationEvent
	/// </summary>
	public interface IScriptableMutationEvent : IScriptableEvent
	{
		void initMutationEvent(string typeArg, bool canBubbleArg, bool cancelableArg, IScriptableNode relatedNodeArg, string prevValueArg, string newValueArg, string attrNameArg, ushort attrChangeArg);
		IScriptableNode relatedNode { get; }
		string prevValue { get; }
		string newValue { get; }
		string attrName { get; }
		ushort attrChange { get; }
	}

}
  