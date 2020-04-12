using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src.model
{
    class ItemPedido
    {
        private Pedido pedido;
        private Item item;
        private int quantidade;

        public int Quantidade
        {
            get
            {
                return this.quantidade;
            }
            set
            {
                this.quantidade = value;
            }
        }
        public Pedido Pedido
        {
            get
            {
                return this.pedido;
            }
            set
            {
                this.pedido = value;
            }
        }
        public Item Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }
    }
}
