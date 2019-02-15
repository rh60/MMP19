<Query Kind="Statements">
  <Namespace>MMP</Namespace>
  <Namespace>static MMP.Interpolation.Curve</Namespace>
  <Namespace>static MMP.OxyPlotAdapter</Namespace>
  <Namespace>static System.Math</Namespace>
</Query>


var curves = new PlainCurve[] 
{ 
	new PlainCurve { x = Cos, y = Sin },
  	new PlainCurve { x = p=>Cos(1.5*p), y = Sin },
	new PlainCurve { x = Cos, y = p=>Sin(1.5*p) }
};
								
var x=new Linspace(0,4*PI,500);
var plot=Plot(curves,x);
plot.Dump();

