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
        public LayoutModel(Layout l)
        {
            Id_Layout = l.Id_Layout;
            Layout_Name = l.Layout_Name;
        }
    }
}
