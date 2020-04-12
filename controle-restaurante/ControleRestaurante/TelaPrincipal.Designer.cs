namespace ControleRestaurante
{
    partial class TelaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnItensPedidos = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnAdministrarMesas = new System.Windows.Forms.Button();
            this.btnAdministrarItens = new System.Windows.Forms.Button();
            this.btnAdministrarGarcons = new System.Windows.Forms.Button();
            this.btnFechaConta = new System.Windows.Forms.Button();
            this.btnAdicionarPedido = new System.Windows.Forms.Button();
            this.btnCadastrarCliente = new System.Windows.Forms.Button();
            this.login = new ControleRestaurante.Login();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnItensPedidos);
            this.groupBox1.Controls.Add(this.btnSair);
            this.groupBox1.Controls.Add(this.btnAdministrarMesas);
            this.groupBox1.Controls.Add(this.btnAdministrarItens);
            this.groupBox1.Controls.Add(this.btnAdministrarGarcons);
            this.groupBox1.Controls.Add(this.btnFechaConta);
            this.groupBox1.Controls.Add(this.btnAdicionarPedido);
            this.groupBox1.Controls.Add(this.btnCadastrarCliente);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 446);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnItensPedidos
            // 
            this.btnItensPedidos.Location = new System.Drawing.Point(6, 107);
            this.btnItensPedidos.Name = "btnItensPedidos";
            this.btnItensPedidos.Size = new System.Drawing.Size(265, 31);
            this.btnItensPedidos.TabIndex = 9;
            this.btnItensPedidos.Text = "Adicionar Itens à Pedidos";
            this.btnItensPedidos.UseVisualStyleBackColor = true;
            this.btnItensPedidos.Click += new System.EventHandler(this.btnItensPedidos_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(6, 306);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(265, 31);
            this.btnSair.TabIndex = 8;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnAdministrarMesas
            // 
            this.btnAdministrarMesas.Location = new System.Drawing.Point(6, 269);
            this.btnAdministrarMesas.Name = "btnAdministrarMesas";
            this.btnAdministrarMesas.Size = new System.Drawing.Size(265, 31);
            this.btnAdministrarMesas.TabIndex = 7;
            this.btnAdministrarMesas.Text = "Administrar Mesas";
            this.btnAdministrarMesas.UseVisualStyleBackColor = true;
            this.btnAdministrarMesas.Click += new System.EventHandler(this.btnAdministrarMesas_Click);
            // 
            // btnAdministrarItens
            // 
            this.btnAdministrarItens.Location = new System.Drawing.Point(6, 232);
            this.btnAdministrarItens.Name = "btnAdministrarItens";
            this.btnAdministrarItens.Size = new System.Drawing.Size(265, 31);
            this.btnAdministrarItens.TabIndex = 6;
            this.btnAdministrarItens.Text = "Administrar Itens";
            this.btnAdministrarItens.UseVisualStyleBackColor = true;
            this.btnAdministrarItens.Click += new System.EventHandler(this.btnAdministrarItens_Click);
            // 
            // btnAdministrarGarcons
            // 
            this.btnAdministrarGarcons.Location = new System.Drawing.Point(6, 195);
            this.btnAdministrarGarcons.Name = "btnAdministrarGarcons";
            this.btnAdministrarGarcons.Size = new System.Drawing.Size(265, 31);
            this.btnAdministrarGarcons.TabIndex = 5;
            this.btnAdministrarGarcons.Text = "Administrar Garçons";
            this.btnAdministrarGarcons.UseVisualStyleBackColor = true;
            this.btnAdministrarGarcons.Click += new System.EventHandler(this.btnAdministrarGarcons_Click);
            // 
            // btnFechaConta
            // 
            this.btnFechaConta.Location = new System.Drawing.Point(6, 144);
            this.btnFechaConta.Name = "btnFechaConta";
            this.btnFechaConta.Size = new System.Drawing.Size(265, 31);
            this.btnFechaConta.TabIndex = 4;
            this.btnFechaConta.Text = "Fechar Conta";
            this.btnFechaConta.UseVisualStyleBackColor = true;
            this.btnFechaConta.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAdicionarPedido
            // 
            this.btnAdicionarPedido.Location = new System.Drawing.Point(6, 70);
            this.btnAdicionarPedido.Name = "btnAdicionarPedido";
            this.btnAdicionarPedido.Size = new System.Drawing.Size(265, 31);
            this.btnAdicionarPedido.TabIndex = 2;
            this.btnAdicionarPedido.Text = "Administrar Pedidos";
            this.btnAdicionarPedido.UseVisualStyleBackColor = true;
            this.btnAdicionarPedido.Click += new System.EventHandler(this.btnAdicionarPedido_Click);
            // 
            // btnCadastrarCliente
            // 
            this.btnCadastrarCliente.Location = new System.Drawing.Point(6, 33);
            this.btnCadastrarCliente.Name = "btnCadastrarCliente";
            this.btnCadastrarCliente.Size = new System.Drawing.Size(265, 31);
            this.btnCadastrarCliente.TabIndex = 1;
            this.btnCadastrarCliente.Text = "Administrar Clientes";
            this.btnCadastrarCliente.UseVisualStyleBackColor = true;
            this.btnCadastrarCliente.Click += new System.EventHandler(this.btnCadastrarCliente_Click);
            // 
            // login
            // 
            this.login.ClientSize = new System.Drawing.Size(283, 143);
            this.login.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.login.Location = new System.Drawing.Point(533, 273);
            this.login.MaximizeBox = false;
            this.login.MinimizeBox = false;
            this.login.Name = "login";
            this.login.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.login.Text = "Controle de Restaurante - Login";
            this.login.Visible = false;
            this.login.Load += new System.EventHandler(this.login_Load);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 470);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Restaurante - Tela Principal";
            this.Load += new System.EventHandler(this.TelaPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Login login;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnAdministrarMesas;
        private System.Windows.Forms.Button btnAdministrarItens;
        private System.Windows.Forms.Button btnAdministrarGarcons;
        private System.Windows.Forms.Button btnFechaConta;
        private System.Windows.Forms.Button btnAdicionarPedido;
        private System.Windows.Forms.Button btnCadastrarCliente;
        private System.Windows.Forms.Button btnItensPedidos;
    }
}