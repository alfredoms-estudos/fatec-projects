using ControleRestaurante.base_src.control;
using ControleRestaurante.base_src.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleRestaurante
{
    public partial class Itens : Form
    {
        public Itens()
        {
            InitializeComponent();
        }

        override protected void OnLoad(EventArgs e)
        {
            this.reloadData();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtCodigo.Clear();
            txtDescricao.Clear();
            txtNome.Clear();
            txtPreco.Clear();
            cmbTipo.SelectedIndex = 0;
        }

        private void gridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridItens.Rows[e.RowIndex];
                
                if (row.Cells[0].Value.ToString().Trim() != "")
                {
                    int codigo = Int32.Parse(row.Cells[0].Value.ToString());
                    try
                    {
                        ControladorManterItem conItem = new ControladorManterItem();
                        List<Item> listaItens = conItem.retornarItens(codigo);
                        var item = listaItens.ElementAt(0);
                        
                        LimparCampos();
                        carregarItem(item);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void carregarItem(Item item)
        {
            txtCodigo.Text = item.Codigo.ToString();
            txtDescricao.Text = item.Descricao;
            txtNome.Text = item.Nome;
            txtPreco.Text = item.Preco.ToString();
            cmbTipo.Text = item.Tipo;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Trim() == "" || txtNome.Text.Trim() == "" || txtPreco.Text.Trim() == "" || cmbTipo.Text.Trim() == "")
            {
                MessageBox.Show("DESCRIÇÃO, NOME, PREÇO ou TIPO referentes ao item estão em branco!");
            }
            else {
                try
                {
                    decimal preco = Decimal.Parse(txtPreco.Text);
                    ControladorManterItem conItem = new ControladorManterItem();
                    conItem.inserirItem(
                        txtNome.Text,
                        txtDescricao.Text,
                        cmbTipo.Text,
                        preco
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

        private void reloadData()
        {
            gridItens.Rows.Clear();
            ControladorManterItem conItem = new ControladorManterItem();
            List<Item> itens = conItem.retornarItens();
            try
            {
                foreach (Item item in itens)
                {
                    gridItens.Rows.Add(item.Codigo.ToString(), item.Nome, item.Descricao, item.Preco.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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

                    ControladorManterItem conItem= new ControladorManterItem();
                    conItem.excluirItem(codigo);
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
                if (txtCodigo.Text.Trim() == "")
                {
                    MessageBox.Show("Escolha um registro já inserido para que ele possa ser alterado!");
                }
                else if (txtDescricao.Text.Trim() == "" || txtNome.Text.Trim() == "" || txtPreco.Text.Trim() == "" || cmbTipo.Text.Trim() == "")
                {
                    MessageBox.Show("DESCRIÇÃO, NOME, PREÇO ou TIPO referentes ao item estão em branco!");
                }
                else
                {
                    int codigo = Int32.Parse(txtCodigo.Text);
                    decimal preco = Decimal.Parse(txtPreco.Text);
                    ControladorManterItem conItem = new ControladorManterItem();
                    conItem.atualizarItem(
                        codigo,
                        txtNome.Text,
                        txtDescricao.Text,
                        cmbTipo.Text,
                        preco
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

        private void gridItens_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridItens.SelectedRows)
            {
                if (row.Cells[0].Value.ToString().Trim() != "")
                {
                    int codigo = Int32.Parse(row.Cells[0].Value.ToString());
                    try
                    {
                        ControladorManterItem conItem = new ControladorManterItem();
                        List<Item> listaItens = conItem.retornarItens(codigo);
                        var item = listaItens.ElementAt(0);

                        LimparCampos();
                        carregarItem(item);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }

                }
            }

        }
    }
}
