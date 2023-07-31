namespace LocadorAutomoveis.WinApp.ModuloFuncionario
{
    partial class TelaFuncionarioForm
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
            btnInserir = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txt_Nome = new TextBox();
            txt_dataAdmissao = new TextBox();
            txt_Salario = new TextBox();
            SuspendLayout();
            // 
            // btnInserir
            // 
            btnInserir.Location = new Point(195, 162);
            btnInserir.Name = "btnInserir";
            btnInserir.Size = new Size(75, 40);
            btnInserir.TabIndex = 0;
            btnInserir.Text = "Gravar";
            btnInserir.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(276, 162);
            button2.Name = "button2";
            button2.Size = new Size(75, 40);
            button2.TabIndex = 1;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 56);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 2;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 93);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 3;
            label2.Text = "Admissão:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 135);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 4;
            label3.Text = "Salario:";
            // 
            // txt_Nome
            // 
            txt_Nome.Location = new Point(85, 53);
            txt_Nome.Name = "txt_Nome";
            txt_Nome.Size = new Size(172, 23);
            txt_Nome.TabIndex = 5;
            // 
            // txt_dataAdmissao
            // 
            txt_dataAdmissao.Location = new Point(85, 90);
            txt_dataAdmissao.Name = "txt_dataAdmissao";
            txt_dataAdmissao.Size = new Size(100, 23);
            txt_dataAdmissao.TabIndex = 6;
            // 
            // txt_Salario
            // 
            txt_Salario.Location = new Point(85, 132);
            txt_Salario.Name = "txt_Salario";
            txt_Salario.Size = new Size(109, 23);
            txt_Salario.TabIndex = 7;
            // 
            // TelaFuncionarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 214);
            Controls.Add(txt_Salario);
            Controls.Add(txt_dataAdmissao);
            Controls.Add(txt_Nome);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(btnInserir);
            Name = "TelaFuncionarioForm";
            Text = "TelaFuncionarioForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInserir;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txt_Nome;
        private TextBox txt_dataAdmissao;
        private TextBox txt_Salario;
    }
}