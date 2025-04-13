using System;
using System.Windows;


namespace AGM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Content = new MainMenu();
        }
	}
}
