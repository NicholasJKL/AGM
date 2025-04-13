using System;
using System.Windows;
using System.Windows.Controls;


namespace AGM
{
	public partial class MathPendulum : Page
	{
		bool _isDragging = false;

		public MathPendulum()
		{
			InitializeComponent();
		}

		private void ResultToEmpty(object sender, RoutedEventArgs e)
		{
			if (pendulumPeriodResult != null)
			{
				pendulumPeriodResult.Text = "Результат T = ";
			}
		}

		private void Calculate(object sender, RoutedEventArgs e)
		{
			try
			{
				double l = double.Parse(lenTextBox.Text),
					phi = double.Parse(angleTextBox.Text),
					g = double.Parse(gTextBox.Text);

				if (l < 0 || phi < 0 || g < 0)
				{
					throw new Exception();
				}

				double T = (2 * Math.PI * Math.Sqrt(l / g)) / PreciseCalc.AGM(1, Math.Cos((phi * Math.PI / 180) / 2));

				pendulumPeriodResult.Text = $"Результат T = {T}";

				errorMessage.Visibility = Visibility.Hidden;

			}
			catch
			{
				errorMessage.Visibility = Visibility.Visible;
			}
		}

		private void GoBack(object sender, RoutedEventArgs e)
		{
			Window.GetWindow(this).Content = new MainMenu();
		}
	}
}
