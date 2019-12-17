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
    public class LayoutRepositorySQL : IRepository<Layout>
    {
        private AgencyDB db;

        public LayoutRepositorySQL(AgencyDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Layout> GetList()
        {
            return db.Layouts.ToList();
        }

        public Layout GetItem(int id)
        {
            return db.Layouts.Find(id);
        }

        public int Create(Layout item)
        {
            db.Layouts.Add(item);
            return item.Id_Layout;

        }

        public void Update(Layout item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Layout item = db.Layouts.Find(id);
            if (item != null)
                db.Layouts.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}


