using System;
using System.Collections.Generic;
using System.Text;

namespace Nim
{
    class DrawBoard
    {
        int LargestPile = 0;

        public DrawBoard(Heap[] HeapArray)
        {
            Console.Clear();
            LargestPile = 0;
            foreach (Heap heap in HeapArray)
            {
                if (heap.NumberOfObjects >= LargestPile)
                {
                    LargestPile = heap.NumberOfObjects;
                }
            }

            for (int i = 0; i < LargestPile + 1; i++)
            {
                for (int j = 0; j < HeapArray.Length; j++)
                {
                    if (LargestPile - i >= HeapArray[j].NumberOfObjects)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(LargestPile - i + " ");
                    }
                }
                Console.Write("\n");
            }
        }

        public void UpdateBoard(Heap[] HeapArray)
        {
            Console.Clear();
            for (int i = 0; i < LargestPile + 1; i++)
            {
                for (int j = 0; j < HeapArray.Length; j++)
                {
                    if (LargestPile - i >= HeapArray[j].NumberOfObjects)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(LargestPile - i + " ");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
