using System;
using System.Runtime.Serialization;
using System.Timers;

namespace Sudoku.Models.Game
{

    internal class GameSession : ISerializable
    {
        #region Constructors
        public GameSession()
        {
            Timer = new Timer
            {
                Enabled = false,
                AutoReset = false,
                Interval = TimeSpan.FromHours(1).Milliseconds
            };
        }
        public GameSession(User.User user, Board.Board board) : this()
        {
            User = user;
            Board = board;
        }
        public GameSession(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            User = (User.User)info.GetValue(name: nameof(User), type: typeof(User.User));
            Board = (Board.Board)info.GetValue(name: nameof(Board), type: typeof(Board.Board));
            Timer = (Timer)info.GetValue(name: nameof(Timer), type: typeof(Timer));
        }
        #endregion

        #region Properties
        public User.User User { get; private set; }
        public Board.Board Board { get; private set; }
        public Timer Timer { get; private set; }
        #endregion

        #region Public methods
        public void AddHandler(ElapsedEventHandler handler)
        {
            Timer.Elapsed += handler;
        }
        public void Start()
        {
            Timer.Start();
        }
        #endregion

        #region ISerializable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(name: nameof(User), value: User);
            info.AddValue(name: nameof(Board), value: Board);
            info.AddValue(name: nameof(Timer), value: Timer);
        }
        #endregion
    }
}
