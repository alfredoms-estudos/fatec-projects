using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleRestaurante.base_src.model
{
    class ItemPedidoDAO
    {
        public void insert(ItemPedido itPedido)
        {
            string select = "SELECT item_pedido.quantidade FROM item_pedido ";
            select+= $"WHERE item_pedido.codigo_item = {itPedido.Item.Codigo}  AND item_pedido.codigo_pedido = {itPedido.Pedido.Codigo}";
            ConnectionFactory.open();
            try {
                var data = ConnectionFactory.command(select);
                if (data.HasRows == true || data.Read())
                {
                    ConnectionFactory.close();
                    MessageBox.Show("A relação entre esse pedido e item já existe");
                }
                else {
                    ConnectionFactory.close();
                    string insertSQL = $"INSERT INTO item_pedido (codigo_item, codigo_pedido, quantidade) ";
                    insertSQL += $" VALUES ('{itPedido.Item.Codigo}','{itPedido.Pedido.Codigo}','{itPedido.Quantidade}') ";
                    try
                    {
                        ConnectionFactory.open();
                        ConnectionFactory.command(insertSQL);
                        ConnectionFactory.close();
                        MessageBox.Show("Item inserido com sucesso");
                    }
                    catch (Exception e)
                    {
                        ConnectionFactory.close();
                        throw e;
                    }
                }
            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }
            
        }

        public void update(ItemPedido itPedido)
        {
            string updateSQL = $"UPDATE item_pedido SET quantidade='{itPedido.Quantidade}'";
            updateSQL += $" WHERE codigo_pedido='{itPedido.Pedido.Codigo}' AND codigo_item = '{itPedido.Item.Codigo}' ";
            try
            {
                ConnectionFactory.open();
                ConnectionFactory.command(updateSQL);
                ConnectionFactory.close();
                MessageBox.Show("Item atualizado com sucesso");
            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }
        }

        public void delete(ItemPedido itPedido)
        {
            string deleteSQL = $"DELETE FROM item_pedido";
            deleteSQL += $" WHERE codigo_pedido={itPedido.Pedido.Codigo} AND codigo_item = {itPedido.Item.Codigo}";
            try
            {
                ConnectionFactory.open();
                ConnectionFactory.command(deleteSQL);
                ConnectionFactory.close();
                MessageBox.Show("Item deletado com sucesso");
            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }
        }

        public List<ItemPedido> find(int codigo)
        {
            List<ItemPedido> listaItens = new List<ItemPedido>();
            listaItens.Clear();
            try
            {
                var query = "SELECT codigo_item, quantidade, item.nome, item.preco, codigo_pedido FROM pedido ";
                query += "INNER JOIN item_pedido ON item_pedido.codigo_pedido = pedido.codigo ";
                query += "INNER JOIN item ON item_pedido.codigo_item = item.codigo ";
                query += "WHERE pedido.pagamento_confirmado = false ";
                if (codigo != -1)
                    query += $"AND item_pedido.codigo_pedido = {codigo}";

                ConnectionFactory.open();
                var data = ConnectionFactory.command(query);
                while (data.Read())
                {
                    Item item = new Item();
                    item.Codigo = data.GetInt32(0);
                    item.Nome = data.GetString(2);
                    item.Preco = data.GetDecimal(3);
                    ItemPedido ip = new ItemPedido();
                    ip.Quantidade = data.GetInt32(1);
                    ip.Pedido = new Pedido(null,null);
                    ip.Pedido.Codigo = data.GetInt32(4); ;
                    ip.Item = item;
                    listaItens.Add(ip);

                }
                ConnectionFactory.close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return listaItens;
        }
    }
}
