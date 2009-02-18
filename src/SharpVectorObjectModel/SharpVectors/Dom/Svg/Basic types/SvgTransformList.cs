using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// Summary description for SvgTransformList.
	/// </summary>
	public class SvgTransformList : SvgList, ISvgTransformList
	{
        #region Constructors
        public SvgTransformList()
        {
        }

        public SvgTransformList(string listString)
        {
            this.FromString(listString);
        }
        #endregion

        #region ISvgTransformList Interface
        public ISvgTransform Initialize(ISvgTransform newItem)
        {
            return (ISvgTransform) base.Initialize(newItem);
        }

        public new ISvgTransform GetItem(uint index)
        {
            return (ISvgTransform) base.GetItem(index);
        }

        public ISvgTransform InsertItemBefore(ISvgTransform newItem, uint index)
        {
            return (ISvgTransform) base.InsertItemBefore(newItem, index);
        }

        public ISvgTransform ReplaceItem(ISvgTransform newItem, uint index)
        {
            return (ISvgTransform) base.ReplaceItem(newItem, index);
        }

        public new ISvgTransform RemoveItem(uint index)
        {
            return (ISvgTransform) base.RemoveItem(index);
        }

        public ISvgTransform AppendItem(ISvgTransform newItem)
        {
            return (ISvgTransform) base.AppendItem(newItem);
        }

        public ISvgTransform CreateSvgTransformFromMatrix(ISvgMatrix matrix)
        {
            return new SvgTransform((SvgMatrix)matrix);
        }

        public ISvgTransform Consolidate()
        {
			SvgTransform result = (SvgTransform)CreateSvgTransformFromMatrix(TotalMatrix);
                    
            Initialize(result);

            return result;
        }
		#endregion

		public SvgMatrix TotalMatrix
		{
			get
			{
				if (NumberOfItems == 0)
				{
					return new SvgMatrix(1, 0, 0, 1, 0, 0);
				}
				else
				{
					SvgMatrix matrix = (SvgMatrix)GetItem(0).Matrix;

					for ( uint i = 1; i < NumberOfItems; i++ )
					{
						matrix = (SvgMatrix)matrix.Multiply(GetItem(i).Matrix);
					}
					return matrix;
				}
			}
		}

        public void FromString(string listString)
		{
			Clear();
			if(listString != null)
			{
				Regex re = new Regex("([A-Za-z]+)\\s*\\(([\\-0-9\\.\\,\\s]+)\\)");
			
				Match match = re.Match(listString);
				while(match.Success)
				{
					AppendItem( new SvgTransform(match.Value) );
					match = match.NextMatch();
				}
			}
		}
	}
}
