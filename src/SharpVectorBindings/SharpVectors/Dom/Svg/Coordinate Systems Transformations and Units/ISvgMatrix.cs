namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// Interface for matrix operations used within the SVG DOM
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <developer>kevin@kevlindev.com</developer>
	/// <completed>100</completed>
	public interface ISvgMatrix
	{
		float A { get;set; }
		float B { get;set; }
		float C { get;set; }
		float D { get;set; }
		float E { get;set; }
		float F { get;set; }
		
		ISvgMatrix Multiply(ISvgMatrix secondMatrix);
		ISvgMatrix Inverse();
		ISvgMatrix Translate(float x, float y);
		ISvgMatrix Scale(float scaleFactor);
		ISvgMatrix ScaleNonUniform(float scaleFactorX, float scaleFactorY);
		ISvgMatrix Rotate(float angle);
		ISvgMatrix RotateFromVector(float x, float y);
		ISvgMatrix FlipX();
		ISvgMatrix FlipY();
		ISvgMatrix SkewX(float angle);
		ISvgMatrix SkewY(float angle);
	}	
}
