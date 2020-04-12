using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src
{
    static class Global
    {
        private static char tipoAcesso;

        public static char TipoAcesso
        {
            get { return tipoAcesso; }
            set { Global.tipoAcesso = value; }
        }

    }
}
