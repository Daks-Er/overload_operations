using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overload_operations
{
    class Square_Matrix
    {
        protected int[,] matrixArray;

        public Square_Matrix(int n)
        {
            matrixArray = new int[n, n];
            FillingMat(n);
        }

        public Square_Matrix(int[,] A)
        {
            matrixArray = A;
        }

        public Square_Matrix() { }

        public int this[int i, int j]
        {
            get
            {
                return matrixArray[i, j];
            }
        }

        private void FillingMat(int n)
        {
            int command = 0;
            Console.WriteLine("Как заполнить матрицу: \n1.Случайно\n2.Самостоятельно");
            command = UI.askInteger(1,3);
            if (command == 1) Rand(n);
            else WriteMat(n);
        }

        //заполнение матрицы случайными значениями
        private void Rand(int n)
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrixArray[i, j] = rand.Next(-100, 100);
                }
            }
        }

        //заполнение матрицы пользователем
        private void WriteMat(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("Введите элемент матрицы {0}:{1}", i + 1, j + 1);
                    matrixArray[i, j] = UI.askInteger(-100,100);
                }
            }
        }

        public int Length()
        {
            return matrixArray.Length;
        }

        //сложение матриц
        private static Square_Matrix Sum(Square_Matrix a, Square_Matrix b)
        {
            int n = a.matrixArray.GetLength(0);
            Square_Matrix resMatrix = new Square_Matrix(new int[n,n]);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resMatrix.matrixArray[i, j] = a[i, j] + b[i, j];
                }
            }
            return resMatrix;
        }
        //перегрузка оператора сложения
        public static Square_Matrix operator +(Square_Matrix a, Square_Matrix b)
        {
            return Sum(a, b);
        }

        //вычитание матриц
        private static Square_Matrix Sub(Square_Matrix a, Square_Matrix b)
        {
            int n = a.matrixArray.GetLength(0);
            Square_Matrix resMatrix = new Square_Matrix(new int[n,n]);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resMatrix.matrixArray[i, j] = a[i, j] - b[i, j];
                }
            }
            return resMatrix;
        }
        //перегрузка оператора вычитания
        public static Square_Matrix operator -(Square_Matrix a, Square_Matrix b)
        {
            return Sub(a, b);
        }

        //умножение матрицы на число
        private static Square_Matrix MultX(Square_Matrix a, int x)
        {
            int n = a.matrixArray.GetLength(0);
            Square_Matrix resMatrix = new Square_Matrix(new int[n,n]);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resMatrix.matrixArray[i, j] = a[i, j] * x;
                }
            }
            return resMatrix;
        }
        //перегрузка оператора умножения
        public static Square_Matrix operator *(Square_Matrix a, int x)
        {
            return MultX(a, x);
        }

        //умножение матриц
        private static Square_Matrix Mult(Square_Matrix a, Square_Matrix b)
        {
            int n = a.matrixArray.GetLength(0);
            Square_Matrix resMatrix = new Square_Matrix(new int[n,n]);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                        resMatrix.matrixArray[i, j] += a[i, k] * b[k, j];

            return resMatrix;
        }
        // перегрузка оператора умножения
        public static Square_Matrix operator *(Square_Matrix a, Square_Matrix b)
        {
            return Mult(a, b);
        }

        //транспонирование матрицы
        private static Square_Matrix Swap(Square_Matrix a)
        {
            int n = a.matrixArray.GetLength(0);
            int x;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    x = a[i, j];
                    a.matrixArray[i, j] = a[j, i];
                    a.matrixArray[j, i] = x;
                }
            }
            return a;
        }
        public static Square_Matrix operator ++(Square_Matrix a)
        {
            return Swap(a);
        }

        //поиск определителя
        protected static int GetM(int[,] a)
        {
            int result;
            int n = a.GetLength(0);
            if (n == 1)
            {
                result = a[0, 0];
            }
            else if (n == 2)
            {
                result = a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0];
            }
            else
            {
                int[,] Minor = new int[n - 1, n - 1];
                int i, j, k;
                short Minus = 1;
                int temp;
                result = 0;

                for (i = 0; i < n; i++)
                {
                    for (j = 1; j < n; j++)
                    {
                        for (k = 0; k < i; k++) //значения до диагонали
                            Minor[j - 1, k] = a[j, k];

                        for (k++; k < n; k++)   //значения после диагонали
                            Minor[j - 1, k - 1] = a[j, k];
                    }

                    temp = GetM(Minor);
                    temp = a[0, i] * Minus * temp;
                    result += temp;

                    if (Minus > 0) 
                        Minus = -1;
                    else
                        Minus = 1;
                }
            }

            return result;
        }
        public static explicit operator int(Square_Matrix a)
        {
            return GetM(a.matrixArray);
        }

        static public bool operator >(Square_Matrix a, Square_Matrix b)
        {
            return (int)a > (int)b;
        }

        static public bool operator <(Square_Matrix a, Square_Matrix b)
        {
            return (int)a < (int)b;
        }

        static public bool operator ==(Square_Matrix a, Square_Matrix b)
        {
            return (int)a == (int)b;
        }

        static public bool operator !=(Square_Matrix a, Square_Matrix b)
        {
            return (int)a != (int)b;
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

                s += "\n";
            }

            return s;
        }
    }
}
