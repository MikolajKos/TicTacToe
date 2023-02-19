using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitsConverterApp.Core;

namespace TicTacToeAutoGenerating.MVVM.Views.ControlDescription
{
    public class FieldDescription : ObservableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int _buttonWidth;

        public int ButtonWidth
        {
            get => _buttonWidth;
            set
            {
                _buttonWidth = value;
                OnPropertyChanged(nameof(ButtonWidth));
            }
        }

        private int _buttonHeight;

        public int ButtonHeight
        {
            get => _buttonHeight;
            set
            {
                _buttonHeight = value;
                OnPropertyChanged(nameof(ButtonHeight));
            }
        }

        public ICommand Command { get; set; }
    }
}
