using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modul1.Zadanie21
{
    class Program
    {
        //  кол-во строк
        const int n = 2;
        //  кол-во столб
        const int m = 10; 
        static int[,] path = new int[n, m] { { 1, 2, 0, 50, 5, 0, 1, 2, 6, 10 }, { 1, 2, 3, 10, 5, 20, 2, 3, 6, 1 } };
        static void Main(string[] args)
        {
            // поток
            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            // этот метод запускаем в Main
            Gardner2();  
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{path[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        //садовники - 2 метода
        static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // если 2й садовник не побывал,то 1й садовник  ставит метку -1
                    if (path[i, j] >= 0) 
                    {
                        // садовник остановится
                        int delay = path[i, j];  
                        path[i, j] = -1;
                        // задержка
                        Thread.Sleep(delay); 
                    }
                }

            }
        }
        static void Gardner2()
        {
            for (int j = m - 1; j > 0; j--)
            {
                for (int i = n - 1; i > 0; i--)
                {
                    // если 1й садовник не побывал,то 2й садовник  ставит метку -2
                    if (path[i, j] >= 0) 
                    {
                        // садовник остановится
                        int delay = path[i, j];  
                        path[i, j] = -2;
                        // задержка
                        Thread.Sleep(delay); 
                    }
                }
            }
        }
    }
}

