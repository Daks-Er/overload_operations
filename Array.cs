using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overload_operations
{
    class Array : Square_Matrix
    {
        protected Square_Matrix[] matrix;

        //конструктор
        public Array(int k, int n)
        {
            matrix = new Square_Matrix[k];
            for (int i = 0; i < k; i++)
            {
                matrix[i] = new Square_Matrix(n);
            }
        }

        //сортировка по возрастанию
        public void Sort()
        {
            int l = matrix.Length;
            for (int i = 0; i < l - 1; i++)
                for (int j = 0; j < l - i - 1; j++)
                    if (matrix[j] > matrix[j + 1])
                    {
                        Square_Matrix A = matrix[j];
                        matrix[j] = matrix[j + 1];
                        matrix[j + 1] = A;
                    }
        }

        //перегрузка метода ToString()
        public override string ToString()
        {
            string s = "";
            int l = matrix.Length;
            int m = matrix[0].Length();
            for (int i = 0; i < l; i++)
            {
                s += matrix[i];
                s += "\n\n";
            }
            /*for (int i = 0; i < m; i++)
            {
                for (int k = 0; k < l; k++)
                {
                    for (int j = 0; j < m; j++)
                        s += $"{matrix[k],5}";
                    s += $"{' ',10}";
                }
                s += "\n";
            }
            s += "\n";*/
            return s;
        }
    }
}
