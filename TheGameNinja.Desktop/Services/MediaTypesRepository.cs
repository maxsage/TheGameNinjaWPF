using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TheGameNinja.Data;

namespace TheGameNinja.Desktop.Services
{
    class MediaTypesRepository : IMediaTypesRepository
    {
        TheGameNinjaDbContext _context = new TheGameNinjaDbContext();

        public async Task<List<MediaType>> GetAllMediaTypesAsync()
        {
            return await _context.MediaTypes.ToListAsync();
        }
    }
}
