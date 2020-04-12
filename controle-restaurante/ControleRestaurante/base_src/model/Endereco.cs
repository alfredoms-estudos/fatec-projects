using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src.model
{
    class Endereco
    {
        private int codigo;
        private string cep;
	    private string logradouro;
        private int numero;
        private string bairro;
        private string cidade;
	    private string complemento;

        public int Codigo
        {
            get
            {
                return this.codigo;
            }
            set
            {
                this.codigo = value;
            }
        }

        public string CEP
        {
            get
            {
                return this.cep;
            }
            set
            {
                this.cep= value;
            }
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

        public string Bairro
        {
            get
            {
                return this.bairro;
            }
            set
            {
                this.bairro = value;
            }
        }

        public string Cidade
        {
            get
            {
                return this.cidade;
            }
            set
            {
                this.cidade = value;
            }
        }

        public string Complemento
        {
            get
            {
                return this.complemento;
            }
            set
            {
                this.complemento = value;
            }
        }

        public string Logradouro
        {
            get
            {
                return this.logradouro;
            }
            set
            {
                this.logradouro = value;
            }
        }

    }
}
