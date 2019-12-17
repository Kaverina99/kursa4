using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IDbCrud
    {
        List<ClientModel> GetAllClients();
        ClientModel GetClients(int Id);
        void CreateClient(ClientModel cl);
        void UpdateClient(ClientModel cl);

        List<PropertyModel> GetAllProperties();
        PropertyModel GetProperties(int Id);
        void CreateProperty(PropertyModel pr);
        void UpdateProperty(PropertyModel pr);

        List<DealModel> GetAllDeals();
        DealModel GetDeals(int Id);
        void CreateDeal(DealModel d);
        void DeleteDeal(int id);

        List<AgentModel> GetAgents();
        List<AreaModel> GetAreas();
        List<BathroomModel> GetBathrooms();
        List<LayoutModel> GetLayouts(); 
        List<MaterialModel> GetMaterials();
        List<TargetModel> GetTargets(); 
        List<TypeModel> GetTypies();
        
    }
}
