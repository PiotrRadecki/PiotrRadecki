using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProjektKolkoiKrzyzyk
{

    public partial class MainWindow : Window
    {
        Game gra = new Game();

        string User = "X";

        public MainWindow()
        {
            InitializeComponent();
            ctlGrid.DataContext = gra;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            gra.tab[Convert.ToInt16(btn.Tag)] = User;
            if (User == "X")
                User = "O";
            else
                User = "X";
            gra.ValuateWinCndition();
        }
    }
    class StringToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string && (string)value == "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Boolean && (Boolean)value)
            {
                return "";
            }
            else
            {
                return "";
            }

        }
    }
}
