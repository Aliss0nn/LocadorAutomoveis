namespace LocadorAutomoveis.WinApp.ModuloTaxasEServicos
{
    partial class TelaTaxasServicoForm
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
            lbPreço = new Label();
            grpBoxPlanos = new GroupBox();
            radiobtnFixo = new RadioButton();
            radioBtnDiario = new RadioButton();
            txtNome = new TextBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            txtPreco = new MaskedTextBox();
            grpBoxPlanos.SuspendLayout();
            SuspendLayout();
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(39, 48);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 0;
            lbNome.Text = "Nome:";
            // 
            // lbPreço
            // 
            lbPreço.AutoSize = true;
            lbPreço.Location = new Point(42, 87);
            lbPreço.Name = "lbPreço";
            lbPreço.Size = new Size(40, 15);
            lbPreço.TabIndex = 1;
            lbPreço.Text = "Preço:";
            // 
            // grpBoxPlanos
            // 
            grpBoxPlanos.Controls.Add(radiobtnFixo);
            grpBoxPlanos.Controls.Add(radioBtnDiario);
            grpBoxPlanos.Location = new Point(89, 128);
            grpBoxPlanos.Name = "grpBoxPlanos";
            grpBoxPlanos.Size = new Size(307, 71);
            grpBoxPlanos.TabIndex = 3;
            grpBoxPlanos.TabStop = false;
            grpBoxPlanos.Text = "Plano De Calculo";
            // 
            // radiobtnFixo
            // 
            radiobtnFixo.AutoSize = true;
            radiobtnFixo.Location = new Point(34, 35);
            radiobtnFixo.Name = "radiobtnFixo";
            radiobtnFixo.Size = new Size(80, 19);
            radiobtnFixo.TabIndex = 4;
            radiobtnFixo.TabStop = true;
            radiobtnFixo.Text = "Preço Fixo";
            radiobtnFixo.UseVisualStyleBackColor = true;
            // 
            // radioBtnDiario
            // 
            radioBtnDiario.AutoSize = true;
            radioBtnDiario.Location = new Point(138, 35);
            radioBtnDiario.Name = "radioBtnDiario";
            radioBtnDiario.Size = new Size(109, 19);
            radioBtnDiario.TabIndex = 5;
            radioBtnDiario.TabStop = true;
            radioBtnDiario.Text = "Cobrança Diária";
            radioBtnDiario.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(88, 45);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(344, 23);
            txtNome.TabIndex = 1;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(244, 226);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(92, 35);
            btnGravar.TabIndex = 6;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(342, 226);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 35);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(89, 84);
            txtPreco.Mask = "00000000";
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(129, 23);
            txtPreco.TabIndex = 8;
            txtPreco.ValidatingType = typeof(int);
            // 
            // TelaTaxasServicoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 280);
            Controls.Add(txtPreco);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtNome);
            Controls.Add(grpBoxPlanos);
            Controls.Add(lbPreço);
            Controls.Add(lbNome);
            Name = "TelaTaxasServicoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Taxas ou Serviços";
            grpBoxPlanos.ResumeLayout(false);
            grpBoxPlanos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbNome;
        private Label lbPreço;
        private GroupBox grpBoxPlanos;
        private RadioButton radiobtnFixo;
        private RadioButton radioBtnDiario;
        private TextBox txtNome;
        private Button btnGravar;
        private Button btnCancelar;
        private MaskedTextBox txtPreco;
    }
}