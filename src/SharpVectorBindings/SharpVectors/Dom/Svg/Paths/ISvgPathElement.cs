using SharpVectors.Dom.Events;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgPathElement interface corresponds to the 'path' element. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>10</completed>
	public interface ISvgPathElement	: 
		ISvgElement,
		ISvgTests,
		ISvgLangSpace,
		ISvgExternalResourcesRequired,
		ISvgStylable,
		ISvgTransformable,
		ISvgAnimatedPathData,
    IEventTarget
  {
		ISvgAnimatedNumber PathLength{get;}
		 float GetTotalLength();
		 ISvgPoint GetPointAtLength(float distance);
		 int GetPathSegAtLength(float distance);

		ISvgPathSegClosePath CreateSvgPathSegClosePath();
		 ISvgPathSegMovetoAbs CreateSvgPathSegMovetoAbs(float x, float y);
		 ISvgPathSegMovetoRel CreateSvgPathSegMovetoRel(float x, float y);
		 ISvgPathSegLinetoAbs CreateSvgPathSegLinetoAbs(float x, float y);
		 ISvgPathSegLinetoRel CreateSvgPathSegLinetoRel(float x, float y);
		 ISvgPathSegCurvetoCubicAbs CreateSvgPathSegCurvetoCubicAbs(float x, 
											float y, 
											float x1, 
			 								float y1, 
			 								float x2, 
			 								float y2);
		 ISvgPathSegCurvetoCubicRel CreateSvgPathSegCurvetoCubicRel(float x, 
			 								float y, 
			 								float x1, 
			 								float y1, 
			 								float x2, 
			 								float y2);
		 ISvgPathSegCurvetoQuadraticAbs CreateSvgPathSegCurvetoQuadraticAbs(float x, 
			 								float y, 
			 								float x1, 
			 								float y1);
		 ISvgPathSegCurvetoQuadraticRel CreateSvgPathSegCurvetoQuadraticRel(float x, 
			 								float y, 
			 								float x1, 
			 								float y1);

		 ISvgPathSegArcAbs CreateSvgPathSegArcAbs(float x,
										   float y,
										   float r1,
										   float r2,
										   float angle,
										   bool largeArcFlag,
										   bool sweepFlag);

		 ISvgPathSegArcRel CreateSvgPathSegArcRel(float x,
										   float y,
										   float r1,
										   float r2,
										   float angle,
										   bool largeArcFlag,
										   bool sweepFlag);

		 ISvgPathSegLinetoHorizontalAbs CreateSvgPathSegLinetoHorizontalAbs(float x);

		 ISvgPathSegLinetoHorizontalRel CreateSvgPathSegLinetoHorizontalRel(float x);

		 ISvgPathSegLinetoVerticalAbs CreateSvgPathSegLinetoVerticalAbs(float y);

		 ISvgPathSegLinetoVerticalRel CreateSvgPathSegLinetoVerticalRel(float y);

		 ISvgPathSegCurvetoCubicSmoothAbs CreateSvgPathSegCurvetoCubicSmoothAbs(float x,
																		 float y,
																		 float x2,
																		 float y2);

		 ISvgPathSegCurvetoCubicSmoothRel CreateSvgPathSegCurvetoCubicSmoothRel(float x,
																		 float y,
																		 float x2,
																		 float y2);

		 ISvgPathSegCurvetoQuadraticSmoothAbs CreateSvgPathSegCurvetoQuadraticSmoothAbs(float x,
																				 float y);

		 ISvgPathSegCurvetoQuadraticSmoothRel CreateSvgPathSegCurvetoQuadraticSmoothRel(float x,
																				 float y);
	}
}
