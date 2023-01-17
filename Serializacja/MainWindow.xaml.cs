using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Serializacja
{
    public partial class MainWindow : Window
    {
        List<Person> listOfPersons = new List<Person>();
        public MainWindow()
        {
        InitializeComponent();
            if (File.Exists("test.xml"))
            {
                listOfPersons = Serializacjaa.DeserializeToObject<List<Person>>("\"\\\\Mac\\Home\\Desktop\"");            }
            else
            {
                listOfPersons.Add(new Person("Imie", "Nazwisko"));
                listOfPersons.Add(new Person("Imie", "Nazwisko"));
                listOfPersons.Add(new Person("Imie", "Nazwisko"));
                listOfPersons.Add(new Person("Imie", "Nazwisko"));
            }
            dataGridPerson.ItemsSource = listOfPersons;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 okno = new Window1();
            Person osoba = new Person();
            okno.DataContext = osoba;
            okno.ShowDialog();
            if (okno.IsOkPressed)
            {
                listOfPersons.Add(osoba);
                dataGridPerson.Items.Refresh();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataGridPerson.SelectedItem != null)
            {
                Window1 okno = new Window1();
                Person osoba = new Person((Person)dataGridPerson.SelectedItem);
                okno.DataContext = osoba;
                okno.ShowDialog();
                if (okno.IsOkPressed)
                {
                    int index = listOfPersons.IndexOf((Person)dataGridPerson.SelectedItem);
                    listOfPersons[index] = osoba;
                    dataGridPerson.Items.Refresh();
                }
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serializacjaa.SerializeToXml<List<Person>>(listOfPersons, @"C:\\Users\\piotrek\\Source\\Repos\\PiotrRadecki\\Serializacja\readAndSave\test.xml");
        }
    }
}
