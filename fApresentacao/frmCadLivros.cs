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
    public partial class frmCadLivros : Form
    {
        public frmCadLivros()
        {
            InitializeComponent();
        }

        private void livroBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.livroBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsNewAlexandria);

        }

        private void frmCadLivros_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsNewAlexandria.Livro' table. You can move, or remove it, as needed.
            this.livroTableAdapter.Fill(this.dsNewAlexandria.Livro);

        }

        private void comentariosLabel_Click(object sender, EventArgs e)
        {

        }

        private void livroBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            try
            {               
                this.Validate();
                this.livroBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dsNewAlexandria);
                MessageBox.Show("Registro Salvo com sucesso!!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.livroTableAdapter.Fill(this.dsNewAlexandria.Livro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar" + ex.Message,"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }       

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Excluir o registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Validate();
                this.livroBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dsNewAlexandria);
            }
            else
            {
                // TODO: This line of code loads data into the 'dsNewAlexandria.Editoras' table. You can move, or remove it, as needed.
                this.livroTableAdapter.Fill(this.dsNewAlexandria.Livro);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.livroTableAdapter.Fill(this.dsNewAlexandria.Livro);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            idLivroTextBox.Text = bindingNavigatorPositionItem.Text;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(idLivroTextBox.Text) > 0)
            {
                openFileDialog1.ShowDialog();

                Bitmap bmp = new Bitmap(openFileDialog1.FileName);
                Bitmap bmp2 = new Bitmap(bmp, pictureBox2.Size);

                pictureBox2.Image = bmp2;

                pictureBox2.Image.Save(Application.StartupPath.ToString() + "\\Capas_Livros\\" + idEditoraTextBox.Text + ".png", System.Drawing.Imaging.ImageFormat.Jpeg);
                
                capaTextBox.Text = Application.StartupPath.ToString() + "\\Capas_Livros\\" + idEditoraTextBox.Text + ".png";

                this.Validate();
                this.livroBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dsNewAlexandria);

            }
            else
            {
                MessageBox.Show("Para inserir a imagem, salve a imagem Primeiro", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                      
                      
    }
}
