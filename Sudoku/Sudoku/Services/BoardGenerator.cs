using Sudoku.Models.Board;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Services
{
    internal static class BoardGenerator
    {
        #region Public methods
        public static Board Generate(int size)
        {
            return BoardConverter.ToBoard(BuildBoard(size));
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
        private static List<int> GetInterval(int size)
        {
            return Enumerable.Range(1, size).ToList();
        }
        private static List<int> GetAvailableNumbers(List<int> numbers, List<int> interval)
        {
            return interval.Except(numbers).ToList();
        }

        private static List<List<Piece>> BuildBoard(int size)
        {
            List<List<Piece>> pieces = new List<List<Piece>>();
            Random random = new Random();
            var interval = GetInterval(size);

            for (int lineIndex = 0; lineIndex < size; ++lineIndex)
            {
                List<Piece> line = new List<Piece>();
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    if (random.Next(0, 2) == 0)
                    {
                        line.Add(BuildPiece((uint)interval[random.Next(0, interval.Count)]));
                    }
                    else
                    {
                        line.Add(new Piece { Value = 0, Enabled = true });
                    }
                }
                pieces.Add(line);
            }
            return pieces;
        }

        #endregion
    }
}
