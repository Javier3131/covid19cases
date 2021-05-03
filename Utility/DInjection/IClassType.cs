using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.DInjection
{
    public interface IClassType
    {
        Type GetInterface();
        Type GetClass();
    }
}
