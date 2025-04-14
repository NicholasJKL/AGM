using System;
using System.Windows;
using System.Windows.Controls;


namespace AGM.Pages
{
	public partial class EllipseLen : Page
	{
		public EllipseLen()
		{
			InitializeComponent();
		}

		private void GoBack(object sender, RoutedEventArgs e)
		{
			Window.GetWindow(this).Content = new MainMenu();
		}

		private void ResultToEmpty(object sender, RoutedEventArgs e)
		{
			if (ellipseLenResult != null)
			{
				ellipseLenResult.Text = "Результат P = ";
			}
		}

		private void Calculate(object sender, RoutedEventArgs e)
		{
			try
			{
				double a = double.Parse(aTextBox.Text),
					b = double.Parse(bTextBox.Text);

				if (a < 0 || b < 0)
				{
					throw new Exception();
				}

				double P = 2 * Math.PI * (PreciseCalc.MAGM(Math.Pow(a, 2), Math.Pow(b, 2), MainWindow.Precision) / PreciseCalc.AGM(a, b, MainWindow.Precision));

				ellipseLenResult.Text = $"Результат P = {Math.Round(P, MainWindow.Precision, MidpointRounding.AwayFromZero)}";

				errorMessage.Visibility = Visibility.Hidden;

			}
			catch
			{
				errorMessage.Visibility = Visibility.Visible;
			}
		}
	}
}
