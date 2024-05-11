using System.ComponentModel.DataAnnotations;

namespace ContasFrontEnd.Model
{
    public class Recebedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe um nome como: Boleto Viacredi, Cartão de Crédito...")]
        [MinLength(3, ErrorMessage = "Precisa ter no mínimo 3 caracteres. Exemplo: Boleto Viacredi, Cartão de Crédito...")]
        public string Nome { get; set; }
    }
}
