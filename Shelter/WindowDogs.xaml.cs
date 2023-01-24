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
    /// Logika interakcji dla klasy WindowDogs.xaml
    /// </summary>
    public partial class WindowDogs : Window
    {
        public WindowDogs()
        {
            InitializeComponent();
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
        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            MainWindow winhome = new MainWindow();
            winhome.Show();
            this.Close();
        }
    }
}
