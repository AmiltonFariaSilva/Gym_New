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
    public partial class frmCadEditora : Form
    {
        public frmCadEditora()
        {
            InitializeComponent();
        }

        private void editorasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.editorasBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dsNewAlexandria);
                MessageBox.Show("Registro Salvo com Sucesso", "Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                MessageBox.Show("Falha ao salvar o registro /n ex.Message.ToString();", "Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmCadEditora_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsNewAlexandria.Editoras' table. You can move, or remove it, as needed.
            this.editorasTableAdapter.Fill(this.dsNewAlexandria.Editoras);

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Excluir o registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Validate();
                this.editorasBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dsNewAlexandria);
            }
            else
            {
                // TODO: This line of code loads data into the 'dsNewAlexandria.Editoras' table. You can move, or remove it, as needed.
                this.editorasTableAdapter.Fill(this.dsNewAlexandria.Editoras); 
            }
        }

        private void editorasBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.editorasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsNewAlexandria);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.editorasTableAdapter.FillByEditoraNome(dsNewAlexandria.Editoras, textBox1.Text);
        }

                
      }
}
