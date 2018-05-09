using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;

namespace ASD_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            Numbers num = new Numbers();
            Number_Plus number = new Number_Plus(); 
            List<int> list = new List<int>();

            Console.WriteLine("Введите количество элементов структуры: ");
            string count = Console.ReadLine();
            num._count = Int32.Parse(count);

            int[] array = new int[num._count];
            int[] array2 = new int[num._count];
            List<int> list1 = new List<int>();

            num.Generate_Array(array);

            Console.WriteLine();
            Console.WriteLine("Сгенерированный массив: ");

            for (int i = 0; i < num._count; i++)
            {
                array2[i] = array[i];
                list1.Add(array2[i]);
                Console.Write(array[i] + " ");

            }

            Console.WriteLine();

            for (int i = 0; i < num._count; i++)
            {
                Console.Write(list1[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Сортировка Шелла: ");

            watch.Start();
            num.Shell_sort(array);
            watch.Stop();

            Console.WriteLine();
            Console.WriteLine("Время выполнения программы в секундах: " + watch.Elapsed.Ticks + " мс");
            watch.Reset();

            Console.WriteLine();
            Console.WriteLine("Сортировка списка: ");

            watch.Start();
            num.List_Sort(list, array);
            watch.Stop();

            Console.WriteLine();
            Console.WriteLine("Время выполнения программы в секундах: " + watch.Elapsed.Ticks + " мс");

            int[] array3 = new int[list1.Capacity]; 
            number.Method(list1, array3); 

            for (int i = 0; i < list1.Capacity; i++) 
            { 
            foreach (int element_list in list1) 
            { 
            array3[i] = element_list; 
            Console.Write(array3[i] + " "); 
            } 
            }

            Console.WriteLine(list1.Capacity);
            number.Shell_sort(array3); 

            Console.ReadKey();
        }
    }

    public class Numbers
    {
        public int _count;

        public int GenerateRandomNumber(int min, int max)
        {
            RNGCryptoServiceProvider c = new RNGCryptoServiceProvider();
            byte[] randomNumber = new byte[4];
            c.GetBytes(randomNumber);
            int result = Math.Abs(BitConverter.ToInt32(randomNumber, 0));
            return result % max + min;
        }

        public void Generate_Array(int[] array)
        {
            for (int i = 0; i < _count; i++)
            {
                array[i] = GenerateRandomNumber(-50, 100);
            }
        }

        public void Shell_sort(int[] array)
        {

            int half = array.Length / 2;
            int swap;
            for (int i = 0; i < _count; i++)
            {
                if (i + half < _count)
                {
                    if (array[i] > array[i + half])
                    {
                        swap = array[i + half];
                        array[i + half] = array[i];
                        array[i] = swap;
                        i = -1;
                    }
                }
                else
                {
                    i = -1;
                    half /= 2;
                }
            }

            for (int i = 0; i < _count; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        public void List_Sort(List<int> list, int[] array)
        {
            for (int i = 0; i < _count; i++)
            {
                list.Add(array[i]);
            }

            list.Sort();

            foreach (int element_list in list)
            {
                Console.Write(element_list + " ");
            }
        }
    }

    public class Number_Plus : Numbers 
    { 
        public void Method(List<int> list1, int[] array) 
        { 
            for (int i = 0; i < list1.Capacity - 1; i++) 
            { 
                if (list1[i] > 0) 
                { 
                    array[i] = list1[i]; 
                } 
            } 
        } 
    }
}



