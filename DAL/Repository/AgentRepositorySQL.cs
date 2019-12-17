using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class AgentRepositorySQL : IRepository<Agent>
    {
        private AgencyDB db;

        public AgentRepositorySQL(AgencyDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Agent> GetList()
        {
            return db.Agents.ToList();
        }

        public Agent GetItem(int id)
        {
            return db.Agents.Find(id);
        }

        public int Create(Agent item)
        {
            db.Agents.Add(item);
            return item.Id_Agent;

        }

        public void Update(Agent item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Agent item = db.Agents.Find(id);
            if (item != null)
                db.Agents.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
