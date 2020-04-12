using ControleRestaurante.base_src.control;
using ControleRestaurante.base_src.model;
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
    public partial class Mesas : Form
    {
        public Mesas()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNumero.Clear();
            cmbGarcom.Text = "";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbGarcom.Text == "")
                {
                    MessageBox.Show("Selecione um garçom para inserir uma mesa!");
                } else if (txtNumero.Text == ""){
                    MessageBox.Show("Digite o número da mesa antes de inserir!");
                } else {
                    string identificacao = cmbGarcom.Text.Substring(0, cmbGarcom.Text.IndexOf(":"));

                    ControladorManterMesa conMesa = new ControladorManterMesa();
                    conMesa.inserirMesa(
                        Int32.Parse(txtNumero.Text),
                        identificacao                        
                    );

                    LimparCampos();
                    reloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void reloadData()
        {
            gridMesas.Rows.Clear();
            ControladorManterMesa conMesa= new ControladorManterMesa();
            List<Mesa> mesas = conMesa.retornarMesas();
            try
            {
                foreach (Mesa mesa in mesas)
                {
                    ControladorManterGarcom conGarcom = new ControladorManterGarcom();
                    var listaGarcons = conGarcom.retornarGarcons(mesa.Garcom.Identificacao);
                    gridMesas.Rows.Add(mesa.Numero.ToString(), (listaGarcons.ElementAt(0).Identificacao+": "+ listaGarcons.ElementAt(0).Nome));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void loadGarcons()
        {
            cmbGarcom.Items.Clear();
            try
            {
                ControladorManterGarcom conGarcom = new ControladorManterGarcom();
                var lista = conGarcom.retornarGarcons();
                foreach (Garcom garcom in lista)
                {
                    cmbGarcom.Items.Add(garcom.Identificacao+": "+garcom.Nome);
                }
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void carregarMesa(Mesa mesa)
        {
            txtNumero.Text = mesa.Numero.ToString();
            cmbGarcom.Text = mesa.Garcom.Identificacao + ": " + mesa.Garcom.Nome;
        }

        override protected void OnLoad(EventArgs e)
        {
            this.reloadData();
            this.loadGarcons();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text.Trim() == "")
                {
                    MessageBox.Show("Digite um número para que a mesa possa ser excluída!");
                }
                else
                {
                    int numero = Int32.Parse(txtNumero.Text);

                    ControladorManterMesa conMesa = new ControladorManterMesa();
                    conMesa.excluirMesa(numero);

                    
                    LimparCampos();
                    reloadData();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbGarcom.Text == "")
                {
                    MessageBox.Show("Selecione um garçom para atualizar a mesa!");
                }
                else if (txtNumero.Text == "")
                {
                    MessageBox.Show("Digite o número da mesa para a atualizar!");
                }
                else
                {
                    string identificacao = cmbGarcom.Text.Substring(0, cmbGarcom.Text.IndexOf(":"));

                    ControladorManterMesa conMesa = new ControladorManterMesa();
                    conMesa.atualizarMesa(
                        Int32.Parse(txtNumero.Text),
                        identificacao
                    );

                    LimparCampos();
                    reloadData();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridMesas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridMesas.Rows[e.RowIndex];

                if (row.Cells[0].Value.ToString().Trim() != "")
                {
                    try
                    {
                        var numero = Int32.Parse(row.Cells[0].Value.ToString());
                        string identificacao = row.Cells[1].Value.ToString().Substring(0, row.Cells[1].Value.ToString().IndexOf(":"));
                        ControladorManterGarcom conGarcom = new ControladorManterGarcom();
                        List<Garcom> lista = conGarcom.retornarGarcons(identificacao);
                        var garcom = lista.ElementAt(0);
                        Mesa mesa = new Mesa(garcom);
                        mesa.Numero = numero;
                        LimparCampos();
                        carregarMesa(mesa);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void gridMesas_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridMesas.SelectedRows)
            {
                try
                {
                    var numero = Int32.Parse(row.Cells[0].Value.ToString());
                    string identificacao = row.Cells[1].Value.ToString().Substring(0, row.Cells[1].Value.ToString().IndexOf(":"));
                    ControladorManterGarcom conGarcom = new ControladorManterGarcom();
                    List<Garcom> lista = conGarcom.retornarGarcons(identificacao);
                    var garcom = lista.ElementAt(0);
                    Mesa mesa = new Mesa(garcom);
                    mesa.Numero = numero;
                    LimparCampos();
                    carregarMesa(mesa);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}
