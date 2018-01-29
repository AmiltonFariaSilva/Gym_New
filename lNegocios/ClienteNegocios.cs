using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lAcessoBancoDados;
using LObjetoTransferencia;
using System.Data;

namespace lNegocios
{
    public class ClienteNegocios
    {
        // Instancia = criar um novo objeto baseado em um modelo
        clAcessoDadosSqlServer acessoDadosSqlServer = new clAcessoDadosSqlServer();

        public string Inserir(Cliente cliente)
        {
            try
            {
                //Limpa os parametros que estiverem na coleção
                acessoDadosSqlServer.LimparParametros();

                //adiciona os novos parametros para inserir no banco                
                acessoDadosSqlServer.AdicionarParametros("@Nome", cliente.Nome);
                acessoDadosSqlServer.AdicionarParametros("@DataNascimento", cliente.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@Sexo", cliente.Sexo);
                acessoDadosSqlServer.AdicionarParametros("@CPF", cliente.CPF);
                acessoDadosSqlServer.AdicionarParametros("@RG", cliente.RG);
                acessoDadosSqlServer.AdicionarParametros("@LimiteCompra", cliente.LimiteCompra);
                acessoDadosSqlServer.AdicionarParametros("@Pagamento", cliente.Pagamento);

                //Executa a procedure para inserir, e recebe um retorno do banco
                string idCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteInserir").ToString();
                
                return idCliente;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        
        public string Alterar(Cliente cliente)
        {
            try
            {
                //Limpa os parametros que estiverem na coleção
                acessoDadosSqlServer.LimparParametros();

                //adiciona os novos parametros para inserir no banco                
                acessoDadosSqlServer.AdicionarParametros("@IdCliente", cliente.IdCliente);
                acessoDadosSqlServer.AdicionarParametros("@Nome", cliente.Nome);
                acessoDadosSqlServer.AdicionarParametros("@DataNascimento", cliente.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@Sexo", cliente.Sexo);
                acessoDadosSqlServer.AdicionarParametros("@CPF", cliente.CPF);
                acessoDadosSqlServer.AdicionarParametros("@RG", cliente.RG);
                acessoDadosSqlServer.AdicionarParametros("@LimiteCompra", cliente.LimiteCompra);
                acessoDadosSqlServer.AdicionarParametros("@Pagamento", cliente.Pagamento);

                string IdCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteAlterar").ToString();

                return IdCliente;

            }
            catch (Exception exception)
            {
                return exception.Message;
            }

        }

        public string Excluir(Cliente cliente)
        {
            try
            {
                //Limpa os parametros que estiverem na coleção
                acessoDadosSqlServer.LimparParametros();

                //adiciona os novos parametros para inserir no banco                
                acessoDadosSqlServer.AdicionarParametros("@IdCliente", cliente.IdCliente);

                string IdCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteExcluir").ToString();

                return IdCliente;

            }
            catch (Exception exception)
            {
                return exception.Message;
            }

        }
        
        public ClienteCollection ConsultaPorNome(string nome)
        {
            try
            {
                //Criar uma coleção nova de clientes (aqui ela está vazia)
                ClienteCollection clienteColecao = new ClienteCollection();

                //Limpa os parametros que estiverem na coleção
                acessoDadosSqlServer.LimparParametros();
                //adiciona os novos parametros para inserir no banco                
                acessoDadosSqlServer.AdicionarParametros("@Nome", nome);
                                
                DataTable dataTableCliente = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspClienteConsultarPorNome");
                
                //Percorrer o DataTable e transformar em coleção de cliente
                //Cada linha do DataTable é um cliente
                foreach (DataRow linha in dataTableCliente.Rows )
                {
                    //Criar um cliente vazio 
                    Cliente cliente = new Cliente();

                    //Colocar os dados da linha nele
                    cliente.IdCliente      = Convert.ToInt32(linha["IdCliente"]);
                    cliente.Nome           = Convert.ToString(linha["Nome"]);
                    cliente.DataNascimento = Convert.ToDateTime(linha["DataNascimento"]);
                    cliente.Sexo           = Convert.ToBoolean(linha["Sexo"]);
                    cliente.LimiteCompra   = Convert.ToDecimal(linha["LimiteCompra"]);
                    cliente.CPF = Convert.ToString(linha["CPF"]);
                    cliente.RG = Convert.ToString(linha["RG"]);
                    cliente.Pagamento      = Convert.ToBoolean(linha["Pagamento"]);

                    //Adicionar ele na coleção
                    clienteColecao.Add(cliente);
                }

                return clienteColecao;

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consular o cliente por nome. Detalhes: " + ex.Message);
            }
        }

        public ClienteCollection ConsultaPorID(string idCliente)
        {
            try
            {
                //Criar uma coleção nova de clientes (aqui ela está vazia)
                ClienteCollection clienteColecao = new ClienteCollection();

                //Limpa os parametros que estiverem na coleção
                acessoDadosSqlServer.LimparParametros();
                //adiciona os novos parametros para inserir no banco                
                acessoDadosSqlServer.AdicionarParametros("@IdCliente", idCliente);

                DataTable dataTableCliente = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspClienteConsultarPorId");

                //Percorrer o DataTable e transformar em coleção de cliente
                //Cada linha do DataTable é um cliente
                foreach (DataRow linha in dataTableCliente.Rows)
                {
                    //Criar um cliente vazio 
                    Cliente clienteEncontrado1 = new Cliente();

                    //Colocar os dados da linha nele
                    clienteEncontrado1.IdCliente = Convert.ToInt32(linha["IdCliente"]);
                    clienteEncontrado1.Nome = Convert.ToString(linha["Nome"]);
                    clienteEncontrado1.DataNascimento = Convert.ToDateTime(linha["DataNascimento"]);
                    clienteEncontrado1.Sexo = Convert.ToBoolean(linha["Sexo"]);
                    clienteEncontrado1.LimiteCompra = Convert.ToDecimal(linha["LimiteCompra"]);
                    clienteEncontrado1.CPF = Convert.ToString(linha["CPF"]);
                    clienteEncontrado1.RG = Convert.ToString(linha["RG"]);
                    clienteEncontrado1.Pagamento = Convert.ToBoolean(linha["Pagamento"]);

                    //Adicionar ele na coleção
                    clienteColecao.Add(clienteEncontrado1);
                }

                return clienteColecao;

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consular o cliente pelo ID. Detalhes: " + ex.Message);
            }
        }
    }
}
