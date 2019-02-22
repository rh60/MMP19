<Query Kind="Statements">
  <Namespace>static ME</Namespace>
  <Namespace>static System.Math</Namespace>
</Query>

var n=100; 
var m=25;
var h=1d/n;
var tp=Util.SeriesType.Line;
var r = Enumerable.Range(0,n+1);
var hm=1d/m;
var rm = Enumerable.Range(0,m+1);
var x = r.Select(i=>i*h).ToArray();
var xm = rm.Select(i=>i*hm).ToArray();
var v = x.Select(t=>Sin(PI*t)).ToArray();
var vm = xm.Select(t=>Sin(PI*t)).ToArray();

var ch=r.Chart(i=>x[i]);
	ch.AddYSeries(i=>v[i],tp,name:"f");
	ch.AddYSeries(i=>QuasiApprox(BernsteinBase(m,x[i]),vm),tp,name:"QI");
	ch.DumpInline();
vm.Dump();