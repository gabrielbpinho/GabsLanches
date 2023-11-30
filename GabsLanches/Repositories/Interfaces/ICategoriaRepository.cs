using GabsLanches.Models;

namespace GabsLanches.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetCategorias { get; }
    }
}
