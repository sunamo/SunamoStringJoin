

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoStringJoin._sunamo
{
    internal class CASH
    {
        internal static List<string> WrapWithIfFunc(Func<string, string, bool, bool> f, bool invert, string mustContains, string wrapWith, params string[] whereIsUsed2)
        {
            for (int i = 0; i < whereIsUsed2.Length; i++)
            {
                if (f.Invoke(whereIsUsed2[i], mustContains, invert))
                {
                    whereIsUsed2[i] = wrapWith + whereIsUsed2[i] + wrapWith;
                }
            }
            return whereIsUsed2.ToList();
        }
    }
}
