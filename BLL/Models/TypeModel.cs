using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TypeModel
    {
        public int Id_Type { get; set; }
        public string TypeP_Name { get; set; }

        public TypeModel() { }
        public TypeModel(Type_of_Property T)
        {
            Id_Type = T.Id_Type;
            TypeP_Name = T.TypeP_Name;
        }
    }
}
