using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src.model
{
    class Pedido
    {
        private int codigo;
        private string data;
        private Mesa mesa;
        private Cliente cliente;
        //private List<ItemQuantidade> itemQuantidade;
        private bool pagamentoConfirmado;
        private decimal precoTotal;

        public Pedido(Mesa _mesa, Cliente _cliente)
        {
            this.mesa = _mesa;
            this.cliente = _cliente;
        }

        public int Codigo
        {
            get
            {
                return this.codigo;
            }
            set
            {
                this.codigo = value;
            }
        }

        public bool PagamentoConfirmado
        {
            set
            {
                this.pagamentoConfirmado = value;
            }
            get
            {
                return this.pagamentoConfirmado;
            }

        }

        public decimal PrecoTotal
        {
            set
            {
                this.precoTotal = value;
            }
            get
            {
                return this.precoTotal;
            }
        }


        public string Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public Mesa Mesa
        {
            set
            {
                this.mesa = value;
            }
            get
            {
                return this.mesa;
            }
        }

        public Cliente Cliente
        {
            set
            {
                this.cliente = value;
            }
            get
            {
                return this.cliente;
            }
        }

//        public void addItem(Item _item, int _quantidade)
//        {
//            ItemQuantidade novoItem = new ItemQuantidade(_item);
//            novoItem.Quantidade = _quantidade;
//            itemQuantidade.Add(novoItem);
//        }

//        public List<ItemQuantidade> getItemList()
//        {
//            return this.itemQuantidade;
//        }
    }
}
