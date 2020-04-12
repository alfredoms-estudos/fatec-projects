using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleRestaurante.base_src.model
{
    class ClienteDAO
    {
        public void insert(Cliente cliente)
        {
            ConnectionFactory.open();
            try
            {
                string select = "SELECT * FROM cliente";
                select += $" WHERE cliente.cpf LIKE '{cliente.CPF}'";
                var data = ConnectionFactory.command(select);
                if (data.HasRows == true || data.Read())
                {
                    MessageBox.Show("Cliente já é cadastrado!!");
                    ConnectionFactory.close();
                    EnderecoDAO ed = new EnderecoDAO();
                    Endereco endereco = new Endereco();
                    endereco.Codigo = cliente.Endereco.Codigo;
                    ed.delete(endereco);
                }
                else {
                    ConnectionFactory.close();
                    string insertSQL = $"INSERT INTO cliente (cpf, nome, telefone, codigo_endereco) ";
                    insertSQL += $" VALUES ('{cliente.CPF}', '{cliente.Nome}', '{cliente.Telefone}', {cliente.Endereco.Codigo}) ";
                    insertSQL += $" RETURNING cpf";
                    ConnectionFactory.open();
                    try
                    {
                        ConnectionFactory.command(insertSQL);
                        ConnectionFactory.close();
                        MessageBox.Show("Cliente cadastrado com sucesso");
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

        public void update(Cliente cliente)
        {
            string updateSQL = $"UPDATE cliente SET cpf='{cliente.CPF}', ";
            updateSQL += $"nome='{cliente.Nome}', telefone='{cliente.Telefone}', codigo_endereco={cliente.Endereco.Codigo} ";
            updateSQL += $" WHERE codigo_endereco='{cliente.Endereco.Codigo}'";
            try
            {
                ConnectionFactory.open();
                ConnectionFactory.command(updateSQL);
                ConnectionFactory.close();
                MessageBox.Show("Cliente atualizado com sucesso!");
            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }
        }

        public void delete(Cliente cliente)
        {
            string query = $"SELECT codigo_pedido FROM (cliente_pedido INNER JOIN cliente ON cliente_pedido.cpf = cliente.cpf) INNER JOIN endereco ON endereco.codigo = cliente.codigo_endereco ";
            query += $"WHERE endereco.codigo = '{cliente.Endereco.Codigo}'";
            try
            {
                ConnectionFactory.open();
                var data = ConnectionFactory.command(query);
                if (data.HasRows == true && data.Read())
                {
                    MessageBox.Show("Esse cliente não pode ser excluido porque há pedidos relacionados a ele!");
                    ConnectionFactory.close();
                }
                else {
                    ConnectionFactory.close();
                    string deleteSQL = $"DELETE FROM cliente ";
                    deleteSQL += $" WHERE codigo_endereco={cliente.Endereco.Codigo}";
                    try
                    {
                        ConnectionFactory.open();
                        ConnectionFactory.command(deleteSQL);
                        ConnectionFactory.close();
                        MessageBox.Show("Cliente excluído com sucesso!");
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

        public List<Cliente> find(string cpf)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            listaClientes.Clear();
            try
            {
                var query = "SELECT cpf, nome, telefone, codigo_endereco FROM cliente ";
                if (cpf != null)
                    query += $" WHERE cpf = '{cpf}'";

                ConnectionFactory.open();
                var data = ConnectionFactory.command(query);
                while (data.Read())
                {
                    Cliente novoCliente = new Cliente();
                    novoCliente.CPF = data.GetString(0);
                    novoCliente.Nome = data.GetString(1);
                    novoCliente.Telefone = data.GetString(2);
                    Endereco endereco = new Endereco();
                    endereco.Codigo = data.GetInt32(3);
                    novoCliente.Endereco = endereco;
                    listaClientes.Add(novoCliente);
                }
                ConnectionFactory.close();
            } catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }

            return listaClientes;
        }
    }
}
