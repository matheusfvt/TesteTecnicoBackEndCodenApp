namespace TesteTecnicoCodenApp.DTOs;

public class OrcamentoCriarResponse
{
    public int Id { get; set; }
    public string Status { get; set; } = "";
    public decimal ValorTotal { get; set; }
    public DateTime DataCriacao { get; set; }
}
