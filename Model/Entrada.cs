using System.ComponentModel.DataAnnotations;

namespace ContasFrontEnd.Model
{
    public class Entrada
    {
        [Required(ErrorMessage = "Informe um nome como: Salário, Aluguel, Venda do Carro...")]
        [MinLength(3, ErrorMessage = "Precisa ter no mínimo 3 caracteres. Exemplo: Salário, Aluguel, Venda do Carro...")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe o valor recebido mensalmente")]
        public double? Valor { get; set; }
        public DateTime DataVigencia { get; set; }
    }
}
