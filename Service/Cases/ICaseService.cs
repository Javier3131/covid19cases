using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Cases
{
    public interface ICaseService
    {
        List<Report> GetRegionCasesTop10();
        List<Report> GetCasesTop10ByRegion(string regionName);
    }
}
