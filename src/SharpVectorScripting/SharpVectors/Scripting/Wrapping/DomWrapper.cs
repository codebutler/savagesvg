using System;
using SharpVectors.Dom;
using SharpVectors.Dom.Css;
using SharpVectors.Dom.Events;
using SharpVectors.Dom.Stylesheets;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Views;
using System.Xml;


namespace SharpVectors.Scripting
{

  /// 
  /// IScriptableDomTimeStamp
  /// 
  public class ScriptableDomTimeStamp : ScriptableObject, IScriptableDomTimeStamp
  {
    public ScriptableDomTimeStamp(object baseObject) : base (baseObject) { }
  }


		/// <summary>
		/// Implementation wrapper for IScriptableDomImplementation
		/// </summary>
		public class ScriptableDomImplementation : ScriptableObject, IScriptableDomImplementation
		{
			public ScriptableDomImplementation(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableDomImplementation
			public bool hasFeature(string feature, string version)
			{
				return ((XmlImplementation)baseObject).HasFeature(feature, version);
			}

			public IScriptableDocumentType createDocumentType(string qualifiedName, string publicId, string systemId)
			{
				throw new NotSupportedException();
        //object result = ((XmlImplementation)baseObject).CreateDocumentType(qualifiedName, publicId, systemId);
				//return (result != null) ? (IScriptableDocumentType)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableDocument createDocument(string namespaceURI, string qualifiedName, IScriptableDocumentType doctype)
			{
        throw new NotSupportedException();
        //object result = ((XmlImplementation)baseObject).CreateDocument(namespaceURI, qualifiedName, ((IDocumentType)((ScriptableDocumentType)doctype).baseObject));
				//return (result != null) ? (IScriptableDocument)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableNode
		/// </summary>
		public class ScriptableNode : ScriptableObject, IScriptableNode
		{
			const ushort ELEMENT_NODE                   = 1;
			const ushort ATTRIBUTE_NODE                 = 2;
			const ushort TEXT_NODE                      = 3;
			const ushort CDATA_SECTION_NODE             = 4;
			const ushort ENTITY_REFERENCE_NODE          = 5;
			const ushort ENTITY_NODE                    = 6;
			const ushort PROCESSING_INSTRUCTION_NODE    = 7;
			const ushort COMMENT_NODE                   = 8;
			const ushort DOCUMENT_NODE                  = 9;
			const ushort DOCUMENT_TYPE_NODE             = 10;
			const ushort DOCUMENT_FRAGMENT_NODE         = 11;
			const ushort NOTATION_NODE                  = 12;

			public ScriptableNode(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableNode
			public IScriptableNode insertBefore(IScriptableNode newChild, IScriptableNode refChild)
			{
				object result = ((INode)baseObject).InsertBefore(((XmlNode)((ScriptableNode)newChild).baseObject), ((XmlNode)((ScriptableNode)refChild).baseObject));
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNode replaceChild(IScriptableNode newChild, IScriptableNode oldChild)
			{
				object result = ((INode)baseObject).ReplaceChild(((XmlNode)((ScriptableNode)newChild).baseObject), ((XmlNode)((ScriptableNode)oldChild).baseObject));
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNode removeChild(IScriptableNode oldChild)
			{
				object result = ((INode)baseObject).RemoveChild(((XmlNode)((ScriptableNode)oldChild).baseObject));
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNode appendChild(IScriptableNode newChild)
			{
				object result = ((INode)baseObject).AppendChild(((XmlNode)((ScriptableNode)newChild).baseObject));
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}

			public bool hasChildNodes()
			{
				return ((INode)baseObject).HasChildNodes;
			}

			public IScriptableNode cloneNode(bool deep)
			{
				object result = ((INode)baseObject).CloneNode(deep);
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}

			public void normalize()
			{
				((INode)baseObject).Normalize();
			}

			public bool isSupported(string feature, string version)
			{
				return ((INode)baseObject).Supports(feature, version);
			}

			public bool hasAttributes()
			{
				return ((INode)baseObject).Attributes.Count > 0;
			}
			#endregion

			#region Properties - IScriptableNode
			public string nodeName
			{
				get { return ((INode)baseObject).Name;  }
			}

			public string nodeValue
			{
				get { return ((INode)baseObject).Value;  }
				set { ((INode)baseObject).Value = value; }
			}

			public ushort nodeType
			{
				get { return (ushort)((INode)baseObject).NodeType;  }
			}

			public IScriptableNode parentNode
			{
				get { object result = ((INode)baseObject).ParentNode; return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableNodeList childNodes
			{
				get { object result = ((INode)baseObject).ChildNodes; return (result != null) ? (IScriptableNodeList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableNode firstChild
			{
				get { object result = ((INode)baseObject).FirstChild; return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableNode lastChild
			{
				get { object result = ((INode)baseObject).LastChild; return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableNode previousSibling
			{
				get { object result = ((INode)baseObject).PreviousSibling; return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableNode nextSibling
			{
				get { object result = ((INode)baseObject).NextSibling; return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableNamedNodeMap attributes
			{
				get { object result = ((INode)baseObject).Attributes; return (result != null) ? (IScriptableNamedNodeMap)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableDocument ownerDocument
			{
				get { object result = ((INode)baseObject).OwnerDocument; return (result != null) ? (IScriptableDocument)ScriptableObject.CreateWrapper(result) : null; }
			}

			public string namespaceURI
			{
				get { return ((INode)baseObject).NamespaceURI;  }
			}

			public string prefix
			{
				get { return ((INode)baseObject).Prefix;  }
				set { ((INode)baseObject).Prefix = value; }
			}

			public string localName
			{
				get { return ((INode)baseObject).LocalName;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableNodeList
		/// </summary>
		public class ScriptableNodeList : ScriptableObject, IScriptableNodeList
		{
			public ScriptableNodeList(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableNodeList
			public IScriptableNode item(ulong index)
			{
				object result = ((INodeList)baseObject)[index];
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableNodeList
			public ulong length
			{
				get { return ((INodeList)baseObject).Count;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableNamedNodeMap
		/// </summary>
		public class ScriptableNamedNodeMap : ScriptableObject, IScriptableNamedNodeMap
		{
			public ScriptableNamedNodeMap(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableNamedNodeMap
			public IScriptableNode getNamedItem(string name)
			{
				object result = ((XmlNamedNodeMap)baseObject).GetNamedItem(name);
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNode setNamedItem(IScriptableNode arg)
			{
				object result = ((XmlNamedNodeMap)baseObject).SetNamedItem(((XmlNode)((ScriptableNode)arg).baseObject));
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNode removeNamedItem(string name)
			{
				object result = ((XmlNamedNodeMap)baseObject).RemoveNamedItem(name);
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNode item(ulong index)
			{
				object result = ((XmlNamedNodeMap)baseObject).Item((int)index);
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNode getNamedItemNS(string namespaceURI, string localName)
			{
				object result = ((XmlNamedNodeMap)baseObject).GetNamedItem(localName, namespaceURI == null ? "" : namespaceURI);
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNode setNamedItemNS(IScriptableNode arg)
			{
				object result = ((XmlNamedNodeMap)baseObject).SetNamedItem(((XmlNode)((ScriptableNode)arg).baseObject));
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNode removeNamedItemNS(string namespaceURI, string localName)
			{
				object result = ((XmlNamedNodeMap)baseObject).RemoveNamedItem(localName, namespaceURI == null ? "" : namespaceURI);
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableNamedNodeMap
			public ulong length
			{
				get { return (ulong)((XmlNamedNodeMap)baseObject).Count;  }
			}

			#endregion
		}

  /// <summary>
  /// Implementation wrapper for IScriptableCharacterData
  /// </summary>
  public class ScriptableCharacterData : ScriptableNode, IScriptableCharacterData
  {
    public ScriptableCharacterData(object baseObject) : base (baseObject) { }

    #region Methods - IScriptableCharacterData
    public string substringData(ulong offset, ulong count)
    {
      if (((ICharacterData)baseObject).Value != null)
        return ((ICharacterData)baseObject).Value.Substring((int)offset, (int)count);
      else
        return null;
    }

    public void appendData(string arg)
    {
      ((ICharacterData)baseObject).Value += arg;
    }

    public void insertData(ulong offset, string arg)
    {
      if (((ICharacterData)baseObject).Value != null)
        ((ICharacterData)baseObject).Value.Insert((int)offset, arg);
      else
        ((ICharacterData)baseObject).Value = arg;
    }

    public void deleteData(ulong offset, ulong count)
    {
      if (((ICharacterData)baseObject).Value != null)
        ((ICharacterData)baseObject).Value.Remove((int)offset, (int)count);
    }

    public void replaceData(ulong offset, ulong count, string arg)
    {
      deleteData(offset, count);
      insertData(offset, arg);
    }
    #endregion

    #region Properties - IScriptableCharacterData
    public string data
    {
      get { return ((ICharacterData)baseObject).Value;  }
      set { ((ICharacterData)baseObject).Value = value; }
    }

    public ulong length
    {
      get { return (((ICharacterData)baseObject).Value != null) ? (ulong)((ICharacterData)baseObject).Value.Length : (ulong)0;  }
    }

    #endregion
  }

		/// <summary>
		/// Implementation wrapper for IScriptableAttr
		/// </summary>
		public class ScriptableAttr : ScriptableNode, IScriptableAttr
		{
			public ScriptableAttr(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableAttr
			public string name
			{
				get { return ((IAttribute)baseObject).Name;  }
			}

			public bool specified
			{
				get { return ((XmlAttribute)baseObject).Specified;  }
			}

			public string value
			{
				get { return ((IAttribute)baseObject).Value;  }
				set { ((IAttribute)baseObject).Value = value; }
			}

			public IScriptableElement ownerElement
			{
				get { object result = ((IAttribute)baseObject).ParentNode; return (result != null) ? (IScriptableElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableElement
		/// </summary>
		public class ScriptableElement : ScriptableNode, IScriptableElement
		{
			public ScriptableElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableElement
			public string getAttribute(string name)
			{
				return ((IElement)baseObject).GetAttribute(name);
			}

			public void setAttribute(string name, string value)
			{
				((IElement)baseObject).SetAttribute(name, value);
			}

			public void removeAttribute(string name)
			{
				((IElement)baseObject).RemoveAttribute(name);
			}

			public IScriptableAttr getAttributeNode(string name)
			{
				object result = ((IElement)baseObject).GetAttributeNode(name);
				return (result != null) ? (IScriptableAttr)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableAttr setAttributeNode(IScriptableAttr newAttr)
			{
				object result = ((IElement)baseObject).SetAttributeNode(((XmlAttribute)((ScriptableAttr)newAttr).baseObject));
				return (result != null) ? (IScriptableAttr)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableAttr removeAttributeNode(IScriptableAttr oldAttr)
			{
				object result = ((IElement)baseObject).RemoveAttributeNode(((XmlAttribute)((ScriptableAttr)oldAttr).baseObject));
				return (result != null) ? (IScriptableAttr)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNodeList getElementsByTagName(string name)
			{
				object result = ((IElement)baseObject).GetElementsByTagName(name);
				return (result != null) ? (IScriptableNodeList)ScriptableObject.CreateWrapper(result) : null;
			}

			public string getAttributeNS(string namespaceURI, string localName)
			{
				return ((IElement)baseObject).GetAttribute(localName, namespaceURI == null ? "" : namespaceURI );
			}

			public void setAttributeNS(string namespaceURI, string qualifiedName, string value)
			{
				((IElement)baseObject).SetAttribute(qualifiedName, namespaceURI == null ? "" : namespaceURI, value);
			}

			public void removeAttributeNS(string namespaceURI, string localName)
			{
				((IElement)baseObject).RemoveAttribute(localName, namespaceURI == null ? "" : namespaceURI);
			}

			public IScriptableAttr getAttributeNodeNS(string namespaceURI, string localName)
			{
				object result = ((IElement)baseObject).GetAttributeNode(localName, namespaceURI == null ? "" : namespaceURI);
				return (result != null) ? (IScriptableAttr)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableAttr setAttributeNodeNS(IScriptableAttr newAttr)
			{
				object result = ((IElement)baseObject).SetAttributeNode(((XmlAttribute)((ScriptableAttr)newAttr).baseObject));
				return (result != null) ? (IScriptableAttr)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNodeList getElementsByTagNameNS(string namespaceURI, string localName)
			{
				object result = ((IElement)baseObject).GetElementsByTagName(localName, namespaceURI == null ? "" : namespaceURI);
				return (result != null) ? (IScriptableNodeList)ScriptableObject.CreateWrapper(result) : null;
			}

			public bool hasAttribute(string name)
			{
				return ((IElement)baseObject).HasAttribute(name);
			}

			public bool hasAttributeNS(string namespaceURI, string localName)
			{
				return ((IElement)baseObject).HasAttribute(localName, namespaceURI == null ? "" : namespaceURI);
			}
			#endregion

			#region Properties - IScriptableElement
			public string tagName
			{
				get { return ((IElement)baseObject).Name;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableText
		/// </summary>
		public class ScriptableText : ScriptableCharacterData, IScriptableText
		{
			public ScriptableText(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableText
			public IScriptableText splitText(ulong offset)
			{
				object result = ((XmlText)baseObject).SplitText((int)offset);
				return (result != null) ? (IScriptableText)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableComment
		/// </summary>
		public class ScriptableComment : ScriptableCharacterData, IScriptableComment
		{
			public ScriptableComment(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCDataSection
		/// </summary>
		public class ScriptableCDataSection : ScriptableText, IScriptableCDataSection
		{
			public ScriptableCDataSection(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableDocumentType
		/// </summary>
		public class ScriptableDocumentType : ScriptableNode, IScriptableDocumentType
		{
			public ScriptableDocumentType(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableDocumentType
			public string name
			{
				get { return ((XmlDocumentType)baseObject).Name;  }
			}

			public IScriptableNamedNodeMap entities
			{
				get { object result = ((XmlDocumentType)baseObject).Entities; return (result != null) ? (IScriptableNamedNodeMap)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableNamedNodeMap notations
			{
				get { object result = ((XmlDocumentType)baseObject).Notations; return (result != null) ? (IScriptableNamedNodeMap)ScriptableObject.CreateWrapper(result) : null; }
			}

			public string publicId
			{
				get { return ((XmlDocumentType)baseObject).PublicId;  }
			}

			public string systemId
			{
				get { return ((XmlDocumentType)baseObject).SystemId;  }
			}

			public string internalSubset
			{
				get { return ((XmlDocumentType)baseObject).InternalSubset;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableNotation
		/// </summary>
		public class ScriptableNotation : ScriptableNode, IScriptableNotation
		{
			public ScriptableNotation(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableNotation
			public string publicId
			{
				get { return ((XmlNotation)baseObject).PublicId;  }
			}

			public string systemId
			{
				get { return ((XmlNotation)baseObject).SystemId;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableEntity
		/// </summary>
		public class ScriptableEntity : ScriptableNode, IScriptableEntity
		{
			public ScriptableEntity(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableEntity
			public string publicId
			{
				get { return ((XmlEntity)baseObject).PublicId;  }
			}

			public string systemId
			{
				get { return ((XmlEntity)baseObject).SystemId;  }
			}

			public string notationName
			{
				get { return ((XmlEntity)baseObject).NotationName;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableEntityReference
		/// </summary>
		public class ScriptableEntityReference : ScriptableNode, IScriptableEntityReference
		{
			public ScriptableEntityReference(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableProcessingInstruction
		/// </summary>
		public class ScriptableProcessingInstruction : ScriptableNode, IScriptableProcessingInstruction
		{
			public ScriptableProcessingInstruction(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableProcessingInstruction
			public string target
			{
				get { return ((XmlProcessingInstruction)baseObject).Target;  }
			}

			public string data
			{
				get { return ((XmlProcessingInstruction)baseObject).Data;  }
				set { ((XmlProcessingInstruction)baseObject).Data = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableDocumentFragment
		/// </summary>
		public class ScriptableDocumentFragment : ScriptableNode, IScriptableDocumentFragment
		{
			public ScriptableDocumentFragment(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableDocument
		/// </summary>
		public class ScriptableDocument : ScriptableNode, IScriptableDocument
		{
			public ScriptableDocument(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableDocument
			public IScriptableElement createElement(string tagName)
			{
				object result = ((IDocument)baseObject).CreateElement(tagName);
				return (result != null) ? (IScriptableElement)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableDocumentFragment createDocumentFragment()
			{
				object result = ((IDocument)baseObject).CreateDocumentFragment();
				return (result != null) ? (IScriptableDocumentFragment)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableText createTextNode(string data)
			{
				object result = ((IDocument)baseObject).CreateTextNode(data);
				return (result != null) ? (IScriptableText)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableComment createComment(string data)
			{
				object result = ((IDocument)baseObject).CreateComment(data);
				return (result != null) ? (IScriptableComment)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableCDataSection createCDATASection(string data)
			{
				object result = ((IDocument)baseObject).CreateCDataSection(data);
				return (result != null) ? (IScriptableCDataSection)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableProcessingInstruction createProcessingInstruction(string target, string data)
			{
				object result = ((IDocument)baseObject).CreateProcessingInstruction(target, data);
				return (result != null) ? (IScriptableProcessingInstruction)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableAttr createAttribute(string name)
			{
				object result = ((IDocument)baseObject).CreateAttribute(name);
				return (result != null) ? (IScriptableAttr)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableEntityReference createEntityReference(string name)
			{
				object result = ((IDocument)baseObject).CreateEntityReference(name);
				return (result != null) ? (IScriptableEntityReference)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNodeList getElementsByTagName(string tagname)
			{
				object result = ((IDocument)baseObject).GetElementsByTagName(tagname);
				return (result != null) ? (IScriptableNodeList)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNode importNode(IScriptableNode importedNode, bool deep)
			{
				object result = ((IDocument)baseObject).ImportNode(((INode)((ScriptableNode)importedNode).baseObject), deep);
				return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableElement createElementNS(string namespaceURI, string qualifiedName)
			{
				object result = ((IDocument)baseObject).CreateElementNs(namespaceURI == null ? "" : namespaceURI, qualifiedName);
				return (result != null) ? (IScriptableElement)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableAttr createAttributeNS(string namespaceURI, string qualifiedName)
			{
				object result = ((IDocument)baseObject).CreateAttributeNs(namespaceURI == null ? "" : namespaceURI, qualifiedName);
				return (result != null) ? (IScriptableAttr)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNodeList getElementsByTagNameNS(string namespaceURI, string localName)
			{
				object result = ((IDocument)baseObject).GetElementsByTagNameNs(namespaceURI == null ? "" : namespaceURI, localName);
				return (result != null) ? (IScriptableNodeList)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableElement getElementById(string elementId)
			{
				object result = ((IDocument)baseObject).GetElementById(elementId);
				return (result != null) ? (IScriptableElement)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableDocument
			public IScriptableDocumentType doctype
			{
				get { object result = ((IDocument)baseObject).Doctype; return (result != null) ? (IScriptableDocumentType)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableDomImplementation implementation
			{
				get { object result = ((IDocument)baseObject).Implementation; return (result != null) ? (IScriptableDomImplementation)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableElement documentElement
			{
				get { object result = ((IDocument)baseObject).DocumentElement; return (result != null) ? (IScriptableElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

}
  
