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
    public class BathroomRepositorySQL : IRepository<Bathroom>
    {
        private AgencyDB db;

        public BathroomRepositorySQL(AgencyDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Bathroom> GetList()
        {
            return db.Bathrooms.ToList();
        }

        public Bathroom GetItem(int id)
        {
            return db.Bathrooms.Find(id);
        }

        public int Create(Bathroom item)
        {
            db.Bathrooms.Add(item);
            return item.Id_Bathroom;

        }

        public void Update(Bathroom item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Bathroom item = db.Bathrooms.Find(id);
            if (item != null)
                db.Bathrooms.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
