using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TargetModel
    {
        public int Id_Target { get; set; }
        public string Target_Name { get; set; }

        public TargetModel() { }
        public TargetModel(Target Tar)
        {
            Id_Target = Tar.Id_Target;
            Target_Name = Tar.Target_Name;
        }
    }
}
