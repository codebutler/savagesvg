using System;
using SharpVectors.Dom;
using SharpVectors.Dom.Css;
using SharpVectors.Dom.Events;
using SharpVectors.Dom.Stylesheets;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Views;


namespace SharpVectors.Scripting
{

		/// <summary>
		/// Implementation wrapper for IScriptableStyleSheet
		/// </summary>
		public class ScriptableStyleSheet : ScriptableObject, IScriptableStyleSheet
		{
			public ScriptableStyleSheet(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableStyleSheet
			public string type
			{
				get { return ((IStyleSheet)baseObject).Type;  }
			}

			public bool disabled
			{
				get { return ((IStyleSheet)baseObject).Disabled;  }
				set { ((IStyleSheet)baseObject).Disabled = value; }
			}

			public IScriptableNode ownerNode
			{
				get { object result = ((IStyleSheet)baseObject).OwnerNode; return (result != null) ? (IScriptableNode)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableStyleSheet parentStyleSheet
			{
				get { object result = ((IStyleSheet)baseObject).ParentStyleSheet; return (result != null) ? (IScriptableStyleSheet)ScriptableObject.CreateWrapper(result) : null; }
			}

			public string href
			{
				get { return ((IStyleSheet)baseObject).Href;  }
			}

			public string title
			{
				get { return ((IStyleSheet)baseObject).Title;  }
			}

			public IScriptableMediaList media
			{
				get { object result = ((IStyleSheet)baseObject).Media; return (result != null) ? (IScriptableMediaList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableStyleSheetList
		/// </summary>
		public class ScriptableStyleSheetList : ScriptableObject, IScriptableStyleSheetList
		{
			public ScriptableStyleSheetList(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableStyleSheetList
			public IScriptableStyleSheet item(ulong index)
			{
				object result = ((IStyleSheetList)baseObject)[index];
				return (result != null) ? (IScriptableStyleSheet)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableStyleSheetList
			public ulong length
			{
				get { return ((IStyleSheetList)baseObject).Length;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableMediaList
		/// </summary>
		public class ScriptableMediaList : ScriptableObject, IScriptableMediaList
		{
			public ScriptableMediaList(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableMediaList
			public string item(ulong index)
			{
				return ((IMediaList)baseObject)[index];
			}

			public void deleteMedium(string oldMedium)
			{
				((IMediaList)baseObject).DeleteMedium(oldMedium);
			}

			public void appendMedium(string newMedium)
			{
				((IMediaList)baseObject).AppendMedium(newMedium);
			}
			#endregion

			#region Properties - IScriptableMediaList
			public string mediaText
			{
				get { return ((IMediaList)baseObject).MediaText;  }
				set { ((IMediaList)baseObject).MediaText = value; }
			}

			public ulong length
			{
				get { return ((IMediaList)baseObject).Length;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableLinkStyle
		/// </summary>
		public class ScriptableLinkStyle : ScriptableObject, IScriptableLinkStyle
		{
			public ScriptableLinkStyle(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableLinkStyle
			public IScriptableStyleSheet sheet
			{
				get { object result = ((ILinkStyle)baseObject).Sheet; return (result != null) ? (IScriptableStyleSheet)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableDocumentStyle
		/// </summary>
		public class ScriptableDocumentStyle : ScriptableObject, IScriptableDocumentStyle
		{
			public ScriptableDocumentStyle(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableDocumentStyle
			public IScriptableStyleSheetList styleSheets
			{
				get { object result = ((IDocumentStyle)baseObject).StyleSheets; return (result != null) ? (IScriptableStyleSheetList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

}
  
