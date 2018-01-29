using System;
using System.Windows.Forms;

namespace fApresentacao
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnVoltaMenu_Click(object sender, EventArgs e)
        {
            this.Dispose();
            frmMenuConfig voltaMenu = new frmMenuConfig();
            voltaMenu.Visible = true;
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
            toolStripStatusLabel3.Text = DateTime.Now.ToShortTimeString();
        }

        private void frmCadastroUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadLivros frmCadLiv = new frmCadLivros();
            frmCadLiv.Show();
        }

        private void Aluno_MenuClick(object sender, EventArgs e)
        {
            frmCadAluno frmAluno = new frmCadAluno();
            frmAluno.Show();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadFuncionario frmFun = new frmCadFuncionario();
            frmFun.Show();
        }

        private void editorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadEditora frmEdt = new frmCadEditora();
            frmEdt.ShowDialog();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void locaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void locatáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editorasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.Dispose();
            frmMenuConfig voltaMenu = new frmMenuConfig();
            voltaMenu.Visible = true;
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void alunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadAluno frmCadAluno = new frmCadAluno();

            frmCadAluno.MdiParent = this;

            frmCadAluno.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frmCadAluno frmCadAluno = new frmCadAluno();

            frmCadAluno.MdiParent = this;

            frmCadAluno.Show();
        }
    }
}
