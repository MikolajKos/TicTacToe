using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TicTacToeAutoGenerating.MVVM.Repository;
using TicTacToeAutoGenerating.MVVM.Views.ControlDescription;
using UnitsConverterApp.Core;

namespace TicTacToeAutoGenerating.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        TicTacToeRepo repo = new();

        //true for "O", false for "X"
        private bool currentPlayer = true;

        private int _buttonsInRow = 3;
        public int ButtonsInRow
        {
            get => _buttonsInRow;
            set
            {
                _buttonsInRow = value;
                OnPropertyChanged(nameof(ButtonsInRow));
            }
        }

        private int _xResult = 0;
        public int XResult
        {
            get => _xResult;
            set
            {
                _xResult = value;
                OnPropertyChanged(nameof(XResult));
            }
        }

        private int _oResult = 0;
        public int OResult
        {
            get => _oResult;
            set
            {
                _oResult = value;
                OnPropertyChanged(nameof(OResult));
            }
        }


        //private ObservableCollection<FieldDescription> _boardList;
        public ObservableCollection<FieldDescription> BoardList { get; set; }

        public MainViewModel()
        {
            BoardList = new ObservableCollection<FieldDescription>();

            for (int i = 0; i < (ButtonsInRow * ButtonsInRow); i++)
            {
                BoardList.Add(new FieldDescription()
                {
                    Name = string.Empty,
                    ButtonWidth = 500 / ButtonsInRow,
                    ButtonHeight = 500 / ButtonsInRow,
                    Command = PropertiesNameCommand
                });
            }

        }

        private ICommand fieldNameCommand;
        public ICommand PropertiesNameCommand
        {
            get
            {
                if (fieldNameCommand == null)
                    fieldNameCommand = new RelayCommand<FieldDescription>(
                        o =>
                        {
                            o.Name = currentPlayer ? "◯" : "╳";
                            currentPlayer = !currentPlayer;

                            repo.GetButtonsContent(BoardList);

                            if (repo.DoesAnybodyWon(ButtonsInRow))
                            {
                                //Add point to player result
                                if (o.Name == "◯")
                                    OResult++;
                                else XResult++;

                                MessageBox.Show($"Player {o.Name} won!");
                                repo.RestartGame(BoardList);
                                


                                //sets O as default player
                                currentPlayer = true;
                            }
                            
                        },
                        o =>
                        {
                            if (o?.Name != string.Empty) return false;

                            return true;
                        });
                return fieldNameCommand;
            }
        }

        private ICommand _restartCommand;
        public ICommand RestartCommand
        {
            get
            {
                if (_restartCommand == null)
                    _restartCommand = new RelayCommand<FieldDescription>(
                        o =>
                        {
                            repo.RestartGame(BoardList);

                            OResult = 0;
                            XResult = 0;
                        });
                return _restartCommand;
            }
        }

    }
}
