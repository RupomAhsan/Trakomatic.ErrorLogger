using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLogger.Entities
{
    public partial class ErrorLoggerEntities
    {
        public ErrorLoggerEntities(string connectionString)
            : base(connectionString)
        {

        }
    }
}
