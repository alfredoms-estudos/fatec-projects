using ControleRestaurante.base_src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src.control
{
    class ControladorManterEndereco
    {
        public int inserirEndereco(string cep,
            string logradouro,
            int numero,
            string bairro,
            string cidade,
	        string complemento)
        {
            int codigo;
            try
            {
                Endereco endereco = new Endereco();
                endereco.CEP = cep;
                endereco.Logradouro = logradouro;
                endereco.Numero = numero;
                endereco.Bairro = bairro;
                endereco.Cidade = cidade;
                endereco.Complemento = complemento;

                EnderecoDAO dao = new EnderecoDAO();
                codigo = dao.insert(endereco);
            }
            catch (Exception e)
            {
                throw e;
            }

            return codigo;
        }

        public int atualizarEndereco(
            int codigo,
            string cep,
            string logradouro,
            int numero,
            string bairro,
            string cidade,
            string complemento
        )
        {
            try
            {
                Endereco endereco = new Endereco();
                endereco.Codigo = codigo;
                endereco.CEP = cep;
                endereco.Logradouro = logradouro;
                endereco.Numero = numero;
                endereco.Bairro = bairro;
                endereco.Cidade = cidade;
                endereco.Complemento = complemento;

                EnderecoDAO dao = new EnderecoDAO();
                dao.update(endereco);
            }
            catch (Exception e)
            {
                throw e;
            }

            return codigo;
        }

        public void excluirEndereco(int codigo)
        {
            Endereco endereco = new Endereco();
            endereco.Codigo = codigo;
            try
            {
                EnderecoDAO dao = new EnderecoDAO();
                dao.delete(endereco);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Endereco> retornarEnderecos(int codigo = -1)
        {
            try
            {
                EnderecoDAO dao = new EnderecoDAO();
                return dao.find(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

