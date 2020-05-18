using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForm;

namespace MyForm
{
    class Sorting
    {
        public int[] sorting(int[] c)
        {
            int t = 0;
            for (int i = 0; i< c.Length; i++)
            {
                for (int j = 0; j< c.Length; j++)
                {
                    if (c[i] < c[j])
                    {
                        t = c[j];
                        c[j] = c[i];
                        c[i] = t;
                        //temp = 1;
                    }
                }

            }
            return c;
        }  
    }
}
