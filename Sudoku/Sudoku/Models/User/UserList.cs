using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Sudoku.Models.User
{
    [Serializable]
    internal class UserList : ISerializable
    {
        #region Constructors
        public UserList()
        {
            Users = new ObservableCollection<User>();
        }
        public UserList(SerializationInfo info, StreamingContext context) : this()
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            Users = (ObservableCollection<User>)info.GetValue(name: nameof(Users), type: typeof(ObservableCollection<User>));
        }
        #endregion

        #region Properties
        public ObservableCollection<User> Users { get; set; }
        #endregion

        #region ISerializable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(name: nameof(Users), value: Users);
        }
        #endregion
    }
}
