﻿using Hotel.Models.Entity;
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
                unitOfWork.Users.Remove(user);
                unitOfWork.Complete();
            }
        }

        public void UpdateUser(User user)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.Users.Get(user.Id);
                result = user;
                unitOfWork.Complete();
            }
        }

        public User GetUser(int id)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                return unitOfWork.Users.Get(id);
            }
        }

        public User Login(User user)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                return unitOfWork.Users.SingleOrDefault(value => (value.Email == user.Email) && (value.Password == user.Password));
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