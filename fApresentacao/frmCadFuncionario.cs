using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fApresentacao
{
    public partial class frmCadFuncionario : Form
    {
        public frmCadFuncionario()
        {
            InitializeComponent();
        }

        private void funcionarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.funcionarioBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.dsNewAlexandria);

        }

        private void frmCadFuncionario_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsNewAlexandria.Funcionario' table. You can move, or remove it, as needed.
            //this.funcionarioTableAdapter.Fill(this.dsNewAlexandria.Funcionario);
        }

        private void funcionarioBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Excluir o registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Validate();
                this.funcionarioBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dsNewAlexandria);
            }
            else
            {
                // TODO: This line of code loads data into the 'dsNewAlexandria.Editoras' table. You can move, or remove it, as needed.
                this.funcionarioTableAdapter.Fill(this.dsNewAlexandria.Funcionario);
            }
        }
    }
}
