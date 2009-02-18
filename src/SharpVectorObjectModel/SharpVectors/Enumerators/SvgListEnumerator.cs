using System;
using System.Collections;

using SharpVectors.Dom.Svg;

namespace SharpVectors.Enumerators
{
	public class SvgListEnumerator : IEnumerator
	{
        #region fields
        private int index;
        private object current;
        private SvgList list;
        #endregion

        #region Properties
        public virtual object Current 
        {
            get { return current; }
        }
        #endregion

        public SvgListEnumerator(SvgList list)
        {
            this.list = list;
            this.Reset();
        }

        public bool MoveNext() 
        {
            bool result = false;
            
            index++;
            if ( index < list.NumberOfItems ) 
            {
                current = list.GetItem((uint) index);
                result = true;
            }
            
            return result;
        }

        public void Reset()
        {
            index = -1;
            current = null;
        }
	}
}