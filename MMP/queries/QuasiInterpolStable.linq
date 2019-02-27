<Query Kind="Statements">
  <Namespace>static ME</Namespace>
  <Namespace>static System.Math</Namespace>
</Query>

var n=100; 
var m=100;
var h=1d/n;
var tp=Util.SeriesType.Line;
var r = Enumerable.Range(0,n+1);
var hm=1d/m;
var rm = Enumerable.Range(0,m+1);
var x = r.Select(i=>i*h).ToArray();
var xm = rm.Select(i=>i*hm).ToArray();
var v = x.Select(t=>Sin(PI*t)).ToArray();
var vm = xm.Select(t=>Sin(PI*t)).ToArray();

var ch=x.Chart();
	ch.AddYSeries(v,tp,name:"f");
	ch.AddYSeries(Lin(BernsteinBase(m,x),vm),tp,name:"QI");
	ch.DumpInline();
//vm.Dump();