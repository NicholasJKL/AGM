using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

			double t = 1, R = 0.5, r0 = 0.01;

			for (double i = 0; i <= R; i += 0.01)
			{
				dataX.Add(i);

				dataY.Add(PreciseCalc.SympsonWaveEq(r0, t, i));
			}

			WavePlot.Plot.Add.Scatter(dataX, dataY);
		}
	}
}
