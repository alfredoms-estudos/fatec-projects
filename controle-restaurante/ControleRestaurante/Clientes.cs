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

namespace ControleRestaurante
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        override protected void OnLoad(EventArgs e)
        {
            this.reloadData();
        }

        private void reloadData()
        {
            gridClientes.Rows.Clear();
            ControladorManterCliente controlador = new ControladorManterCliente();
            List<Cliente> clientes = controlador.retornarClientes(null);
            try {
                foreach (Cliente cliente in clientes)
                {
                    gridClientes.Rows.Add(cliente.CPF, cliente.Nome, cliente.Telefone);
                }
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text.Trim() == "" || txtTelefone.Text.Trim() == "")
            {

                MessageBox.Show("O CPF ou o TELEFONE do cliente estão em branco!!");

            }
            else
            {
                try
                {
                    Endereco endereco = new Endereco();
                    ControladorManterEndereco controladorEndereco = new ControladorManterEndereco();
                    endereco.Codigo = controladorEndereco.inserirEndereco(
                        txtCEP.Text,
                        txtLogradouro.Text,
                        Int32.Parse(txtNumero.Text),
                        txtBairro.Text,
                        txtCidade.Text,
                        txtComplemento.Text
                    );

                    ControladorManterCliente controladorCliente = new ControladorManterCliente();
                    controladorCliente.inserirCliente(
                        txtCPF.Text,
                        txtNome.Text,
                        txtTelefone.Text,
                        endereco
                    );

                    LimparCampos();
                    reloadData();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos(){
        
            txtCodigo.Clear();
            txtCEP.Clear();
            txtLogradouro.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtComplemento.Clear();
            txtCPF.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text.Trim() == "")
                {
                    MessageBox.Show("Escolha um registro já inserido para que ele possa ser alterado!");
                }
                else if (txtCPF.Text.Trim() == "" || txtTelefone.Text.Trim() == "")
                {

                    MessageBox.Show("O CPF ou o TELEFONE do cliente estão em branco!!");

                }
                else
                {
                    int codigo = Int32.Parse(txtCodigo.Text);
                    ControladorManterCliente conCliente = new ControladorManterCliente();
                    conCliente.atualizarCliente(
                        txtCPF.Text,
                        txtNome.Text,
                        txtTelefone.Text,
                        codigo
                    );

                    ControladorManterEndereco conEndereco = new ControladorManterEndereco();
                    conEndereco.atualizarEndereco(
                        codigo,
                        txtCEP.Text,
                        txtLogradouro.Text,
                        Int32.Parse(txtNumero.Text),
                        txtBairro.Text,
                        txtCidade.Text,
                        txtComplemento.Text
                    );
                    LimparCampos();
                    reloadData();

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text.Trim() == "")
                {
                    MessageBox.Show("Escolha um registro já inserido para que ele possa ser excluído!");
                }
                else
                {
                    int codigo = Int32.Parse(txtCodigo.Text);

                    ControladorManterCliente conCliente = new ControladorManterCliente();
                    conCliente.excluirCliente(codigo);

                    //ControladorManterEndereco conEndereco = new ControladorManterEndereco();
                    //conEndereco.excluirEndereco(codigo);
                    LimparCampos();
                    reloadData();
                }

            } catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void gridClientes_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridClientes.SelectedRows)
            {
                string cpf = row.Cells[0].Value.ToString();
                if (cpf.Trim() != "")
                {
                    try {
                        ControladorManterCliente conCliente = new ControladorManterCliente();
                        List<Cliente> listaClientes = conCliente.retornarClientes(cpf);
                        var cliente = listaClientes.ElementAt(0);
                        ControladorManterEndereco conEndereco = new ControladorManterEndereco();
                        List<Endereco> listaEnderecos = conEndereco.retornarEnderecos(cliente.Endereco.Codigo);
                        var endereco = listaEnderecos.ElementAt(0);

                        LimparCampos();
                        carregarCliente(cliente);
                        carregarEndereco(endereco);
                    }catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }

            }
        }

        private void gridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridClientes.Rows[e.RowIndex];
                string cpf = row.Cells[0].Value.ToString();
                if (cpf.Trim() != "")
                {
                    try
                    {
                        ControladorManterCliente conCliente = new ControladorManterCliente();
                        List<Cliente> listaClientes = conCliente.retornarClientes(cpf);
                        var cliente = listaClientes.ElementAt(0);
                        ControladorManterEndereco conEndereco = new ControladorManterEndereco();
                        List<Endereco> listaEnderecos = conEndereco.retornarEnderecos(cliente.Endereco.Codigo);
                        var endereco = listaEnderecos.ElementAt(0);

                        LimparCampos();
                        carregarCliente(cliente);
                        carregarEndereco(endereco);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void carregarCliente(Cliente cliente)
        {
            txtCPF.Text = cliente.CPF;
            txtNome.Text = cliente.Nome;
            txtTelefone.Text = cliente.Telefone;
        }

        private void carregarEndereco(Endereco endereco)
        {
            txtBairro.Text = endereco.Bairro;
            txtCEP.Text = endereco.CEP;
            txtCidade.Text = endereco.Cidade;
            txtCodigo.Text = endereco.Codigo.ToString();
            txtComplemento.Text = endereco.Complemento;
            txtLogradouro.Text = endereco.Logradouro;
            txtNumero.Text = endereco.Numero.ToString();
        }
    }
}
