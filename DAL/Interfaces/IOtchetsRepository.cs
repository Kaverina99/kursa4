using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IOtchetsRepository
    {
        List<OtchetAgency> Otchet1(DateTime date1, DateTime date2);
        List<OtchetAgent> Otchet2(int agent);
    }
}