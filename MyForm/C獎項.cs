using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
    class C獎項
    {
        public int c獎項(int notsp, int sp) 
        {
            if (notsp == 6)
                return 1;
            else if (notsp == 5 && sp == 1)
                return 2;
            else if (notsp == 5)
                return 3;
            else if (notsp == 4 && sp == 1)
                return 4;
            else if (notsp == 4)
                return 5;
            else if (notsp == 3 && sp == 1)
                return 6;
            else if (notsp == 2 && sp == 1)
                return 7;
            else if (notsp == 3)
                return 8;
            else return 9;
        }
    }
}
