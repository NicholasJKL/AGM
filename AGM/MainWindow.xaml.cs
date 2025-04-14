using System;
using System.Windows;


namespace AGM
{
    public partial class MainWindow : Window
    {
        public static int Precision { get; set; } = 4;

        public MainWindow()
        {
            InitializeComponent();

            this.Content = new MainMenu();
        }
	}
}
