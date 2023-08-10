namespace LocadorAutomoveis.WinApp.ModuloParceiro
{
    partial class TelaParceiroForm
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
            lbNome = new Label();
            txtNome = new TextBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(27, 45);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 0;
            lbNome.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(76, 37);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(234, 23);
            txtNome.TabIndex = 1;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(133, 111);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(90, 40);
            btnGravar.TabIndex = 2;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(229, 111);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(84, 40);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaParceiroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 167);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtNome);
            Controls.Add(lbNome);
            Name = "TelaParceiroForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Parceiros";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbNome;
        private TextBox txtNome;
        private Button btnGravar;
        private Button btnCancelar;
    }
}