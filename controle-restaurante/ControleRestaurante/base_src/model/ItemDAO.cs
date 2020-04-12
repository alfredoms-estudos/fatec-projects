using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleRestaurante.base_src.model
{
    class ItemDAO
    {
        public int insert(Item item)
        {
            try
            {
                string select = "SELECT * FROM item ";
                select += $"WHERE item.nome = '{item.Nome}'";
                ConnectionFactory.open();
                var data = ConnectionFactory.command(select);
                if (data.HasRows == true || data.Read())
                {
                    ConnectionFactory.close();
                    MessageBox.Show("O item com esse nome já é cadastrado");
                    return item.Codigo;

                }
                else
                {
                    ConnectionFactory.close();
                    int codigo;
                    string insertSQL = $"INSERT INTO item (nome, descricao, tipo, preco) ";
                    insertSQL += $" VALUES ('{item.Nome}', '{item.Descricao}', '{item.Tipo}', '{ item.Preco}') ";
                    insertSQL += $" RETURNING codigo";
                    try
                    {
                        ConnectionFactory.open();
                        data = ConnectionFactory.command(insertSQL);
                        data.Read();

                        codigo = data.GetInt32(0);
                        ConnectionFactory.close();
                        MessageBox.Show("Item inserido com sucesso!");
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                    return codigo;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void update(Item item)
        {
            try
            {
                String query = "SELECT item_pedido.codigo_pedido FROM item_pedido INNER JOIN item ON  item_pedido.codigo_item = item.codigo ";
                query += $"WHERE item.codigo = {item.Codigo}";
                ConnectionFactory.open();
                var data = ConnectionFactory.command(query);
                if (data.HasRows == true && data.Read())
                {
                    MessageBox.Show("Esse item esta relacionado a um pedido e não pode ser alterado");
                    ConnectionFactory.close();
                }
                else
                {
                    ConnectionFactory.close();
                    string updateSQL = $"UPDATE item SET nome='{item.Nome}', descricao='{item.Descricao}', ";
                    updateSQL += $"tipo='{item.Tipo}', preco='{item.Preco}' ";
                    updateSQL += $" WHERE codigo='{item.Codigo}'";
                    try
                    {
                        ConnectionFactory.open();
                        ConnectionFactory.command(updateSQL);
                        ConnectionFactory.close();
                        MessageBox.Show("Item alterado com sucesso!");
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

        public void delete(Item item)
        {
            try
            {
                String query = "SELECT item_pedido.codigo_pedido FROM item_pedido INNER JOIN item ON  item_pedido.codigo_item = item.codigo ";
                query += $"WHERE item.codigo = {item.Codigo}";
                ConnectionFactory.open();
                var data = ConnectionFactory.command(query);
                if (data.HasRows == true && data.Read())
                {
                    MessageBox.Show("Esse item esta relacionado a um pedido e não pode ser excluido");
                    ConnectionFactory.close();
                }
                else
                {
                    ConnectionFactory.close();
                    string deleteSQL = $"DELETE FROM item";
                    deleteSQL += $" WHERE codigo={item.Codigo} ";
                    try
                    {
                        ConnectionFactory.open();
                        ConnectionFactory.command(deleteSQL);
                        ConnectionFactory.close();
                        MessageBox.Show("Item deletado com sucesso!");
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

        public List<Item> find(int codigo)
        {
            List<Item> listaItens= new List<Item>();
            listaItens.Clear();
            try
            {
                var query = "SELECT codigo, nome, descricao, tipo, preco FROM item";
                if (codigo != -1)
                    query += $" WHERE codigo={codigo}";

                ConnectionFactory.open();
                var data = ConnectionFactory.command(query);
                while (data.Read())
                {
                    Item novoItem = new Item();
                    novoItem.Codigo = data.GetInt32(0);
                    novoItem.Nome = data.GetString(1);
                    novoItem.Descricao = data.GetString(2);
                    novoItem.Tipo = data.GetString(3);
                    novoItem.Preco = data.GetDecimal(4);
                    listaItens.Add(novoItem);
                }
                ConnectionFactory.close();
            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }

            return listaItens;
        }
    }
}
