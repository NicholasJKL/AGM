using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace AGM
{
	public partial class WaveEq : Page
	{
		public class FuncData
		{
			public int Id { get; set; }

			public string Name { get; set; }

			public PreciseCalc.PreciseFunc PreciseFunc { get; set; }
		}

		public List<FuncData> funcDatas = new List<FuncData>()
		{
			new FuncData{ Id = 0, Name = "e^x", PreciseFunc = Math.Exp },
			new FuncData{ Id = 1, Name = "e^(-x)", PreciseFunc = PreciseCalc.NegExp},
			new FuncData{ Id = 2, Name = "|cos(x)|" , PreciseFunc = PreciseCalc.AbsCos},
			new FuncData{ Id = 3, Name = "|sin(x)|", PreciseFunc = PreciseCalc.AbsSin },
			new FuncData{ Id = 4, Name = "ln(x)", PreciseFunc = Math.Log }
		};

		public WaveEq()
		{
			InitializeComponent();

			funcPicker.ItemsSource = funcDatas;
		}

		private void GoBack(object sender, RoutedEventArgs e)
		{
			Window.GetWindow(this).Content = new MainMenu();
		}

		private void Calculate(object sender, RoutedEventArgs e)
		{
			try
			{
				double t = double.Parse(timeTextBox.Text),
					step = double.Parse(stepTextBox.Text);

				var dataX = new List<double>();
				var dataY = new List<double>();

				if (funcPicker.SelectedItem is FuncData funcData)
				{
					for (double R = 0; R <= t; R += step)
					{
						double r0 = t - R - step;

						dataX.Add(R);

						dataY.Add(PreciseCalc.SympsonWaveEq(funcData.PreciseFunc, r0, t, R));
					}
				}

				else 
				{
					throw new Exception();
				}

				WavePlot.Plot.Clear();
				WavePlot.Plot.Add.Scatter(dataX, dataY);
				WavePlot.Plot.Axes.AutoScale();
				WavePlot.Refresh();

				errorMessage.Visibility = Visibility.Hidden;
			}

			catch
			{
				errorMessage.Visibility = Visibility.Visible;
			}
		}
	}
}
