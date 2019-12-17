using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AreaModel
    {
        public int Id_Area { get; set; }
        public string Area_Name { get; set; }

        public AreaModel() { }
        public AreaModel(Area ar)
        {
            Id_Area = ar.Id_Area;
            Area_Name = ar.Area_Name;
        }
    }
}
