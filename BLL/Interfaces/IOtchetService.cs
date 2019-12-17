using BLL.Models.OtchetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOtchetService
    {
        List<OtchetAgency> Otchet1(DateTime date1, DateTime date2);
        List<OtchetAgent> Otchet2(int agent);
    }
}
