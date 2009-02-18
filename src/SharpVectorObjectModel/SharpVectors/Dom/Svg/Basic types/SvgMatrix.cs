using System;
using System.Drawing.Drawing2D;

namespace SharpVectors.Dom.Svg
{
  /// <summary>
  /// Summary description for SvgMatrix.
  /// </summary>
  /// <developer>niklas@protocol7.com</developer>
  /// <developer>kevin@kevlindev.com</developer>
  public class SvgMatrix : ISvgMatrix
  {
    #region Private Fields
    private double a;
    private double b;
    private double c;
    private double d;
    private double e;
    private double f;
    #endregion

    #region Constructors
    public SvgMatrix() : this(1, 0, 0, 1, 0, 0)
    {
    }

    public SvgMatrix(double a, double b, double c, double d, double e, double f)
    {
      this.a = a;
      this.b = b;
      this.c = c;
      this.d = d;
      this.e = e;
      this.f = f;
    }
    #endregion

		
    #region ISvgMatrix Interface
    public float A
    {
      get { return (float) this.a; }
      set { this.a = value; }
    }

    public float B
    {
      get { return (float) this.b; }
      set { this.b = value; }
    }

    public float C
    {
      get { return (float) this.c; }
      set { this.c = value; }
    }

    public float D
    {
      get { return (float) this.d; }
      set { this.d = value; }
    }

    public float E
    {
      get { return (float) this.e; }
      set { this.e = value; }
    }

    public float F
    {
      get { return (float) this.f; }
      set { this.f = value; }
    }

    public ISvgMatrix Multiply(ISvgMatrix secondMatrix)
    {
      SvgMatrix matrix = (SvgMatrix)secondMatrix;
      return new SvgMatrix(
        this.a*matrix.a + this.c*matrix.b,
        this.b*matrix.a + this.d*matrix.b,
        this.a*matrix.c + this.c*matrix.d,
        this.b*matrix.c + this.d*matrix.d,
        this.a*matrix.e + this.c*matrix.f + this.e,
        this.b*matrix.e + this.d*matrix.f + this.f
        );
    }

    public ISvgMatrix Inverse()
    {
      double det1 = this.a*this.d - this.b*this.c;

      if ( det1 == 0 )
        throw new SvgException(SvgExceptionType.SvgMatrixNotInvertable);

      double iDet = 1.0 / det1;

      double det2 = this.f*this.c - this.e*this.d;

      double det3 = this.e*this.b - this.f*this.a;



      return new SvgMatrix(

        this.d * iDet,

        -this.b * iDet,

        -this.c * iDet,

        this.a * iDet,

        det2 * iDet,

        det3 * iDet

        );
    }

    public ISvgMatrix Translate(float x, float y)
    {
      return new SvgMatrix(
        this.a,
        this.b,
        this.c,
        this.d,
        this.a*x + this.c*y + this.e,
        this.b*x + this.d*y + this.f
        );
    }

    public ISvgMatrix Scale(float scaleFactor)
    {
      return new SvgMatrix(
        this.a*scaleFactor,
        this.b*scaleFactor,
        this.c*scaleFactor,
        this.d*scaleFactor,
        this.e,
        this.f
        );
    }

    public ISvgMatrix ScaleNonUniform(float scaleFactorX, float scaleFactorY)
    {
      return new SvgMatrix(
        this.a*scaleFactorX,
        this.b*scaleFactorX,
        this.c*scaleFactorY,
        this.d*scaleFactorY,
        this.e,
        this.f
        );
    }

    public ISvgMatrix Rotate(float angle)
    {
      double radians = angle * (Math.PI / 180.0);
      double cos = Math.Cos(radians);
      double sin = Math.Sin(radians);

      return new SvgMatrix(
        this.a*cos + this.c*sin,
        this.b*cos + this.d*sin,
        this.a*(-sin) + this.c*cos,
        this.b*(-sin) + this.d*cos,
        this.e,
        this.f
        );
    }

    public ISvgMatrix RotateFromVector(float x, float y)
    {
      if ( x == 0 || y == 0 )
        throw new SvgException(SvgExceptionType.SvgInvalidValueErr);

      double length = Math.Sqrt((x*x) + (y*y));
      double cos = x / length;
      double sin = y / length;

      return new SvgMatrix(
        this.a*cos + this.c*sin,
        this.b*cos + this.d*sin,
        this.a*(-sin) + this.c*cos,
        this.b*(-sin) + this.d*cos,
        this.e,
        this.f
        );
    }

    public ISvgMatrix FlipX()
    {
      return new SvgMatrix(
        -this.a,
        -this.b,
        this.c,
        this.d,
        this.e,
        this.f
        );
    }

    public ISvgMatrix FlipY()
    {
      return new SvgMatrix(
        this.a,
        this.b,
        -this.c,
        -this.d,
        this.e,
        this.f
        );
    }

    public ISvgMatrix SkewX(float angle)
    {
      double tan = Math.Tan(angle * (Math.PI / 180.0));

      return new SvgMatrix(
        this.a,
        this.b,
        this.a*tan + this.c,
        this.b*tan + this.d,
        this.e,
        this.f
        );
    }

    public ISvgMatrix SkewY(float angle)
    {
      double tan = Math.Tan(angle * (Math.PI / 180.0));

      return new SvgMatrix(
        this.a + this.c*tan,
        this.b + this.d*tan,
        this.c,
        this.d,
        this.e,
        this.f
        );
    }
    #endregion

    #region Additional operators
    public Matrix ToMatrix() 

    {
      return new Matrix(
        (float) this.a,
        (float) this.b,
        (float) this.c,
        (float) this.d,
        (float) this.e,
        (float) this.f
        );
    }

    public static SvgMatrix operator*(SvgMatrix a, SvgMatrix b)
    {
      return (SvgMatrix) a.Multiply(b);
    }
    #endregion
  }
}
