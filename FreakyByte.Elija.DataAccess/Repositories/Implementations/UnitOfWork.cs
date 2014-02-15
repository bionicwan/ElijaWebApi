namespace FreakyByte.Elija.DataAccess.Repositories.Implementations
{
    using System;

    using FreakyByte.Elija.DataAccess.Model;

    public class UnitOfWork : IDisposable
    {

        private ElijaEntities Context { get; set; }

        private readonly DbContextFactory dbContextFactory = new DbContextFactory();

        private Repository<User> userRepository;

        private Repository<UserDevice> userDeviceRepository;

        private Repository<Device> deviceRepository;

        private Repository<Authentication> authenticationRepository;

        public UnitOfWork()
        {
            this.Context = this.dbContextFactory.GetDbContext();
        }

        public Repository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new Repository<User>(this.Context);
                }
                return this.userRepository;
            }
        }

        public Repository<Authentication> AuthenticationrRepository
        {
            get
            {
                if (this.authenticationRepository == null)
                {
                    this.authenticationRepository = new Repository<Authentication>(this.Context);
                }
                return this.authenticationRepository;
            }
        }

        public Repository<UserDevice> UserDeviceRepository
        {
            get
            {
                if (this.userDeviceRepository == null)
                {
                    this.userDeviceRepository = new Repository<UserDevice>(this.Context);
                }
                return this.userDeviceRepository;
            }
        }

        public Repository<Device> DeviceRepository
        {
            get
            {
                if (this.deviceRepository == null)
                {
                    this.deviceRepository = new Repository<Device>(this.Context);
                }
                return this.deviceRepository;
            }
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
