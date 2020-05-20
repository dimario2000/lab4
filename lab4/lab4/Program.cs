using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LAB4
{
    class Program
    {
        //Функція вводу масиву з клавіатури
        static double[,] EnterArray(int n, int m, string name)
        {
            Console.WriteLine(name + ":");
            double[,] arr = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = int.Parse(Console.ReadLine().ToString());
                }
            }
            return arr;
        }
        //Функція генерації масива
        static double[,] GenerationArray(int n, int m)
        {
            double[,] arr = new double[n, m];
            var r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = r.Next(30);
                }
            }
            return arr;
        }
        public static void Show(double[,] arr, int n, int m, string name)
        {
            Console.WriteLine(name);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
        public static void Osn(double[,] a, int n, int m)
        {
            double min, max;
            for (int i = 0; i < n; i++)
            {
                min = a[i, 0];

                Thread one = new Thread(() =>
                {
                    for (int j = 1; j < m; j++)
                    {
                        if (min > a[i, j])
                        {
                            min = a[i, j];
                        }
                    }

                });
                Thread two = new Thread(() =>
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (a[i, j] == min)
                        {
                            max = a[0, j];
                            for (int i2 = 1; i2 < n; i2++)
                            {

                                if (max < a[i2, j])
                                {
                                    max = a[i2, j];
                                }
                            }
                            if (a[i, j] == max)
                            {
                                Console.WriteLine(String.Format("Сiдлова точка = {0}, {1}", i, j));
                            }
                        }
                    }

                });
                one.Start();

                two.Start();
                two.Join();





            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введiть n:");
            int n = int.Parse(Console.ReadLine().ToString());
            Console.WriteLine("Введiть m:");
            int m = int.Parse(Console.ReadLine().ToString());

            Console.WriteLine("1.Random\n2.Enter value");

            int choose = int.Parse(Console.ReadLine().ToString());
            double[,] arr = new double[n, m];
            switch (choose)
            {
                case 1:

                    arr = GenerationArray(n, m);
                    Thread three = new Thread(() =>
                    {
                        Show(arr, n, m, "arr");

                    });
                    Thread four = new Thread(() =>
                    {

                        Osn(arr, n, m);
                    });
                    three.Start();
                    four.Start();
                    



                    break;
                case 2:
                    arr = EnterArray(n, m, "arr");

                    Thread five = new Thread(() =>
                    {
                        Show(arr, n, m, "arr");
                    });
                    Thread six = new Thread(() =>
                    {

                        Osn(arr, n, m);
                    });
                    five.Start();
                    six.Start();
                    

                    break;
            }
            Console.Read();

        }
    }
}
