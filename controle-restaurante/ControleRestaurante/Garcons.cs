using ControleRestaurante.base_src.model;
using ControleRestaurante.base_src.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleRestaurante
{
    public partial class Garcons : Form
    {
        public Garcons()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtIdentificacao.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdentificacao.Text.Trim() == "")
                {
                    MessageBox.Show("A identificação não pode estar vazia para que o registro possa ser excluído!");
                }
                else if (txtTelefone.Text.Trim() == "")
                {
                    MessageBox.Show("O telefone do garçom não pode estar em branco!");
                }
                else
                {
                    string identificacao = txtIdentificacao.Text;

                    ControladorManterGarcom conGarcom = new ControladorManterGarcom();
                    conGarcom.excluirGarcom(identificacao);
                    LimparCampos();
                    reloadData();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        override protected void OnLoad(EventArgs e)
        {
            this.reloadData();
        }

        private void reloadData()
        {
            gridGarcons.Rows.Clear();
            ControladorManterGarcom controlador = new ControladorManterGarcom();
            List<Garcom> lista = controlador.retornarGarcons(null);
            try
            {
                foreach (Garcom garcom in lista)
                {
                    gridGarcons.Rows.Add(garcom.Identificacao, garcom.Nome, garcom.Telefone);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtTelefone.Text.Trim() == "")
            {
                MessageBox.Show("O telefone do garçom não pode estar em branco!");
            }
            else
            {
                try
                {
                    ControladorManterGarcom conGarcom = new ControladorManterGarcom();
                    conGarcom.inserirGarcom(
                        txtIdentificacao.Text,
                        txtNome.Text,
                        txtTelefone.Text
                    );

                    LimparCampos();
                    reloadData();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdentificacao.Text.Trim() == "")
                {
                    MessageBox.Show("A identificação não pode estar vazia para que o registro possa ser alterado!");
                }
                else if (txtTelefone.Text.Trim() == "") {
                    MessageBox.Show("O telefone do garçom não pode estar em branco!");
                }
                else{
                    ControladorManterGarcom conGarcom = new ControladorManterGarcom();
                    conGarcom.atualizarGarcom(
                        txtIdentificacao.Text,
                        txtNome.Text,
                        txtTelefone.Text
                    );

                    
                    LimparCampos();
                    reloadData();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void gridGarcons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridGarcons.Rows[e.RowIndex];

                if (row.Cells[0].Value.ToString().Trim() != "")
                {
                    try
                    {
                        Garcom garcom = new Garcom();
                        garcom.Identificacao = row.Cells[0].Value.ToString();
                        garcom.Nome = row.Cells[1].Value.ToString();
                        garcom.Telefone = row.Cells[2].Value.ToString();

                        LimparCampos();
                        carregarGarcom(garcom);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void carregarGarcom(Garcom garcom)
        {
            txtIdentificacao.Text = garcom.Identificacao;
            txtNome.Text = garcom.Nome;
            txtTelefone.Text = garcom.Telefone;
        }

        private void gridGarcons_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridGarcons.SelectedRows)
            {
                if (row.Cells[0].Value.ToString().Trim() != "")
                {
                    try
                    {
                        Garcom garcom = new Garcom();
                        garcom.Identificacao = row.Cells[0].Value.ToString();
                        garcom.Nome = row.Cells[1].Value.ToString();
                        garcom.Telefone = row.Cells[2].Value.ToString();

                        LimparCampos();
                        carregarGarcom(garcom);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }

                }
            }

        }
    }
}
