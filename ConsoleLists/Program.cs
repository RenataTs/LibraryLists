using ListsLibrary;
using System;
using System.Collections.Generic;

namespace NewMyLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> array = new ArrayList<int>(new[] { 1, 2, 3 });
            Console.WriteLine();
            array.AddBy(2, 2);
            //array.RemoveAllItemsByValue("a");
            //Console.WriteLine(array.MinValueIndex());
            //array.Add(array);

            //array.AddFront(array);
            //array.Sort();

            //array.InsertByIndex(array, 5);
            //array.AddFrontList(list);
            //array.AddListbyIndex(list, 2);

            //Console.WriteLine(array.MaxValueIndex());
            //array.Reverse();
            //array.AddFront(2);
            //new[] { 5, 6, 7, 8, 9, 10, 11 }

            //array.Sort();

            //array.RemoveAt(3);

            foreach (var item in array)
            {
                Console.Write($"{item}\t");
            }

            //for (int i = 0; i < ; i++)
            //{
            //    array[i] = i;
            //    Console.Write($"{array[i]}\t");
            //}

            //Resize(ref array);

            ////Console.WriteLine();
            ////foreach (var item in array)
            //{
            //    Console.Write($"{item}\t");
            //}

            //ArrayList<int> parts = new ArrayList<int>();

            //// Add parts to the list.
            //parts.Add(4);
            //parts.Add(5);

            //// Write out the parts in the list. This will call the overridden ToString method
            //// in the Part class.
            //Console.WriteLine();
            //foreach (ArrayList aPart in parts)
            //{
            //    Console.WriteLine(aPart);
            //}



        }


    }
}
