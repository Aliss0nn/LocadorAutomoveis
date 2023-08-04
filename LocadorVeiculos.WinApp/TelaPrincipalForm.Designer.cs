using System;

namespace LocadorAutomoveis.WinApp
{
    partial class TelaPrincipalForm
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
            menu = new MenuStrip();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            taxasEServiçosToolStripMenuItem = new ToolStripMenuItem();
            gruposDeAutomóveisToolStripMenuItem = new ToolStripMenuItem();
            parceirosToolStripMenuItem = new ToolStripMenuItem();
            funcionáriosToolStripMenuItem = new ToolStripMenuItem();
            planosDeCobrançaToolStripMenuItem = new ToolStripMenuItem();
            cupomToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            automóveisToolStripMenuItem = new ToolStripMenuItem();
            toolbox = new ToolStrip();
            btnInserir = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnFiltrar = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator4 = new ToolStripSeparator();
            labelTipoCadastro = new ToolStripLabel();
            statusStrip1 = new StatusStrip();
            labelRodape = new ToolStripStatusLabel();
            panelRegistros = new Panel();
            menu.SuspendLayout();
            toolbox.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(686, 24);
            menu.TabIndex = 0;
            menu.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { taxasEServiçosToolStripMenuItem, gruposDeAutomóveisToolStripMenuItem, parceirosToolStripMenuItem, funcionáriosToolStripMenuItem, planosDeCobrançaToolStripMenuItem, cupomToolStripMenuItem, clientesToolStripMenuItem, automóveisToolStripMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(71, 20);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // taxasEServiçosToolStripMenuItem
            // 
            taxasEServiçosToolStripMenuItem.Name = "taxasEServiçosToolStripMenuItem";
            taxasEServiçosToolStripMenuItem.Size = new Size(196, 22);
            taxasEServiçosToolStripMenuItem.Text = "Taxas e Serviços";
            taxasEServiçosToolStripMenuItem.Click += taxasEServiçosToolStripMenuItem_Click;
            // 
            // gruposDeAutomóveisToolStripMenuItem
            // 
            gruposDeAutomóveisToolStripMenuItem.Name = "gruposDeAutomóveisToolStripMenuItem";
            gruposDeAutomóveisToolStripMenuItem.Size = new Size(196, 22);
            gruposDeAutomóveisToolStripMenuItem.Text = "Grupos De Automóveis";
            gruposDeAutomóveisToolStripMenuItem.Click += gruposDeAutomóveisToolStripMenuItem_Click;
            // 
            // parceirosToolStripMenuItem
            // 
            parceirosToolStripMenuItem.Name = "parceirosToolStripMenuItem";
            parceirosToolStripMenuItem.Size = new Size(196, 22);
            parceirosToolStripMenuItem.Text = "Parceiros";
            parceirosToolStripMenuItem.Click += parceirosToolStripMenuItem_Click;
            // 
            // funcionáriosToolStripMenuItem
            // 
            funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            funcionáriosToolStripMenuItem.Size = new Size(196, 22);
            funcionáriosToolStripMenuItem.Text = "Funcionários";
            funcionáriosToolStripMenuItem.Click += funcionáriosToolStripMenuItem_Click;
            // 
            // planosDeCobrançaToolStripMenuItem
            // 
            planosDeCobrançaToolStripMenuItem.Name = "planosDeCobrançaToolStripMenuItem";
            planosDeCobrançaToolStripMenuItem.Size = new Size(196, 22);
            planosDeCobrançaToolStripMenuItem.Text = "Planos de Cobrança";
            planosDeCobrançaToolStripMenuItem.Click += planosDeCobrançaToolStripMenuItem_Click;
            // 
            // cupomToolStripMenuItem
            // 
            cupomToolStripMenuItem.Name = "cupomToolStripMenuItem";
            cupomToolStripMenuItem.Size = new Size(196, 22);
            cupomToolStripMenuItem.Text = "Cupom";
            cupomToolStripMenuItem.Click += cupomToolStripMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(196, 22);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // automóveisToolStripMenuItem
            // 
            automóveisToolStripMenuItem.Name = "automóveisToolStripMenuItem";
            automóveisToolStripMenuItem.Size = new Size(196, 22);
            automóveisToolStripMenuItem.Text = "Automóveis";
            automóveisToolStripMenuItem.Click += automóveisToolStripMenuItem_Click;
            // 
            // toolbox
            // 
            toolbox.Enabled = false;
            toolbox.ImageScalingSize = new Size(20, 20);
            toolbox.Items.AddRange(new ToolStripItem[] { btnInserir, btnEditar, btnExcluir, toolStripSeparator2, btnFiltrar, toolStripSeparator3, toolStripSeparator1, toolStripSeparator4, labelTipoCadastro });
            toolbox.Location = new Point(0, 24);
            toolbox.Name = "toolbox";
            toolbox.Size = new Size(686, 41);
            toolbox.TabIndex = 1;
            toolbox.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            btnInserir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnInserir.Image = Properties.Resources.outline_add_circle_outline_black_24dp;
            btnInserir.ImageScaling = ToolStripItemImageScaling.None;
            btnInserir.ImageTransparentColor = Color.Magenta;
            btnInserir.Name = "btnInserir";
            btnInserir.Padding = new Padding(5);
            btnInserir.Size = new Size(38, 38);
            btnInserir.Text = "Adicionar";
            btnInserir.Click += btnInserir_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Image = Properties.Resources.outline_mode_edit_black_24dp;
            btnEditar.ImageScaling = ToolStripItemImageScaling.None;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new Padding(5);
            btnEditar.Size = new Size(38, 38);
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExcluir.Image = Properties.Resources.outline_delete_black_24dp;
            btnExcluir.ImageScaling = ToolStripItemImageScaling.None;
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new Padding(5);
            btnExcluir.Size = new Size(38, 38);
            btnExcluir.Text = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 41);
            // 
            // btnFiltrar
            // 
            btnFiltrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFiltrar.Image = Properties.Resources.outline_filter_alt_black_24dp;
            btnFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            btnFiltrar.ImageTransparentColor = Color.Magenta;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Padding = new Padding(5);
            btnFiltrar.Size = new Size(38, 38);
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 41);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 41);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 41);
            // 
            // labelTipoCadastro
            // 
            labelTipoCadastro.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelTipoCadastro.Name = "labelTipoCadastro";
            labelTipoCadastro.Size = new Size(90, 38);
            labelTipoCadastro.Text = "[tipoCadastro]";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelRodape });
            statusStrip1.Location = new Point(0, 399);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(686, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            labelRodape.Name = "labelRodape";
            labelRodape.Size = new Size(52, 17);
            labelRodape.Text = "[rodapé]";
            // 
            // panelRegistros
            // 
            panelRegistros.Dock = DockStyle.Fill;
            panelRegistros.Location = new Point(0, 65);
            panelRegistros.Name = "panelRegistros";
            panelRegistros.Size = new Size(686, 334);
            panelRegistros.TabIndex = 3;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 421);
            Controls.Add(panelRegistros);
            Controls.Add(statusStrip1);
            Controls.Add(toolbox);
            Controls.Add(menu);
            MainMenuStrip = menu;
            MinimumSize = new Size(702, 458);
            Name = "TelaPrincipalForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Locador Automóveis";
            WindowState = FormWindowState.Maximized;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            toolbox.ResumeLayout(false);
            toolbox.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStrip toolbox;
        private StatusStrip statusStrip1;
        private Panel panelRegistros;
        private ToolStripButton btnInserir;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private ToolStripStatusLabel labelRodape;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel labelTipoCadastro;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem gruposDeAutomóveisToolStripMenuItem;
        private ToolStripMenuItem parceirosToolStripMenuItem;
        private ToolStripMenuItem funcionáriosToolStripMenuItem;
        private ToolStripMenuItem taxasEServiçosToolStripMenuItem;
        private ToolStripMenuItem planosDeCobrançaToolStripMenuItem;
        private ToolStripMenuItem cupomToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem automóveisToolStripMenuItem;
        private ToolStripButton btnFiltrar;
    }
}
