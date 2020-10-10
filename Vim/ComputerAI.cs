using System;
using System.Collections.Generic;
using System.Text;

namespace Nim
{
    class ComputerAI
    {
        public void TakeTurn(Heap[] board, out int pile, out int stones, out string message)
        {
            Random random = new Random();

            do
            {
                pile = random.Next(0, board.Length);
            } while (board[pile].NumberOfObjects <= 0);

            stones = random.Next(1, board[pile].NumberOfObjects);

            message = "The computer removed " + stones + " stones from pile " + pile;
        }
    }
}
