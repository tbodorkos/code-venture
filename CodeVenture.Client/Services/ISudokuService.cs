using System.Threading.Tasks;
using CodeVenture.Shared.DTOs;

namespace CodeVenture.Client.Services
{
    public interface ISudokuService 
    {
        Task<SudokuGrid> GenerateRandomGrid();
        Task<SudokuGrid> Solve(SudokuGrid grid);
    }
}