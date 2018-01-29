using System;

namespace LObjetoTransferencia
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Boolean Sexo { get; set; }
        public decimal LimiteCompra { get; set; }
        public String CPF { get; set; }
        public String RG { get; set; }
        public Boolean Pagamento { get; set; }
    }
}
