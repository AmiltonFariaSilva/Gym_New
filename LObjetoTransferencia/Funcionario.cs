using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LObjetoTransferencia
{
    class Funcionario
    {
        public int IdFuncionario { get; set; }
        public String Nome { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        public String Perfil { get; set; }
        public Boolean Situacao { get; set; }
        public int IdEndereco { get; set; }
    }
}
