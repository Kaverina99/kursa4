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
        public MaterialModel(Material M)
        {
            Id_Material = M.Id_Material;
            Material_Name = M.Material_Name;
        }
    }
}
