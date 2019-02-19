<Query Kind="Statements">
  <Namespace>static ME</Namespace>
  <Namespace>static System.Math</Namespace>
</Query>

var n=50; 
var m=4;
var h=1d/n;
var tp=Util.SeriesType.Line;
var r = Enumerable.Range(0,n+1);
var x = r.Select(i=>i*h).ToArray();
var B = r.Select(i=>BernsteinBase(m,i*h)).ToArray();
B[0].Dump();
var ch=r.Chart(i=>x[i]);
for(int j=0;j<m+1;j++)
	ch.AddYSeries(i=>B[i][j],tp,name:$"b{j}");
ch.DumpInline();