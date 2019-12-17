using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaterialModel
    {
        public int Id_Material { get; set; }
        public string Material_Name { get; set; }

        public MaterialModel() { }
        public MaterialModel(Material m)
        {
            Id_Material = m.Id_Material;
            Material_Name = m.Material_Name;
        }
    }
}
