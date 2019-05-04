using Sudoku.Models.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Services
{
    internal static class BoardGenerator
    {
        #region Public methods
        public static Board Generate(int size)
        {
            //1. generare matrice de piese
            // - https://stackoverflow.com/questions/5636438/difference-between-two-lists
            //2. conversie la tipul Board
          
            //return new Board....
            return new Board();
        }

        #endregion

        #region Private methods
        private static Piece BuildPiece(uint value)
        {
            return new Piece()
            {
                Value = value,
                Enabled = false
            };
        }
        #endregion
    }
}
