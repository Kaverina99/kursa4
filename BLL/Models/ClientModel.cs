using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClientModel
    {
        public int Id_Client { get; set; }
        public string Client_Name { get; set; }
        public string Client_Passport { get; set; }
        public string Client_INN { get; set; }
        public string Client_BIK { get; set; }
        public string Client_SNILS { get; set; }
        public string Client_Phone { get; set; }

        public ClientModel() { }
        public ClientModel(Client c)
        {
            Id_Client = c.Id_Client;
            Client_Name = c.Client_Name;
            Client_Passport = c.Client_Passport;
            Client_INN = c.Client_INN;
            Client_BIK = c.Client_BIK;
            Client_SNILS = c.Client_SNILS;
            Client_Phone = c.Client_Phone;
        }
    }
}
