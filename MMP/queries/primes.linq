<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>OxyPlot</Namespace>
  <Namespace>OxyPlot.Series</Namespace>
</Query>

void Main()
{
	GetPrimeNumbers(13).Dump();
}

private static IEnumerable<int> GetPrimeNumbers(int max)
{
    var all = Enumerable.Range(3, max-2);
    var primes = all
            .AsParallel()
            .Where(n => Enumerable.Range(2, (int)Math.Sqrt(n))
                                  .All(i => n % i != 0)
            )
            ;
    return primes;           
}