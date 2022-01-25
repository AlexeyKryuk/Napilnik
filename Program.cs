using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Program
    {
        public static int FindIndexOf(int[] array, int element)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == element)
                    return i;

            return -1;
        }

        static void Main(string[] args)
        {
            int[] numbers = new int[] { 41, 1, 3, 10, -81 };

            Console.WriteLine(FindIndexOf(numbers, 10));
        }
    }
}
