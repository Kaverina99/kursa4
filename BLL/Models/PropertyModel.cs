using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PropertyModel
    {
        public int Id_Property { get; set; }
        public decimal Pr_Cost { get; set; }
        public string Pr_Address { get; set; }
        public decimal? Pr_Metric_area { get; set; }
        public string Pr_Floor { get; set; }
        public decimal? Pr_Plot_size { get; set; }
        public int Pr_Number_of_rooms { get; set; }
        public int Pr_Client_FK { get; set; }
        public int Pr_TypeP_FK { get; set; }
        public int Pr_Target_FK { get; set; }
        public int? Pr_Area_FK { get; set; }
        public int? Pr_Bathroom_FK { get; set; }
        public int? Pr_Layout_FK { get; set; }
        public int? Pr_Material_FK { get; set; }


        public PropertyModel() { }
        public PropertyModel(Property p)
        {
            Id_Property = p.Id_Property;
            Pr_Cost = p.Pr_Cost;
            Pr_Address = p.Pr_Address;
            Pr_Metric_area = p.Pr_Metric_area;
            Pr_Floor = p.Pr_Floor;
            Pr_Plot_size = p.Pr_Plot_size;
            Pr_Number_of_rooms = p.Pr_Number_of_rooms;
            Pr_Client_FK = p.Pr_Client_FK;
            Pr_TypeP_FK = p.Pr_TypeP_FK;
            Pr_Target_FK = p.Pr_Target_FK;
            Pr_Area_FK = p.Pr_Area_FK;
            Pr_Bathroom_FK = p.Pr_Bathroom_FK;
            Pr_Layout_FK = p.Pr_Layout_FK;
            Pr_Material_FK = p.Pr_Material_FK;
        }
    }
}
