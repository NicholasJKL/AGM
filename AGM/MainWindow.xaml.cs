using System;
using System.Windows;


namespace AGM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonMathPendulumClick(object sender, RoutedEventArgs e)
        {
            this.Content = new MathPendulum();
        }

        private void ButtonWaveEqClick(object sender, RoutedEventArgs e) 
        {
            this.Content = new WaveEq();
        }

	}
}
