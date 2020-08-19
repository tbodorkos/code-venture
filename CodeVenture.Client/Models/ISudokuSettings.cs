namespace CodeVenture.Client.Models
{
    public interface ISudokuSettings
    {
        string GenerateRandomUrl { get; set; }
        string SolveUrl { get; set; }
    }
}