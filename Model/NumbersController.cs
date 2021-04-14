using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home0422_2048.Model
{

    public class NumbersController
    {
        public NumbersController()
        {
            ResetGame();
        }
        public int _score = 0;
        public int _highScore = 0;
        public bool IsGameOver { get; set; }
        private string _path = (Directory.GetCurrentDirectory() + @"\highScore.txt");

        public NumbersModel NumberModel = new NumbersModel();


        #region SetNumber Reset
        public void SetNewNumber()
        {
            Random rand = new();
            var x = NumberModel.FreeCells;
            if (x.Count == 0)
            {
                IsGameOver = true;
                return;
            }
            else
            {
                int n = rand.Next(0, x.Count);
                NumberModel.Numbers[NumberModel.FreeCells[n].I, NumberModel.FreeCells[n].J]
                    = NumberModel.NewNumber[rand.Next(0, 10)];
            }
        }
        public void ResetGame()
        {
            _score = 0;
            ReadHighScore();
            NumberModel.Numbers = new int[,]
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };
            SetNewNumber();
            SetNewNumber();
            
        }
        #endregion

        #region Count Move
        private void CountScores()
        {
            if (_highScore < _score)
            {
                _highScore = _score;
                SaveHighScore();
            }
        }
        public void CountLeft()
        {
           
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    MoveLeft();

                    if (NumberModel.Numbers[i, j] != 0 && NumberModel.Numbers[i, j] == NumberModel.Numbers[i, j + 1])
                    {
                        NumberModel.Numbers[i, j] += NumberModel.Numbers[i, j + 1];
                        NumberModel.Numbers[i, j + 1] = 0;
                        _score += NumberModel.Numbers[i, j];
                    }
                }
            }
            CountScores();
            SetNewNumber();
        }
        private void MoveLeft()
        {
            bool _changed = true;

            while (_changed)
            {
                _changed = false;
                for (int i = 0; i < 4; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        if (NumberModel.Numbers[i, j] == 0 && NumberModel.Numbers[i, j + 1] != 0)
                        {
                            NumberModel.Numbers[i, j] = NumberModel.Numbers[i, j + 1];
                            NumberModel.Numbers[i, j + 1] = 0;
                            _changed = true;
                        }
                    }
                }

            }
        }
        public void CountRight()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 3; j > 0; --j)
                {
                    MoveRight();
                    if (NumberModel.Numbers[i, j] != 0 && NumberModel.Numbers[i, j] == NumberModel.Numbers[i, j - 1])
                    {
                        NumberModel.Numbers[i, j] += NumberModel.Numbers[i, j - 1];
                        
                        NumberModel.Numbers[i, j - 1] = 0;
                        _score += NumberModel.Numbers[i, j];
                    }

                }
            }
            CountScores();
            SetNewNumber();
        }
        private void MoveRight()
        {
            bool _changed = true;

            while (_changed)
            {
                _changed = false;
                for (int i = 0; i < 4; ++i)
                {
                    for (int j = 3; j > 0; --j)
                    {
                        if (NumberModel.Numbers[i, j] == 0)
                        {
                            NumberModel.Numbers[i, j] = NumberModel.Numbers[i, j - 1];
                            NumberModel.Numbers[i, j - 1] = 0;
                        }
                    }
                }

            }

        }
        public void CountUp()
        {
            for (int j = 0; j < 4; ++j)
            {
                for (int i = 0; i < 3; ++i)
                {
                    MoveUp();
                    if (NumberModel.Numbers[i, j] != 0 && NumberModel.Numbers[i, j] == NumberModel.Numbers[i + 1, j])
                    {
                        NumberModel.Numbers[i, j] += NumberModel.Numbers[i + 1, j];
                        
                        NumberModel.Numbers[i + 1, j] = 0;
                        _score += NumberModel.Numbers[i, j];
                    }
                }
            }
            CountScores();
            SetNewNumber();
        }
        private void MoveUp()
        {
            bool _changed = true;

            while (_changed)
            {
                _changed = false;
                for (int j = 0; j < 4; ++j)
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        if (NumberModel.Numbers[i, j] == 0)
                        {
                            NumberModel.Numbers[i, j] = NumberModel.Numbers[i + 1, j];
                            NumberModel.Numbers[i + 1, j] = 0;
                        }
                    }
                }

            }
        }
        public void CountDown()
        {
            for (int j = 0; j < 4; ++j)
            {
                for (int i = 3; i > 0; --i)
                {
                    MoveDown();
                    if (NumberModel.Numbers[i, j] != 0 && NumberModel.Numbers[i, j] == NumberModel.Numbers[i - 1, j])
                    {
                        NumberModel.Numbers[i, j] += NumberModel.Numbers[i - 1, j];
                        
                        NumberModel.Numbers[i - 1, j] = 0;
                        _score += NumberModel.Numbers[i, j];
                    }
                }
            }
            CountScores();
            SetNewNumber();
        }
        private void MoveDown()
        {
            bool _changed = true;

            while (_changed)
            {
                _changed = false;
                for (int j = 0; j < 4; ++j)
                {
                    for (int i = 3; i > 0; --i)
                    {
                        if (NumberModel.Numbers[i, j] == 0)
                        {
                            NumberModel.Numbers[i, j] = NumberModel.Numbers[i - 1, j];
                            NumberModel.Numbers[i - 1, j] = 0;
                        }
                    }
                }
            }
        }
        #endregion

        #region Save Open
        private void SaveHighScore()
        {
            File.WriteAllText(_path, _highScore.ToString());
        }
        private void ReadHighScore()
        {
            if (File.Exists(_path))
            {
                string str = File.ReadAllText(_path);
                int tmp = 0;
                if (Int32.TryParse(str, out tmp)) _highScore = tmp;
            }
            else
            {
                File.Create(_path);
                _highScore = 0;
            }
        }
        #endregion

    }
}
