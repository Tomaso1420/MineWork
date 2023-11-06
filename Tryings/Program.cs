using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Program
    {
        public static void Main()
        {

            string s = "342";
            int.TryParse(s, out int n);
                Console.WriteLine(n);
        }
    }
}