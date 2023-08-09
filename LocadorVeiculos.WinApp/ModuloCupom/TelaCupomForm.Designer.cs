namespace LocadorAutomoveis.WinApp.ModuloCupom
{
    partial class TelaCupomForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbParceiro = new ComboBox();
            DataValidadePicker = new DateTimePicker();
            txtValor = new MaskedTextBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            lbParceiro = new Label();
            txtNome = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 41);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 82);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "Valor:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 123);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 2;
            label3.Text = "Data Validade:";
            // 
            // cmbParceiro
            // 
            cmbParceiro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbParceiro.FormattingEnabled = true;
            cmbParceiro.Location = new Point(107, 159);
            cmbParceiro.Name = "cmbParceiro";
            cmbParceiro.Size = new Size(170, 23);
            cmbParceiro.TabIndex = 4;
            // 
            // DataValidadePicker
            // 
            DataValidadePicker.Location = new Point(107, 117);
            DataValidadePicker.Name = "DataValidadePicker";
            DataValidadePicker.Size = new Size(268, 23);
            DataValidadePicker.TabIndex = 3;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(107, 74);
            txtValor.Mask = "000000000000";
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(170, 23);
            txtValor.TabIndex = 2;
            txtValor.ValidatingType = typeof(int);
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(184, 213);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(93, 45);
            btnGravar.TabIndex = 5;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(283, 213);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(92, 45);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lbParceiro
            // 
            lbParceiro.AutoSize = true;
            lbParceiro.Location = new Point(36, 167);
            lbParceiro.Name = "lbParceiro";
            lbParceiro.Size = new Size(53, 15);
            lbParceiro.TabIndex = 11;
            lbParceiro.Text = "Parceiro:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(107, 38);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(268, 23);
            txtNome.TabIndex = 1;
            // 
            // TelaCupomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 273);
            Controls.Add(txtNome);
            Controls.Add(lbParceiro);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtValor);
            Controls.Add(DataValidadePicker);
            Controls.Add(cmbParceiro);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaCupomForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Cupom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox cmbParceiro;
        private DateTimePicker DataValidadePicker;
        private MaskedTextBox txtValor;
        private Button btnGravar;
        private Button btnCancelar;
        private Label lbParceiro;
        private TextBox txtNome;
    }
}