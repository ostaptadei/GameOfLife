

namespace GameOfLifeKata
{
    public class GameOfLife
    {
        private readonly int _width;
        private readonly int _height;
        private int[,] _currentGeneration;
        public GameOfLife(int width, int height)
        {
            _width = width;
            _height = height;
            _currentGeneration = new int[_height, _width];
            InitCells();
        }

        public void SetCellState(int row, int col, int value)
        {
            _currentGeneration[row, col] = value;
        }
        public int GetCellState(int row, int col)
        {
            return _currentGeneration[row, col];
        }

        public void Show()
        {
            for (int row = 0; row < _height; row++)
            {
                for (int col = 0; col < _width; col++)
                {
                    Console.Write(_currentGeneration[row, col] == 0 ? "." : "*");
                }

                Console.WriteLine();

            }
            string delimiter = new('-', _width);
            Console.WriteLine(delimiter);
        }

        public void InitCells()
        {
            for (int row = 0; row < _height; row++)
            {
                for (int col = 0; col < _width; col++)
                {
                    _currentGeneration[row, col] = 0;
                }
            }
        }

        public void NextGeneration()
        {
            int[,] futureGeneration = new int[_height, _width];

            for (int col = 0; col < _height; col++)
            {
                for (int row = 0; row < _width; row++)
                {
                    int aliveNeighbours = 0;
                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                            aliveNeighbours += _currentGeneration[(col + i + _height) % _height, (row + j + _width) % _width];

                    aliveNeighbours -= _currentGeneration[col, row];

                    if ((_currentGeneration[col, row] == 1) && (aliveNeighbours < 2))
                        futureGeneration[col, row] = 0;

                    else if ((_currentGeneration[col, row] == 1) && (aliveNeighbours > 3))
                        futureGeneration[col, row] = 0;

                    else if ((_currentGeneration[col, row] == 0) && (aliveNeighbours == 3))
                        futureGeneration[col, row] = 1;

                    else
                        futureGeneration[col, row] = _currentGeneration[col, row];
                }
            }

            _currentGeneration = futureGeneration;
        }
    }
}
