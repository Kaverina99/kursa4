using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AgentModel
    {
        public int Id_Agent { get; set; }
        public string Agent_Name { get; set; }
        public string Agent_Passport { get; set; }
        public string Agent_Position { get; set; }

        public AgentModel() { }
        public AgentModel(Agent a)
        {
            Id_Agent = a.Id_Agent;
            Agent_Name = a.Agent_Name;
            Agent_Passport = a.Agent_Passport;
            Agent_Position = a.Agent_Position;
        }
    }
}
