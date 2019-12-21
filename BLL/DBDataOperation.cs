using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DAL.Repository;

namespace BLL
{
    public class DBDataOperation : IDbCrud//внедрение зависимости
    {
        IDbRepos db;
        public DBDataOperation()
        {
            db = new DbReposSQL();
        }

        #region Client
        public List<ClientModel> GetAllClients()
        {
            return db.Clients.GetList().Select(i => new ClientModel(i)).ToList();
        }

        public ClientModel GetClients(int Id)
        {
            return new ClientModel(db.Clients.GetItem(Id));
        }

        public void CreateClient(ClientModel cl)
        {
            db.Clients.Create(new Client() { Client_Name = cl.Client_Name, Client_Passport = cl.Client_Passport, Client_INN = cl.Client_INN, Client_BIK = cl.Client_BIK, Client_SNILS = cl.Client_SNILS, Client_Phone = cl.Client_Phone });
            Save();
            //db.Produkt.Attach(p);
        }

        public void UpdateClient(ClientModel cl)
        {
            Client c = db.Clients.GetItem(cl.Id_Client);
            c.Client_Name = cl.Client_Name;
            c.Client_Passport = cl.Client_Passport;
            c.Client_INN = cl.Client_INN;
            c.Client_BIK = cl.Client_BIK;
            c.Client_SNILS = cl.Client_SNILS;
            c.Client_Phone = cl.Client_Phone;
            Save();
        }

        #endregion

        #region Property
        public List<PropertyModel> GetAllProperties()
        {
            return db.Properties.GetList().Select(i => new PropertyModel(i)).ToList();
        }

        public PropertyModel GetProperties(int Id)
        {
            return new PropertyModel(db.Properties.GetItem(Id));
        }

        public void CreateProperty(PropertyModel pr)
        {
            db.Properties.Create(new Property() {
            Pr_Cost = pr.Pr_Cost,
            Pr_Address = pr.Pr_Address,
            Pr_Metric_area = pr.Pr_Metric_area,
            Pr_Floor = pr.Pr_Floor,
            Pr_Plot_size = pr.Pr_Plot_size,
            Pr_Number_of_rooms = pr.Pr_Number_of_rooms,
            Pr_Client_FK = pr.Pr_Client_FK,
            Pr_TypeP_FK = pr.Pr_TypeP_FK,
            Pr_Target_FK = pr.Pr_Target_FK,
            Pr_Area_FK = pr.Pr_Area_FK,
            Pr_Bathroom_FK = pr.Pr_Bathroom_FK,
            Pr_Layout_FK = pr.Pr_Layout_FK,
            Pr_Material_FK = pr.Pr_Material_FK,
            });
            Save();
            //db.Produkt.Attach(p);
        }

        public void UpdateProperty(PropertyModel pr)
        {
            Property p = db.Properties.GetItem(pr.Id_Property);
            p.Pr_Cost = pr.Pr_Cost;
            p.Pr_Address = pr.Pr_Address;
            p.Pr_Metric_area = pr.Pr_Metric_area;
            p.Pr_Floor = pr.Pr_Floor;
            p.Pr_Plot_size = pr.Pr_Plot_size;
            p.Pr_Number_of_rooms = pr.Pr_Number_of_rooms;
            p.Pr_Client_FK = pr.Pr_Client_FK;
            p.Pr_TypeP_FK = pr.Pr_TypeP_FK;
            p.Pr_Target_FK = pr.Pr_Target_FK;
            p.Pr_Area_FK = pr.Pr_Area_FK;
            p.Pr_Bathroom_FK = pr.Pr_Bathroom_FK;
            p.Pr_Layout_FK = pr.Pr_Layout_FK;
            p.Pr_Material_FK = pr.Pr_Material_FK;
            Save();
        }

        #endregion

        #region Deal
        public List<DealModel> GetAllDeals()
        {
            return db.Deals.GetList().Select(i => new DealModel(i)).ToList();
        }

        public DealModel GetDeals(int Id)
        {
            return new DealModel(db.Deals.GetItem(Id));
        }
        public void DeleteDeal(int id)
        {
            if (db.Deals.GetItem(id) != null)
            {
                db.Deals.Delete(id);
                Save();
            }
        }
        public void CreateDeal(DealModel d)
        {
            db.Deals.Create(new Deal()
            {
                Deal_Date = d.Deal_Date, Deal_Form_of_Payment = d.Deal_Form_of_Payment, Deal_Mortgage_Period = d.Deal_Mortgage_Period,
                Deal_Monthly_Payout = d.Deal_Monthly_Payout, Deal_Total_Cost = d.Deal_Total_Cost, Deal_Seller_FK = d.Deal_Seller_FK,
                Deal_Customer_FK = d.Deal_Customer_FK, Deal_Property_FK = d.Deal_Property_FK, Deal_Agent_FK = d.Deal_Agent_FK, Deal_AgentShare_Cost = d.Deal_AgentShare_Cost
            });
            Save();
        }
        #endregion

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }

        public List<AgentModel> GetAgents()
        {
            return db.Agents.GetList().Select(i => new AgentModel(i)).ToList();
        }
        public List<AreaModel> GetAreas()
        {
            return db.Areas.GetList().Select(i => new AreaModel(i)).ToList();
        }
        public List<BathroomModel> GetBathrooms()
        {
            return db.Bathrooms.GetList().Select(i => new BathroomModel(i)).ToList();
        }
        public List<LayoutModel> GetLayouts()
        {
            return db.Layouts.GetList().Select(i => new LayoutModel(i)).ToList();
        }
        public List<MaterialModel> GetMaterials()
        {
            return db.Materials.GetList().Select(i => new MaterialModel(i)).ToList();
        }
        public List<TargetModel> GetTargets()
        {
            return db.Targets.GetList().Select(i => new TargetModel(i)).ToList();
        }
        public List<TypeModel> GetTypies()
        {
            return db.Type_of_Property.GetList().Select(i => new TypeModel(i)).ToList();
        }

    }
}