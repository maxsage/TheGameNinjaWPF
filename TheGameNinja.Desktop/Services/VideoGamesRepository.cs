using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TheGameNinja.Data;

namespace TheGameNinja.Desktop.Services
{
    public class VideoGamesRepository : IVideoGamesRepository
    {
        TheGameNinjaDbContext _context = new TheGameNinjaDbContext();

        public Task<List<VideoGame>> GetVideoGamesAsync()
        {
            //return _context.VideoGames.Include("Accolades").ToListAsync();
            return _context.VideoGames.ToListAsync();

        }

        public async Task SaveVideoGamesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task<List<VideoGameSummary>> GetVideoGameSummariesAsync()
        {
            var videoGameSummaries =
                    (from v in _context.VideoGames
                     select new VideoGameSummary
                     {
                         Name = v.Name,
                         Description = v.Description,
                         Genre = v.Genre,
                         Platform = v.Platform,
                         MediaType = v.MediaType,
                         ImageUrl = v.ImageUrl,
                         DatePurchased = v.DatePurchased,
                         DateReleased = v.DateReleased,
                         Rating = v.Rating,
                         MultiplayerRating = v.MultiplayerRating,
                         CurrentlyPlaying = v.CurrentlyPlaying,
                         Completed = v.Completed
                     });


            return videoGameSummaries.ToListAsync();
        }

        public Task<VideoGame> GetVideoGameAsync(int id)
        {
            return _context.VideoGames.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<VideoGame> AddVideoGameAsync(VideoGame videogame)
        {
            _context.VideoGames.Add(videogame);
            await _context.SaveChangesAsync();
            return videogame;
        }

        public async Task<VideoGame> UpdateVideoGameAsync(VideoGame videoGame)
        {
            if (!_context.VideoGames.Local.Any(v => v.Id == videoGame.Id))
            {
                _context.VideoGames.Attach(videoGame);
            }
            _context.Entry(videoGame).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return videoGame;

        }

        public async Task DeleteVideoGameAsync(int videoGameId)
        {
            var videoGame = _context.VideoGames.FirstOrDefault(v => v.Id == videoGameId);
            if (videoGame != null)
            {
                _context.VideoGames.Remove(videoGame);
            }
            await _context.SaveChangesAsync();
        }
    }
}
