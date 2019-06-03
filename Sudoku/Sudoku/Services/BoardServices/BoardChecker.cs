using Sudoku.Models.Board;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Services.BoardServices
{
    internal static class BoardChecker
    {
        #region Private methods
        private static int GetSquareIndex(int boardSize, int index)
        {
            return (int)Math.Truncate(decimal.Divide(index, boardSize));
        }
        #endregion

        #region Public methods
        public static bool IsBoardSizeValid(int size)
        {
            return size <= 0 ? false : Math.Sqrt(size) % 1 == 0;
        }
        public static bool IsBoardSquareValid(Square square)
        {
            List<Piece> pieces = square.Pieces.SelectMany(piece => piece).ToList();
            return pieces.Count != pieces.Distinct().Count();
        }
        public static bool IsBoardLineValid(Board board, int lineIndex)
        {
            int squareIndex = GetSquareIndex(board.Size, lineIndex);
            List<Piece> pieces = new List<Piece>();
            for (int index = 0; index < board.Size; ++index)
            {
                pieces.AddRange(board.Squares[squareIndex][index].GetLine(line: lineIndex % board.Size));
            }
            return pieces.Count != pieces.Distinct().Count();
        }
        public static bool IsBoardColumnValid(Board board, int columnIndex)
        {
            int squareIndex = GetSquareIndex(board.Size, columnIndex);
            List<Piece> pieces = new List<Piece>();
            for (int index = 0; index < board.Size; ++index)
            {
                pieces.AddRange(board.Squares[index][squareIndex].GetColumn(column: columnIndex % board.Size));
            }
            return pieces.Count != pieces.Distinct().Count();
        }

        public static bool CheckBoard(Board board)
        {
            int numberOfPieces = board.Size * board.Size;
            for (int index = 0; index < numberOfPieces; ++index)
            {
                if (!IsBoardLineValid(board, index))
                {
                    return false;
                }
            }
            for (int index = 0; index < numberOfPieces; ++index)
            {
                if (!IsBoardColumnValid(board, index))
                {
                    return false;
                }
            }
            return board.Squares.SelectMany(square => square).Count(square => !IsBoardSquareValid(square)) != 0;
        }
        #endregion
    }
}
