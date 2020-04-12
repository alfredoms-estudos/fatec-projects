using ControleRestaurante.base_src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src.control
{
    class ControladorManterCliente
    {
        public void inserirCliente(string cpf, string nome, string telefone, Endereco endereco)
        {
            try {
                Cliente cliente = new Cliente();
                cliente.Nome = nome;
                cliente.CPF = cpf;
                cliente.Endereco = endereco;
                cliente.Telefone = telefone;

                ClienteDAO dao = new ClienteDAO();
                dao.insert(cliente);
            } catch (Exception e)
            {
                throw e;
            }
        }

        public void atualizarCliente(string cpf, string nome, string telefone, int codigo_endereco)
        {
            Endereco endereco = new Endereco();
            endereco.Codigo = codigo_endereco;
            Cliente cliente = new Cliente();
            cliente.Nome = nome;
            cliente.CPF = cpf;
            cliente.Endereco = endereco;
            cliente.Telefone = telefone;

            try
            {
                ClienteDAO dao = new ClienteDAO();
                dao.update(cliente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void excluirCliente(int codigo)
        {
            Endereco endereco = new Endereco();
            endereco.Codigo = codigo;
            Cliente cliente = new Cliente();
            cliente.Endereco = endereco;
            try
            {
                ClienteDAO dao = new ClienteDAO();
                dao.delete(cliente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Cliente> retornarClientes(string cpf = null)
        {
            try {
                ClienteDAO dao = new ClienteDAO();
                return dao.find(cpf);
            } catch (Exception e)
            {
                throw e;
            }
        }
    }
}
