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

            UpdateBoard(HeapArray);
        }

        public void UpdateBoard(Heap[] HeapArray)
        {
            Console.Clear();

            // From 1 to the largest number in a pile... ROW
            for (int i = 0; i < LargestPile; i++)
            {
                // For each pile... COLUMN
                for (int j = 0; j < HeapArray.Length; j++)
                {
                    // 
                    if (LargestPile - i > HeapArray[j].NumberOfObjects)
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
