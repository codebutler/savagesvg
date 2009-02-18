using System;
using System.Xml;

namespace SharpVectors.Dom
{
	public interface IDocument
		: INode
	{
		IDocumentType Doctype
		{
			get;
		}
		
		IDomImplementation Implementation
		{
			get;
		}
		
		IElement DocumentElement
		{
			get;
		}
		
		IElement CreateElement(
			string tagName);
		
		IDocumentFragment CreateDocumentFragment();
		
		IText CreateTextNode(
			string data);
		
		IComment CreateComment(
			string data);
		
		ICDataSection CreateCDataSection(
			string data);
		
		IProcessingInstruction CreateProcessingInstruction(
			string target,
			string data);
		
		IAttribute CreateAttribute(
			string name);
		
		IEntityReference CreateEntityReference(
			string name);
		
		INodeList GetElementsByTagName(
			string tagname);
		
		INode ImportNode(
			INode importedNode,
			bool deep);
		
		IElement CreateElementNs(
			string namespaceUri,
			string qualifiedName);
		
		IAttribute CreateAttributeNs(
			string namespaceUri,
			string qualifiedName);
		
		INodeList GetElementsByTagNameNs(
			string namespaceURI,
			string localName);
		
		IElement GetElementById(
			string elementId);
		
		[Obsolete("Introduced in DOM Level 3")]
		string ActualEncoding
		{
			get;
		}
		
		[Obsolete("Introduced in DOM Level 3")]
		string XmlEncoding
		{
			get;
			set;
		}
		
		[Obsolete("Introduced in DOM Level 3")]
		bool XmlStandalone
		{
			get;
			set;
		}
		
		[Obsolete("Introduced in DOM Level 3")]
		string XmlVersion
		{
			get;
			set;
		}
		
		[Obsolete("Introduced in DOM Level 3")]
		bool StrictErrorChecking
		{
			get;
			set;
		}
		
		[Obsolete("Introduced in DOM Level 3")]
		string DocumentUri
		{
			get;
			set;
		}
		
		[Obsolete("Introduced in DOM Level 3")]
		INode AdoptNode(
			INode source);
		
		[Obsolete("Introduced in DOM Level 3")]
		IDomConfiguration Config
		{
			get;
		}
		
		[Obsolete("Introduced in DOM Level 3")]
		void NormalizeDocument();
		
		[Obsolete("Introduced in DOM Level 3")]
		INode RenameNode(
			INode n,
			string namespaceUri,
			string qualifiedName);
	}
}
