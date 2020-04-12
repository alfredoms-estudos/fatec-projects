using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleRestaurante.base_src.model
{
    class MesaDAO
    {
        public int insert(Mesa mesa)
        {
            ConnectionFactory.open();
            string select = "SELECT * FROM mesa";
            select += $" WHERE mesa.numero ={mesa.Numero}";
            var data = ConnectionFactory.command(select);
            if (data.HasRows == true && data.Read())
            {
                MessageBox.Show("Essa mesa já é cadastrada!");
                ConnectionFactory.close();
                return mesa.Numero;
            }
            else
            {
                ConnectionFactory.close();
                int numero;
                string insertSQL = $"INSERT INTO mesa (numero, identificacao_garcom) ";
                insertSQL += $" VALUES ({mesa.Numero}, '{mesa.Garcom.Identificacao}') ";
                insertSQL += $" RETURNING numero ";
                try
                {
                    ConnectionFactory.open();
                    data = ConnectionFactory.command(insertSQL);
                    data.Read();

                    numero = data.GetInt32(0);
                    ConnectionFactory.close();
                    MessageBox.Show("Mesa inserida com sucesso!");
                }
                catch (Exception e)
                {
                    ConnectionFactory.close();
                    throw e;
                }

                return numero;
            }
        }

        public void update(Mesa mesa)
        {
            string query = $"SELECT pedido.codigo FROM pedido INNER JOIN mesa ON pedido.numero_mesa = mesa.numero";
                query+= $" WHERE mesa.numero = {mesa.Numero}";
            ConnectionFactory.open();
            var data = ConnectionFactory.command(query);
            if (data.Read()) {
                MessageBox.Show("Essa mesa está relacionado a um pedido e não pode ser alterada");
                ConnectionFactory.close(); 
            }
            else
            {
                ConnectionFactory.close();
                string updateSQL = $"UPDATE mesa SET numero={mesa.Numero}, identificacao_garcom='{mesa.Garcom.Identificacao}' ";
                updateSQL += $" WHERE numero={mesa.Numero}";
                try
                {
                    ConnectionFactory.open();
                    ConnectionFactory.command(updateSQL);
                    ConnectionFactory.close();
                    MessageBox.Show("Mesa atualizada com sucesso!");
                }
                catch (Exception e)
                {
                    ConnectionFactory.close();
                    throw e;
                }
            }
        }

        public void delete(Mesa mesa)
        {
            string query = $"SELECT pedido.codigo FROM pedido INNER JOIN mesa ON pedido.numero_mesa = mesa.numero";
            query += $" WHERE mesa.numero = {mesa.Numero}";
            ConnectionFactory.open();
            var data = ConnectionFactory.command(query);
            if (data.Read())
            {
                MessageBox.Show("Essa mesa está relacionado a um pedido e não pode ser excluida");
                ConnectionFactory.close();
            }
            else
            {
                ConnectionFactory.close();
                string deleteSQL = $"DELETE FROM mesa";
                deleteSQL += $" WHERE numero={mesa.Numero} ";
                try
                {
                    ConnectionFactory.open();
                    ConnectionFactory.command(deleteSQL);
                    ConnectionFactory.close();
                    MessageBox.Show("Mesa excluída com sucesso!");
                }
                catch (Exception e)
                {
                    ConnectionFactory.close();
                    throw e;
                }
            }
        }

        public List<Mesa> find(int numero)
        {
            List<Mesa> lista = new List<Mesa>();
            lista.Clear();
            try
            {
                var query = "SELECT numero, identificacao_garcom FROM mesa";
                if (numero != -1)
                    query += $" WHERE numero={numero}";

                ConnectionFactory.open();
                var data = ConnectionFactory.command(query);
                while (data.Read())
                {
                    Mesa mesa = new Mesa(null);
                    mesa.Numero = data.GetInt32(0);
                    Garcom garcom = new Garcom();
                    garcom.Identificacao = data.GetString(1);
                    mesa.Garcom = garcom;
                    lista.Add(mesa);
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
