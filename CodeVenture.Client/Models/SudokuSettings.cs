namespace CodeVenture.Client.Models
{
    public class SudokuSettings : ISudokuSettings
    {
        public string GenerateRandomUrl { get; set; }
        public string SolveUrl { get; set; }
    }
}