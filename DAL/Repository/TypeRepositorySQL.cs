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
    public class TypeRepositorySQL : IRepository<Type_of_Property>
    {
        private AgencyDB db;

        public TypeRepositorySQL(AgencyDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Type_of_Property> GetList()
        {
            return db.Type_of_Property.ToList();
        }

        public Type_of_Property GetItem(int id)
        {
            return db.Type_of_Property.Find(id);
        }

        public int Create(Type_of_Property item)
        {
            db.Type_of_Property.Add(item);
            return item.Id_Type;

        }

        public void Update(Type_of_Property item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Type_of_Property item = db.Type_of_Property.Find(id);
            if (item != null)
                db.Type_of_Property.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
