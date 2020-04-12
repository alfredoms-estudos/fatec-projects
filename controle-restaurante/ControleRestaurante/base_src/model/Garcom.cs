using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src.model
{
    class Garcom
    {
        private string identificacao;
        private string nome;
        private string telefone;

        public string Identificacao {
            get{
                return this.identificacao;
            }
            set{
                this.identificacao = value;
            }
        }

        public string Nome
        {
            get
            {
                return this.nome;
            }
            set
            {
                this.nome = value;
            }
        }

        public string Telefone
        {
            get
            {
                return this.telefone;
            }
            set
            {
                this.telefone = value;
            }
        }
    }
}
