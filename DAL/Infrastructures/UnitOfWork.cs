using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interfaces;
using Repositories;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private readonly TrakoDbContext _context;

        public UnitOfWork(TrakoDbContext context)
        {
            _context = context;
            InstallDevices = new InstallDeviceRepository(_context);
        }
        public IInstallDeviceRepository InstallDevices { get;private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            IRepository<TEntity> repo = new BaseRepository<TEntity>(_context);
            repositories.Add(typeof(TEntity), repo);
            return repo;
        }
    }
}
