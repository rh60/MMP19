using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;
using static MELib.OxyPlotAdapter;
using static MELib.Linspace;
using fd=System.Func<double,double>;

namespace WindowsFormsExamples
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var X = linspace(0, 2*PI);
            var F = new fd[] { Sin, x=>Sin(x)/x };
            Plot(plotView1, F, X);
        }
    }
}
