using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TheGameNinja.Data;

namespace TheGameNinja.Desktop.Services
{
    class PlatformsRepository : IPlatformsRepository
    {
        TheGameNinjaDbContext _context = new TheGameNinjaDbContext();

        public async Task<List<Platform>> GetAllPlatformsAsync()
        {
            return await _context.Platforms.ToListAsync();
        }
    }
}
