using System;
using System.Runtime.Serialization;

namespace Sudoku.Models.Board
{
    [Serializable]
    internal class Piece : Utils.NotifyPropertyChanged, IEquatable<Piece>, ISerializable
    {
        #region Constructors
        public Piece()
        {

        }
        public Piece(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            Value = (uint)info.GetValue(name: nameof(Value), type: typeof(uint));
            Enabled = (bool)info.GetValue(name: nameof(Enabled), type: typeof(bool));
        }
        #endregion

        #region Private fields
        private uint value;
        private bool enabled;
        #endregion

        #region Properties
        public uint Value
        {
            get => this.value;
            set
            {
                this.value = value;
                OnPropertyChanged(propertyName: nameof(Value));
            }
        }

        public bool Enabled
        {
            get => this.enabled;
            set
            {
                this.enabled = value;
                OnPropertyChanged(propertyName: nameof(Enabled));
            }
        }
        #endregion

        #region Equality methods
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        bool IEquatable<Piece>.Equals(Piece other)
        {
            return other == null ? false : Value == other.Value;
        }
        #endregion

        #region ISerializable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(name: nameof(Value), value: Value);
            info.AddValue(name: nameof(Enabled), value: Enabled);
        }
        #endregion
    }
}
