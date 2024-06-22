using GameOfLifeKata;

namespace GameOfLifeTests
{
    public class GameOfLifeTests
    {
        [Fact]
        public void InitCells_ShouldSetAllCellsToZero()
        {
            var game = new GameOfLife(5, 5);

            var cellsSum = SumAllCells(game);
            Assert.Equal(0, cellsSum);
        }

        [Fact]
        public void SetCellState_ShouldChangeCellState()
        {
            var game = new GameOfLife(5, 5);
            game.SetCellState(2, 2, 1);

            Assert.Equal(1, game.GetCellState(2, 2));
        }

        [Fact]
        public void NextGeneration_ShouldKillSolitaryCell()
        {
            var game = new GameOfLife(5, 5);
            game.SetCellState(2, 2, 1);

            game.NextGeneration();

            Assert.Equal(0, game.GetCellState(2, 2));
        }

        [Fact]
        public void NextGeneration_ShouldKillCellWithMoreThanThreeNeighbours()
        {
            var game = new GameOfLife(5, 5);
            game.SetCellState(2, 2, 1);
            game.SetCellState(2, 3, 1);
            game.SetCellState(3, 3, 1);
            game.SetCellState(2, 4, 1);
            game.SetCellState(3, 2, 1);

            game.NextGeneration();

            Assert.Equal(0, game.GetCellState(3, 3));
        }


        [Fact]
        public void NextGeneration_ShouldKillCellWithLessThanTwoNeighbours()
        {
            var game = new GameOfLife(5, 5);
            game.SetCellState(2, 2, 1);
            game.SetCellState(2, 3, 1);

            game.NextGeneration();

            Assert.Equal(0, game.GetCellState(2, 2));
        }

        [Fact]
        public void NextGeneration_ShouldBringCellWithThreeNeighboursToLife()
        {
            var game = new GameOfLife(5, 5);
            game.SetCellState(2, 2, 1);
            game.SetCellState(3, 3, 1);
            game.SetCellState(2, 4, 1);

            game.NextGeneration();

            Assert.Equal(1, game.GetCellState(2, 3));
        }

    

        [Fact]
        public void NextGeneration_ShouldKeepCellWithTwoNeighboursAlive()
        {
            var game = new GameOfLife(5, 5);
            game.SetCellState(2, 2, 1);
            game.SetCellState(2, 3, 1);
            game.SetCellState(2, 4, 1);

            game.NextGeneration();

            Assert.Equal(1, game.GetCellState(2, 3));
        }

        // Helper method.
        private int SumAllCells(GameOfLife game)
        {
            var sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sum += game.GetCellState(i, j);
                }
            }
            return sum;
        }
    }
}