using lNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LObjetoTransferencia;

namespace fApresentacao
{
    public partial class frmCadastrarAluno : Form
    {
        AcaoNaTela acaoNaTelaSelecionada;
        public frmCadastrarAluno( AcaoNaTela acaoNaTela, Cliente cliente)
        {
            InitializeComponent();

            this.acaoNaTelaSelecionada = acaoNaTela;

            if (acaoNaTela == AcaoNaTela.Inserir)
            {
                this.label1.Text = "Inserir Aluno";
                this.txbIdCliente.ReadOnly = true;
                
            }
            else if (acaoNaTela == AcaoNaTela.Alterar)
            {
                this.label1.Text = "Alterar Aluno";
                this.txbIdCliente.Text = cliente.IdCliente.ToString();
                this.txbNome.Text = cliente.Nome;
                this.txbRG.Text = cliente.RG;
                this.txbCPF.Text = cliente.CPF;
                this.dtpData.Value = cliente.DataNascimento;
                if (cliente.Sexo == true)
                {
                    this.rbMasculino.Checked = true;
                }
                else
                {
                    this.rbFeminio.Checked = true;
                }
                if (cliente.Pagamento == true)
                {
                    this.cbOk.Checked = true;
                }
                else
                {
                    this.cbOk.Checked = false;
                }
            }
            else if (acaoNaTela == AcaoNaTela.Consultar)
            {
                this.label1.Text = "Consultar Aluno";

                this.btnSalvar.Visible = false;
                this.btnCancelar.Text = "&Fechar";
                this.btnCancelar.Focus();

                this.label1.Text = "Alterar Aluno";

                this.txbIdCliente.ReadOnly = true;
                this.txbNome.ReadOnly = true;
                this.txbRG.ReadOnly = true;
                this.txbCPF.ReadOnly = true;
                this.dtpData.Enabled = false;
                this.rbMasculino.Enabled = false;
                this.rbFeminio.Enabled = false;
                this.cbOk.Enabled = false;

                this.txbIdCliente.TabStop = false;
                this.txbNome.TabStop = false;
                this.txbRG.TabStop = false;
                this.txbCPF.TabStop = false;
                this.dtpData.TabStop = false;
                this.rbMasculino.TabStop = false;
                this.rbFeminio.TabStop = false;
                this.cbOk.TabStop = false;

                this.label1.Text = "Alterar Aluno";
                this.txbIdCliente.Text = cliente.IdCliente.ToString();
                this.txbNome.Text = cliente.Nome;
                this.txbRG.Text = cliente.RG;
                this.txbCPF.Text = cliente.CPF;
                this.dtpData.Value = cliente.DataNascimento;
                if (cliente.Sexo == true)
                {
                    this.rbMasculino.Checked = true;
                }
                else
                {
                    this.rbFeminio.Checked = true;
                }
                if (cliente.Pagamento == true)
                {
                    this.cbOk.Checked = true;
                }
                else
                {
                    this.cbOk.Checked = false;
                }
            }
        }        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (acaoNaTelaSelecionada == AcaoNaTela.Inserir)
            {
                Cliente cliente = new Cliente();
                Endereco endereco = new Endereco();

                cliente.Nome = txbNome.Text;
                cliente.DataNascimento = dtpData.Value;
                if (rbMasculino.Checked == true){cliente.Sexo = true;}else{cliente.Sexo = false;}
                if (cbOk.Checked == true) { cliente.Pagamento = true; } else {cliente.Pagamento = false; }                
                cliente.CPF = txbCPF.Text;
                cliente.RG = txbRG.Text;
                cliente.LimiteCompra = Convert.ToDecimal(0);

                //criar os campos de endereço que seram inseridos
                endereco.Cidade = txbCidade.Text;
                endereco.Estado = txbEstado.Text;
                endereco.Sigla = txbSigla.Text;
                endereco.CEP = txbCEP.Text;
                endereco.Logradouro = txbRua.Text;
                endereco.Numero = Convert.ToInt32(txbNumero.Text);
                endereco.Bairro = txtBairro.Text;
                endereco.IdFuncionario = 1;

                ClienteNegocios clienteNegocios = new ClienteNegocios();
                EnderecoNegocios enderecoNegocios = new EnderecoNegocios();

                string retorno = clienteNegocios.Inserir(cliente);
                endereco.IdAluno =Convert.ToInt32(retorno);
                string retornoEnd = enderecoNegocios.Inserir(endereco);

                try
                {
                    int idCliente = Convert.ToInt32(retorno);
                    int idEndereco = Convert.ToInt32(retornoEnd);

                    MessageBox.Show("Aluno inserido com sucesso. Código: " + idCliente.ToString() + idEndereco.ToString());
                    
                    this.DialogResult = DialogResult.Yes;
                }
                catch (Exception)
                {
                    MessageBox.Show("Não foi possível inserir o Aluno. Detalhes:  " + retorno + retornoEnd, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.No;
                }
            }
            else if (acaoNaTelaSelecionada == AcaoNaTela.Alterar)
            {
                Cliente cliente = new Cliente();

                cliente.IdCliente = Convert.ToInt32(txbIdCliente.Text);
                cliente.Nome = txbNome.Text;
                cliente.DataNascimento = dtpData.Value;
                if (rbMasculino.Checked == true) { cliente.Sexo = true; } else { cliente.Sexo = false; }
                if (cbOk.Checked == true) { cliente.Pagamento = true; } else { cliente.Pagamento = false; }
                cliente.CPF = txbCPF.Text;
                cliente.RG = txbRG.Text;
                cliente.LimiteCompra = Convert.ToDecimal(0);

                ClienteNegocios clienteNegocios = new ClienteNegocios();

                string retorno = clienteNegocios.Alterar(cliente);

                try
                {
                    int idCliente = Convert.ToInt32(retorno);

                    MessageBox.Show("Aluno alterado com sucesso. Código: " + idCliente.ToString());

                    this.DialogResult = DialogResult.Yes;
                }
                catch (Exception)
                {
                    MessageBox.Show("Não foi possível alterar o Aluno. Detalhes:  " + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.No;
                }
            }                       
        }

        private void frmCadastrarAluno_Load(object sender, EventArgs e)
        {

        }

        private void txbCPF_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCPF_Click(object sender, EventArgs e)
        {

        }
    }
}
