using GabsLanches.Context;
using GabsLanches.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

namespace GabsLanches.Areas.Admin.Servicos
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext context;

        public RelatorioVendasService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Pedido>> FindByDataAsync(DateTime? dataInicio, DateTime? dataFim)
        {
            var resultado = from obj in context.Pedidos select obj;

            if (dataInicio.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= dataInicio.Value);
            }
            if (dataFim.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= dataFim.Value);
            }

            return await resultado
                .Include(x => x.PedidoItens)
                .ThenInclude(x => x.Lanche)
                .OrderByDescending(x => x.PedidoEnviado)
                .ToListAsync();
        }    
    }
}
