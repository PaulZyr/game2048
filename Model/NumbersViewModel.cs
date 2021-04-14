using sabatex.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home0422_2048.Model
{
    public class NumbersViewModel : ObservableObject
    {
        public NumbersViewModel()
        {
            _numbersController = new NumbersController();
            NewGame();
        }
        private NumbersController _numbersController;
        public ObservableCollection<ObservableCollection<string>> Cells { get; set; } 
            = new ObservableCollection<ObservableCollection<string>>
            {
                new ObservableCollection<string> { "", "", "", "" },
                new ObservableCollection<string> { "", "", "", "" },
                new ObservableCollection<string> { "", "", "", "" },
                new ObservableCollection<string> { "", "", "", "" },
                new ObservableCollection<string> { "", "" }
            };
        #region NewGame Cells Scores
        public void NewGame()
        {
            _numbersController.ResetGame();
            CreateCells();
            SetScores();
        }
        private void CreateCells()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if(_numbersController.NumberModel.Numbers[i,j] == 0)
                    {
                        Cells[i][j] = "";
                    }
                    else
                    {
                        Cells[i][j] = _numbersController.NumberModel.Numbers[i, j].ToString();
                    }
                }
            }
        }
        private void SetScores()
        {
            Cells[4][0] = _numbersController._score.ToString();
            Cells[4][1] = _numbersController._highScore.ToString();
        }
        #endregion

        #region Count
        public void CountLeft()
        {
            _numbersController.CountLeft();
            CreateCells();
            SetScores();
            CheckGameOver();
        }
        public void CountRight()
        {
            _numbersController.CountRight();
            CreateCells();
            SetScores();
            CheckGameOver();
        }
        public void CountUp()
        {
            _numbersController.CountUp();
            CreateCells();
            SetScores();
            CheckGameOver();
        }
        public void CountDown()
        {
            _numbersController.CountDown();
            CreateCells();
            SetScores();
            CheckGameOver();
        }
        #endregion

        #region GameOver
        private void CheckGameOver()
        {
            if (_numbersController.IsGameOver)
            {
                GameOver();
            }
        }
        private void GameOver()
        {
            string str = "";
            if (_numbersController._score >= 2048) str += "You WIN!!!";
            else str += "Game Over!";
            str += Environment.NewLine;
            if (_numbersController._score == _numbersController._highScore)
            {
                str += $"Your result: {_numbersController._score} - is the Best for now";
            }
            else str += $"Your Result: {_numbersController._score}";
            str += Environment.NewLine + "New game?";
            if (MessageBox.Show(str, "New Game?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                NewGame();
            }
        }
        #endregion
    }
}
