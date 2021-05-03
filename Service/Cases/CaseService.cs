using Data.Cases;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Service.Cases
{
    public class CaseService : ICaseService
    {
        [Dependency]
        public ICaseRepository CasesRepository { get; set; }
        public List<Report> GetRegionCasesTop10()
        {
            return CasesRepository.GetRegionCasesTop10();
        }

        public List<Report> GetCasesTop10ByRegion(string regionName)
        {
            return CasesRepository.GetCasesTop10ByRegion(regionName);
        }
    }
}
