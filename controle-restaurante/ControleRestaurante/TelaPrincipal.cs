using ControleRestaurante.base_src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleRestaurante
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        override protected void OnLoad(EventArgs e)
        {
            login.ShowDialog();
            if (Global.TipoAcesso == 'C')
            {
                btnAdministrarGarcons.Enabled = false;
                btnAdministrarItens.Enabled = false;
                btnAdministrarMesas.Enabled = false;
            }
        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.ShowDialog();
        }

        private void btnAdministrarItens_Click(object sender, EventArgs e)
        {
            Itens itens = new Itens();
            itens.ShowDialog();
        }

        private void btnAdministrarGarcons_Click(object sender, EventArgs e)
        {
            Garcons garcons = new Garcons();
            garcons.ShowDialog();
        }

        private void btnAdministrarMesas_Click(object sender, EventArgs e)
        {
            Mesas mesas = new Mesas();
            mesas.ShowDialog();
        }

        private void btnAdicionarPedido_Click(object sender, EventArgs e)
        {
            Pedidos pedidos = new Pedidos();
            pedidos.ShowDialog();
        }

        private void btnItensPedidos_Click(object sender, EventArgs e)
        {
            AdicionaItens add = new AdicionaItens();
            add.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fechar_Pedido add = new Fechar_Pedido();
            add.ShowDialog();
        }
    }
}
