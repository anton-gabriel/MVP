using Sudoku.Models.Board;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sudoku.Services.BoardServices
{
    internal static class BoardConverter
    {
        #region Public methods
        public static Board ToBoard(List<List<Piece>> pieces)
        {
            int size = pieces.Count;
            int numberOfSquares = (int)Math.Sqrt(size);

            Board board = new Board();
            for (int lineIndex = 0; lineIndex < size; lineIndex += numberOfSquares)
            {
                var lines = pieces.Skip(lineIndex).Take(numberOfSquares);
                ObservableCollection<Square> squares = new ObservableCollection<Square>();
                for (int columnIndex = 0; columnIndex < size; columnIndex += numberOfSquares)
                {
                    Square square = new Square();
                    foreach (var line in lines)
                    {
                        var segment = line.Skip(columnIndex).Take(numberOfSquares);
                        square.Pieces.Add(new ObservableCollection<Piece>(segment));
                    }
                    squares.Add(square);
                }
                board.Squares.Add(squares);
            }

            return board;
        }
        public static List<List<Piece>> FromBoard(Board board)
        {
            List<List<Piece>> pieces = new List<List<Piece>>();
            foreach (var line in board.Squares)
            {
                for (int lineIndex = 0; lineIndex < board.Size; ++lineIndex)
                {
                    List<Piece> linePieces = new List<Piece>();
                    foreach (var square in line)
                    {
                        linePieces.AddRange(square.GetLine(lineIndex));
                    }
                    pieces.Add(linePieces);
                }
            }
            return pieces;
        }
        #endregion
    }
}
