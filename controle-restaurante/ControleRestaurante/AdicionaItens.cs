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
    public partial class AdicionaItens : Form
    {
        public AdicionaItens()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void loadPedidos()
        {
            cmbPedido.Items.Clear();
            try
            {
                ControladorManterPedido conPedidos = new ControladorManterPedido();
                var lista = conPedidos.retornarPedidos(); 
                foreach (Pedido ped in lista)
                {
                    cmbPedido.Items.Add(ped.Codigo);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void loadItens()
        {
            cmbItem.Items.Clear();
            try
            {
                ControladorManterItem conItens = new ControladorManterItem();
                var lista = conItens.retornarItens();
                foreach (Item it in lista)
                {
                    cmbItem.Items.Add(it.Codigo+":"+it.Nome);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        override protected void OnLoad(EventArgs e)
        {
            this.loadPedidos();
            this.loadItens();
            this.reloadData(-1);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cmbPedido.Text))
            {
                MessageBox.Show("Selecione um pedido válido");
            }
            else {
                
                try
                {
                    ControladorManterPedido_Item cmip = new ControladorManterPedido_Item();
                    List<ItemPedido> lista = cmip.retornarItemPedido(int.Parse(cmbPedido.Text));
                    gridItemPedido.Rows.Clear();
                    for (int i=0;i<lista.Count;i++)
                    {
                        gridItemPedido.Rows.Add(
                            lista[i].Pedido.Codigo, // codigo_pedido
                            lista[i].Quantidade.ToString(), // quantidade
                            lista[i].Item.Codigo.ToString()+":"+lista[i].Item.Nome //codigo do item : nome do item
                        );
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cmbItem.Text)) {
                MessageBox.Show("Selecione um item");
            }
            else if (String.IsNullOrWhiteSpace(cmbPedido.Text)) {
                MessageBox.Show("Selecione um Pedido");
            }
            else if (String.IsNullOrWhiteSpace(txtQtd.Text))
            {
                MessageBox.Show("Insira uma quantidade");
            }
            else
            {
                ControladorManterPedido_Item cmpi = new ControladorManterPedido_Item();
                cmpi.inserirItemPedido(int.Parse(cmbItem.Text.Substring(0, cmbItem.Text.IndexOf(":"))),int.Parse(cmbPedido.Text),int.Parse(txtQtd.Text));
                reloadData(int.Parse(cmbPedido.Text));
                LimparCampos();
            }

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cmbItem.Text))
            {
                MessageBox.Show("Selecione um item");
            }
            else if (String.IsNullOrWhiteSpace(cmbPedido.Text))
            {
                MessageBox.Show("Selecione um Pedido");
            }
            else
            {
                ControladorManterPedido_Item cmpi = new ControladorManterPedido_Item();
                cmpi.deletarItemPedido(int.Parse(cmbItem.Text.Substring(0, cmbItem.Text.IndexOf(":"))), int.Parse(cmbPedido.Text));
                reloadData(int.Parse(cmbPedido.Text));
                LimparCampos();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cmbItem.Text))
            {
                MessageBox.Show("Selecione um item");
            }
            else if (String.IsNullOrWhiteSpace(cmbPedido.Text))
            {
                MessageBox.Show("Selecione um Pedido");
            }
            else
            {
                ControladorManterPedido_Item cmpi = new ControladorManterPedido_Item();
                cmpi.atualizarItemPedido(int.Parse(cmbItem.Text.Substring(0, cmbItem.Text.IndexOf(":"))), int.Parse(cmbPedido.Text),int.Parse(txtQtd.Text));
                reloadData(int.Parse(cmbPedido.Text));
                LimparCampos();
            }
        }
        private void LimparCampos()
        {
            txtQtd.Clear();
            cmbPedido.Text = "";
            cmbItem.Text = "";
        }
        private void gridItemPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridItemPedido.Rows[e.RowIndex];

                if (row.Cells[0].Value.ToString().Trim() != "")
                {
                    try
                    {
                        LimparCampos();
                        cmbPedido.Text = row.Cells[0].Value.ToString();
                        txtQtd.Text = row.Cells[1].Value.ToString();
                        cmbItem.Text = row.Cells[2].Value.ToString();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQtd_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPedido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reloadData(int cod)
        {
            try
            {
                ControladorManterPedido_Item cmip = new ControladorManterPedido_Item();
                List<ItemPedido> lista = cmip.retornarItemPedido(cod);
                gridItemPedido.Rows.Clear();
                for (int i = 0; i < lista.Count; i++)
                {
                    gridItemPedido.Rows.Add(
                        lista[i].Pedido.Codigo, // codigo_pedido
                        lista[i].Quantidade.ToString(), // quantidade
                        lista[i].Item.Codigo.ToString() + ":" + lista[i].Item.Nome //codigo do item : nome do item
                    );
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            cmbPedido.Text = "";
            cmbItem.Text = "";
            txtQtd.Clear();
        }

        private void gridItemPedido_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridItemPedido.SelectedRows)
            {
                string cpf = row.Cells[0].Value.ToString();
                if (cpf.Trim() != "")
                {
                    try
                    {
                        LimparCampos();
                        cmbPedido.Text = row.Cells[0].Value.ToString();
                        txtQtd.Text = row.Cells[1].Value.ToString();
                        cmbItem.Text = row.Cells[2].Value.ToString();
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
