namespace LocadorAutomoveis.WinApp.ModuloPlanoCobranca
{
    partial class TelaPlanoCobrancaForm
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
            txtId = new TextBox();
            label1 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            label2 = new Label();
            cmbTipo = new ComboBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            txtKmLivres = new NumericUpDown();
            txtPrecoKm = new NumericUpDown();
            txtPrecoDiario = new NumericUpDown();
            label = new Label();
            label4 = new Label();
            cmbGrupo = new ComboBox();
            label5 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKmLivres).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoKm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoDiario).BeginInit();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(94, 24);
            txtId.Name = "txtId";
            txtId.Size = new Size(60, 23);
            txtId.TabIndex = 1;
            txtId.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 27);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 11;
            label1.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(259, 285);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(178, 285);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 8;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 53);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 12;
            label2.Text = "Grupo:";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(94, 82);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(214, 23);
            cmbTipo.TabIndex = 3;
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 39);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 14;
            label3.Text = "Preço Diário:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtKmLivres);
            groupBox1.Controls.Add(txtPrecoKm);
            groupBox1.Controls.Add(txtPrecoDiario);
            groupBox1.Controls.Add(label);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(45, 125);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(263, 145);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configurações do Plano";
            // 
            // txtKmLivres
            // 
            txtKmLivres.DecimalPlaces = 2;
            txtKmLivres.Location = new Point(86, 96);
            txtKmLivres.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            txtKmLivres.Name = "txtKmLivres";
            txtKmLivres.Size = new Size(54, 23);
            txtKmLivres.TabIndex = 7;
            // 
            // txtPrecoKm
            // 
            txtPrecoKm.DecimalPlaces = 2;
            txtPrecoKm.Location = new Point(86, 67);
            txtPrecoKm.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            txtPrecoKm.Name = "txtPrecoKm";
            txtPrecoKm.Size = new Size(54, 23);
            txtPrecoKm.TabIndex = 6;
            // 
            // txtPrecoDiario
            // 
            txtPrecoDiario.DecimalPlaces = 2;
            txtPrecoDiario.Location = new Point(86, 39);
            txtPrecoDiario.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            txtPrecoDiario.Name = "txtPrecoDiario";
            txtPrecoDiario.Size = new Size(54, 23);
            txtPrecoDiario.TabIndex = 5;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(6, 69);
            label.Name = "label";
            label.Size = new Size(61, 15);
            label.TabIndex = 16;
            label.Text = "Preço Km:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 96);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 15;
            label4.Text = "Km Livres:";
            // 
            // cmbGrupo
            // 
            cmbGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupo.FormattingEnabled = true;
            cmbGrupo.Location = new Point(94, 53);
            cmbGrupo.Name = "cmbGrupo";
            cmbGrupo.Size = new Size(214, 23);
            cmbGrupo.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 82);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 16;
            label5.Text = "Tipo:";
            // 
            // TelaPlanoCobrancaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 342);
            Controls.Add(cmbGrupo);
            Controls.Add(label5);
            Controls.Add(groupBox1);
            Controls.Add(cmbTipo);
            Controls.Add(txtId);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(label2);
            Name = "TelaPlanoCobrancaForm";
            Text = "Cadastro de Planos de Cobrança ";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtKmLivres).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoKm).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoDiario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private Label label1;
        private Button btnCancelar;
        private Button btnGravar;
        private Label label2;
        private ComboBox cmbTipo;
        private Label label3;
        private GroupBox groupBox1;
        private NumericUpDown txtKmLivres;
        private NumericUpDown txtPrecoKm;
        private NumericUpDown txtPrecoDiario;
        private Label label;
        private Label label4;
        private ComboBox cmbGrupo;
        private Label label5;
    }
}