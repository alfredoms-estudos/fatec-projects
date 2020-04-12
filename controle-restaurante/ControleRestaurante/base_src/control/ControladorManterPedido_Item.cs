using ControleRestaurante.base_src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src.control
{
    class ControladorManterPedido_Item
    {
        public void inserirItemPedido(int codItem, int codPedido, int quantidade)
        {
            Item it = new Item();
            it.Codigo = codItem;
            Pedido pedido = new Pedido(null,null);
            pedido.Codigo = codPedido;
            ItemPedido itpedido = new ItemPedido();
            itpedido.Pedido = pedido;
            itpedido.Item = it;
            itpedido.Quantidade = quantidade;
            ItemPedidoDAO itDAO = new ItemPedidoDAO();
            itDAO.insert(itpedido);

        }
        public void atualizarItemPedido(int codItem, int codPedido, int quantidade)
        {
            Item it = new Item();
            it.Codigo = codItem;
            Pedido pedido = new Pedido(null, null);
            pedido.Codigo = codPedido;
            ItemPedido itpedido = new ItemPedido();
            itpedido.Pedido = pedido;
            itpedido.Item = it;
            itpedido.Quantidade = quantidade;
            ItemPedidoDAO itDAO = new ItemPedidoDAO();
            itDAO.update(itpedido);

        }
        public void deletarItemPedido(int codItem, int codPedido)
        {
            Item it = new Item();
            it.Codigo = codItem;
            Pedido pedido = new Pedido(null, null);
            pedido.Codigo = codPedido;
            ItemPedido itpedido = new ItemPedido();
            itpedido.Pedido = pedido;
            itpedido.Item = it;
            ItemPedidoDAO itDAO = new ItemPedidoDAO();
            itDAO.delete(itpedido);
        }
        public List<ItemPedido> retornarItemPedido(int codPedido = -1)
        {
            try
            {
                ItemPedidoDAO itDAO = new ItemPedidoDAO();
                return itDAO.find(codPedido);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
