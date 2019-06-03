using Hotel.Services.Repository;
using System;

namespace Hotel.Services.UnitOfWork
{
    internal interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        int Complete();
    }
}