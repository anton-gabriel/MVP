using Hotel.Services.Repository;

namespace Hotel.Services.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        #region Constructors
        public UnitOfWork(HotelContext context)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
            Users = new UserRepository(context);
        }
        #endregion

        #region Private fields
        private readonly HotelContext context;
        #endregion

        #region Properties
        public IUserRepository Users { get; private set; }

        #endregion

        #region IUnitOfWork
        public int Complete()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
        #endregion
    }
}
