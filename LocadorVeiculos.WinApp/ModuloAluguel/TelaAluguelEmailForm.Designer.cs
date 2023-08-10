namespace LocadorAutomoveis.WinApp.ModuloAluguel
{
    partial class TelaAluguelEmailForm
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
            btnCancelar = new Button();
            btnGravar = new Button();
            txtEmail = new TextBox();
            lbNome = new Label();
            txtSenha = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(293, 124);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(84, 40);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(197, 124);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(90, 40);
            btnGravar.TabIndex = 6;
            btnGravar.Text = "Logar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(162, 39);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(234, 23);
            txtEmail.TabIndex = 5;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(55, 42);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(100, 15);
            lbNome.TabIndex = 4;
            lbNome.Text = "Email do Emissor:";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(162, 80);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(234, 23);
            txtSenha.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 83);
            label1.Name = "label1";
            label1.Size = new Size(135, 15);
            label1.TabIndex = 8;
            label1.Text = "Senha(chave de acesso):";
            // 
            // TelaAluguelEmailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 173);
            Controls.Add(txtSenha);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtEmail);
            Controls.Add(lbNome);
            Name = "TelaAluguelEmailForm";
            Text = "Login Email";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnGravar;
        private TextBox txtEmail;
        private Label lbNome;
        private TextBox txtSenha;
        private Label label1;
    }
}