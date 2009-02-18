namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// This interface defines a list of string objects. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <developer>kevin@kevlindev.com</developer>
	/// <completed>100</completed>
	public interface ISvgStringList
	{
		uint NumberOfItems{get;}
		void Clear();
		string Initialize(string newItem);
		string GetItem(uint index);
		string InsertItemBefore(string newItem, uint index);
		string ReplaceItem(string newItem, uint index);
		string RemoveItem(uint index);
		string AppendItem(string newItem);
                
        // not part of the SVG spec
        void FromString(string listString);
	}
}
