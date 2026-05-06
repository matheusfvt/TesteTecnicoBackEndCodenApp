namespace TesteTecnicoCodenApp.DTOs;

public class OrcamentoCriarRequest
{
    public int ClienteId { get; set; }
    public int VeiculoId { get; set; }
    public List<OrcamentoItemRequest> Itens { get; set; } = new();
}

public class OrcamentoItemRequest
{
    public string Descricao { get; set; } = "";
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
}
