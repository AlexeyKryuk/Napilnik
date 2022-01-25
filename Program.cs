using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public static class Mathf
    {
        public static int Median(int a, int b, int c)
        {
            if (a < b)
                return b;
            else if (a > c)
                return c;
            else
                return a;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = 2, b = 0, c = 1;
            int median = Mathf.Median(a, b, c);

            Console.WriteLine(median); // 1
        }
    }
}
