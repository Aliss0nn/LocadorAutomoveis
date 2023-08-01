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
            lbID = new Label();
            txtId = new TextBox();
            SuspendLayout();
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(39, 68);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 0;
            lbNome.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(97, 60);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(208, 23);
            txtNome.TabIndex = 1;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(155, 113);
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
            btnCancelar.Location = new Point(251, 113);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(84, 40);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lbID
            // 
            lbID.AutoSize = true;
            lbID.Location = new Point(62, 32);
            lbID.Name = "lbID";
            lbID.Size = new Size(20, 15);
            lbID.TabIndex = 4;
            lbID.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(97, 24);
            txtId.Name = "txtId";
            txtId.Size = new Size(29, 23);
            txtId.TabIndex = 5;
            // 
            // TelaParceiroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(347, 165);
            Controls.Add(txtId);
            Controls.Add(lbID);
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
        private Label lbID;
        private TextBox txtId;
    }
}