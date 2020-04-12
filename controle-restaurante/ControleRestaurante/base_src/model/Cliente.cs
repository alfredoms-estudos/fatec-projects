using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src.model
{
    class Cliente
    {
        private string cpf;
        private string nome;
        private string telefone;
        private Endereco endereco;

        public string CPF
        {
            get
            {
                return this.cpf;
            }
            set
            {
                this.cpf = value;
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

        public Endereco Endereco
        {
            get
            {
                return this.endereco;
            }
            set
            {
                this.endereco = value;
            }
        }
    }
}
