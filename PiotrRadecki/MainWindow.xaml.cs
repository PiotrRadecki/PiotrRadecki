using System.Windows;
using System.Windows.Controls;

namespace PiotrRadecki
{
    public partial class MainWindow : Window
    {
   
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModels();
        }
    }
}
