using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OtchetRepositorySQL : IOtchetsRepository
    {
        private AgencyDB db;

        public OtchetRepositorySQL(AgencyDB dbcontext)
        {
            this.db = dbcontext;
        }

       
        public List<OtchetAgency> Otchet1(DateTime date1, DateTime date2)
        {
            List<OtchetAgency> deal = db.Deals
                .Where(i => i.Deal_Date >= date1)
                .Where(i => i.Deal_Date <= date2)
                .Select(i => new OtchetAgency() { Id_Deal = i.Id_Deal, Deal_Date = i.Deal_Date, Deal_Property_FK = i.Deal_Property_FK, Deal_Total_Cost = i.Deal_Total_Cost, Deal_Agent_FK = i.Deal_Agent_FK, Deal_AgentShare_Cost = i.Deal_AgentShare_Cost })
                .ToList();
            return deal;


                //ХП
            //System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@DATE1", date);
            //List<OtchetAgency> result = db.Database.SqlQuery<OtchetAgency>("Otchet1 @DATE1", new object[] { param1 }).ToList();
            //return result;
        }

        public List<OtchetAgent> Otchet2(int agent)
        {
            List<OtchetAgent> deal2 = db.Deals
             .Join(db.Agents, d => d.Deal_Agent_FK, a => a.Id_Agent, (d, a) => d)
             .Where(i => i.Deal_Agent_FK == agent)
             .Select(i => new OtchetAgent() { Id_Deal = i.Id_Deal, Deal_Date = i.Deal_Date, Deal_Property_FK = i.Deal_Property_FK, Deal_Total_Cost = i.Deal_Total_Cost, Deal_AgentShare_Cost = i.Deal_AgentShare_Cost })
             .ToList();
            return deal2;
        }
    }
}
