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
    public partial class Fechar_Pedido : Form
    {
        public Fechar_Pedido()
        {
            InitializeComponent();
            loadPedNFec();
            loadPedFec();
        }
        private void loadPedNFec() {

            try
            {
                ControladorManterPedido conPedidos = new ControladorManterPedido();
                var lista = conPedidos.retornarPedidos();
                foreach (Pedido ped in lista)
                {
                    cmbPedNFe.Items.Add(ped.Codigo);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void loadPedFec()
        {

            try
            {
                ControladorManterPedido conPedidos = new ControladorManterPedido();
                var lista = conPedidos.retornarPedidosFechados();
                foreach (Pedido ped in lista)
                {
                    cmbPedFec.Items.Add(ped.Codigo);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Clear() {
            cmbPedFec.Items.Clear();
            cmbPedNFe.Text = "";
            cmbPedNFe.Items.Clear();
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (cmbPedNFe.Text.Trim() == "")
            {
                MessageBox.Show("Escolha um pedido para finalizá-lo!");
            }
            else
            {
                ControladorManterPedido_Item c = new ControladorManterPedido_Item();
                List<ItemPedido> lista = c.retornarItemPedido(int.Parse(cmbPedNFe.Text));
                decimal preco_total = 0;
                var msg = "Lista de Itens do pedido: ";
                List<Pedido> listaped = new ControladorManterPedido().retornarPedidosFechados(int.Parse(cmbPedNFe.Text));
                msg += $"{listaped[0].Codigo.ToString()}\n";
                for (int i = 0; i < lista.Count(); i++)
                {

                    msg += $"ITEM: {lista[i].Item.Nome} QTD: {lista[i].Quantidade} PREÇO: R${lista[i].Item.Preco}\n";
                    preco_total += (lista[i].Item.Preco * lista[i].Quantidade);

                }
                List<Mesa> mesa = new ControladorManterMesa().retornarMesas(listaped[0].Mesa.Numero);
                MessageBox.Show(msg + "\n" + "Preço total: R$" + preco_total.ToString() + "\nCodigo do garçom " + mesa[0].Garcom.Identificacao + "\nFechado pedido...");

                new ControladorManterPedido().atualizarPedido(int.Parse(cmbPedNFe.Text), listaped[0].Mesa.Numero, preco_total, true, listaped[0].Cliente.CPF);

                MessageBox.Show("Pedido Fechado");

                Clear();
                loadPedFec();
                loadPedNFec();
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (cmbPedFec.Text.Trim() == "")
            {
                MessageBox.Show("Escolha um pedido finalizado para mostrá-lo!");
            }
            else
            {

                ControladorManterPedido_Item c = new ControladorManterPedido_Item();
                List<ItemPedido> lista = c.retornarItemPedido(int.Parse(cmbPedFec.Text));
                decimal preco_total = 0;
                var msg = "Lista de Itens do pedido Fechado: ";
                List<Pedido> listaped = new ControladorManterPedido().retornarPedidosFechados(int.Parse(cmbPedFec.Text));
                msg += $"{listaped[0].Codigo.ToString()}\n";
                preco_total = listaped[0].PrecoTotal;

                for (int i = 0; i < lista.Count(); i++)
                {
                    msg += $"ITEM: {lista[i].Item.Nome} QTD: {lista[i].Quantidade} PREÇO: R${lista[i].Item.Preco}\n";
                }
                List<Mesa> mesa = new ControladorManterMesa().retornarMesas(listaped[0].Mesa.Numero);
                MessageBox.Show(msg + "\n" + "Preço total: R$" + preco_total.ToString() + "\nCodigo do garçom " + mesa[0].Garcom.Identificacao + "\n");

            }
        }

        private void Fechar_Pedido_Load(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
