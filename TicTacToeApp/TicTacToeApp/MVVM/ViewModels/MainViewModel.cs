using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using UnitsConverterApp.Core;

namespace TicTacToeApp.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private int _contentValue;
        public int ContentValue
        {
            get => _contentValue; 
            set
            {
                _contentValue = value;
                OnPropertyChanged(nameof(ContentValue));
            }
        }



        #region Commands

        private ICommand _playerPutsASign;
        public ICommand PlayerPutsASign
        {
            get
            {
                if (_playerPutsASign == null) _playerPutsASign = new RelayCommand(
                    (object o) =>
                    {
                        var clickedButton = o.ToString();
                        Button bt = new Button();
                        bt.Content = "ASD";
                    },
                    (object o) => true);
                return _playerPutsASign;
            }
        }

        #endregion
    }
}
