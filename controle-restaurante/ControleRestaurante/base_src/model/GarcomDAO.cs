using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleRestaurante.base_src.model
{
    class GarcomDAO
    {
        public string insert(Garcom garcom)
        {
            try { 
                ConnectionFactory.open();
                string select = "SELECT garcom.telefone FROM garcom ";
                select += $"WHERE garcom.identificacao = '{garcom.Identificacao}'";
                var data = ConnectionFactory.command(select);
                if (data.HasRows == true && data.Read())
                {
                    ConnectionFactory.close();
                    MessageBox.Show("Esse garçom já é cadastrado");
                    return garcom.Identificacao;
                }
                else {
                    ConnectionFactory.close();
                    string identificacao;
                    string insertSQL = $"INSERT INTO garcom (identificacao, telefone, nome) ";
                    insertSQL += $" VALUES ('{garcom.Identificacao}', '{garcom.Telefone}', '{ garcom.Nome}') ";
                    insertSQL += $" RETURNING identificacao";
                    try
                    {
                        ConnectionFactory.open();
                        data = ConnectionFactory.command(insertSQL);
                        data.Read();
                        identificacao = data.GetString(0);
                        ConnectionFactory.close();
                        MessageBox.Show("Garçom inserido com sucesso!");
                    }
                    catch (Exception e)
                    {
                        ConnectionFactory.close();
                        throw e;
                    }

                    return identificacao;
                }

            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }
        }

        public void update(Garcom garcom)
        {
            string updateSQL = $"UPDATE garcom SET identificacao='{garcom.Identificacao}', nome='{garcom.Nome}', ";
            updateSQL += $"telefone='{garcom.Telefone}' ";
            updateSQL += $" WHERE identificacao='{garcom.Identificacao}'";
            try
            {
                ConnectionFactory.open();
                ConnectionFactory.command(updateSQL);
                ConnectionFactory.close();
                MessageBox.Show("Garçom atualizado com sucesso!");
            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }
        }

        public void delete(Garcom garcom)
        {
            string selectSQL = $"SELECT identificacao_garcom FROM mesa ";
            if (garcom.Identificacao != null)
                selectSQL += $"where identificacao_garcom like '{garcom.Identificacao}'";
            try
            {
                ConnectionFactory.open();
                var data = ConnectionFactory.command(selectSQL);

                if (data.HasRows == true && data.Read())
                {
                    MessageBox.Show("Garçom está associado a uma mesa e não pode ser excluído");
                    ConnectionFactory.close();
                }
                else
                {
                    ConnectionFactory.close();
                    string deleteSQL = $"DELETE FROM garcom";
                    deleteSQL += $" WHERE identificacao='{garcom.Identificacao}' ";
                    try
                    {
                        ConnectionFactory.open();
                        ConnectionFactory.command(deleteSQL);
                        MessageBox.Show("Garçom excluído com sucesso!");
                        ConnectionFactory.close();
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

        public List<Garcom> find(string identificacao)
        {
            List<Garcom> lista = new List<Garcom>();
            lista.Clear();
            try
            {
                var query = "SELECT identificacao, nome, telefone FROM garcom";
                if (identificacao != null)
                    query += $" WHERE identificacao='{identificacao}'";

                ConnectionFactory.open();
                var data = ConnectionFactory.command(query);
                while (data.Read())
                {
                    Garcom novoGarcom = new Garcom();
                    novoGarcom.Identificacao = data.GetString(0);
                    novoGarcom.Nome = data.GetString(1);
                    novoGarcom.Telefone = data.GetString(2);
                    lista.Add(novoGarcom);
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
