using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Timers;

namespace Sudoku.Models.Game
{
    [Serializable]
    internal class GameSession : ISerializable
    {
        #region Constructors
        public GameSession()
        {
            Timer = new Timer
            {
                Enabled = false,
                AutoReset = false,
                Interval = TimeSpan.FromHours(1).TotalMilliseconds
            };
            Stopwatch = new Stopwatch();
        }
        public GameSession(SerializationInfo info, StreamingContext context) : this()
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            User = (User.User)info.GetValue(name: nameof(User), type: typeof(User.User));
            Board = (Board.Board)info.GetValue(name: nameof(Board), type: typeof(Board.Board));
            Stopwatch = (Stopwatch)info.GetValue(name: nameof(Stopwatch), type: typeof(Stopwatch));
            Timer.Interval = TimeSpan.FromHours(1).TotalMilliseconds - Stopwatch.ElapsedMilliseconds;
        }
        #endregion

        #region Properties
        public User.User User { get; set; }
        public Board.Board Board { get; set; }
        public Timer Timer { get; private set; }
        public Stopwatch Stopwatch { get; private set; }
        public bool Started => Stopwatch.IsRunning;
        #endregion

        #region Public methods
        public void AddHandler(ElapsedEventHandler handler)
        {
            Timer.Elapsed += handler;
        }
        public void Start()
        {
            Timer.Start();
            Stopwatch.Start();
        }
        public void Stop()
        {
            Timer.Stop();
            Stopwatch.Stop();
        }
        #endregion

        #region ISerializable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(name: nameof(User), value: User);
            info.AddValue(name: nameof(Board), value: Board);
            info.AddValue(name: nameof(Stopwatch), value: Stopwatch);
        }
        #endregion
    }
}
