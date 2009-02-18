using System;
using System.Text.RegularExpressions;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// Summary description for SvgTransform.
	/// <developer>niklas@protocol7.com</developer>
	/// <developer>kevin@kevlindev.com</developer>
	/// </summary>
	public class SvgTransform : ISvgTransform
	{
        #region Enum
        enum SvgTransformType : short
        {
            Unknown,

            Matrix,

            Translate,

            Scale,

            Rotate,

            SkewX,

            SkewY
        }
        #endregion

        #region Fields
        private short type;
        private ISvgMatrix matrix;
        private double angle;
        #endregion

        #region Constructors
		public SvgTransform()
		{
		}

        public SvgTransform(ISvgMatrix matrix)
        {
            this.type = (short) SvgTransformType.Matrix;
            this.matrix = matrix;
        }

		public SvgTransform(string str)
		{
			int start = str.IndexOf("(");
			string type = str.Substring(0, start);
			string valuesList = (str.Substring(start+1, str.Length - start - 2)).Trim(); //JR added trim
			Regex re = new Regex("[\\s\\,]+"); 
			valuesList = re.Replace(valuesList, ",");
			string[] valuesStr = valuesList.Split(new char[]{','});
			int len = valuesStr.GetLength(0);
			float[] values = new float[len];

			for(int i = 0; i<len; i++)
			{
				values.SetValue(SvgNumber.ParseToFloat(valuesStr[i]), i);
			}

            switch (type)
            {
                case "translate":
                    switch (len)
                    {
                        case 1:
                            SetTranslate(values[0], 0);
                            break;
                        case 2:
                            SetTranslate(values[0], values[1]);
                            break;
                        default:
                            throw new ApplicationException("Wrong number of arguments in translate transform");
                    }
                    break;
                case "rotate":
                    switch (len)
                    {
                        case 1:
                            SetRotate(values[0]);
                            break;
                        case 3:
                            SetRotate(values[0], values[1], values[2]);
                            break;
                        default:
                            throw new ApplicationException("Wrong number of arguments in rotate transform");
                    }
                    break;
                case "scale":
                    switch (len)
                    {
                        case 1:
                            SetScale(values[0], values[0]);
                            break;
                        case 2:
                            SetScale(values[0], values[1]);
                            break;
                        default:
                            throw new ApplicationException("Wrong number of arguments in scale transform");
                    }
                    break;
                case "skewX":
                    if (len != 1)
                        throw new ApplicationException("Wrong number of arguments in skewX transform");
                    SetSkewX(values[0]);
                    break;
                case "skewY":
                    if (len != 1)
                        throw new ApplicationException("Wrong number of arguments in skewY transform");
                    SetSkewY(values[0]);
                    break;
                case "matrix":
                    if(len != 6)
                        throw new ApplicationException("Wrong number of arguments in matrix transform");
                    SetMatrix(
                        new SvgMatrix(
                        values[0],
                        values[1],
                        values[2],
                        values[3],
                        values[4],
                        values[5]
                        ));
                    break;
                default:
                    this.type = (short) SvgTransformType.Unknown;
                    break;
            }
		}
        #endregion

        #region ISvgTransform Interface
		public short Type
		{
			get { return type; }
		}

		public ISvgMatrix Matrix
		{
			get { return matrix; }
		}

		public double Angle
		{
			get { return angle; }
		}

		public void SetMatrix(ISvgMatrix matrix)
		{
			type = (short) SvgTransform.SvgTransformType.Matrix;
			this.matrix = matrix;
		}

		public void SetTranslate(float tx, float ty)
		{
			type = (short) SvgTransform.SvgTransformType.Translate;
			matrix = new SvgMatrix().Translate(tx, ty);
		}

		public void SetScale(float sx, float sy)
		{
			type = (short) SvgTransform.SvgTransformType.Scale;
			matrix = new SvgMatrix().ScaleNonUniform(sx, sy);
		}

		public void SetRotate(float angle)
		{
			type = (short) SvgTransform.SvgTransformType.Rotate;
			this.angle = angle;
			matrix = new SvgMatrix().Rotate(angle);
		}

		public void SetRotate(float angle, float cx, float cy)
		{
			type = (short) SvgTransform.SvgTransformType.Rotate;
			this.angle = angle;
			matrix = new SvgMatrix().Translate(cx, cy).Rotate(angle).Translate(-cx,-cy);
		}

		public void SetSkewX(float angle)
		{
			type = (short) SvgTransform.SvgTransformType.SkewX;
			this.angle = angle;
			matrix = new SvgMatrix().SkewX(angle);
		}

		public void SetSkewY(float angle)
		{
			type = (short) SvgTransform.SvgTransformType.SkewY;
			this.angle = angle;
			matrix = new SvgMatrix().SkewY(angle);
		}
        #endregion
	}
}
