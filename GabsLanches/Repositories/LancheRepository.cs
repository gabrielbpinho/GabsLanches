using GabsLanches.Context;
using GabsLanches.Models;
using GabsLanches.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GabsLanches.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> GetLanches => _context.Lanches.
                                   Include(x=>x.Categoria);

        public IEnumerable<Lanche> GetLanchesPreferidos => _context.Lanches.
                                   Where(x => x.IsLanchePreferido).
                                   Include(x=>x.Categoria);

        public Lanche GetLancheById(int lacheId)
        {
            return _context.Lanches.FirstOrDefault(x => x.LancheId == lacheId);
        }
    }
}
