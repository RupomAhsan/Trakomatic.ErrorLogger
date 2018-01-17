using Entities.Corporates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IInstallDeviceRepository:IRepository<InstallDevice>
    {
        IEnumerable<InstallDevice> GetTopInstalledCorporates(int count);
        IEnumerable<InstallDevice> GetDeviceWithUUId(string uuid);

    }
}
