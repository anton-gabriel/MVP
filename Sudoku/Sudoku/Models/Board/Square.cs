using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sudoku.Models.Board
{
    internal class Square
    {
        #region Constructors
        public Square()
        {
            Pieces = new ObservableCollection<ObservableCollection<Piece>>();
        }
        #endregion

        #region Properties
        public ObservableCollection<ObservableCollection<Piece>> Pieces { get; set; }
        #endregion

        #region Public methods
        public List<Piece> GetLine(int line)
        {
            return Pieces[line].ToList();
        }
        public List<Piece> GetColumn(int column)
        {
            List<Piece> pieces = new List<Piece>();
            for (int index = 0; index < Pieces.Count; ++index)
            {
                pieces.Add(Pieces[index][column]);
            }
            return pieces;
        }
        #endregion
    }
}