namespace ContasFrontEnd.Model
{
    public class Dividas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public byte DiaVencimento { get; set; }

        public int PagamentosId { get; set; }
        public Pagamentos Pagamentos { get; set; }

        public int RecebedorId { get; set; }
        public Recebedor Recebedor { get; set; }

        //public ICollection<PagamentoDeDividas> PagamentoDeDividas { get; set; }
    }
}
