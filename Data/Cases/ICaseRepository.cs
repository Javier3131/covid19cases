using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Cases
{
    public interface ICaseRepository
    {
        List<Report> GetRegionCasesTop10();
        List<Report> GetCasesTop10ByRegion(string regionName);
    }
}
