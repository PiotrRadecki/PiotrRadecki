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

namespace Shelter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(Home);
        }
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Cats(object sender, RoutedEventArgs e)
        {
            WindowCats wincats = new WindowCats();
            wincats.Show();
            this.Close();
        }
        private void Button_Click_Dogs(object sender, RoutedEventArgs e)
        {
            WindowDogs windogs = new WindowDogs();
            windogs.Show();
            this.Close();
        }

        public void SetActiveUserControl(UserControl control)
        {
            Home.Visibility = Visibility.Collapsed;
            Cats.Visibility = Visibility.Collapsed;
            Dogs.Visibility = Visibility.Collapsed;

            control.Visibility = Visibility.Visible;
        }
    }
}
