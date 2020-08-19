using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using CodeVenture.Shared.DTOs;
using CodeVenture.Client.Models;
using Microsoft.Extensions.Options;

namespace CodeVenture.Client.Services
{
    public class SudokuService : ISudokuService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ISudokuSettings _sudokuSettings;

        public SudokuService(IHttpClientFactory clientFactory, IOptions<SudokuSettings> sudokuSettings)
        {
            _clientFactory = clientFactory;
            _sudokuSettings = sudokuSettings?.Value;
        }

        public async Task<SudokuGrid> GenerateRandomGrid()
        {
            try 
            {
                var response = await _clientFactory.CreateClient().GetAsync(_sudokuSettings.GenerateRandomUrl);
                if(response.IsSuccessStatusCode) 
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<SudokuGrid>(json);
                }
                
                return await GetDummyGrid();
            }
            catch
            {
                return await GetDummyGrid();
            }
        }

        public async Task<SudokuGrid> Solve(SudokuGrid grid)
        {
            try 
            {
                var response = await _clientFactory.CreateClient().GetAsync(_sudokuSettings.SolveUrl);
                if(response.IsSuccessStatusCode) 
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<SudokuGrid>(json);
                }
                
                return null;
            }
            catch
            {
                return null;
            }
        }

        private Task<SudokuGrid> GetDummyGrid()
        {
            var grid = new SudokuGrid();
            grid.Grid[0, 0].Value = 5;
            grid.Grid[0, 1].Value = 3;
            grid.Grid[0, 4].Value = 7;
            grid.Grid[1, 0].Value = 6;
            grid.Grid[1, 3].Value = 1;
            grid.Grid[1, 4].Value = 9;
            grid.Grid[1, 5].Value = 5;
            grid.Grid[2, 1].Value = 9;
            grid.Grid[2, 2].Value = 8;
            grid.Grid[2, 7].Value = 6;

            grid.Grid[3, 0].Value = 8;
            grid.Grid[3, 4].Value = 6;
            grid.Grid[3, 8].Value = 3;
            grid.Grid[4, 0].Value = 4;
            grid.Grid[4, 3].Value = 8;
            grid.Grid[4, 5].Value = 3;
            grid.Grid[4, 8].Value = 1;
            grid.Grid[5, 0].Value = 7;
            grid.Grid[5, 4].Value = 2;
            grid.Grid[5, 8].Value = 6;

            grid.Grid[6, 1].Value = 6;
            grid.Grid[6, 6].Value = 2;
            grid.Grid[6, 7].Value = 8;
            grid.Grid[7, 3].Value = 4;
            grid.Grid[7, 4].Value = 1;
            grid.Grid[7, 5].Value = 9;
            grid.Grid[7, 8].Value = 5;
            grid.Grid[8, 4].Value = 8;
            grid.Grid[8, 7].Value = 7;
            grid.Grid[8, 8].Value = 9;

            return Task.FromResult(grid);
        }
    }
}