namespace LocadorAutomoveis.WinApp.ModuloAluguel
{
    partial class TelaAluguelConfiguracaoForm
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
            btnConfigurar = new Button();
            label2 = new Label();
            txtGasolina = new NumericUpDown();
            label1 = new Label();
            txtGas = new NumericUpDown();
            txtAlcool = new NumericUpDown();
            label3 = new Label();
            txtDiesel = new NumericUpDown();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)txtGasolina).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAlcool).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDiesel).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(167, 144);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfigurar
            // 
            btnConfigurar.DialogResult = DialogResult.OK;
            btnConfigurar.Location = new Point(86, 144);
            btnConfigurar.Name = "btnConfigurar";
            btnConfigurar.Size = new Size(75, 45);
            btnConfigurar.TabIndex = 5;
            btnConfigurar.Text = "Configurar";
            btnConfigurar.UseVisualStyleBackColor = true;
            btnConfigurar.Click += btnConfigurar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 14);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 5;
            label2.Text = "Preço Gasolina:";
            // 
            // txtGasolina
            // 
            txtGasolina.DecimalPlaces = 2;
            txtGasolina.Location = new Point(129, 12);
            txtGasolina.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            txtGasolina.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtGasolina.Name = "txtGasolina";
            txtGasolina.Size = new Size(84, 23);
            txtGasolina.TabIndex = 1;
            txtGasolina.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 42);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 10;
            label1.Text = "Preço Gás:";
            // 
            // txtGas
            // 
            txtGas.DecimalPlaces = 2;
            txtGas.Location = new Point(129, 42);
            txtGas.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            txtGas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtGas.Name = "txtGas";
            txtGas.Size = new Size(84, 23);
            txtGas.TabIndex = 2;
            txtGas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtAlcool
            // 
            txtAlcool.DecimalPlaces = 2;
            txtAlcool.Location = new Point(129, 101);
            txtAlcool.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            txtAlcool.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtAlcool.Name = "txtAlcool";
            txtAlcool.Size = new Size(84, 23);
            txtAlcool.TabIndex = 4;
            txtAlcool.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 103);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 14;
            label3.Text = "Preço Álcool:";
            // 
            // txtDiesel
            // 
            txtDiesel.DecimalPlaces = 2;
            txtDiesel.Location = new Point(129, 71);
            txtDiesel.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            txtDiesel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtDiesel.Name = "txtDiesel";
            txtDiesel.Size = new Size(84, 23);
            txtDiesel.TabIndex = 3;
            txtDiesel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 73);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 12;
            label4.Text = "Preço Diesel:";
            // 
            // TelaAluguelConfiguracaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(254, 201);
            Controls.Add(txtAlcool);
            Controls.Add(label3);
            Controls.Add(txtDiesel);
            Controls.Add(label4);
            Controls.Add(txtGas);
            Controls.Add(label1);
            Controls.Add(txtGasolina);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfigurar);
            Controls.Add(label2);
            Name = "TelaAluguelConfiguracaoForm";
            Text = "Configuração de Preços";
            ((System.ComponentModel.ISupportInitialize)txtGasolina).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGas).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAlcool).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDiesel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnConfigurar;
        private Label label2;
        private NumericUpDown txtGasolina;
        private Label label1;
        private NumericUpDown txtGas;
        private NumericUpDown txtAlcool;
        private Label label3;
        private NumericUpDown txtDiesel;
        private Label label4;
    }
}