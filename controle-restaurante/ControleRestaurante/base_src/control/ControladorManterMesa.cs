using ControleRestaurante.base_src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src.control
{
    class ControladorManterMesa
    {
        public void inserirMesa(int numero, string identificacao_garcom)
        {
            try
            {
                Garcom garcom = new Garcom();
                garcom.Identificacao = identificacao_garcom;
                Mesa mesa = new Mesa(garcom);
                mesa.Numero = numero;

                MesaDAO dao = new MesaDAO();
                dao.insert(mesa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void atualizarMesa(int numero, string identificacao_garcom)
        {
            try
            {
                Garcom garcom = new Garcom();
                garcom.Identificacao = identificacao_garcom;
                Mesa mesa = new Mesa(garcom);
                mesa.Numero = numero;

                MesaDAO dao = new MesaDAO();
                dao.update(mesa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void excluirMesa(int numero)
        {
            Mesa mesa = new Mesa(null);
            mesa.Numero = numero;
            try
            {
                MesaDAO dao = new MesaDAO();
                dao.delete(mesa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Mesa> retornarMesas(int numero = -1)
        {
            try
            {
                MesaDAO dao = new MesaDAO();
                return dao.find(numero);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
