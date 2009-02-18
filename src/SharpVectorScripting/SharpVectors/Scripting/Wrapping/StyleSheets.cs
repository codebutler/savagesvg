using System;


namespace SharpVectors.Scripting
{

	/// <summary>
	/// IScriptableStyleSheet
	/// </summary>
	public interface IScriptableStyleSheet
	{
		string type { get; }
		bool disabled { get; set; }
		IScriptableNode ownerNode { get; }
		IScriptableStyleSheet parentStyleSheet { get; }
		string href { get; }
		string title { get; }
		IScriptableMediaList media { get; }
	}

	/// <summary>
	/// IScriptableStyleSheetList
	/// </summary>
	public interface IScriptableStyleSheetList
	{
		IScriptableStyleSheet item(ulong index);
		ulong length { get; }
	}

	/// <summary>
	/// IScriptableMediaList
	/// </summary>
	public interface IScriptableMediaList
	{
		string item(ulong index);
		void deleteMedium(string oldMedium);
		void appendMedium(string newMedium);
		string mediaText { get; set; }
		ulong length { get; }
	}

	/// <summary>
	/// IScriptableLinkStyle
	/// </summary>
	public interface IScriptableLinkStyle
	{
		IScriptableStyleSheet sheet { get; }
	}

	/// <summary>
	/// IScriptableDocumentStyle
	/// </summary>
	public interface IScriptableDocumentStyle
	{
		IScriptableStyleSheetList styleSheets { get; }
	}

}
  