using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Sudoku.Models.Board
{
    [Serializable]
    internal class Square : ISerializable
    {
        #region Constructors
        public Square()
        {
            Pieces = new ObservableCollection<ObservableCollection<Piece>>();
        }

        public Square(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            Pieces = (ObservableCollection<ObservableCollection<Piece>>)info.GetValue(name: nameof(Pieces), type: typeof(ObservableCollection<ObservableCollection<Piece>>));
        }
        #endregion

        #region Properties
        public ObservableCollection<ObservableCollection<Piece>> Pieces { get; set; }
        #endregion

        #region Public methods
        public List<Piece> GetLine(int line)
        {
            return Pieces[line].ToList();
        }
        public List<Piece> GetColumn(int column)
        {
            List<Piece> pieces = new List<Piece>();
            for (int index = 0; index < Pieces.Count; ++index)
            {
                pieces.Add(Pieces[index][column]);
            }
            return pieces;
        }
        #endregion

        #region ISerializable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(name: nameof(Pieces), value: Pieces);
        }
        #endregion
    }
}