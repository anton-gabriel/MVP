using Hotel.Services.Repository;
using System;

namespace Hotel.Services.UnitOfWork
{
    internal interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
    }
}