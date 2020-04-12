using ControleRestaurante.base_src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src.control
{
    class ControladorManterItem
    {
        public void inserirItem(string nome, string descricao, string tipo, decimal preco)
        {
            try
            {
                Item item = new Item();
                item.Nome = nome;
                item.Descricao = descricao;
                item.Tipo = tipo;
                item.Preco = preco;

                ItemDAO dao = new ItemDAO();
                dao.insert(item);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void atualizarItem(int codigo, string nome, string descricao, string tipo, decimal preco)
        {
            try
            {
                Item item = new Item();
                item.Codigo = codigo;
                item.Nome = nome;
                item.Descricao = descricao;
                item.Tipo = tipo;
                item.Preco = preco;

                ItemDAO dao = new ItemDAO();
                dao.update(item);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void excluirItem(int codigo)
        {
            Item item = new Item();
            item.Codigo = codigo;
            try
            {
                ItemDAO dao = new ItemDAO();
                dao.delete(item);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Item> retornarItens(int codigo = -1)
        {
            try
            {
                ItemDAO dao = new ItemDAO();
                return dao.find(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
