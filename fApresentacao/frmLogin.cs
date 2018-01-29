using System;
using System.Windows.Forms;


namespace fApresentacao
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {           
            
            //int result = funcionarioTableAdapter.FillByFuncionarioLogin(dsNewAlexandria.Funcionario, loginTextBox.Text, senhaTextBox.Text);

            if (loginTextBox.Text == "AFS" && senhaTextBox.Text == "1234")
            {
                this.Visible = false;
                frmMenuConfig menu = new frmMenuConfig();
                menu.ShowDialog();                
            }
            else
            {
                MessageBox.Show("Úsuario ou Senha Inválidos", "Ocorreu um erro de autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void funcionarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.funcionarioBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsNewAlexandria);

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsNewAlexandria.Funcionario' table. You can move, or remove it, as needed.
            //this.funcionarioTableAdapter.Fill(this.dsNewAlexandria.Funcionario);

        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }
                               
    }
}
