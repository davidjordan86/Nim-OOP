using System;

namespace Nim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Nim!");
            Console.WriteLine("Play the game by removing stones from the piles. You have to remove at least one (1) stone on each of your turns." +
                " Whoever removes the last stone loses the game.");
            
            // Get valid input from the user:
            // Ask them to pick the number of heaps to play with, must be between 1 and 10.
            int numOfHeaps;
            do
            {
                Console.WriteLine("How many piles do you want to play with? (1 - 10)");
                int.TryParse(Console.ReadLine(), out numOfHeaps); // NOTE: the out keyword works like passing by address in c++ (the & operator)
            } while (numOfHeaps < 1 || numOfHeaps > 10);

            // Create an array (called board) to store the number of heaps the player selected.
            Heap[] board = new Heap[numOfHeaps];

            // Fill that array with new heaps each having a random number of stones from 2 to 10
            for (int i = 0; i < numOfHeaps; i++)
            {
                board[i] = new Heap(new Random().Next(2, 10));
            }

            DrawBoard Output = new DrawBoard();
            Output.RenderBoard(board);
            Console.ReadKey();
        }
    }
}
