namespace LocadorAutomoveis.WinApp.ModuloAluguel
{
    partial class TelaAluguelForm
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
            cmbFuncionario = new ComboBox();
            label1 = new Label();
            label3 = new Label();
            cmbCliente = new ComboBox();
            label4 = new Label();
            cmbGrupo = new ComboBox();
            label5 = new Label();
            cmbPlano = new ComboBox();
            label6 = new Label();
            txtLocacao = new DateTimePicker();
            label7 = new Label();
            cmbAutomovel = new ComboBox();
            label8 = new Label();
            cmbCupom = new ComboBox();
            txtKmAutomovel = new TextBox();
            label2 = new Label();
            txtPrevisao = new DateTimePicker();
            label9 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            listTaxas = new CheckedListBox();
            label10 = new Label();
            cmbondutor = new ComboBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(597, 402);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(516, 402);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 7;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // cmbFuncionario
            // 
            cmbFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFuncionario.FormattingEnabled = true;
            cmbFuncionario.Location = new Point(151, 41);
            cmbFuncionario.Name = "cmbFuncionario";
            cmbFuncionario.Size = new Size(190, 23);
            cmbFuncionario.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 44);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 10;
            label1.Text = "Funcionário:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(98, 73);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 12;
            label3.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(151, 70);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(190, 23);
            cmbCliente.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 107);
            label4.Name = "label4";
            label4.Size = new Size(126, 15);
            label4.TabIndex = 14;
            label4.Text = "Grupo de Automóveis:";
            // 
            // cmbGrupo
            // 
            cmbGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupo.FormattingEnabled = true;
            cmbGrupo.Location = new Point(151, 99);
            cmbGrupo.Name = "cmbGrupo";
            cmbGrupo.Size = new Size(190, 23);
            cmbGrupo.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 136);
            label5.Name = "label5";
            label5.Size = new Size(110, 15);
            label5.TabIndex = 16;
            label5.Text = "Plano de Cobrança:";
            // 
            // cmbPlano
            // 
            cmbPlano.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlano.FormattingEnabled = true;
            cmbPlano.Location = new Point(151, 128);
            cmbPlano.Name = "cmbPlano";
            cmbPlano.Size = new Size(190, 23);
            cmbPlano.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(64, 164);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 17;
            label6.Text = "Data Locação:";
            // 
            // txtLocacao
            // 
            txtLocacao.Format = DateTimePickerFormat.Short;
            txtLocacao.Location = new Point(151, 157);
            txtLocacao.Name = "txtLocacao";
            txtLocacao.Size = new Size(190, 23);
            txtLocacao.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(407, 76);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 20;
            label7.Text = "Automovel:";
            // 
            // cmbAutomovel
            // 
            cmbAutomovel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAutomovel.FormattingEnabled = true;
            cmbAutomovel.Location = new Point(482, 73);
            cmbAutomovel.Name = "cmbAutomovel";
            cmbAutomovel.Size = new Size(190, 23);
            cmbAutomovel.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(230, 199);
            label8.Name = "label8";
            label8.Size = new Size(50, 15);
            label8.TabIndex = 22;
            label8.Text = "Cupom:";
            // 
            // cmbCupom
            // 
            cmbCupom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCupom.FormattingEnabled = true;
            cmbCupom.Location = new Point(286, 196);
            cmbCupom.Name = "cmbCupom";
            cmbCupom.Size = new Size(190, 23);
            cmbCupom.TabIndex = 21;
            // 
            // txtKmAutomovel
            // 
            txtKmAutomovel.Location = new Point(482, 102);
            txtKmAutomovel.Name = "txtKmAutomovel";
            txtKmAutomovel.Size = new Size(190, 23);
            txtKmAutomovel.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(389, 105);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 23;
            label2.Text = "KmAutomovel:";
            // 
            // txtPrevisao
            // 
            txtPrevisao.Format = DateTimePickerFormat.Short;
            txtPrevisao.Location = new Point(482, 131);
            txtPrevisao.Name = "txtPrevisao";
            txtPrevisao.Size = new Size(190, 23);
            txtPrevisao.TabIndex = 26;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(395, 136);
            label9.Name = "label9";
            label9.Size = new Size(81, 15);
            label9.TabIndex = 25;
            label9.Text = "Data Previsão:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(35, 255);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(396, 192);
            tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(listTaxas);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(388, 164);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Taxas Selecionadas";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // listTaxas
            // 
            listTaxas.FormattingEnabled = true;
            listTaxas.Location = new Point(6, 6);
            listTaxas.Name = "listTaxas";
            listTaxas.Size = new Size(376, 148);
            listTaxas.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(418, 44);
            label10.Name = "label10";
            label10.Size = new Size(58, 15);
            label10.TabIndex = 29;
            label10.Text = "Condutor";
            // 
            // cmbondutor
            // 
            cmbondutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbondutor.FormattingEnabled = true;
            cmbondutor.Location = new Point(482, 41);
            cmbondutor.Name = "cmbondutor";
            cmbondutor.Size = new Size(190, 23);
            cmbondutor.TabIndex = 28;
            // 
            // TelaAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 459);
            Controls.Add(label10);
            Controls.Add(cmbondutor);
            Controls.Add(tabControl1);
            Controls.Add(txtPrevisao);
            Controls.Add(label9);
            Controls.Add(txtKmAutomovel);
            Controls.Add(label2);
            Controls.Add(label8);
            Controls.Add(cmbCupom);
            Controls.Add(label7);
            Controls.Add(cmbAutomovel);
            Controls.Add(txtLocacao);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cmbPlano);
            Controls.Add(label4);
            Controls.Add(cmbGrupo);
            Controls.Add(label3);
            Controls.Add(cmbCliente);
            Controls.Add(label1);
            Controls.Add(cmbFuncionario);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaAluguelForm";
            Text = "Cadastro de Aluguéis";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnGravar;
        private ComboBox cmbFuncionario;
        private Label label1;
        private Label label3;
        private ComboBox cmbCliente;
        private Label label4;
        private ComboBox cmbGrupo;
        private Label label5;
        private ComboBox cmbPlano;
        private Label label6;
        private DateTimePicker txtLocacao;
        private Label label7;
        private ComboBox cmbAutomovel;
        private Label label8;
        private ComboBox cmbCupom;
        private TextBox txtKmAutomovel;
        private Label label2;
        private DateTimePicker txtPrevisao;
        private Label label9;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private CheckedListBox listTaxas;
        private Label label10;
        private ComboBox cmbondutor;
    }
}