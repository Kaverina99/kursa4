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
        public int Deal_Property_FK { get; set; }
        public decimal Deal_Total_Cost { get; set; }
        public int Deal_Agent_FK { get; set; }
        public decimal Deal_AgentShare_Cost { get; set; }
    }

    public class OtchetAgent
    {
        public int Id_Deal { get; set; }
        public DateTime Deal_Date { get; set; }
        public int Deal_Property_FK { get; set; }
        public decimal Deal_Total_Cost { get; set; }
        public decimal Deal_AgentShare_Cost { get; set; }
    }
}
