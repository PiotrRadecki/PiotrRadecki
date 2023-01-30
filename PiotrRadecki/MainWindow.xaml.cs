using System.Windows;

using System.Windows.Controls;


namespace PiotrRadecki
{
    public partial class MainWindow : Window
    {
            enum Operations
            {
                empty = 0,
                add,
                sub,
                mult,
                div,
                result
            }

            private string firstValue;
            private string secondValue;
            private Operations LastOperation = Operations.empty;

            private void NumButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
            {
                if (TextBlok.Text == "0")
                {
                    TextBlok.Text = string.Empty;
                }

                if (Operations.result == LastOperation)
                {
                    TextBlok.Text = string.Empty;
                    LastOperation = Operations.empty;
                }

                Button oButton = (Button)oSender;
                TextBlok.Text += oButton.Content;

                if (LastOperation != Operations.empty)
                {
                    secondValue += oButton.Content;
                }
            }

            private void ResultButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
            {

                if ((Operations.result == LastOperation) || (Operations.empty == LastOperation))
                {
                    return;
                }

                if (string.IsNullOrEmpty(TextBlok.Text))
                {
                    TextBlok.Text = "0";
                }

                var firstNum = double.Parse(firstValue);
                var secondNum = double.Parse(secondValue);

                switch (LastOperation)
                {
                    case Operations.add:
                        TextBlok.Text = (firstNum + secondNum).ToString();
                        break;
                    case Operations.sub:
                        TextBlok.Text = (firstNum - secondNum).ToString();
                        break;
                    case Operations.mult:
                        TextBlok.Text = (firstNum * secondNum).ToString();
                        break;
                    case Operations.div:
                        if (secondNum == 0)
                        {
                            MessageBox.Show("Nie można dzielić przez zero!");
                            TextBlok.Text = string.Empty;
                            break;
                        }
                        else
                        {
                            TextBlok.Text = (firstNum / secondNum).ToString();
                            break;
                        }
                }

                LastOperation = Operations.result;
                firstValue = secondValue;
                secondValue = string.Empty;
            }

            private void OperationButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
            {

                firstValue = TextBlok.Text;

                if ((Operations.empty != LastOperation) || (Operations.result != LastOperation))
                {
                    ResultButton_Click(this, eRoutedEventArgs);
                }

                Button oButton = (Button)oSender;

                switch (oButton.Content.ToString())
                {
                    case "+":
                        LastOperation = Operations.add;
                        break;
                    case "-":
                        LastOperation = Operations.sub;
                        break;
                    case "*":
                        LastOperation = Operations.mult;
                        break;
                    case "/":
                        LastOperation = Operations.div;
                        break;
                    default:
                        MessageBox.Show("Nieznana operacja!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                }

                TextBlok.Text = oButton.Content.ToString();
            }

            private void ClearButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
            {
                TextBlok.Text = string.Empty;
                LastOperation = Operations.empty;
                firstValue = string.Empty;
                secondValue = string.Empty;
            }

            private void DotButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
            {
                if (Operations.result == LastOperation)
                {
                    TextBlok.Text = string.Empty;
                    LastOperation = Operations.empty;
                }
                if ((TextBlok.Text.Contains(',')) || (0 == TextBlok.Text.Length))
                {
                    return;
                }
                TextBlok.Text += ",";
            }

            public MainWindow()
            {
                InitializeComponent();
                TextBlok.Text = "0";
            }
        }
    }
