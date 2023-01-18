using System.Windows;

namespace Serializacja
{
    public partial class Window1 : Window
    {
        public bool IsOkPressed { get; set; }
        public Window1()
        {
            InitializeComponent();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsOkPressed = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IsOkPressed = false;
            this.Close();
        }
    }
}
