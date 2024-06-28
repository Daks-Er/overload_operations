using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overload_operations
{
    class System : Square_Matrix
    {
        //свободные члены уравнений
        protected int[] freeMembers;
        public System(int n) : base(n) 
        {
            freeMembers = new int[n];
            FillingMem(n);
        }
        public System(int[,] n) : base(n) 
        {
            freeMembers = new int[n.Length];
            FillingMem(n.Length);
        }
        public System(int[,] n, int[] n1) : base(n)
        {
            freeMembers = n1;
        }
        public System() : base() { }

        private void FillingMem(int n)
        {
            int command = 0;
            Console.WriteLine("Как заполнить свободные члены: \n1.Случайно\n2.Самостоятельно");
            command = UI.askInteger(1, 3);
            if (command == 1) RandMem(n);
            else WriteMem(n);
        }

        //заполнение свободных членов случайными значениями
        private void RandMem(int n)
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                freeMembers[i] = rand.Next(-100, 100);   
            }
        }

        //заполнение свободных членов пользователем
        private void WriteMem(int n)
        {
            Console.WriteLine("Введите свободные члены:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите элемент свободного члена {0}", i + 1);
                freeMembers[i] = UI.askInteger(-100, 100);
            }
        }

        public static double Members(System system, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                system.matrixArray[i, m] = system.freeMembers[i];
            }
            double p = GetM(system.matrixArray);
            return p;
        }

        //кол-во решений
        public static string Number(System system, int n)
        {
            int res = 0, k = 0;
            if (GetM(system.matrixArray) != 0)
            {
                return "Одно решение";
            }
            else
            {
                System systemResult = new System(new int[n,n], new int[n]);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        systemResult.matrixArray[i, j] = system.matrixArray[i, j];
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (Members(systemResult, n, k) == 0)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            for (int z = 0; z < n; z++)
                            {
                                systemResult.matrixArray[j, z] = system.matrixArray[j, z];
                            }
                        }
                        res++;
                        k++;
                    }
                }
                if (res != n)
                {
                    return "Решений нет";
                }
                else
                {
                    return "Бесконечно много решений";
                }
            }
        }
        //поиск решения системы
        public static string Result(System system, int n)
        {
            System systemResult = new System(new int[n,n], new int[n]);
            double opr = GetM(system.matrixArray);
            int k = 0;
            double[] res = new double[n];
            string s = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    systemResult.matrixArray[i, j] = system.matrixArray[i, j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                res[i] = (Members(systemResult, n, k) / opr);
                k++;
                for (int j = 0; j < n; j++)
                {
                    for (int z = 0; z < n; z++)
                    {
                        systemResult.matrixArray[j, z] = system.matrixArray[j, z];
                    }
                }
            }
            for (int i = 0; i < n; i++)
                s += $"{res[i]} ";
            return s;
        }

        //перегрузка метода ToString()
        public override string ToString()
        {
            String s = "";
            int n = matrixArray.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s += matrixArray[i, j] + "\t";
                }
                s += "|\t" + freeMembers[i];
                s += "\n";
            }
            return s;
        }
    }
}
