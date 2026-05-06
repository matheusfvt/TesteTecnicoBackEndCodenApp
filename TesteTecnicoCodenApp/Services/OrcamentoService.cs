using TesteTecnicoCodenApp.Data;
using TesteTecnicoCodenApp.DTOs;
using TesteTecnicoCodenApp.Models;

namespace TesteTecnicoCodenApp.Services;

public class OrcamentoService
{
    private readonly AppDbContext _context;

    public OrcamentoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<OrcamentoCriarResponse> CriarAsync(OrcamentoCriarRequest request)
    {
        var orcamento = new Orcamento
        {
            ClienteId   = request.ClienteId,
            VeiculoId   = request.VeiculoId,
            Status      = "Aberto",
            DataCriacao = DateTime.UtcNow
        };

        foreach (var itemRequest in request.Itens)
        {
            orcamento.Itens.Add(new OrcamentoItem
            {
                Descricao     = itemRequest.Descricao,
                Quantidade    = itemRequest.Quantidade,
                ValorUnitario = itemRequest.ValorUnitario,
                ValorTotal    = itemRequest.Quantidade * itemRequest.ValorUnitario
            });
        }

        orcamento.ValorTotal = orcamento.Itens.Sum(i => i.ValorTotal);

        _context.Orcamentos.Add(orcamento);
        await _context.SaveChangesAsync();

        return new OrcamentoCriarResponse
        {
            Id          = orcamento.Id,
            Status      = orcamento.Status,
            ValorTotal  = orcamento.ValorTotal,
            DataCriacao = orcamento.DataCriacao
        };
    }
}
