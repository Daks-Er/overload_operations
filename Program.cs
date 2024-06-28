using System;

namespace overload_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность матрицы: ");
            int n = UI.askInteger(1, 20);

            Console.WriteLine("Матрица А:");
            Square_Matrix matrix1 = new Square_Matrix(n);
            
            Console.WriteLine("Матрица B:");
            Square_Matrix matrix2 = new Square_Matrix(n);
            
            Console.WriteLine("Матрица А: \n" + matrix1.ToString());
            Console.WriteLine();
            Console.WriteLine("Матрица В: \n" + matrix2.ToString());
            Console.WriteLine();

            Console.WriteLine("Сложение матриц А и B: ");
            Console.WriteLine((matrix1 + matrix2).ToString());

            Console.WriteLine("Вычитание матриц А и B: ");
            Console.WriteLine((matrix1 - matrix2).ToString());

            Console.WriteLine("Умножение матриц А и B: ");
            Console.WriteLine((matrix1 * matrix2).ToString());

            Console.WriteLine("Введите число для умножения (от 0 до 100): ");
            int k = UI.askInteger(0,100);

            Console.WriteLine("Умножение матрицы А на число " + k + ": ");
            Console.WriteLine((matrix1 * k).ToString());

            Console.WriteLine("Определитель матрицы А: " + (int)matrix1);
            Console.WriteLine("Определитель матрицы B: " + (int)matrix2);
            Console.WriteLine();

            Console.WriteLine("Транспонирование матрицы А: ");
            ++matrix1;
            Console.WriteLine(matrix1.ToString());

            Console.WriteLine("Транспонирование матрицы B: ");
            ++matrix2;
            Console.WriteLine(matrix2.ToString());

            Console.WriteLine("Сравнение матриц A и B: ");
            Console.WriteLine("A > B:" + (matrix1 > matrix2));
            Console.WriteLine("A < B:" + (matrix1 < matrix2));
            Console.WriteLine("A == B:" + (matrix1 == matrix2));
            Console.WriteLine("A != B:" + (matrix1 != matrix2));

            Console.WriteLine();

            Console.WriteLine("Система линейных алгебраических уравнений");

            Console.WriteLine("Матрица:");
            System system = new System(n);

            Console.WriteLine("Матрица:");
            Console.WriteLine(system.ToString());
            Console.WriteLine();
            
            string s = System.Number(system, n);
            if (s == "Решений нет" || s == "Бесконечно много решений")
                Console.WriteLine(s);
            else
            {
                Console.WriteLine(s);
                Console.Write("Решение системы: ");
                Console.WriteLine(System.Result(system, n));
            }
            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Массив матриц");
            Console.WriteLine("Введите длину массива матриц: ");
            int n1 = UI.askInteger(1,20);

            Array a = new Array(n1, n);
            Console.WriteLine();
            Console.WriteLine("Массив матриц:");
            Console.WriteLine(a);
            a.Sort();
            Console.WriteLine("Отсортированный по возрастанию массив матриц:");
            Console.WriteLine(a);

            Console.WriteLine();

            Console.WriteLine("Индивидуальное задание");
            
            Console.WriteLine("Матрица C:");
            Square_Matrix matrix3 = new Square_Matrix(n);
            Console.WriteLine("Матрица D:");
            Square_Matrix matrix4 = new Square_Matrix(n);
            ++matrix1;
            ++matrix2;
            Console.WriteLine("Матрица А: \n" + matrix1.ToString());
            Console.WriteLine();
            Console.WriteLine("Матрица В: \n" + matrix2.ToString());
            Console.WriteLine();
            Console.WriteLine("Матрица C: \n" + matrix3.ToString());
            Console.WriteLine();
            Console.WriteLine("Матрица D: \n" + matrix4.ToString());
            Console.WriteLine();
            Console.WriteLine("B*C*D-AТ");
            Console.WriteLine((matrix2 * matrix3) * matrix4 - (++matrix1));
        }
    }
}
