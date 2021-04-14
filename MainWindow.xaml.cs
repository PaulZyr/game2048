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
using Home0422_2048.Model;

namespace Home0422_2048
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NumbersViewModel numbersViewModel = new NumbersViewModel();
        public MainWindow()
        {
            DataContext = numbersViewModel;
            InitializeComponent();
            
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
            {
                numbersViewModel.CountLeft();
            }
            else if (e.Key == Key.Right)
            {
                numbersViewModel.CountRight();
            }
            else if (e.Key == Key.Up)
            {
                numbersViewModel.CountUp();
            }
            else if (e.Key == Key.Down)
            {
                numbersViewModel.CountDown();
            }
        }

        private void startNew_Click(object sender, RoutedEventArgs e)
        {
            numbersViewModel.NewGame();
        }
    }
}
