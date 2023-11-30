using GabsLanches.Models;

namespace GabsLanches.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> GetLanches { get; }
        IEnumerable<Lanche> GetLanchesPreferidos { get; }
        Lanche GetLancheById(int lacheId);
    }
}
