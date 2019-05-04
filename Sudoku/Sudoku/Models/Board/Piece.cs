using System;

namespace Sudoku.Models.Board
{
    internal class Piece : Utils.NotifyPropertyChanged, IEquatable<Piece>
    {
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
    }
}
