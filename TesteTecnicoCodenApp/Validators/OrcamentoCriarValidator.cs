using TesteTecnicoCodenApp.DTOs;

namespace TesteTecnicoCodenApp.Validators;

public static class OrcamentoCriarValidator
{
    public static List<string> Validar(OrcamentoCriarRequest request)
    {
        var erros = new List<string>();

        if (request.ClienteId <= 0)
            erros.Add("clienteId é obrigatório.");

        if (request.VeiculoId <= 0)
            erros.Add("veiculoId é obrigatório.");

        if (request.Itens == null || request.Itens.Count == 0)
            erros.Add("O orçamento deve ter pelo menos 1 item.");

        if (request.Itens != null)
        {
            for (int i = 0; i < request.Itens.Count; i++)
            {
                var item = request.Itens[i];

                if (string.IsNullOrWhiteSpace(item.Descricao))
                    erros.Add($"Item {i + 1}: descrição é obrigatória.");

                if (item.Quantidade <= 0)
                    erros.Add($"Item {i + 1}: quantidade deve ser maior que zero.");

                if (item.ValorUnitario <= 0)
                    erros.Add($"Item {i + 1}: valor unitário deve ser maior que zero.");
            }
        }

        return erros;
    }
}
