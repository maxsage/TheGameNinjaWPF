using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TheGameNinja.Data;

namespace TheGameNinja.Desktop.Services
{
    public class GenresRepository : IGenresRepository
    {
        TheGameNinjaDbContext _context = new TheGameNinjaDbContext();

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }
    }
}
