using ControleRestaurante.base_src.control;
using ControleRestaurante.base_src.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleRestaurante.base_src
{
    public partial class Pedidos : Form
    {
        public Pedidos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtCodigo.Clear();
            cmbCliente.Text = "";
            cmbMesa.Text = "";
            txtPrecoTotal.Clear();
            txtData.Clear();
            txtConfirmado.Clear();
        }

        private void loadMesas()
        {
            cmbMesa.Items.Clear();
            try
            {
                ControladorManterMesa conMesa = new ControladorManterMesa();
                var lista = conMesa.retornarMesas();
                foreach (Mesa mesa in lista)
                {
                    cmbMesa.Items.Add(mesa.Numero);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void loadClientes()
        {
            cmbCliente.Items.Clear();
            try
            {
                ControladorManterCliente conCliente = new ControladorManterCliente();
                var lista = conCliente.retornarClientes();
                foreach (Cliente cliente in lista)
                {
                    cmbCliente.Items.Add(cliente.CPF + ": " + cliente.Nome);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void reloadData()
        {
            gridPedidos.Rows.Clear();
            ControladorManterPedido conPedido = new ControladorManterPedido();
            List<Pedido> lista = conPedido.retornarPedidos();
            try
            {
                foreach (Pedido pedido in lista)
                {
                    ControladorManterCliente conCliente = new ControladorManterCliente();
                    Cliente cliente = null;
                    if (pedido.Cliente.CPF != null) {
                        var listaClientes = conCliente.retornarClientes(pedido.Cliente.CPF);
                        cliente = listaClientes.ElementAt(0);
                    } 
                    gridPedidos.Rows.Add(
                        pedido.Codigo.ToString(), // codigo
                        pedido.Mesa.Numero == -1 ? "" :pedido.Mesa.Numero.ToString(),  // numero_mesa
                        cliente == null ? "" : (cliente.CPF+ ": " + cliente.Nome), // cliente 
                        pedido.Data, // data
                        pedido.PagamentoConfirmado == true? "Sim" : "Não", // pagamento confirmado 
                        pedido.PrecoTotal == -1 ? "Não Calculado" : pedido.PrecoTotal.ToString() // preço total
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        override protected void OnLoad(EventArgs e)
        {
            this.reloadData();
            this.loadClientes();
            this.loadMesas();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCliente.Text == "")
                {
                    MessageBox.Show("Selecione um cliente para inserir um novo pedido!");
                }
                else if (cmbMesa.Text == "")
                {
                    MessageBox.Show("Selecione uma mesa para inserir um novo pedido!");
                }
                else
                {
                    int codigo_mesa = Int32.Parse(cmbMesa.Text);
                    string cpf_cliente = cmbCliente.Text.Substring(0, cmbCliente.Text.IndexOf(":"));

                    ControladorManterPedido conPedido = new ControladorManterPedido();
                    conPedido.inserirPedido(
                        codigo_mesa,
                        cpf_cliente
                    );

                    LimparCampos();
                    reloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridPedidos.Rows[e.RowIndex];

                if (row.Cells[0].Value.ToString().Trim() != "")
                {
                    try
                    {
                        LimparCampos();
                        txtCodigo.Text = row.Cells[0].Value.ToString();
                        cmbMesa.Text = row.Cells[1].Value.ToString();
                        cmbCliente.Text = row.Cells[2].Value.ToString();
                        txtData.Text = row.Cells[3].Value.ToString();
                        txtConfirmado.Text = row.Cells[4].Value.ToString();
                        txtPrecoTotal.Text = row.Cells[5].Value.ToString();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void gridPedidos_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridPedidos.SelectedRows)
            {
                if (row.Cells[0].Value.ToString().Trim() != "")
                {
                    try
                    {
                        LimparCampos();
                        txtCodigo.Text = row.Cells[0].Value.ToString();
                        cmbMesa.Text = row.Cells[1].Value.ToString();
                        cmbCliente.Text = row.Cells[2].Value.ToString();
                        txtData.Text = row.Cells[3].Value.ToString();
                        txtConfirmado.Text = row.Cells[4].Value.ToString();
                        txtPrecoTotal.Text = row.Cells[5].Value.ToString();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text.Trim() == "")
                {
                    MessageBox.Show("Escolha um pedido já inserido para poder excluir!");
                }
                else
                {
                    int numero = Int32.Parse(txtCodigo.Text);

                    ControladorManterPedido conPedido = new ControladorManterPedido();
                    conPedido.excluirPedido(numero);
                    LimparCampos();
                    reloadData();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCliente.Text == "")
                {
                    MessageBox.Show("Selecione um cliente para atualizar o pedido!");
                }
                else if (cmbMesa.Text == "")
                {
                    MessageBox.Show("Selecione uma mesa para atualizar o pedido!");
                }
                else
                {
                    int codigo = int.Parse(txtCodigo.Text);
                    int codigo_mesa = int.Parse(cmbMesa.Text);
                    string cpf_cliente = cmbCliente.Text.Substring(0, cmbCliente.Text.IndexOf(":"));
                    
                    ControladorManterPedido conPedido = new ControladorManterPedido();
                    conPedido.atualizarPedido(
                        codigo,
                        codigo_mesa,
                        -1,
                        false,
                        cpf_cliente
                    );

                    LimparCampos();
                    reloadData();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbMesa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
