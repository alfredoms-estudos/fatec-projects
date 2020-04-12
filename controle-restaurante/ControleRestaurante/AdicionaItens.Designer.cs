namespace ControleRestaurante
{
    partial class AdicionaItens
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
            this.gridItemPedido = new System.Windows.Forms.DataGridView();
            this.txtPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblQtd = new System.Windows.Forms.Label();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.cmbPedido = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemPedido)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridItemPedido
            // 
            this.gridItemPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItemPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItemPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtPedido,
            this.txtQuantidade,
            this.txtItem});
            this.gridItemPedido.Location = new System.Drawing.Point(12, 168);
            this.gridItemPedido.Name = "gridItemPedido";
            this.gridItemPedido.Size = new System.Drawing.Size(704, 185);
            this.gridItemPedido.TabIndex = 4;
            this.gridItemPedido.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridItemPedido_CellContentClick);
            this.gridItemPedido.SelectionChanged += new System.EventHandler(this.gridItemPedido_SelectionChanged);
            // 
            // txtPedido
            // 
            this.txtPedido.HeaderText = "Pedido";
            this.txtPedido.Name = "txtPedido";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.HeaderText = "Quantidade";
            this.txtQuantidade.Name = "txtQuantidade";
            // 
            // txtItem
            // 
            this.txtItem.HeaderText = "Item Associado";
            this.txtItem.Name = "txtItem";
            this.txtItem.Width = 200;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(398, 139);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 5;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(117, 139);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(259, 23);
            this.btnListar.TabIndex = 8;
            this.btnListar.Text = "Atualizar Lista (Pelo número do pedido)";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(560, 139);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 9;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(479, 139);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 10;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnVoltar.Location = new System.Drawing.Point(641, 139);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 11;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblQtd);
            this.groupBox2.Controls.Add(this.txtQtd);
            this.groupBox2.Controls.Add(this.cmbItem);
            this.groupBox2.Controls.Add(this.cmbPedido);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 116);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adicionar itens ao pedido";
            // 
            // lblQtd
            // 
            this.lblQtd.AutoSize = true;
            this.lblQtd.Location = new System.Drawing.Point(15, 76);
            this.lblQtd.Name = "lblQtd";
            this.lblQtd.Size = new System.Drawing.Size(62, 13);
            this.lblQtd.TabIndex = 13;
            this.lblQtd.Text = "Quantidade";
            // 
            // txtQtd
            // 
            this.txtQtd.Location = new System.Drawing.Point(91, 73);
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(100, 20);
            this.txtQtd.TabIndex = 12;
            this.txtQtd.TextChanged += new System.EventHandler(this.txtQtd_TextChanged);
            // 
            // cmbItem
            // 
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(91, 46);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(121, 21);
            this.cmbItem.TabIndex = 11;
            this.cmbItem.SelectedIndexChanged += new System.EventHandler(this.cmbItem_SelectedIndexChanged);
            // 
            // cmbPedido
            // 
            this.cmbPedido.FormattingEnabled = true;
            this.cmbPedido.Location = new System.Drawing.Point(91, 19);
            this.cmbPedido.Name = "cmbPedido";
            this.cmbPedido.Size = new System.Drawing.Size(121, 21);
            this.cmbPedido.TabIndex = 10;
            this.cmbPedido.SelectedIndexChanged += new System.EventHandler(this.cmbPedido_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Item";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Pedido";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(12, 139);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(99, 23);
            this.btnLimpar.TabIndex = 13;
            this.btnLimpar.Text = "Limpar Campos";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // AdicionaItens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 365);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.gridItemPedido);
            this.Name = "AdicionaItens";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adiciona Itens";
            ((System.ComponentModel.ISupportInitialize)(this.gridItemPedido)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gridItemPedido;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblQtd;
        private System.Windows.Forms.TextBox txtQtd;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.ComboBox cmbPedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpar;
    }
}