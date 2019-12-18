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
        public ClientModel(Client C)
        {
            Id_Client = C.Id_Client;
            Client_Name = C.Client_Name;
            Client_Passport = C.Client_Passport;
            Client_INN = C.Client_INN;
            Client_BIK = C.Client_BIK;
            Client_SNILS = C.Client_SNILS;
            Client_Phone = C.Client_Phone;
        }
    }
}
