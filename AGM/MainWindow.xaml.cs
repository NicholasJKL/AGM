using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MAGM(3, 4);
            InitializeComponent();
        }

        public double AGM(double a, double b)
        {
            while (Math.Abs(a - b) > 10E-6)
            {
                a = (a + b) / 2;
                b = Math.Sqrt(a * b);

                Debug.Print($"a - {a}");
                Debug.Print($"b - {b}");
            }

            return a;
        }

        public double MAGM(double a, double b)
        {
            double c = 0;

            while (Math.Abs(a - b) > 10E-6)
            {
                a = (a + b) / 2;
                b = c + Math.Sqrt((a - c)*(b-c));
                c = c - Math.Sqrt((a - c)*(b-c));

                Debug.Print($"a - {a}");
                Debug.Print($"b - {b}");
            }


            return a;
        }

        private void ButtonMathPendulum_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MathPendulum();
        }
    }
}
