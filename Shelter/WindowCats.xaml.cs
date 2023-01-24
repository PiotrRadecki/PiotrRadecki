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
using System.Windows.Shapes;

namespace Shelter
{
    /// <summary>
    /// Logika interakcji dla klasy WindowCats.xaml
    /// </summary>
    public partial class WindowCats : Window
    {
        public WindowCats()
        {
            InitializeComponent();
        }
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_Dogs(object sender, RoutedEventArgs e)
        {
            WindowDogs windogs = new WindowDogs();
            windogs.Show();
            this.Close();
        }
        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            MainWindow winhome = new MainWindow();
            winhome.Show();
            this.Close();
        }
    }
}
