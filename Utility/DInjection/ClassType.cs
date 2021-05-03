using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.DInjection
{
    public class ClassType<i, t> : IClassType
    {
        public ClassType()
        {

        }
        public Type GetInterface()
        {
            return typeof(i);
        }
        public Type GetClass()
        {
            return typeof(t);
        }

    }
}
