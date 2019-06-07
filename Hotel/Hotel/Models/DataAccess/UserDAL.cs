using Hotel.Models.Entity;
using Hotel.Services;
using Hotel.Services.UnitOfWork;

namespace Hotel.Models.DataAccess
{
    internal class UserDAL
    {
        #region Public methods
        public void AddUser(User user)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                unitOfWork.Users.Add(user);
                unitOfWork.Complete();
            }
        }

        public void RemoveUser(User user)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                user.Deleted = true;
                unitOfWork.Complete();
            }
        }

        public void UpdateUser(User user)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.Users.Get(user.Id);
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.Email = user.Email;
                result.Deleted = user.Deleted;
                result.Password = user.Password;
                result.UserType = user.UserType;
                unitOfWork.Complete();
            }
        }

        public User GetUser(int id)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.Users.Get(id);
                return result?.Deleted == false ? result : null;
            }
        }

        public User Login(User user)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.Users.SingleOrDefault(value => (value.Email == user.Email) && (value.Password == user.Password));
                return result?.Deleted == false ? result : null;
            }
        }

        public User Register(User user)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.Users.SingleOrDefault(value => value.Email == user.Email);
                if (result != null)
                {
                    unitOfWork.Users.Add(user);
                    return unitOfWork.Users.Get(user.Id);
                }
                return null;
            }
        }
        #endregion
    }
}