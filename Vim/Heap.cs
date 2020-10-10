namespace Nim
{
    class Heap
    {
        // Keeps track of the number of objects left in this heap
        private int _stones;

        // Sets initial number of objects on creation
        public Heap(int numberOfStones)
        {
            _stones = numberOfStones;
        }

        // Public property for getting the number of objects left
        public int NumberOfObjects
        {
            get => _stones;
        }

        // Only valid move is to reduce stones, so this is the function other classes will use
        // while playing the game.
        // Returns the number of stones removed from the pile, if no stones removed, returns 0
        public int RemoveStones(int number)
        {
            if (_stones > 0 && _stones - number >= 0)
            {
                _stones -= number;
                return number;
            }
            return 0;
        }
    }
}
