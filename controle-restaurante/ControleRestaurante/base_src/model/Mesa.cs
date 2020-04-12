using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src.model
{
    class Mesa
    {
        private int numero;
        private Garcom garcom;

        public Mesa(Garcom _garcom)
        {
            this.garcom = _garcom;
        }

        public int Numero
        {
            get
            {
                return this.numero;
            }
            set
            {
                this.numero = value;
            }
        }

        public Garcom Garcom
        {
            get
            {
                return this.garcom;
            }
            set
            {
                this.garcom = value;
            }
        }
    }
}
