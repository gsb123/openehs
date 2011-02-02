using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public interface IServiceRepository : IRepository<Service>
    {
        IList<Service> GetActiveServices();
        IList<Service> GetInactiveServices();
    }
}
