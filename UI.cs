using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overload_operations
{
    internal class UI
    {
        public static int askInteger(int a, int b)
        {
            bool good = false;
            int result = 0;
            while (!good)
            {
                good = int.TryParse(Console.ReadLine(), out result);
                if (!good || result < a || result >= b)
                {
                    Console.WriteLine("\nПолучено некорректное значение. Повторите ввод.\n");
                    good = false;
                }
            }
            return result;
        }
    }
}
