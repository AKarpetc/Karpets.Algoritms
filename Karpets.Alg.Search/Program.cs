using System;
using System.Collections.Generic;
using System.Linq;

namespace Karpets.Alg.Search
{
    public class Node
    {
        public Node(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }

    class Program
    {
        static int BinaryReqursionSearch(int[] array, int searchedValue, int first, int last)
        {
            if (first >= last)
            {
                return -1;
            }

            var middle = (first + last) / 2;
            var middleValue = array[middle];

            if (searchedValue == middleValue)
            {
                return middle;
            }
            else
            {
                if (middleValue > searchedValue)
                {
                    //рекурсивный вызов поиска для левого подмассива
                    return BinaryReqursionSearch(array, searchedValue, first, middle - 1);
                }
                else
                {
                    //рекурсивный вызов поиска для правого подмассива
                    return BinaryReqursionSearch(array, searchedValue, middle + 1, last);
                }
            }
        }

        static int BinaryLoopSearch(int[] array, int searchedValue)
        {
            var first = 0;
            var last = array.Count() - 1;
            while (first <= last)
            {
                var middle = (first + last) / 2;
                var middleValue = array[middle];

                if (searchedValue == middleValue)
                {
                    return middle;
                }
                else
                {
                    if (searchedValue > middleValue)
                    {
                        first = middle + 1;

                    }
                    else
                    {
                        last = middle - 1;
                    }
                }

            }

            return -1;
        }

        static void Main(string[] args)
        {
            var array = new List<int>() { 1, 22, 55, 88, 4, 6, 545, 879, 656891, 54, 3, 2, 15, 51, 6, 61, 8, 894, 89894, 9849849, 4, 9498, 4894894, 9484, 984, 984, 8, 9494, 9, 989877979, 6546, 3538, 4648, 464, 4, 66, 11, 22, 33, 88, 99, 77, 654, 456, 987, 789, 312, 123, 333, 222, 111 };

            Console.WriteLine("Массив:");

            array.ForEach(x => Console.Write(x + ","));

            Console.WriteLine();

            while (true)
            {
                Console.Write("Введите искомое значение или -777 для выхода: ");
                var finidngNumber = Convert.ToInt32(Console.ReadLine());
                if (finidngNumber == -777)
                {
                    break;
                }
                var sortedArray = array.OrderBy(x => x).ToArray();
                Console.WriteLine("Бинарный поиск рекурсия");
                var searchResult = BinaryReqursionSearch(sortedArray, finidngNumber, 0, array.Count() - 1);
                if (searchResult < 0)
                {
                    Console.WriteLine("Элемент со значением {0} не найден", finidngNumber);
                }
                else
                {
                    Console.WriteLine("Элемент найден. Индекс элемента со значением {0} равен {1}", finidngNumber, searchResult);
                }

                Console.WriteLine("Бинарный поиск цикл");
                searchResult = BinaryLoopSearch(sortedArray, finidngNumber);
                if (searchResult < 0)
                {
                    Console.WriteLine("Элемент со значением {0} не найден", finidngNumber);
                }
                else
                {
                    Console.WriteLine("Элемент найден. Индекс элемента со значением {0} равен {1}", finidngNumber, searchResult);
                }

            }

            Console.ReadLine();

        }
    }
}
