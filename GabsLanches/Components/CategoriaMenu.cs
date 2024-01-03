using GabsLanches.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GabsLanches.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.GetCategorias.OrderBy(c => c.CategoriaNome);
            return View(categorias);
        }
    }
}
