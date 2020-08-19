namespace CodeVenture.Shared.DTOs
{
    public class SudokuGrid 
    {
        public SudokuCell[,] Grid { get; set; } = new SudokuCell[9, 9];

        public SudokuGrid()
        {
            for(int x = 0; x < 9; ++x)
            {
                for(int y = 0; y < 9; ++y)
                {
                    Grid[x, y] = new SudokuCell(x, y);
                }
            }
        }
    }
}