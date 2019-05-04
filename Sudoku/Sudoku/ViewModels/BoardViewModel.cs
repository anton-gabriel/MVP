using Sudoku.Commands;
using Sudoku.Models.Board;
using Sudoku.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Sudoku.ViewModels
{
    class BoardViewModel
    {
        #region Constructors
        public BoardViewModel()
        {
            //hardcoded
            List<List<Piece>> pieces = new List<List<Piece>>();
            for (int i = 0; i < 9; i++)
            {
                List<Piece> list = new List<Piece>();
                for (int j = 0; j < 9; j++)
                {
                    list.Add(new Piece { Value = (uint) (i+j), Enabled = true });
                }
                pieces.Add(list);
            }

            Board = BoardConverter.ToBoard(pieces);
            List<List<Piece>> boardPieces = BoardConverter.FromBoard(Board);
            string text = "";
            foreach (var line in boardPieces)
            {
                foreach (var item in line)
                {
                    text += item.Value.ToString() + " ";
                }
                text += System.Environment.NewLine;
            }
            MessageBox.Show(text);
        }
        #endregion

        #region Private fields
        uint boardSize;
        #endregion

        #region Properties
        public Board Board { get; set; }
        public ObservableCollection<ObservableCollection<Square>> Squares
        {
            get => Board.Squares;
            set => Board.Squares = value;
        }
        public uint BoardSize
        {
            get => this.boardSize;
            set
            {
                this.boardSize = value;
                CanGenerate = BoardChecker.IsBoardSizeValid(size: BoardSize);
            }
        }
        public bool CanGenerate { get; set; }
        #endregion

        #region Commands
        ICommand generate;
        public ICommand Generate
        {
            get
            {
                if (this.generate == null)
                {
                    this.generate = new RelayCommand(param => CanGenerate, param => LoadBoard());
                }
                return this.generate;
            }
        }
        //De adaugat comanda pentru load - care va incarca jocul din fisierul asociat jucatorului curent
        //                          check - care va verifica daca jocul curent e gata
        //                          start - care va incepe jocul (timer-ul)
        #endregion

        #region Private methods
        private void LoadBoard()
        {
            //De inmpartit in doua metode, una GenerateBoard, alta LoadBoard
            //Board = new Board(BoardSize);
        }
        #endregion
    }
}
