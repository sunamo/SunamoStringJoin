using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoStringJoin;
public class SHSE
{
    public static string TrimEnd(string name, string ext)
    {
        while (name.EndsWith(ext)) return name.Substring(0, name.Length - ext.Length);

        return name;
    }
}
