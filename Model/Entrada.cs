﻿using System.ComponentModel.DataAnnotations;

namespace ContasFrontEnd.Model
{
    public class Entrada
    {
        [Required(ErrorMessage = "Informe um nome como: Salário, Aluguel, Venda do Carro...")]
        [MinLength(3, ErrorMessage = "Precisa ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }
        public double Valor { get; set; }
        public DateTime DataVigencia { get; set; }
    }
}
