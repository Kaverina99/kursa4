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
            //return db.Otchets.Otchet1(date1, date2).Join((db., d => d.Deal_Seller_FK, c => c.Id_Client, (d, c) => d)).Select(i => new OtchetAgency
            //{ Id = i.Id, Date_Death = i.Date_Death, Nazvanie = i.Nazvanie, Tip = i.Tip, Cost = i.Cost, Kolichestvo = i.Kolichestvo, TotalCost = i.TotalCost }).ToList();

        }

        public List<OtchetAgent> Otchet2(int agent)
        {
            //var deal = db.Otchets.Otchet2(agent)
            // .Select(i => new OtchetAgent() { Id = i.Id, Nazvanie = i.Nazvanie, Cost = i.Cost, Kolichestvo = i.Kolichestvo, Date_Birth = i.Date_Birth, Date_Death = i.Date_Death })
            // .ToList();
            //return deal;
        }
    }
}