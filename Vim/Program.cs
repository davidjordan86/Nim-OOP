using System;
using System.ComponentModel.Design;

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

            // Create an object that is responsible for outputting the current board state as text
            DrawBoard Output = new DrawBoard(board);

            // Create new computer AI for the player to play against
            ComputerAI Opponent = new ComputerAI();
            
            // GAME LOOP
            while (true)
            {

                // Getting valid input from user: which pile they want to select
                int selectedPile;
                do
                {
                    Console.WriteLine("Which pile do you want to take from?");
                    int.TryParse(Console.ReadLine(), out selectedPile);
                } while (selectedPile < 1 || selectedPile > board.Length || board[selectedPile - 1].NumberOfObjects < 1);


                // More valid input: how many stones to remove
                int numOfStonesToRemove;
                do
                {
                    Console.WriteLine("How many stones do you want to remove from pile {0}", selectedPile);
                    int.TryParse(Console.ReadLine(), out numOfStonesToRemove);
                } while (numOfStonesToRemove < 1 || numOfStonesToRemove > board[selectedPile-1].NumberOfObjects);

                // Remove the number of stones the player wants from the pile they choose
                board[selectedPile-1].RemoveStones(numOfStonesToRemove);

                // Now the computer can take it's turn
                // We send it the current state of the board, as well as two empty ints
                // We will pass the ints by referance so the function can override them
                // This is because we are returning mutiple variables from the function
                int pile;
                int stones;
                string message;
                Opponent.TakeTurn(board, out pile, out stones, out message);

                // Apply the computer's turn
                board[pile].RemoveStones(stones);

                // Clear and update the board
                Output.UpdateBoard(board);

                // print out what the computer did
                Console.WriteLine(message);

            }
        }

        bool CheckForEndGame(Heap[] board)
        {
            // Check for end game
            int highestPile = 0;
            foreach (var item in board)
            {
                if (item.NumberOfObjects > highestPile) { highestPile = item.NumberOfObjects; }
            }

            // If the largest pile in the game is 1 stone or less then the game is over
            if (highestPile <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
