using System;
using FreakyByte.Elija.DataAccess.Model;

namespace FreakyByte.Elija.DataAccess.Repositories.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContextFactory _dbContextFactory = new DbContextFactory();

        private Repository<Article> _articleRepository;
        private Repository<Authentication> _authenticationRepository;
        private Repository<Device> _deviceRepository;
        private bool _disposed;
        private Repository<Image> _imageRepository;
        private Repository<Section> _sectionRepository;
        private Repository<UserDevice> _userDeviceRepository;
        private Repository<User> _userRepository;

        public UnitOfWork()
        {
            Context = _dbContextFactory.GetDbContext();
            Context.ContextOptions.LazyLoadingEnabled = true;
        }

        private ElijaEntities Context { get; set; }

        public Repository<Image> ImageRepository
        {
            get
            {
                if (_imageRepository == null)
                {
                    _imageRepository = new Repository<Image>(Context);
                }
                return _imageRepository;
            }
        }

        public Repository<Article> ArticleRepository
        {
            get
            {
                if (_articleRepository == null)
                {
                    _articleRepository = new Repository<Article>(Context);
                }
                return _articleRepository;
            }
        }

        public Repository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new Repository<User>(Context);
                }
                return _userRepository;
            }
        }

        public Repository<Authentication> AuthenticationrRepository
        {
            get
            {
                if (_authenticationRepository == null)
                {
                    _authenticationRepository = new Repository<Authentication>(Context);
                }
                return _authenticationRepository;
            }
        }

        public Repository<UserDevice> UserDeviceRepository
        {
            get
            {
                if (_userDeviceRepository == null)
                {
                    _userDeviceRepository = new Repository<UserDevice>(Context);
                }
                return _userDeviceRepository;
            }
        }

        public Repository<Device> DeviceRepository
        {
            get
            {
                if (_deviceRepository == null)
                {
                    _deviceRepository = new Repository<Device>(Context);
                }
                return _deviceRepository;
            }
        }

        public Repository<Section> SectionRepository
        {
            get
            {
                if (_sectionRepository == null)
                {
                    _sectionRepository = new Repository<Section>(Context);
                }
                return _sectionRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}