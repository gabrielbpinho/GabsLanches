using GabsLanches.Context;
using GabsLanches.Models;
using GabsLanches.Repositories.Interfaces;

namespace GabsLanches.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> GetCategorias => _context.Categorias;
    }
}
