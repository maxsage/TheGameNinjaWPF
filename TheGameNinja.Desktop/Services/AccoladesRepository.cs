using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TheGameNinja.Data;

namespace TheGameNinja.Desktop.Services
{
    public class AccoladesRepository : IAccoladesRepository
    {
        TheGameNinjaDbContext _context = new TheGameNinjaDbContext();

        public async Task<List<Accolade>> GetAccoladesForVideoGamesAsync(int videoGameId)
        {
            return await _context.Accolades.Where(o => o.VideoGameId == videoGameId).ToListAsync();
        }

        public async Task<List<Accolade>> GetAllAccoladesAsync()
        {
            return await _context.Accolades.ToListAsync();
        }

        public async Task<Accolade> AddAccoladeAsync(Accolade accolade)
        {
            _context.Accolades.Add(accolade);
            await _context.SaveChangesAsync();
            return accolade;
        }

        public async Task<Accolade> UpdateAccoladeAsync(Accolade accolade)
        {
            if (!_context.Accolades.Local.Any(a => a.Id == accolade.Id))
            {
                _context.Accolades.Attach(accolade);
            }
            _context.Entry(accolade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return accolade;
        }

        public async Task DeleteAccoladeAsync(int accoladeId)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var accolade = _context.Accolades.FirstOrDefault(a => a.Id == accoladeId);
                if (accolade != null)
                {
                }
                await _context.SaveChangesAsync();
                scope.Complete();
            }
        }
    }
}
