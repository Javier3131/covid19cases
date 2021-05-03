using Data;
using Service.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.DInjection;

namespace Service
{
    public class DiRegisterServices
    {
        public static List<IClassType> GetServiceList()
        {
            var list = new List<IClassType>();
            list.AddRange(DiRegisterData.GetDataList());

            list.Add(new ClassType<ICaseService, CaseService>());

            return list;
        }
        
    }
}
