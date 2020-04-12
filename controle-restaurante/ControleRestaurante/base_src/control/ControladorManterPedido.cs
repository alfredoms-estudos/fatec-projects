using ControleRestaurante.base_src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleRestaurante.base_src.control
{
    class ControladorManterPedido
    {
        public int inserirPedido(int numero_mesa, string cpf)
        {
            int codigo;
            try
            {
                Mesa mesa = new Mesa(null);
                mesa.Numero = numero_mesa;
                Cliente cliente = new Cliente();
                cliente.CPF = cpf;
                Pedido pedido = new Pedido(mesa, cliente);

                PedidoDAO dao = new PedidoDAO();
                codigo = dao.insert(pedido);
            }
            catch (Exception e)
            {
                throw e;
            }

            return codigo;
        }

        public void atualizarPedido(int codigo, int numero_mesa, decimal preco_total, bool pagamento_confirmado, string cpf)
        {
            try
            {
                Mesa mesa = new Mesa(null);
                mesa.Numero = numero_mesa;
                Cliente cliente = new Cliente();
                cliente.CPF = cpf;
                Pedido pedido = new Pedido(mesa, cliente);
                pedido.PrecoTotal = preco_total;
                pedido.PagamentoConfirmado = pagamento_confirmado;
                pedido.Codigo = codigo;
                PedidoDAO dao = new PedidoDAO();
                dao.update(pedido);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void excluirPedido(int codigo)
        {
            Pedido pedido = new Pedido(null, null);
            pedido.Codigo = codigo;
            try
            {
                PedidoDAO dao = new PedidoDAO();
                dao.delete(pedido);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Pedido> retornarPedidos()
        {
            try
            {
                PedidoDAO dao = new PedidoDAO();
                return dao.find();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Pedido> retornarPedidosFechados(int codigo = -1)
        {
            try
            {
                PedidoDAO dao = new PedidoDAO();
                
                return dao.find(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
