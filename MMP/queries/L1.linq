<Query Kind="Statements">
  <Namespace>MMP</Namespace>
</Query>

int n=60;
var x = new double[n];
double h = 0.1;
for(int i=0;i<n;i++)	
	x[i]=i*h;

x.Chart(p=>Math.Cos(p))
 .AddYSeries(p=>Math.Sin(p),Util.SeriesType.Line)
 .Dump();


