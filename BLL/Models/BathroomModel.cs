using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BathroomModel
    {
        public int Id_Bathroom { get; set; }
        public string Bathroom_Name { get; set; }

        public BathroomModel() { }
        public BathroomModel(Bathroom b)
        {
            Id_Bathroom = b.Id_Bathroom;
            Bathroom_Name = b.Bathroom_Name;
        }
    }
}
