namespace CodeVenture.Shared.DTOs
{
    public class SudokuCell
    {
        public Coordinate Position { get; private set; }
        public int Value { get; set; } = 0;

        public SudokuCell()
        {
        }

        public SudokuCell(int x, int y)
        {
            Position = new Coordinate(x, y);
        }

        public override string ToString()
        {
            return Value == 0 ? "" : Value.ToString();
        }
    }
}