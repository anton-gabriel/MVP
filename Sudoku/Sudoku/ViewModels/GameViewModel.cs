using Sudoku.Commands;
using Sudoku.Models.Board;
using Sudoku.Models.Game;
using Sudoku.Models.User;
using Sudoku.Services;
using Sudoku.Services.BoardServices;
using Sudoku.Services.ReaderServices;
using Sudoku.Services.SerializationServices;
using Sudoku.Views;
using System;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace Sudoku.ViewModels
{
    internal class GameViewModel : Models.Utils.NotifyPropertyChanged
    {
        #region Constructors
        public GameViewModel()
        {
            GameSession = new GameSession();
            GameSession.AddHandler(GameTimerElapsed);
        }
        #endregion

        #region Private fields
        private GameSession gameSession;
        #endregion

        #region Properties
        public GameSession GameSession
        {
            get => this.gameSession;
            set
            {
                this.gameSession = value;
                OnPropertyChanged(propertyName: nameof(GameSession));
                OnPropertyChanged(propertyName: nameof(Board));
                OnPropertyChanged(propertyName: nameof(User));
            }
        }


        public User User
        {
            get => GameSession?.User;
            set
            {
                if (GameSession != null)
                {
                    GameSession.User = value;
                }
                OnPropertyChanged(propertyName: nameof(User));
            }
        }

        public Board Board
        {
            get => GameSession?.Board;
            set
            {
                if (GameSession != null)
                {
                    GameSession.Board = value;
                }
                OnPropertyChanged(propertyName: nameof(Board));
            }
        }

        public string DisplayTime
        {
            get
            {
                double interval = TimeSpan.FromHours(1).TotalMilliseconds - GameSession.Stopwatch.ElapsedMilliseconds;
                return TimeSpan.FromMilliseconds(interval).TotalMinutes.ToString() + ":" + TimeSpan.FromMilliseconds(interval).TotalSeconds.ToString();
            }
        }

        private bool CanCheckBoard => Board != null;
        private bool CanStartNewGameSession => User != null;
        private bool CanSaveGameSession => (Board != null) && (User != null);
        private bool CanOpenStatistics => User != null;
        private bool CanGenerateBoard => (User != null) && (GameMode == GameMode.Custom) && BoardChecker.IsBoardSizeValid(size: BoardGeneratorSize);
        public int BoardGeneratorSize { get; set; }
        public GameMode GameMode { get; private set; }

        #endregion


        #region Commands
        ICommand generateBoardCommand;
        public ICommand GenerateBoardCommand
        {
            get
            {
                if (this.generateBoardCommand == null)
                {
                    this.generateBoardCommand = new RelayCommand(param => CanGenerateBoard, param => GenerateBoard());
                }
                return this.generateBoardCommand;
            }
        }

        ICommand checkBoardCommand;
        public ICommand CheckBoardCommand
        {
            get
            {
                if (this.checkBoardCommand == null)
                {
                    this.checkBoardCommand = new RelayCommand(param => CanCheckBoard, param => CheckBoard());
                }
                return this.checkBoardCommand;
            }
        }


        ICommand startNewGameCommand;
        public ICommand StartNewGameCommand
        {
            get
            {
                if (this.startNewGameCommand == null)
                {
                    this.startNewGameCommand = new RelayCommand(param => CanStartNewGameSession, param => StartNewGameSession());
                }
                return this.startNewGameCommand;
            }
        }
        ICommand openGameCommand;
        public ICommand OpenGameCommand
        {
            get
            {
                if (this.openGameCommand == null)
                {
                    this.openGameCommand = new RelayCommand(param => LoadGameSession());
                }
                return this.openGameCommand;
            }
        }
        ICommand saveGameCommand;
        public ICommand SaveGameCommand
        {
            get
            {
                if (this.saveGameCommand == null)
                {
                    this.saveGameCommand = new RelayCommand(param => CanSaveGameSession, param => SaveGameSession());
                }
                return this.saveGameCommand;
            }
        }

        ICommand openStatisticsCommand;
        public ICommand OpenStatisticsCommand
        {
            get
            {
                if (this.openStatisticsCommand == null)
                {
                    this.openStatisticsCommand = new RelayCommand(param => CanOpenStatistics, param => OpenStatistics());
                }
                return this.openStatisticsCommand;
            }
        }

        private ICommand standardGameCommand;
        public ICommand StandardGameCommand
        {
            get
            {
                if (this.standardGameCommand == null)
                {
                    this.standardGameCommand = new RelayCommand(param => GameMode = GameMode.Standard);
                }
                return this.standardGameCommand;
            }
        }

        private ICommand customGameCommand;
        public ICommand CustomGameCommand
        {
            get
            {
                if (this.customGameCommand == null)
                {
                    this.customGameCommand = new RelayCommand(param => GameMode = GameMode.Custom);
                }
                return this.customGameCommand;
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

        private void GenerateBoard()
        {
            ++User.Stats.TotalGames;
            Board = BoardGenerator.Generate(BoardGeneratorSize);
        }


        private void StartNewGameSession()
        {
            try
            {
                if (GameSession.Started)
                {
                    EndTheGame();
                }
                Board = BoardsReader.ReadRandomBoard(Paths.StandardBoards);
                GameSession.Start();
            }
            catch (System.Exception)
            {
                //no board exists
                throw;
            }
        }
        private void LoadGameSession()
        {
            try
            {
                if (GameSession.Started)
                {
                    EndTheGame();
                }
                GameSession = Serializer.DeserializeJsonObject<GameSession>(Paths.GameSessions + User.FullName);
                GameSession.Start();
            }
            catch (System.Exception)
            {
                //No session exists sau already start?
                throw;
            }
        }
        private void SaveGameSession()
        {
            try
            {
                Serializer.SerializeJsonObject(Paths.GameSessions + User.FullName, GameSession);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        private void OpenStatistics()
        {
            UserStatisticsView userStatisticsView = new UserStatisticsView();
            (userStatisticsView.DataContext as UserStatisticsViewModel).User = User;
            userStatisticsView.Show();
        }

        private void CloseWindow(Window window)
        {
            if (GameSession.Started)
            {
                EndTheGame();
            }

            if (window != null)
            {
                window.Close();
            }
        }
        private void CheckBoard()
        {
            if (BoardChecker.CheckBoard(Board))
            {
                ++User.Stats.WonGames;
                GameSession.Stop();
            }
        }
        private void EndTheGame()
        {
            ++User.Stats.TotalGames;
            GameSession.Stop();
        }
        #endregion


        #region Handlers
        private void GameTimerElapsed(object sender, ElapsedEventArgs e)
        {
            GameSession.Stop();
            if (BoardChecker.CheckBoard(Board))
            {
                ++User.Stats.WonGames;
            }
        }
        #endregion
    }
}
