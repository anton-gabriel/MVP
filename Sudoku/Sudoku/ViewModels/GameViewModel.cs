using Sudoku.Commands;
using Sudoku.Models.Board;
using Sudoku.Services.BoardServices;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Sudoku.ViewModels
{
    internal class GameViewModel : Models.Utils.NotifyPropertyChanged
    {
        #region Constructors
        public GameViewModel()
        {
            this.board = new Board();
        }
        #endregion

        #region Private fields
        private int newBoardSize;
        private readonly Board board;
        #endregion

        #region Properties
        public ObservableCollection<ObservableCollection<Square>> Squares
        {
            get => this.board?.Squares;
            set
            {
                this.board.Squares = value;
                OnPropertyChanged(propertyName: nameof(Squares));
            }
        }
        public int BoardSize
        {
            get => this.newBoardSize;
            set
            {
                this.newBoardSize = value;
                CanGenerate = BoardChecker.IsBoardSizeValid(size: value);
            }
        }


        public bool CanGenerate { get; private set; } = false;
        #endregion

        #region Commands
        ICommand generateBoardCommand;
        public ICommand GenerateBoardCommand
        {
            get
            {
                if (this.generateBoardCommand == null)
                {
                    this.generateBoardCommand = new RelayCommand(param => CanGenerate, param => GenerateBoard());
                }
                return this.generateBoardCommand;
            }
        }

        //ICommand startGameCommand;
        //public ICommand StartGameCommand
        //{
        //    get
        //    {
        //        if (this.startGameCommand == null)
        //        {
        //            this.startGameCommand = new RelayCommand(param => CanStart, param => StartGame());
        //        }
        //        return this.startGameCommand;
        //    }
        //}

        //ICommand checkBoardCommand;
        //public ICommand CheckBoardCommand
        //{
        //    get
        //    {
        //        if (this.checkBoardCommand == null)
        //        {
        //            this.checkBoardCommand = new RelayCommand(param => CanCheck, param => CheckBoard());
        //        }
        //        return this.checkBoardCommand;
        //    }
        //}

        ICommand loadBoardCommand;
        ICommand LoadBoardCommand
        {
            get
            {
                if (this.loadBoardCommand == null)
                {
                    this.loadBoardCommand = new RelayCommand(param => LoadBoard());
                }
                return this.loadBoardCommand;
            }
        }
        private ICommand exitCommand;
        public ICommand ExitCommand
        {
            get
            {
                if (this.exitCommand == null)
                {
                    this.exitCommand = new RelayCommand<Window>(CloseWindow);
                }
                return this.exitCommand;
            }
        }
        #endregion


        #region Private methods
        private void LoadBoard()
        {
            //Squares = BoardConverter.ToBoard()
        }
        private void GenerateBoard()
        {
            Squares = BoardGenerator.Generate(this.newBoardSize).Squares;
        }
        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
        #endregion
    }
}
