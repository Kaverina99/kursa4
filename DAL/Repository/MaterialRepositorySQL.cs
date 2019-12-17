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
    public class MaterialRepositorySQL : IRepository<Material>
    {
        private AgencyDB db;

        public MaterialRepositorySQL(AgencyDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Material> GetList()
        {
            return db.Materials.ToList();
        }

        public Material GetItem(int id)
        {
            return db.Materials.Find(id);
        }

        public int Create(Material item)
        {
            db.Materials.Add(item);
            return item.Id_Material;

        }

        public void Update(Material item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Material item = db.Materials.Find(id);
            if (item != null)
                db.Materials.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}


