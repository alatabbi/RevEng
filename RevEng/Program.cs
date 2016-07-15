
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALATABBI.Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] p = new int[] { 3, 2, 1, 3,0,1 };
            var x =  p.RevEng();

            foreach (KeyValuePair<int, List<int>> kv in x)
                Console.WriteLine(string.Format("x[{0}] = {{{1}}}", kv.Key, string.Join(",", kv.Value)));
            Console.ReadLine();

        }
    }
}
