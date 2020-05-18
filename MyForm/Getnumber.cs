using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
    class Getnumber
    {
        public int[] Random_Number(int c,string s)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            
            List<int> listLinq = new List<int>(Enumerable.Range(1, 49));
            listLinq = listLinq.OrderBy(num => rand.Next()).ToList<int>();

            if (s != "")
            {
                int[] number = new int[6];
                string[] sarray = s.Split(' ');
                for (int j = 0; j < sarray.Length - 1; j++)
                {
                    listLinq.Remove(int.Parse(sarray[j]));
                    number[j] = int.Parse(sarray[j]);
                    Console.WriteLine(number[j].ToString());
                }
                Console.WriteLine(listLinq.Count);
                for (int i = sarray.Length - 1; i < 6; i++)
                {
                    Console.WriteLine($"i {i}");
                    number[i] = listLinq[i];
                }
                return number;
            }
            else
            {
                int[] number = new int[c];
                for (int i = 0; i < c; i++)
                {
                    number[i] = listLinq[i];
                }
                return number;
            }
            

        }
    }
}
