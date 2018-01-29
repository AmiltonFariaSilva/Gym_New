using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lAcessoBancoDados;
using LObjetoTransferencia;
using System.Data;

namespace lNegocios
{
    public class EnderecoNegocios
    {
        // Instancia = criar um novo objeto baseado em um modelo
        clAcessoDadosSqlServer acessoDadosSqlServer = new clAcessoDadosSqlServer();

        public string Inserir(Endereco endereco)
        {
            try
            {
                //Limpa os parametros que estiverem na coleção
                acessoDadosSqlServer.LimparParametros();
                         

                //adiciona os novos parametros para inserir no banco                
                acessoDadosSqlServer.AdicionarParametros("@Cidade", endereco.Cidade);
                acessoDadosSqlServer.AdicionarParametros("@Estado", endereco.Estado);
                acessoDadosSqlServer.AdicionarParametros("@Sigla", endereco.Sigla);
                acessoDadosSqlServer.AdicionarParametros("@CEP", endereco.CEP);
                acessoDadosSqlServer.AdicionarParametros("@Logradouro", endereco.Logradouro);
                acessoDadosSqlServer.AdicionarParametros("@Numero", endereco.Numero);
                acessoDadosSqlServer.AdicionarParametros("@Bairro", endereco.Bairro);
                acessoDadosSqlServer.AdicionarParametros("@IdAluno", endereco.IdAluno);
                acessoDadosSqlServer.AdicionarParametros("@IdFuncionario", endereco.IdFuncionario);

                //Executa a procedure para inserir, e recebe um retorno do banco
                string idCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspEnderecoInserir").ToString();
                
                return idCliente;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        
        public string Alterar(Endereco endereco)
        {
            try
            {
                //Limpa os parametros que estiverem na coleção
                acessoDadosSqlServer.LimparParametros();

                //adiciona os novos parametros para inserir no banco                
                acessoDadosSqlServer.AdicionarParametros("@IdEndereco", endereco.idEndereco);
                acessoDadosSqlServer.AdicionarParametros("@Cidade", endereco.Cidade);
                acessoDadosSqlServer.AdicionarParametros("@Estado", endereco.Estado);
                acessoDadosSqlServer.AdicionarParametros("@Sigla", endereco.Sigla);
                acessoDadosSqlServer.AdicionarParametros("@CEP", endereco.CEP);
                acessoDadosSqlServer.AdicionarParametros("@Logradouro", endereco.Logradouro);
                acessoDadosSqlServer.AdicionarParametros("@Numero", endereco.Numero);
                acessoDadosSqlServer.AdicionarParametros("@Bairro", endereco.Bairro);
                acessoDadosSqlServer.AdicionarParametros("@IdAluno", endereco.IdAluno);
                acessoDadosSqlServer.AdicionarParametros("@IdFuncionario", endereco.IdFuncionario);

                string IdCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspEnderecoAlterar").ToString();

                return IdCliente;

            }
            catch (Exception exception)
            {
                return exception.Message;
            }

        }

        public string Excluir(Endereco endereco)
        {
            try
            {
                //Limpa os parametros que estiverem na coleção
                acessoDadosSqlServer.LimparParametros();

                //adiciona os novos parametros para inserir no banco                
                acessoDadosSqlServer.AdicionarParametros("@IdEndereco", endereco.idEndereco);

                string IdCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspEnderecoExcluir").ToString();

                return IdCliente;

            }
            catch (Exception exception)
            {
                return exception.Message;
            }

        }
        
        public EnderecoCollection ConsultaPorLogradouro(string Logradouro)
        {
            try
            {
                //Criar uma coleção nova de clientes (aqui ela está vazia)
                EnderecoCollection enderecoColecao = new EnderecoCollection();

                //Limpa os parametros que estiverem na coleção
                acessoDadosSqlServer.LimparParametros();
                //adiciona os novos parametros para inserir no banco                
                acessoDadosSqlServer.AdicionarParametros("@Logradouro", Logradouro);
                                
                DataTable dataTableCliente = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspEnderecoConsultarPorLogradouro");
                
                //Percorrer o DataTable e transformar em coleção de cliente
                //Cada linha do DataTable é um cliente
                foreach (DataRow linha in dataTableCliente.Rows )
                {
                    //Criar um cliente vazio 
                    Endereco endereco = new Endereco();

                    //Colocar os dados da linha nele
                    endereco.idEndereco = Convert.ToInt32(linha["idEndereco"]);
                    endereco.Cidade = Convert.ToString(linha["Cidade"]);
                    endereco.Estado = Convert.ToString(linha["Estado"]);
                    endereco.Sigla = Convert.ToString(linha["Sigla"]);
                    endereco.CEP = Convert.ToString(linha["CEP"]);
                    endereco.Logradouro = Convert.ToString(linha["Logradouro"]);
                    endereco.Numero = Convert.ToInt32(linha["Numero"]);
                    endereco.Bairro = Convert.ToString(linha["Bairro"]);
                    endereco.IdAluno = Convert.ToInt32(linha["IdAluno"]);
                    endereco.IdFuncionario = Convert.ToInt32(linha["IdFuncionario"]);

                    //Adicionar ele na coleção
                    enderecoColecao.Add(endereco);
                }

                return enderecoColecao;

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consular o cliente por nome. Detalhes: " + ex.Message);
            }
        }

        public EnderecoCollection ConsultaPorCep(string Cep)
        {
            try
            {
                //Criar uma coleção nova de clientes (aqui ela está vazia)
                EnderecoCollection enderecoColecao = new EnderecoCollection();

                //Limpa os parametros que estiverem na coleção
                acessoDadosSqlServer.LimparParametros();
                //adiciona os novos parametros para inserir no banco                
                acessoDadosSqlServer.AdicionarParametros("@CEP", Cep);

                DataTable dataTableCliente = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspEnderecoConsultarPorLogradouro");

                //Percorrer o DataTable e transformar em coleção de cliente
                //Cada linha do DataTable é um cliente
                foreach (DataRow linha in dataTableCliente.Rows)
                {
                    //Criar um cliente vazio 
                    Endereco endereco = new Endereco();

                    //Colocar os dados da linha nele
                    endereco.idEndereco = Convert.ToInt32(linha["idEndereco"]);
                    endereco.Cidade = Convert.ToString(linha["Cidade"]);
                    endereco.Estado = Convert.ToString(linha["Estado"]);
                    endereco.Sigla = Convert.ToString(linha["Sigla"]);
                    endereco.CEP = Convert.ToString(linha["CEP"]);
                    endereco.Logradouro = Convert.ToString(linha["Logradouro"]);
                    endereco.Numero = Convert.ToInt32(linha["Numero"]);
                    endereco.Bairro = Convert.ToString(linha["Bairro"]);
                    endereco.IdAluno = Convert.ToInt32(linha["IdAluno"]);
                    endereco.IdFuncionario = Convert.ToInt32(linha["IdFuncionario"]);

                    //Adicionar ele na coleção
                    enderecoColecao.Add(endereco);
                }

                return enderecoColecao;

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consular o cliente por nome. Detalhes: " + ex.Message);
            }
        }
    }
}
