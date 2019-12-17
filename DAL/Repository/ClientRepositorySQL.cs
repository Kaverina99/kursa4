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
    public class ClientRepositorySQL : IRepository<Client>
    {
        private AgencyDB db;

        public ClientRepositorySQL(AgencyDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Client> GetList()
        {
            return db.Clients.ToList();
        }

        public Client GetItem(int id)
        {
            return db.Clients.Find(id);
        }

        public int Create(Client item)
        {
            db.Clients.Add(item);
            return item.Id_Client;

        }

        public void Update(Client item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Client item = db.Clients.Find(id);
            if (item != null)
                db.Clients.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
