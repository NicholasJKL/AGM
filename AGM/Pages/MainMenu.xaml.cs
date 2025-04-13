using AGM.Pages;
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
	public partial class MainMenu : Page
	{
		public MainMenu()
		{
			InitializeComponent();
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
	}
}
