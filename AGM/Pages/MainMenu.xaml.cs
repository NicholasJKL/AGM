using AGM.Pages;
using System.Windows;
using System.Windows.Controls;


namespace AGM
{
	public partial class MainMenu : Page
	{
		public MainMenu()
		{
			InitializeComponent();

			precisionBox.Text = MainWindow.Precision.ToString();
		}

		private void ButtonMathPendulumClick(object sender, RoutedEventArgs e)
		{
			Window.GetWindow(this).Content = new MathPendulum();
		}

		private void ButtonEllipseLenClick(object sender, RoutedEventArgs e)
		{
			Window.GetWindow(this).Content = new EllipseLen();
		}

		private void ButtonWaveEqClick(object sender, RoutedEventArgs e)
		{
			Window.GetWindow(this).Content = new WaveEq();
		}

		private void PrecisionChanged(object sender, TextChangedEventArgs e)
		{
			if (int.TryParse(precisionBox.Text, out int result) && result >= 0 && result <= 12)
			{
				MainWindow.Precision = result;
			}
			else 
			{
				precisionBox.Text = "4";
			}
		}
	}
}
