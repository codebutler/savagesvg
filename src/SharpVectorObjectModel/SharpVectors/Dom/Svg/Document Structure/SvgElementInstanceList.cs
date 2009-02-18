using System;
using System.Collections;
using System.Xml;


namespace SharpVectors.Dom.Svg
{
	public class SvgElementInstanceList : ISvgElementInstanceList
	{
		#region Constructors
		public SvgElementInstanceList(SvgUseElement useElement, SvgElementInstance parent)
		{
      if (parent.CorrespondingElement == null) 
      {
        // Handle non SVGElement cases
        items = new SvgElementInstance[0];
      } 
      else if (parent.CorrespondingElement is ISvgUseElement) 
      {
        // Handle recursive SVGUseElement cases
        items = new SvgElementInstance[1];
        items[0] = (SvgElementInstance)((ISvgUseElement)parent).InstanceRoot;
        return;
      } 
      else 
      {
        XmlNodeList xmlChildNodes = parent.CorrespondingElement.ChildNodes;
        for (int i = 0; i < xmlChildNodes.Count; i++) 
        {
          items[i] = new SvgElementInstance(xmlChildNodes[i], useElement, parent);
          if (i > 0) 
          {
            items[i].SetPreviousSibling(items[i-1]);
            items[i-1].SetNextSibling(items[i]);
          }
        }
      }
		}
		#endregion

		#region Private fields
		private SvgElementInstance[] items;
		#endregion

		#region Implementation of ISvgElementInstanceList
		public ulong Length
		{
			get
			{
				return (ulong)items.GetLength(0);
			}
		}

		public ISvgElementInstance Item(ulong index)
		{
			if(index<Length)
			{
				return (ISvgElementInstance)items.GetValue((int) index);
			}
			else return null;
		}
		#endregion
	}
}
