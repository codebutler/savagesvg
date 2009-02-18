using System;

using SharpVectors.Dom.Events;


namespace SharpVectors.Dom.Events
{
	/// <summary>
	/// Summary description for EventListenerMapEntry.
	/// </summary>
	public struct EventListenerMapEntry
	{
		public string NamespaceUri;
		public string Type;
		public object Group;
		public EventListener Listener;
    public bool Locked;
		
		public EventListenerMapEntry(
			string namespaceUri,
			string type,
			object group,
			EventListener listener,
      bool locked)
		{
			NamespaceUri = namespaceUri;
			Type = type;
			Group = group;
			Listener = listener;
      Locked = locked;
		}
	}
}
