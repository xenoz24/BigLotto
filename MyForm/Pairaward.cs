using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyForm
{
    class Pairaward
    {
        public string check(int[] check, int[] win)
        {
            string c = "";
            //MessageBox.Show(check.Length.ToString());
            for (int i = 0; i < check.Length; i++)
            {
                for (int j = 0; j < win.Length-1; j++)
                {
                    if (check[i] == win[j]) 
                    {
                        c += " "+check[i].ToString();
                    }
                }
            }
            for(int i = 0; i < check.Length; i++) 
            {
                if(check[i]==win[6])
                    c += "sp" + check[i].ToString();
            }
            Console.WriteLine(c);
            return c;
        }
    }
}
