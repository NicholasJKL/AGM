using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace AGM
{
    /// <summary>
    /// Interaction logic for WaveEq.xaml
    /// </summary>
    public partial class WaveEq : Page
    {
        public WaveEq()
        {
            InitializeComponent();

            var dataX = new List<double>();
            var dataY = new List<double>();

            double t = 1;

            for (double R = 0; R <= t; R += 0.01)
            {
                double r0 = t - R - 0.01;

                dataX.Add(R);

                dataY.Add(PreciseCalc.SympsonWaveEq(r0, t, R));
            }

            WavePlot.Plot.Add.Scatter(dataX, dataY);
        }
    }
}
