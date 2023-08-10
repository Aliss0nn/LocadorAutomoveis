namespace LocadorAutomoveis.WinApp.ModuloClientes
{
    partial class TelaClientesForm
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
            txtNome = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtEmail = new TextBox();
            txtTelefone = new TextBox();
            label3 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtCpf = new TextBox();
            txtEstado = new TextBox();
            txtBairro = new TextBox();
            txtRua = new TextBox();
            txtCnpj = new TextBox();
            txtCidade = new TextBox();
            txtNumero = new TextBox();
            label11 = new Label();
            btninserir = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(85, 12);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(263, 23);
            txtNome.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 15);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 44);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 2;
            label2.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(85, 41);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(263, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(85, 70);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(100, 23);
            txtTelefone.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 73);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 5;
            label3.Text = "Telefone:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(234, 115);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(104, 19);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "Pessoa Jurídica";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(119, 117);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(96, 19);
            radioButton2.TabIndex = 4;
            radioButton2.TabStop = true;
            radioButton2.Text = " Pessoa Fisica";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 169);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 8;
            label4.Text = "CPF:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 198);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 9;
            label5.Text = "Estado:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(41, 227);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 10;
            label6.Text = "Bairro:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(49, 256);
            label7.Name = "label7";
            label7.Size = new Size(30, 15);
            label7.TabIndex = 11;
            label7.Text = "Rua:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(191, 169);
            label8.Name = "label8";
            label8.Size = new Size(37, 15);
            label8.TabIndex = 12;
            label8.Text = "CNPJ:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(188, 194);
            label9.Name = "label9";
            label9.Size = new Size(47, 15);
            label9.TabIndex = 13;
            label9.Text = "Cidade:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(25, 285);
            label10.Name = "label10";
            label10.Size = new Size(54, 15);
            label10.TabIndex = 14;
            label10.Text = "Numero:";
            // 
            // txtCpf
            // 
            txtCpf.Enabled = false;
            txtCpf.Location = new Point(85, 166);
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(100, 23);
            txtCpf.TabIndex = 6;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(85, 195);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(100, 23);
            txtEstado.TabIndex = 8;
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(85, 224);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(263, 23);
            txtBairro.TabIndex = 10;
            // 
            // txtRua
            // 
            txtRua.Location = new Point(85, 253);
            txtRua.Name = "txtRua";
            txtRua.Size = new Size(263, 23);
            txtRua.TabIndex = 11;
            // 
            // txtCnpj
            // 
            txtCnpj.Enabled = false;
            txtCnpj.Location = new Point(234, 166);
            txtCnpj.Name = "txtCnpj";
            txtCnpj.Size = new Size(114, 23);
            txtCnpj.TabIndex = 7;
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(234, 195);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(114, 23);
            txtCidade.TabIndex = 9;
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(85, 282);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(100, 23);
            txtNumero.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(40, 119);
            label11.Name = "label11";
            label11.Size = new Size(73, 15);
            label11.TabIndex = 22;
            label11.Text = "Tipo Cliente:";
            // 
            // btninserir
            // 
            btninserir.DialogResult = DialogResult.OK;
            btninserir.Location = new Point(203, 320);
            btninserir.Name = "btninserir";
            btninserir.Size = new Size(75, 41);
            btninserir.TabIndex = 13;
            btninserir.Text = "Gravar";
            btninserir.UseVisualStyleBackColor = true;
            btninserir.Click += btninserir_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(284, 320);
            button2.Name = "button2";
            button2.Size = new Size(75, 41);
            button2.TabIndex = 14;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // TelaClientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 373);
            Controls.Add(button2);
            Controls.Add(btninserir);
            Controls.Add(label11);
            Controls.Add(txtNumero);
            Controls.Add(txtCidade);
            Controls.Add(txtCnpj);
            Controls.Add(txtRua);
            Controls.Add(txtBairro);
            Controls.Add(txtEstado);
            Controls.Add(txtCpf);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label3);
            Controls.Add(txtTelefone);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNome);
            Name = "TelaClientesForm";
            Text = "Cadastro de Clientes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private Label label1;
        private Label label2;
        private TextBox txtEmail;
        private TextBox txtTelefone;
        private Label label3;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox txtCpf;
        private TextBox txtEstado;
        private TextBox txtBairro;
        private TextBox txtRua;
        private TextBox txtCnpj;
        private TextBox txtCidade;
        private TextBox txtNumero;
        private Label label11;
        private Button btninserir;
        private Button button2;
    }
}