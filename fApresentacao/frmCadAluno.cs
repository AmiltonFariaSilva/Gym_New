using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lNegocios;
using LObjetoTransferencia;

namespace fApresentacao
{
    public partial class frmCadAluno : Form
    {
        public frmCadAluno()
        {
            InitializeComponent();

            //Não gerar linhas automaticamente
            dataGridViewPrincipal.AutoGenerateColumns = false;
        }
        private void frmCadAluno_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsNewAlexandria.Aluno' table. You can move, or remove it, as needed.
            //this.alunoTableAdapter.Fill(this.dsNewAlexandria.Aluno);
        }        
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            AtualizaGrid();           
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Verificar se tem algum registro selecionado
            if (dataGridViewPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum aluno selecionado.");
                return;
            }

            //Perguntar se realmente quer excluir
            DialogResult  resultado = MessageBox.Show("Deseja mesmo excluir o aluno?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                return;
            }

            //Pegar o cliente selecionado no grid
            Cliente clienteSelecionado = (dataGridViewPrincipal.SelectedRows[0].DataBoundItem as Cliente);

            //Instanciar a regra de negócios
            ClienteNegocios clienteNegocios = new ClienteNegocios();

            string retorno = clienteNegocios.Excluir(clienteSelecionado);

            //Verificar se excluiu com sucesso, se for numero foi sucesso senão erro
            try
            {
                int idCliente = Convert.ToInt32(retorno);

                MessageBox.Show("Cliente excluido com sucesso!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AtualizaGrid();  
            }
            catch 
            {
                MessageBox.Show("Não foi possivel excluir. Detalhes: " + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }
        private void AtualizaGrid()
        {
            ClienteNegocios clienteNegocios = new ClienteNegocios();

            ClienteCollection clienteCollection = clienteNegocios.ConsultaPorNome(txbPesquisa.Text);

            dataGridViewPrincipal.DataSource = null;

            dataGridViewPrincipal.DataSource = clienteCollection;

            dataGridViewPrincipal.Update();
            dataGridViewPrincipal.Refresh();

        }

        private void frmCadAluno_Shown(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            // Verificar se tem algum registro selecionado
            if (dataGridViewPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum aluno selecionado.");
                return;
            }
                        
            //Pegar o cliente selecionado no grid
            Cliente clienteSelecionado = (dataGridViewPrincipal.SelectedRows[0].DataBoundItem as Cliente);
            
            frmCadastrarAluno cadastrarAluno = new frmCadastrarAluno(AcaoNaTela.Alterar, clienteSelecionado);

            DialogResult dialogResult = cadastrarAluno.ShowDialog();

            if (dialogResult == DialogResult.Yes)
            {
                AtualizaGrid();
            }            
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            frmCadastrarAluno cadastrarAluno = new frmCadastrarAluno(AcaoNaTela.Inserir, null);
            DialogResult dialogResult = cadastrarAluno.ShowDialog();

            if (dialogResult == DialogResult.Yes)
            {
                AtualizaGrid();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // Verificar se tem algum registro selecionado
            if (dataGridViewPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum aluno selecionado.");
                return;
            }

            //Pegar o cliente selecionado no grid
            Cliente clienteSelecionado = (dataGridViewPrincipal.SelectedRows[0].DataBoundItem as Cliente);

            frmCadastrarAluno consultarAluno = new frmCadastrarAluno(AcaoNaTela.Consultar, clienteSelecionado);
            consultarAluno.Show();      
        }
    }
}
