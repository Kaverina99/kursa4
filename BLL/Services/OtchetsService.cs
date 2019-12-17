using BLL.Interfaces;
using BLL.Models.OtchetModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OtchetsService : IOtchetService
    {
        private IDbRepos db;
        public OtchetsService(IDbRepos repos)
        {
            db = repos;
        }

        //выполнить ХП
        public List<OtchetAgency> Otchet1(DateTime date1, DateTime date2)
        {
            return db.Otchets.Otchet1(date1, date2).Select(i => new OtchetAgency
            { Id_Deal = i.Id_Deal, Deal_Date = i.Deal_Date, Deal_Property_FK = i.Deal_Property_FK, Deal_Total_Cost = i.Deal_Total_Cost, Deal_Agent_FK = i.Deal_Agent_FK, Deal_AgentShare_Cost = i.Deal_AgentShare_Cost })
            .ToList();
        }

        public List<OtchetAgent> Otchet2(int agent)
        {
            var deal = db.Otchets.Otchet2(agent)
             .Select(i => new OtchetAgent() { Id_Deal = i.Id_Deal, Deal_Date = i.Deal_Date, Deal_Property_FK = i.Deal_Property_FK, Deal_Total_Cost = i.Deal_Total_Cost, Deal_AgentShare_Cost = i.Deal_AgentShare_Cost })
             .ToList();
            return deal;
        }
    } 
}