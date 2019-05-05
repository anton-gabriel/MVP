using System;
using System.Runtime.Serialization;

namespace Sudoku.Models.User
{
    [Serializable]
    internal class Statistics : ISerializable
    {
        #region Constructors
        public Statistics() { }
        public Statistics(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            WonGames = (uint)info.GetValue(name: nameof(WonGames), type: typeof(uint));
            TotalGames = (uint)info.GetValue(name: nameof(TotalGames), type: typeof(uint));
        }
        #endregion

        #region Properties
        public uint WonGames { get; set; }
        public uint TotalGames { get; set; }
        #endregion

        #region ISerializable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(name: nameof(WonGames), value: WonGames);
            info.AddValue(name: nameof(TotalGames), value: TotalGames);
        }
        #endregion
    }
}
