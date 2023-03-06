using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TicTacToeAutoGenerating.MVVM.Models;
using TicTacToeAutoGenerating.MVVM.Views.ControlDescription;

namespace TicTacToeAutoGenerating.MVVM.Repository
{
    public class TicTacToeRepo
    {
        MainModel model = new MainModel();

        public void GetButtonsContent(ObservableCollection<FieldDescription> buttonsList)
        {
            model.buttonsContentList = new List<string>();

            foreach (var item in buttonsList)
            {
                model.buttonsContentList.Add(item.Name);
            }
        }

        public bool IsVerticalWin(int buttonsInRow)
        {
            List<string> verticalButtons = new List<string>();

            for (int j = 0; j < buttonsInRow; j++)
            {
                for (int i = j; i < model.buttonsContentList.Count; i += buttonsInRow)
                    verticalButtons.Add(model.buttonsContentList[i]);

                if (!verticalButtons.Any(o => o != verticalButtons[0]) && verticalButtons[0] != string.Empty)
                    return true;

                verticalButtons.Clear();
            }

            return false;
        }

        public bool IsHorizontalWin(int buttonsInRow)
        {
            List<string> horizontalButtons = new List<string>();

            for (int j = 0; j < model.buttonsContentList.Count; j += buttonsInRow)
            {
                for (int i = j; i < (buttonsInRow + j); i++)
                    horizontalButtons.Add(model.buttonsContentList[i]);

                if (!horizontalButtons.Any(o => o != horizontalButtons[0]) && horizontalButtons[0] != string.Empty)
                    return true;

                horizontalButtons.Clear();
            }

            return false;
        }

        public bool IsLesftCrossWin(int buttonsInRow)
        {
            List<string> leftCrossButtons = new List<string>();

            for (int i = 0; i < model.buttonsContentList.Count; i += (buttonsInRow + 1))
                leftCrossButtons.Add(model.buttonsContentList[i]);

            if (!leftCrossButtons.Any(o => o != leftCrossButtons[0]) && leftCrossButtons[0] != string.Empty)
                return true;

            leftCrossButtons.Clear();
            
            return false;
        }

        public bool IsRightCrossWin(int buttonsInRow)
        {
            List<string> rightCrossButtons = new List<string>();

            for (int i = (buttonsInRow - 1); i < model.buttonsContentList.Count - 1; i += (buttonsInRow - 1))
                rightCrossButtons.Add(model.buttonsContentList[i]);

            if (!rightCrossButtons.Any(o => o != rightCrossButtons[0]) && rightCrossButtons[0] != string.Empty)
                return true;

            rightCrossButtons.Clear();

            return false;
        }

        public bool IsRemis(ObservableCollection<FieldDescription> buttonsList)
        {
            foreach (var item in buttonsList)
            {
                if (item.Name == string.Empty || item.Name == null)
                    return false;
            }
            
            return true;
        }

        public bool DoesAnybodyWon(int btnsInRow)
        {
            if (IsHorizontalWin(btnsInRow) || IsVerticalWin(btnsInRow) || IsLesftCrossWin(btnsInRow) || IsRightCrossWin(btnsInRow))
                return true;

            return false;
        }

        public void RestartGame(ObservableCollection<FieldDescription> buttonsList)
        {
            foreach (var item in buttonsList)
                item.Name = string.Empty;       
        }
    }
}
 