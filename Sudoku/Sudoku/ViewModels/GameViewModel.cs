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
using System.Windows.Threading;
using TotalCommander.Services;

namespace Sudoku.ViewModels
{
    internal class GameViewModel : Models.Utils.NotifyPropertyChanged
    {
        #region Constructors
        public GameViewModel()
        {
            GameSession = new GameSession();
            GameSession.AddHandler(GameTimerElapsed);
            InitilaizeTimer();
        }
        #endregion

        #region Private fields
        private GameSession gameSession;
        private DispatcherTimer timer;
        private string displayTime;
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
            get => this.displayTime;
            set
            {
                this.displayTime = value;
                OnPropertyChanged(propertyName: nameof(DisplayTime));
            }
        }

        private bool CanCheckBoard => Board != null;
        private bool CanStartNewGameSession => User != null;
        private bool CanSaveGameSession => (Board != null) && (User != null);
        private bool CanOpenStatistics => User != null;
        private bool CanStartGame => Board != null && !GameSession.Started;
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

        ICommand startGameCommand;
        public ICommand StartGameCommand
        {
            get
            {
                if (this.startGameCommand == null)
                {
                    this.startGameCommand = new RelayCommand(param => CanStartGame, param => StartGame());
                }
                return this.startGameCommand;
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

        private void StartGame()
        {
            GameSession.Start();
        }

        private void CheckBoard()
        {
            if (BoardChecker.CheckBoard(Board))
            {
                ++User.Stats.WonGames;
                GameSession.Stop();
                UserDialog.MessageDialog("You won!", type: DialogType.Info);
            }
            else
            {
                UserDialog.MessageDialog("Try again.", type: DialogType.Info);
            }
        }

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
            }
            catch (System.Exception)
            {
                UserDialog.MessageDialog("No available boards.");
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
            }
            catch (System.Exception)
            {
                UserDialog.MessageDialog("No session available.");
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
                UserDialog.MessageDialog("Save failed.", type: DialogType.Alert);
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
            if (UserDialog.GetResponseDialog("Are you sure?", type: DialogType.Alert))
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
        }

        private void EndTheGame()
        {
            ++User.Stats.TotalGames;
            GameSession.Stop();
        }

        private void InitilaizeTimer()
        {
            this.timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1),
            };
            this.timer.Tick += TimeChanged;
            this.timer.Start();
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
        private void TimeChanged(object sender, EventArgs e)
        {
            TimeSpan interval = TimeSpan.FromHours(1) - GameSession.Stopwatch.Elapsed;
            DisplayTime = interval.ToString(@"mm\:ss"); ;
        }
        #endregion
    }
}
