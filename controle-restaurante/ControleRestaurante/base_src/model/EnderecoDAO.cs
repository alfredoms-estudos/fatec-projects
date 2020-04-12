using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleRestaurante.base_src.model
{
    class EnderecoDAO
    {
        public int insert(Endereco endereco)
        {
            int codigo;
            string insertSQL = $"INSERT INTO endereco (cep, logradouro, numero, bairro, cidade, complemento) ";
            insertSQL += $" VALUES ('{endereco.CEP}', '{endereco.Logradouro}', {endereco.Numero}, '{ endereco.Bairro}', '{ endereco.Cidade}', '{ endereco.Complemento}') ";
            insertSQL += $" RETURNING codigo";
            try
            {
                ConnectionFactory.open();
                var data = ConnectionFactory.command(insertSQL);
                data.Read();

                codigo = data.GetInt32(0);
                ConnectionFactory.close();
            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }

            return codigo;
        }

        public void update(Endereco endereco)
        {
            string updateSQL = $"UPDATE endereco SET cep='{endereco.CEP}', logradouro='{endereco.Logradouro}', ";
            updateSQL += $"numero={endereco.Numero}, bairro='{endereco.Bairro}', ";
            updateSQL += $"cidade='{endereco.Cidade}', complemento='{endereco.Complemento}'";
            updateSQL += $" WHERE codigo='{endereco.Codigo}'";
            try
            {
                ConnectionFactory.open();
                ConnectionFactory.command(updateSQL);
                ConnectionFactory.close();
            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }
        }

        public void delete(Endereco endereco)
        {
            string deleteSQL = $"DELETE FROM endereco";
            deleteSQL += $" WHERE codigo={endereco.Codigo} ";
            try
            {
                ConnectionFactory.open();
                ConnectionFactory.command(deleteSQL);
                ConnectionFactory.close();
            }
            catch (Exception e)
            {

                ConnectionFactory.close();
                throw e;
            }
        }

        public List<Endereco> find(int codigo)
        {
            List<Endereco> listaEnderecos = new List<Endereco>();
            listaEnderecos.Clear();
            try
            {
                var query = "SELECT codigo, cep, logradouro, numero, bairro, cidade, complemento FROM endereco";
                if (codigo != -1)
                    query += $" WHERE codigo={codigo}";

                ConnectionFactory.open();
                var data = ConnectionFactory.command(query);
                while (data.Read())
                {
                    Endereco novoEndereco = new Endereco();
                    novoEndereco.Codigo = data.GetInt32(0);
                    novoEndereco.CEP = data.GetString(1);
                    novoEndereco.Logradouro = data.GetString(2);
                    novoEndereco.Numero = data.GetInt32(3);
                    novoEndereco.Bairro = data.GetString(4);
                    novoEndereco.Cidade = data.GetString(5);
                    novoEndereco.Complemento = data.GetString(6);
                    listaEnderecos.Add(novoEndereco);
                }
                ConnectionFactory.close();
            }
            catch (Exception e)
            {
                ConnectionFactory.close();
                throw e;
            }

            return listaEnderecos;
        }
    }
}
