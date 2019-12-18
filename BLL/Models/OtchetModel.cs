using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.OtchetModels
{
    public class OtchetAgency
    {
        public int Id_Deal { get; set; }
        public DateTime Deal_Date { get; set; }
        public string Pr_Address { get; set; }
        public string Client_Name { get; set; }
        public string Agent_Name { get; set; }
        public decimal Agency_salary { get; set; }
    }

    public class OtchetAgent
    {
        public int Id_Deal { get; set; }
        public DateTime Deal_Date { get; set; }
        public string Pr_Address { get; set; }
        public string Client_Name { get; set; }
        public decimal Deal_AgentShare_Cost { get; set; }
        //   public decimal Agency_salary { get; set; }

    }
}
