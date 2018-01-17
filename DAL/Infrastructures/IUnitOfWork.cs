using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        IInstallDeviceRepository InstallDevices { get; }

        int Commit();
    }
}
