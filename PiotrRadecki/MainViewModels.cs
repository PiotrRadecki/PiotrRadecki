using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xaml;

namespace PiotrRadecki
{
    internal class MainViewModels : INotifyPropertyChanged
    {
        public MainViewModels()
        {
            ScreenVal = "0";
            AddNumberCommand = new RelayCommand(AddNumber);
            AddNumberCommand = new RelayCommand(AddOperation);
        }

        private void AddOperation(object obj)
        {

        }

        private void AddNumber(object obj)
        {
            
        }

        public ICommand AddNumberCommand { get; set; }

        private string _screenVal;
        private string ScreenVal
        {
            get { return _screenVal; }
            set
            {
                _screenVal = value;
                OnPropertyChanged();
            }
        }



        public event PropertyChangedEventHandler
            PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
