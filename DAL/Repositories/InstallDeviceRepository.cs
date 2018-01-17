using Entities.Corporates;
using Repositories;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Infrastructures;

namespace Repositories
{
    public class InstallDeviceRepository : BaseRepository<InstallDevice>, IInstallDeviceRepository
    {
        public InstallDeviceRepository(TrakoDbContext context) : base(context)
        {
        }

        public IEnumerable<InstallDevice> GetDeviceWithUUId(string uuid)
        {
            return TrakoDbContext.InstallDevices.Where(c=>c.DeviceUUId== uuid).ToList();
           
        }

        public IEnumerable<InstallDevice> GetTopInstalledCorporates(int count)
        {
            throw new NotImplementedException();
        }
        public TrakoDbContext TrakoDbContext { get { return _context as TrakoDbContext; } }
    }
}
