using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleRestaurante.base_src.model
{
    class PedidoDAO
    {
        public int insert(Pedido pedido)
        {
            int codigo;
            string insertSQL = $"INSERT INTO pedido (numero_mesa, pagamento_confirmado, data) ";
            insertSQL += $" VALUES (";
            insertSQL += $"{ pedido.Mesa.Numero}, false, now()) ";
            insertSQL += $" RETURNING codigo ";

            try
            {
                ConnectionFactory.open();
                var data = ConnectionFactory.command(insertSQL);
                data.Read();

                codigo = data.GetInt32(0);
                ConnectionFactory.close();

                var insertSQLCliente = $"INSERT INTO cliente_pedido (codigo_pedido, cpf) ";
                insertSQLCliente += $"VALUES ({codigo}, '{pedido.Cliente.CPF}')";

                ConnectionFactory.open();
                ConnectionFactory.command(insertSQLCliente);
                ConnectionFactory.close();
                MessageBox.Show("Pedido inserido com sucesso!");
            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }

            return codigo;
        }

        public void update(Pedido pedido)
        {
            try
            {
                int numero = pedido.Codigo;
                string updateSQL = $"UPDATE pedido SET ";
                updateSQL += $"numero_mesa={pedido.Mesa.Numero} ";
                if (pedido.PrecoTotal != -1)
                updateSQL += $", preco_total='{pedido.PrecoTotal}' ";
                updateSQL += $", pagamento_confirmado={pedido.PagamentoConfirmado} ";
                updateSQL += $"WHERE codigo={numero}";
                ConnectionFactory.open();
                ConnectionFactory.command(updateSQL);
                ConnectionFactory.close();
                var updateSQLCliente = $" UPDATE cliente_pedido set cpf = '{pedido.Cliente.CPF}' ";
                updateSQLCliente += $"WHERE codigo_pedido= {numero}";
                ConnectionFactory.open();
                ConnectionFactory.command(updateSQLCliente);
                ConnectionFactory.close();
                MessageBox.Show("Pedido atualizado com sucesso!");

            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }
        }

        public void delete(Pedido pedido)
        {
            ConnectionFactory.open();
            try {
                string query = "SELECT item_pedido.codigo_item FROM item_pedido INNER JOIN pedido ON  item_pedido.codigo_pedido = pedido.codigo";
                query += $" WHERE pedido.codigo = {pedido.Codigo}";
                var data = ConnectionFactory.command(query);
                if (data.HasRows == true && data.Read())
                {
                    MessageBox.Show("Este pedido não pode ser excluido, pois está associado a itens");
                    ConnectionFactory.close();
                }
                else {
                    try
                    {
                        ConnectionFactory.close();

                        string deleteSQL = "DELETE FROM cliente_pedido";
                        deleteSQL += $" WHERE codigo_pedido={pedido.Codigo} ";

                        ConnectionFactory.open();
                        ConnectionFactory.command(deleteSQL);
                        ConnectionFactory.close();

                        deleteSQL = "DELETE FROM pedido";
                        deleteSQL += $" WHERE codigo={pedido.Codigo} ";

                        ConnectionFactory.open();
                        ConnectionFactory.command(deleteSQL);
                        ConnectionFactory.close();

                        MessageBox.Show("Pedido excluído com sucesso!");
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
        public List<Pedido> find()
        {
            List<Pedido> lista = new List<Pedido>();
            lista.Clear();
            try
            {
                var query = "SELECT cliente_pedido.cpf, pedido.numero_mesa, pedido.codigo, to_char(pedido.data,'DD/MM/YYYY HH24:MI:SS'), ";
                query += "pedido.preco_total, pedido.pagamento_confirmado FROM pedido ";
                query += $"LEFT JOIN cliente_pedido ON pedido.codigo=cliente_pedido.codigo_pedido ";
                    query += $" WHERE pedido.pagamento_confirmado = false";

                ConnectionFactory.open();
                var data = ConnectionFactory.command(query);
                while (data.Read())
                {
                    Cliente cliente = new Cliente();
                    if (!data.IsDBNull(0))
                        cliente.CPF = data.GetString(0);
                    else
                        cliente.CPF = null;
                    Mesa mesa = new Mesa(null);
                    if (!data.IsDBNull(1))
                        mesa.Numero = data.GetInt32(1);
                    else
                        mesa.Numero = -1;
                    Pedido pedido = new Pedido(mesa, cliente);
                    pedido.Codigo = data.GetInt32(2);
                    pedido.Data = data.GetString(3);
                    if (!data.IsDBNull(4))
                        pedido.PrecoTotal = data.GetDecimal(4);
                    else
                        pedido.PrecoTotal = -1;
                    pedido.PagamentoConfirmado = data.GetBoolean(5);

                    lista.Add(pedido);
                }
                ConnectionFactory.close();
            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }

            return lista;
        }
        public List<Pedido> find(int codigo)
        {
            List<Pedido> lista = new List<Pedido>();
            lista.Clear();
            try
            {
                var query = "SELECT cliente_pedido.cpf, pedido.numero_mesa, pedido.codigo, to_char(pedido.data,'DD/MM/YYYY HH24:MI:SS'), ";
                query += "pedido.preco_total, pedido.pagamento_confirmado FROM pedido ";
                query += $"LEFT JOIN cliente_pedido ON pedido.codigo=cliente_pedido.codigo_pedido ";
                if (codigo == -1)
                {
                    query += $" WHERE pedido.pagamento_confirmado = true";
                }
                else {
                    query += $" WHERE pedido.codigo={codigo}";
                }

                ConnectionFactory.open();
                var data = ConnectionFactory.command(query);
                while (data.Read())
                {
                    Cliente cliente = new Cliente();
                    if (!data.IsDBNull(0))
                        cliente.CPF = data.GetString(0);
                    else
                        cliente.CPF = null;
                    Mesa mesa = new Mesa(null);
                    if (!data.IsDBNull(1))
                        mesa.Numero = data.GetInt32(1);
                    else
                        mesa.Numero = -1;
                    Pedido pedido = new Pedido(mesa,cliente);
                    pedido.Codigo = data.GetInt32(2);
                    pedido.Data = data.GetString(3);
                    if (!data.IsDBNull(4))
                        pedido.PrecoTotal = data.GetDecimal(4);
                    else
                        pedido.PrecoTotal = -1;
                    pedido.PagamentoConfirmado = data.GetBoolean(5);

                    lista.Add(pedido);
                }
                ConnectionFactory.close();
            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }

            return lista;
        }
    }
}
