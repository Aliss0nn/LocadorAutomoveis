namespace LocadorAutomoveis.WinApp.ModuloCondutor
{
    partial class TelaCondutorForm
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
            cmbClientes = new ComboBox();
            lbCliente = new Label();
            lbNome = new Label();
            lbValidade = new Label();
            lbEmail = new Label();
            lbTelefone = new Label();
            lbCNH = new Label();
            lbCPF = new Label();
            checkboxClienteCondutor = new CheckBox();
            txtEmail = new TextBox();
            txtNome = new TextBox();
            btnCancelar = new Button();
            dateTimeValidade = new DateTimePicker();
            maskTelefone = new MaskedTextBox();
            btnGravar = new Button();
            txtCPF = new TextBox();
            txtCNH = new TextBox();
            SuspendLayout();
            // 
            // cmbClientes
            // 
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(88, 25);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(332, 23);
            cmbClientes.TabIndex = 1;
            // 
            // lbCliente
            // 
            lbCliente.AutoSize = true;
            lbCliente.Location = new Point(28, 33);
            lbCliente.Name = "lbCliente";
            lbCliente.Size = new Size(47, 15);
            lbCliente.TabIndex = 1;
            lbCliente.Text = "Cliente:";
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(32, 102);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 2;
            lbNome.Text = "Nome:";
            // 
            // lbValidade
            // 
            lbValidade.AutoSize = true;
            lbValidade.Location = new Point(21, 289);
            lbValidade.Name = "lbValidade";
            lbValidade.Size = new Size(54, 15);
            lbValidade.TabIndex = 3;
            lbValidade.Text = "Validade:";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(32, 147);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(39, 15);
            lbEmail.TabIndex = 4;
            lbEmail.Text = "Email:";
            // 
            // lbTelefone
            // 
            lbTelefone.AutoSize = true;
            lbTelefone.Location = new Point(21, 197);
            lbTelefone.Name = "lbTelefone";
            lbTelefone.Size = new Size(54, 15);
            lbTelefone.TabIndex = 5;
            lbTelefone.Text = "Telefone:";
            // 
            // lbCNH
            // 
            lbCNH.AutoSize = true;
            lbCNH.Location = new Point(39, 245);
            lbCNH.Name = "lbCNH";
            lbCNH.Size = new Size(36, 15);
            lbCNH.TabIndex = 6;
            lbCNH.Text = "CNH:";
            // 
            // lbCPF
            // 
            lbCPF.AutoSize = true;
            lbCPF.Location = new Point(213, 197);
            lbCPF.Name = "lbCPF";
            lbCPF.Size = new Size(31, 15);
            lbCPF.TabIndex = 7;
            lbCPF.Text = "CPF:";
            // 
            // checkboxClienteCondutor
            // 
            checkboxClienteCondutor.AutoSize = true;
            checkboxClienteCondutor.Location = new Point(88, 63);
            checkboxClienteCondutor.Name = "checkboxClienteCondutor";
            checkboxClienteCondutor.Size = new Size(126, 19);
            checkboxClienteCondutor.TabIndex = 2;
            checkboxClienteCondutor.Text = "Cliente é Condutor";
            checkboxClienteCondutor.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(88, 139);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(332, 23);
            txtEmail.TabIndex = 4;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(88, 99);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(332, 23);
            txtNome.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(319, 354);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 38);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // dateTimeValidade
            // 
            dateTimeValidade.Location = new Point(88, 283);
            dateTimeValidade.Name = "dateTimeValidade";
            dateTimeValidade.Size = new Size(332, 23);
            dateTimeValidade.TabIndex = 8;
            // 
            // maskTelefone
            // 
            maskTelefone.Location = new Point(88, 189);
            maskTelefone.Mask = "(99) 00000-0000";
            maskTelefone.Name = "maskTelefone";
            maskTelefone.Size = new Size(119, 23);
            maskTelefone.TabIndex = 5;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(213, 354);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(100, 38);
            btnGravar.TabIndex = 9;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(250, 189);
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(169, 23);
            txtCPF.TabIndex = 11;
            // 
            // txtCNH
            // 
            txtCNH.Location = new Point(88, 237);
            txtCNH.Name = "txtCNH";
            txtCNH.Size = new Size(169, 23);
            txtCNH.TabIndex = 12;
            // 
            // TelaCondutorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 407);
            Controls.Add(txtCNH);
            Controls.Add(txtCPF);
            Controls.Add(maskTelefone);
            Controls.Add(dateTimeValidade);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtNome);
            Controls.Add(txtEmail);
            Controls.Add(checkboxClienteCondutor);
            Controls.Add(lbCPF);
            Controls.Add(lbCNH);
            Controls.Add(lbTelefone);
            Controls.Add(lbEmail);
            Controls.Add(lbValidade);
            Controls.Add(lbNome);
            Controls.Add(lbCliente);
            Controls.Add(cmbClientes);
            Name = "TelaCondutorForm";
            Text = "Cadastro De Condutor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbClientes;
        private Label lbCliente;
        private Label lbNome;
        private Label lbValidade;
        private Label lbEmail;
        private Label lbTelefone;
        private Label lbCNH;
        private Label lbCPF;
        private CheckBox checkboxClienteCondutor;
        private TextBox txtEmail;
        private TextBox txtNome;
        private Button btnCancelar;
        private DateTimePicker dateTimeValidade;
        private MaskedTextBox maskTelefone;
        private Button btnGravar;
        private TextBox txtCPF;
        private TextBox txtCNH;
    }
}