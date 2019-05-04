using System;
using System.Collections.ObjectModel;

namespace Sudoku.Models.Board
{
    class Board
    {
        #region Constructors
        public Board()
        {
            Squares = new ObservableCollection<ObservableCollection<Square>>();
        }
        #endregion

        #region Properties
        public ObservableCollection<ObservableCollection<Square>> Squares { get; set; }
        public int Size => Squares.Count;
        #endregion
    }
}
