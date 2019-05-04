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
            // - folosind CopyBlocks..? vezi stackoverflow => se poate crea o clasa separata
            //   numita BoardConverter care converteste o matrice[,] de pieces(sau uint) care
            //   poata fi folosita si la citirea din fisier si salvare (adica
            //      public static Board ToBoard(Pieces [,]) si 
            //      public static Pieces[,] FromBoard(Board)
            //          prima functie va fi folosita in clasa BoardGenerator
            //          iar ambele vor fi folosite pt citirea si salvarea in fisier

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
