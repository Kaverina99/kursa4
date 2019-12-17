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
    public class PropertyRepositorySQL : IRepository<Property>
    {
        private AgencyDB db;

        public PropertyRepositorySQL(AgencyDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Property> GetList()
        {
            return db.Properties.ToList();
        }

        public Property GetItem(int id)
        {
            return db.Properties.Find(id);
        }

        public int Create(Property item)
        {
            db.Properties.Add(item);
            return item.Id_Property;

        }

        public void Update(Property item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Property item = db.Properties.Find(id);
            if (item != null)
                db.Properties.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
