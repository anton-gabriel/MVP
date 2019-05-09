using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Sudoku.Models.Board
{
    [Serializable]
    class Board : ISerializable
    {
        #region Constructors
        public Board()
        {
            Squares = new ObservableCollection<ObservableCollection<Square>>();
        }
        public Board(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            Squares = (ObservableCollection<ObservableCollection<Square>>)info.GetValue(name: nameof(Squares), type: typeof(ObservableCollection<ObservableCollection<Square>>));
        }
        #endregion

        #region Properties
        public ObservableCollection<ObservableCollection<Square>> Squares { get; set; }
        public int Size => Squares.Count;
        #endregion

        #region ISerializable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(name: nameof(Squares), value: Squares);
        }
        #endregion
    }
}
