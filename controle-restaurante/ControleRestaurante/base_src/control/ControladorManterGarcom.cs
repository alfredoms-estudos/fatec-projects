using ControleRestaurante.base_src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src.control
{
    class ControladorManterGarcom
    {
        public void inserirGarcom(string identificacao, string nome, string telefone)
        {
            try
            {
                Garcom garcom = new Garcom();
                garcom.Identificacao = identificacao;
                garcom.Nome = nome;
                garcom.Telefone = telefone;

                GarcomDAO dao = new GarcomDAO();
                dao.insert(garcom);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void atualizarGarcom(string identificacao, string nome, string telefone)
        {
            try
            {
                Garcom garcom = new Garcom();
                garcom.Identificacao = identificacao;
                garcom.Nome = nome;
                garcom.Telefone = telefone;

                GarcomDAO dao = new GarcomDAO();
                dao.update(garcom);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void excluirGarcom(string identificacao)
        {
            Garcom garcom= new Garcom();
            garcom.Identificacao = identificacao;
            try
            {
                GarcomDAO dao = new GarcomDAO();
                dao.delete(garcom);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Garcom> retornarGarcons(string identificacao = null)
        {
            try
            {
                GarcomDAO dao = new GarcomDAO();
                return dao.find(identificacao);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
