using Data.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.DInjection;

namespace Data
{
    public class DiRegisterData
    {
        public static List<IClassType> GetDataList()
        {
            var list = new List<IClassType>();

            list.Add(new ClassType<ICaseRepository, CaseRepository>());

            return list;
        }
    }
}
