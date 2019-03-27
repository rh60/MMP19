<Query Kind="Program">
  <Namespace>static System.Math</Namespace>
  <Namespace>System.Drawing</Namespace>
</Query>

void Main()
{
	var U1 = new Ulam(9);
    	var U2 = new Ulam(150);
	var U = U1;    
	for(int i=0; i<numbers.Length; i++)
	{
		U.Fill(numbers[i](U.Length));	
		U.Dump(names[i++]);
	}
}

static Func<int,IEnumerable<int>>[] numbers = 
        { Primes, ****************************************** };
static string[] names = 
		{"Prime numbers","Triangular numbers","Square numbers","Pentagonal numbers", "Hexagonal numbers"};

static int odd(int n) => 2*n+1;
static int tri(int n) => n*(n+1)/2;
static int sqr(int n) => n*n;
static int penta(int n) => (3*n*n-n)/2;
static int hexa(int n) => n*(2*n-1);

static IEnumerable<int> Primes(int upperBound)
{
  *************************************************
}

static IEnumerable<int> Remarkable(int upperBound, Func<int,int> f)
{
  *************************************************
}

class Ulam
{	

    int[,] m;
        
    readonly int n;
        
    public Ulam(int n)
    {
        this.n = n;
        var n1 = odd(n);
        m = new int[n1, n1];      
        PixelSize = 30;
    }

    public int Length
    {
        get { return m.Length; }
    }

    public void Fill(IEnumerable<int> source)
     {
        Array.Clear(m, 0, m.Length);
	    **********************************************************
    }
		
	public static implicit operator int[,] (Ulam u) { return u.m; }
	public int PixelSize { get; set; }
	object ToDump()
	{   		
		int n = m.GetLength(1);
		var sp = n<40;
		if(!sp) PixelSize=2;
		int h; if(sp) h=PixelSize/2; else h=PixelSize;
		int w = PixelSize;
		var bitmap = new Bitmap(n*w,n*h);
   		using (var gr = Graphics.FromImage(bitmap))
   		{
      		gr.Clear(Color.White);
			var br = Brushes.Black;
			var rbr = Brushes.Red;
			var bbr = Brushes.Blue;
			var wbr = Brushes.White;
			var fnt = new Font("Arial", 10);			
			for(int i=0;i<n;i++)
				for(int j=0;j<n;j++)
				{						
					var rect = new RectangleF(i*w, j*h, w, h);
					if(m[i,j]>0)
					{
      					gr.FillRectangle(bbr,rect);					
						if(sp) gr.DrawString(m[i,j].ToString(), fnt, wbr, rect);
					}
					else
						if(sp) gr.DrawString((-m[i,j]).ToString(), fnt, br, rect);
				}		
   		}
   		return bitmap;
	}
}