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
    public partial class frmMenuConfig : Form
    {
        public frmMenuConfig()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmMenu cadastraUsuario = new frmMenu();
            cadastraUsuario.ShowDialog();
        }
    }
}
