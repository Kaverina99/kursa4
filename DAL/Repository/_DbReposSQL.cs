using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private AgencyDB db;
        private AgentRepositorySQL agentRepository;
        private AreaRepositorySQL areaRepository;
        private BathroomRepositorySQL bathroomRepository;
        private ClientRepositorySQL clientRepository;
        private DealRepositorySQL dealRepository;
        private LayoutRepositorySQL layoutRepository;
        private MaterialRepositorySQL materialRepository;
        private PropertyRepositorySQL propertyRepository;
        private TargetRepositorySQL targetRepository;
        private TypeRepositorySQL typeRepository;
        private OtchetRepositorySQL otchetRepository;

        public DbReposSQL()
        {
            db = new AgencyDB();
        }

        public IRepository<Agent> Agents
        {
            get
            {
                if (agentRepository == null)
                    agentRepository = new AgentRepositorySQL(db);
                return agentRepository;
            }
        }
        public IRepository<Area> Areas
        {
            get
            {
                if (areaRepository == null)
                    areaRepository = new AreaRepositorySQL(db);
                return areaRepository;
            }
        }
        public IRepository<Bathroom> Bathrooms
        {
            get
            {
                if (bathroomRepository == null)
                    bathroomRepository = new BathroomRepositorySQL(db);
                return bathroomRepository;
            }
        }
        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepositorySQL(db);
                return clientRepository;
            }
        }
        public IRepository<Deal> Deals
        {
            get
            {
                if (dealRepository == null)
                    dealRepository = new DealRepositorySQL(db);
                return dealRepository;
            }
        }
        public IRepository<Layout> Layouts
        {
            get
            {
                if (layoutRepository == null)
                    layoutRepository = new LayoutRepositorySQL(db);
                return layoutRepository;
            }
        }
        public IRepository<Material> Materials
        {
            get
            {
                if (materialRepository == null)
                    materialRepository = new MaterialRepositorySQL(db);
                return materialRepository;
            }
        }
        public IRepository<Property> Properties
        {
            get
            {
                if (propertyRepository == null)
                    propertyRepository = new PropertyRepositorySQL(db);
                return propertyRepository;
            }
        }
        public IRepository<Target> Targets
        {
            get
            {
                if (targetRepository == null)
                    targetRepository = new TargetRepositorySQL(db);
                return targetRepository;
            }
        }
        public IRepository<Type_of_Property> Type_of_Property
        {
            get
            {
                if (typeRepository == null)
                    typeRepository = new TypeRepositorySQL(db);
                return typeRepository;
            }
        }
        public IOtchetsRepository Otchets
        {
            get
            {
                if (otchetRepository == null)
                    otchetRepository = new OtchetRepositorySQL(db);
                return otchetRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
