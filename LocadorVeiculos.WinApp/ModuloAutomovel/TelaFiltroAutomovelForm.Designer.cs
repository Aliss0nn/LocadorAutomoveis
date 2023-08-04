namespace LocadorAutomoveis.WinApp.ModuloAutomovel
{
    partial class TelaFiltroAutomovelForm
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
            label7 = new Label();
            cmbGrupo = new ComboBox();
            btnCancelar = new Button();
            btnSelecionar = new Button();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(59, 9);
            label7.Name = "label7";
            label7.Size = new Size(200, 15);
            label7.TabIndex = 31;
            label7.Text = "Selecione um Grupo de Automóveis:";
            // 
            // cmbGrupo
            // 
            cmbGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupo.FormattingEnabled = true;
            cmbGrupo.Location = new Point(36, 39);
            cmbGrupo.Name = "cmbGrupo";
            cmbGrupo.Size = new Size(253, 23);
            cmbGrupo.TabIndex = 30;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(235, 80);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 29;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSelecionar
            // 
            btnSelecionar.DialogResult = DialogResult.OK;
            btnSelecionar.Location = new Point(154, 80);
            btnSelecionar.Name = "btnSelecionar";
            btnSelecionar.Size = new Size(75, 45);
            btnSelecionar.TabIndex = 28;
            btnSelecionar.Text = "Selecionar";
            btnSelecionar.UseVisualStyleBackColor = true;
            btnSelecionar.Click += btnGravar_Click;
            // 
            // TelaFiltroAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 137);
            Controls.Add(label7);
            Controls.Add(cmbGrupo);
            Controls.Add(btnCancelar);
            Controls.Add(btnSelecionar);
            Name = "TelaFiltroAutomovelForm";
            Text = "Filtro de Aluguéis";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private ComboBox cmbGrupo;
        private Button btnCancelar;
        private Button btnSelecionar;
    }
}