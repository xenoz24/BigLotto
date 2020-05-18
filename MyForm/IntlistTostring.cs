using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
    class IntlistTostring
    {
        public string intlistTostring(int[] l) 
        {
            string s = "";
            for (int i = 0; i < l.Length; i++)
            {
                s += " " + l[i];
            }
            return s.Trim();
        }
    }
}
