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
    public class AreaRepositorySQL : IRepository<Area>
    {
        private AgencyDB db;

        public AreaRepositorySQL(AgencyDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Area> GetList()
        {
            return db.Areas.ToList();
        }

        public Area GetItem(int id)
        {
            return db.Areas.Find(id);
        }

        public int Create(Area item)
        {
            db.Areas.Add(item);
            return item.Id_Area;

        }

        public void Update(Area item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Area item = db.Areas.Find(id);
            if (item != null)
                db.Areas.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
