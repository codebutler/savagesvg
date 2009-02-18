namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// SvgTransform is the interface for one of the component transformations within a SvgTransformList; thus, a SvgTransform object corresponds to a single component (e.g., "scale(..)" or "matrix(...)") within a transform attribute specification. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <developer>kevin@kevlindev.com</developer>
	/// <completed>100</completed>
	public interface ISvgTransform
	{
		short Type { get; }
		ISvgMatrix Matrix { get; }
		double Angle { get; }

		void SetMatrix(ISvgMatrix matrix);
		void SetTranslate(float tx, float ty);
		void SetScale(float sx, float sy);
		void SetRotate(float angle, float cx, float cy);
		void SetSkewX(float angle);
		void SetSkewY(float angle);
	}
}
