using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    internal class CleanCode_ExampleTask17
    {
        private static int _chance;
        private static int _hourlyRate;

        public static void CreateObject()
        {
            //Создание объекта на карте
        }

        public static void Chance()
        {
            _chance = Random.Range(0, 100);
        }

        public static int CalculateSalary(int hoursWorked)
        {
            return _hourlyRate * hoursWorked;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
