using System.Collections.Generic;
using System.Threading.Tasks;
using TheGameNinja.Data;

namespace TheGameNinja.Desktop.Services
{
    public interface IVideoGamesRepository
    {
        Task<List<VideoGame>> GetVideoGamesAsync();
        Task<List<VideoGameSummary>> GetVideoGameSummariesAsync();
        Task<VideoGame> GetVideoGameAsync(int id);
        Task<VideoGame> AddVideoGameAsync(VideoGame videoGame);
        Task<VideoGame> UpdateVideoGameAsync(VideoGame videogame);
        Task DeleteVideoGameAsync(int videoGameId);
        Task SaveVideoGamesAsync();
    }
}
