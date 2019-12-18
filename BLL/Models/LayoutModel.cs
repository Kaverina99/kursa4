using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LayoutModel
    {
        public int Id_Layout { get; set; }
        public string Layout_Name { get; set; }

        public LayoutModel() { }
        public LayoutModel(Layout L)
        {
            Id_Layout = L.Id_Layout;
            Id_Layout = L.Id_Layout;
        }
    }
}
