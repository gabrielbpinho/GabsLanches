﻿using GabsLanches.Models;
using GabsLanches.Repositories.Interfaces;
using GabsLanches.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GabsLanches.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches = new List<Lanche>();
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.GetLanches.OrderBy(l => l.Nome);
                categoriaAtual = "Todas os laches";
            }
            else
            {
                lanches = _lancheRepository.GetLanches
                                .Where(l => l.Categoria.CategoriaNome
                                .Equals(categoria))
                                .OrderBy(l => l.Nome);

                categoriaAtual = categoria;

            }

            var lanchesListViewModel = new LancheListViewModel
            {

                Lanches = lanches,
                CategoriaAtual = categoriaAtual

            };

            return View(lanchesListViewModel);
        }

        public ActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.GetLanches.FirstOrDefault(l => l.LancheId == lancheId);

            return View(lanche);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.GetLanches.OrderBy(l => l.Nome);
                categoriaAtual = "Todas os laches";
            }
            else 
            {
                lanches = _lancheRepository.GetLanches.Where(l => l.Nome.ToLower().Contains(searchString.ToLower()));

                if (lanches.Any())

                    categoriaAtual = "Lanches";
                else
                    categoriaAtual = "Nenhum lanche foi encontrado";
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            });
        }

    }
    
}
