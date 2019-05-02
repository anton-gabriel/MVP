namespace Sudoku.Models.Board
{
    internal class Piece : Utils.NotifyPropertyChanged
    {
        private byte value;

        public byte Value
        {
            get => this.value;

            set
            {
                this.value = value;
                OnPropertyChanged(propertyName: nameof(Value));
            }
        }
    }
}
