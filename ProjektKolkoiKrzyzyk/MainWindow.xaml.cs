using System.Windows;
using System.Windows.Controls;

namespace ProjektKolkoiKrzyzyk
{

    public partial class MainWindow : Window
    {
        public bool IsPlayer1Turn { get; set; } = true;
        public int Counter { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        public void NewGame()
        {
            IsPlayer1Turn = false;
            Counter = 0;

            Button_0_0.Content = string.Empty;
            Button_0_0.Content = string.Empty;
            Button_0_0.Content = string.Empty;
            Button_0_0.Content = string.Empty;
            Button_0_0.Content = string.Empty;
            Button_0_0.Content = string.Empty;
            Button_0_0.Content = string.Empty;
            Button_0_0.Content = string.Empty;
            Button_0_0.Content = string.Empty;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsPlayer1Turn ^= true;
            Counter++;

            if (Counter > 9)
            {
                NewGame();
                return;
            }

            var button = sender as Button;

            button.Content = "X";

            if (IsPlayer1Turn)
                button.Content = "O";
            else
                button.Content = "X";

            button.Content = IsPlayer1Turn ? "O" : "X";
        }
    }
}
