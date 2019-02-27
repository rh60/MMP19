<Query Kind="Statements" />

var x=ME.linspace(0,1);
var ch=x.Chart();
double f(double a) => Math.Exp(a);
double T(double a) => 1+a+a*a/2+a*a*a/6;
ch.AddYSeries(a=>f(a),Util.SeriesType.Line,name:"exp(x)");
ch.AddYSeries(a=>T(a),Util.SeriesType.Line,name:"Taylor(3)");
ch.DumpInline();
