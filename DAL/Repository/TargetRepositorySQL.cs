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
    public class TargetRepositorySQL : IRepository<Target>
    {
        private AgencyDB db;

        public TargetRepositorySQL(AgencyDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Target> GetList()
        {
            return db.Targets.ToList();
        }

        public Target GetItem(int id)
        {
            return db.Targets.Find(id);
        }

        public int Create(Target item)
        {
            db.Targets.Add(item);
            return item.Id_Target;

        }

        public void Update(Target item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Target item = db.Targets.Find(id);
            if (item != null)
                db.Targets.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
