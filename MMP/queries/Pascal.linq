<Query Kind="Statements" />

int n=5;
var P=new int[n][];
for(int i=0;i<n;i++)
{
	P[i]=new int[i+1];
	P[i][0]=1;
	P[i][i]=1;
	for(int j=1;j<i;j++)
		P[i][j]=P[i-1][j-1]+P[i-1][j];   
}
P.Dump();
