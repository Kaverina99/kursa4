using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDbRepos
    {
        IRepository<Agent> Agents { get; }
        IRepository<Area> Areas { get; }
        IRepository<Bathroom> Bathrooms { get; }
        IRepository<Client> Clients { get; }
        IRepository<Deal> Deals { get; }
        IRepository<Layout> Layouts { get; }
        IRepository<Material> Materials { get; }
        IRepository<Property> Properties { get; }
        IRepository<Target> Targets { get; }
        IRepository<Type_of_Property> Type_of_Property { get; }
        IOtchetsRepository Otchets { get; }
        int Save();
    }
}
