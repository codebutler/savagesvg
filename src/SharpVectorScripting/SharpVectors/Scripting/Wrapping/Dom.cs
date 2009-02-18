using System;


namespace SharpVectors.Scripting
{

	/// 
	/// IScriptableDomTimeStamp
	/// 
	public interface IScriptableDomTimeStamp
	{
	}

	/// <summary>
	/// IScriptableDomImplementation
	/// </summary>
	public interface IScriptableDomImplementation
	{
		bool hasFeature(string feature, string version);
		IScriptableDocumentType createDocumentType(string qualifiedName, string publicId, string systemId);
		IScriptableDocument createDocument(string namespaceURI, string qualifiedName, IScriptableDocumentType doctype);
	}

	/// <summary>
	/// IScriptableNode
	/// </summary>
	public interface IScriptableNode
	{
		IScriptableNode insertBefore(IScriptableNode newChild, IScriptableNode refChild);
		IScriptableNode replaceChild(IScriptableNode newChild, IScriptableNode oldChild);
		IScriptableNode removeChild(IScriptableNode oldChild);
		IScriptableNode appendChild(IScriptableNode newChild);
		bool hasChildNodes();
		IScriptableNode cloneNode(bool deep);
		void normalize();
		bool isSupported(string feature, string version);
		bool hasAttributes();
		string nodeName { get; }
		string nodeValue { get; set; }
		ushort nodeType { get; }
		IScriptableNode parentNode { get; }
		IScriptableNodeList childNodes { get; }
		IScriptableNode firstChild { get; }
		IScriptableNode lastChild { get; }
		IScriptableNode previousSibling { get; }
		IScriptableNode nextSibling { get; }
		IScriptableNamedNodeMap attributes { get; }
		IScriptableDocument ownerDocument { get; }
		string namespaceURI { get; }
		string prefix { get; set; }
		string localName { get; }
	}

	/// <summary>
	/// IScriptableNodeList
	/// </summary>
	public interface IScriptableNodeList
	{
		IScriptableNode item(ulong index);
		ulong length { get; }
	}

	/// <summary>
	/// IScriptableNamedNodeMap
	/// </summary>
	public interface IScriptableNamedNodeMap
	{
		IScriptableNode getNamedItem(string name);
		IScriptableNode setNamedItem(IScriptableNode arg);
		IScriptableNode removeNamedItem(string name);
		IScriptableNode item(ulong index);
		IScriptableNode getNamedItemNS(string namespaceURI, string localName);
		IScriptableNode setNamedItemNS(IScriptableNode arg);
		IScriptableNode removeNamedItemNS(string namespaceURI, string localName);
		ulong length { get; }
	}

	/// <summary>
	/// IScriptableCharacterData
	/// </summary>
	public interface IScriptableCharacterData : IScriptableNode
	{
		string substringData(ulong offset, ulong count);
		void appendData(string arg);
		void insertData(ulong offset, string arg);
		void deleteData(ulong offset, ulong count);
		void replaceData(ulong offset, ulong count, string arg);
		string data { get; set; }
		ulong length { get; }
	}

	/// <summary>
	/// IScriptableAttr
	/// </summary>
	public interface IScriptableAttr : IScriptableNode
	{
		string name { get; }
		bool specified { get; }
		string value { get; set; }
		IScriptableElement ownerElement { get; }
	}

	/// <summary>
	/// IScriptableElement
	/// </summary>
	public interface IScriptableElement : IScriptableNode
	{
		string getAttribute(string name);
		void setAttribute(string name, string value);
		void removeAttribute(string name);
		IScriptableAttr getAttributeNode(string name);
		IScriptableAttr setAttributeNode(IScriptableAttr newAttr);
		IScriptableAttr removeAttributeNode(IScriptableAttr oldAttr);
		IScriptableNodeList getElementsByTagName(string name);
		string getAttributeNS(string namespaceURI, string localName);
		void setAttributeNS(string namespaceURI, string qualifiedName, string value);
		void removeAttributeNS(string namespaceURI, string localName);
		IScriptableAttr getAttributeNodeNS(string namespaceURI, string localName);
		IScriptableAttr setAttributeNodeNS(IScriptableAttr newAttr);
		IScriptableNodeList getElementsByTagNameNS(string namespaceURI, string localName);
		bool hasAttribute(string name);
		bool hasAttributeNS(string namespaceURI, string localName);
		string tagName { get; }
	}

	/// <summary>
	/// IScriptableText
	/// </summary>
	public interface IScriptableText : IScriptableCharacterData
	{
		IScriptableText splitText(ulong offset);
	}

	/// <summary>
	/// IScriptableComment
	/// </summary>
	public interface IScriptableComment : IScriptableCharacterData
	{
	}

	/// <summary>
	/// IScriptableCDataSection
	/// </summary>
	public interface IScriptableCDataSection : IScriptableText
	{
	}

	/// <summary>
	/// IScriptableDocumentType
	/// </summary>
	public interface IScriptableDocumentType : IScriptableNode
	{
		string name { get; }
		IScriptableNamedNodeMap entities { get; }
		IScriptableNamedNodeMap notations { get; }
		string publicId { get; }
		string systemId { get; }
		string internalSubset { get; }
	}

	/// <summary>
	/// IScriptableNotation
	/// </summary>
	public interface IScriptableNotation : IScriptableNode
	{
		string publicId { get; }
		string systemId { get; }
	}

	/// <summary>
	/// IScriptableEntity
	/// </summary>
	public interface IScriptableEntity : IScriptableNode
	{
		string publicId { get; }
		string systemId { get; }
		string notationName { get; }
	}

	/// <summary>
	/// IScriptableEntityReference
	/// </summary>
	public interface IScriptableEntityReference : IScriptableNode
	{
	}

	/// <summary>
	/// IScriptableProcessingInstruction
	/// </summary>
	public interface IScriptableProcessingInstruction : IScriptableNode
	{
		string target { get; }
		string data { get; set; }
	}

	/// <summary>
	/// IScriptableDocumentFragment
	/// </summary>
	public interface IScriptableDocumentFragment : IScriptableNode
	{
	}

	/// <summary>
	/// IScriptableDocument
	/// </summary>
	public interface IScriptableDocument : IScriptableNode
	{
		IScriptableElement createElement(string tagName);
		IScriptableDocumentFragment createDocumentFragment();
		IScriptableText createTextNode(string data);
		IScriptableComment createComment(string data);
		IScriptableCDataSection createCDATASection(string data);
		IScriptableProcessingInstruction createProcessingInstruction(string target, string data);
		IScriptableAttr createAttribute(string name);
		IScriptableEntityReference createEntityReference(string name);
		IScriptableNodeList getElementsByTagName(string tagname);
		IScriptableNode importNode(IScriptableNode importedNode, bool deep);
		IScriptableElement createElementNS(string namespaceURI, string qualifiedName);
		IScriptableAttr createAttributeNS(string namespaceURI, string qualifiedName);
		IScriptableNodeList getElementsByTagNameNS(string namespaceURI, string localName);
		IScriptableElement getElementById(string elementId);
		IScriptableDocumentType doctype { get; }
		IScriptableDomImplementation implementation { get; }
		IScriptableElement documentElement { get; }
	}

}
  