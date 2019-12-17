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
    public class DealRepositorySQL : IRepository<Deal>
    {
        private AgencyDB db;

        public DealRepositorySQL(AgencyDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Deal> GetList()
        {
            return db.Deals.ToList();
        }

        public Deal GetItem(int id)
        {
            return db.Deals.Find(id);
        }

        public int Create(Deal item)
        {
            db.Deals.Add(item);
            return item.Id_Deal;

        }

        public void Update(Deal item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Deal item = db.Deals.Find(id);
            if (item != null)
                db.Deals.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
