namespace LocadorAutomoveis.WinApp.ModuloTaxasEServicos
{
    partial class TabelaTaxaServicoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridTaxaServico = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridTaxaServico).BeginInit();
            SuspendLayout();
            // 
            // gridTaxaServico
            // 
            gridTaxaServico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTaxaServico.Dock = DockStyle.Fill;
            gridTaxaServico.Location = new Point(0, 0);
            gridTaxaServico.Name = "gridTaxaServico";
            gridTaxaServico.RowTemplate.Height = 25;
            gridTaxaServico.Size = new Size(291, 248);
            gridTaxaServico.TabIndex = 0;
            // 
            // TabelaTaxaServicoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridTaxaServico);
            Name = "TabelaTaxaServicoControl";
            Size = new Size(291, 248);
            ((System.ComponentModel.ISupportInitialize)gridTaxaServico).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridTaxaServico;
    }
}
