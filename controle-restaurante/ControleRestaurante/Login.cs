using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleRestaurante.base_src;

namespace ControleRestaurante
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int escolha = cmbPerfil.SelectedIndex;
            if (escolha == -1)
            {
                MessageBox.Show("Escolha um perfil!");
            }
            else
            {
                //Global
                switch (escolha)
                {
                    case 0:
                        Global.TipoAcesso = 'A';
                        break;
                    case 1:
                        Global.TipoAcesso = 'C';
                        break;
                }

                this.Close();
            }
        }

        private void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
