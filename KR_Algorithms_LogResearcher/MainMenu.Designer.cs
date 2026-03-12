namespace KR_Algorithms_LogResearcher
{
    partial class MainMenu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            openSubMenuItem = new ToolStripMenuItem();
            exportSubMenuItem = new ToolStripMenuItem();
            separator1 = new ToolStripSeparator();
            exitSubMenuItem = new ToolStripMenuItem();
            helpMenu = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            btnOpenTool = new ToolStripButton();
            btnAnalyzeTool = new ToolStripButton();
            btnExportTool = new ToolStripButton();
            mainContentPanel = new Panel();
            panelSettings = new Panel();
            tableLayoutPanelSettings = new TableLayoutPanel();
            lblFileLabel = new Label();
            txtFilePath = new TextBox();
            lblThreshold = new Label();
            numThreshold = new NumericUpDown();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            progressBar = new ToolStripProgressBar();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            tabControl = new TabControl();
            tabOverview = new TabPage();
            tabIPs = new TabPage();
            tabPages = new TabPage();
            tabErrors = new TabPage();
            tabSecurity = new TabPage();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            mainContentPanel.SuspendLayout();
            panelSettings.SuspendLayout();
            tableLayoutPanelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numThreshold).BeginInit();
            statusStrip1.SuspendLayout();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenu, helpMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1024, 24);
            menuStrip1.TabIndex = 4;
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { openSubMenuItem, exportSubMenuItem, separator1, exitSubMenuItem });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(48, 20);
            fileMenu.Text = "&Файл";
            // 
            // openSubMenuItem
            // 
            openSubMenuItem.Name = "openSubMenuItem";
            openSubMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openSubMenuItem.Size = new Size(173, 22);
            openSubMenuItem.Text = "&Открыть...";
            openSubMenuItem.Click += openSubMenuItem_Click;
            // 
            // exportSubMenuItem
            // 
            exportSubMenuItem.Enabled = false;
            exportSubMenuItem.Name = "exportSubMenuItem";
            exportSubMenuItem.Size = new Size(173, 22);
            exportSubMenuItem.Text = "&Экспорт отчета...";
            // 
            // separator1
            // 
            separator1.Name = "separator1";
            separator1.Size = new Size(170, 6);
            // 
            // exitSubMenuItem
            // 
            exitSubMenuItem.Name = "exitSubMenuItem";
            exitSubMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitSubMenuItem.Size = new Size(173, 22);
            exitSubMenuItem.Text = "В&ыход";
            // 
            // helpMenu
            // 
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(65, 20);
            helpMenu.Text = "Справка";
            helpMenu.Click += helpMenu_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnOpenTool, btnAnalyzeTool, btnExportTool });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1024, 32);
            toolStrip1.TabIndex = 3;
            // 
            // btnOpenTool
            // 
            btnOpenTool.BackColor = Color.White;
            btnOpenTool.Font = new Font("Segoe UI", 9F);
            btnOpenTool.ForeColor = Color.FromArgb(48, 48, 48);
            btnOpenTool.Margin = new Padding(0, 0, 5, 0);
            btnOpenTool.Name = "btnOpenTool";
            btnOpenTool.Padding = new Padding(10, 5, 10, 5);
            btnOpenTool.Size = new Size(93, 32);
            btnOpenTool.Text = "📂 Открыть";
            btnOpenTool.Click += btnOpenTool_Click;
            // 
            // btnAnalyzeTool
            // 
            btnAnalyzeTool.BackColor = Color.FromArgb(0, 120, 215);
            btnAnalyzeTool.Enabled = false;
            btnAnalyzeTool.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAnalyzeTool.ForeColor = Color.White;
            btnAnalyzeTool.Margin = new Padding(5, 0, 10, 0);
            btnAnalyzeTool.Name = "btnAnalyzeTool";
            btnAnalyzeTool.Padding = new Padding(15, 5, 15, 5);
            btnAnalyzeTool.Size = new Size(97, 32);
            btnAnalyzeTool.Text = "▶ Анализ";
            // 
            // btnExportTool
            // 
            btnExportTool.BackColor = Color.White;
            btnExportTool.Enabled = false;
            btnExportTool.Font = new Font("Segoe UI", 9F);
            btnExportTool.ForeColor = Color.FromArgb(48, 48, 48);
            btnExportTool.Name = "btnExportTool";
            btnExportTool.Padding = new Padding(10, 5, 10, 5);
            btnExportTool.Size = new Size(91, 29);
            btnExportTool.Text = "💾 Экспорт";
            // 
            // mainContentPanel
            // 
            mainContentPanel.BackColor = Color.White;
            mainContentPanel.Controls.Add(tabControl);
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(0, 106);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(1024, 442);
            mainContentPanel.TabIndex = 1;
            // 
            // panelSettings
            // 
            panelSettings.BackColor = Color.FromArgb(250, 250, 250);
            panelSettings.Controls.Add(tableLayoutPanelSettings);
            panelSettings.Dock = DockStyle.Top;
            panelSettings.Location = new Point(0, 56);
            panelSettings.MinimumSize = new Size(0, 50);
            panelSettings.Name = "panelSettings";
            panelSettings.Padding = new Padding(10, 8, 10, 8);
            panelSettings.Size = new Size(1024, 50);
            panelSettings.TabIndex = 2;
            // 
            // tableLayoutPanelSettings
            // 
            tableLayoutPanelSettings.ColumnCount = 4;
            tableLayoutPanelSettings.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelSettings.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanelSettings.Controls.Add(lblFileLabel, 0, 0);
            tableLayoutPanelSettings.Controls.Add(txtFilePath, 1, 0);
            tableLayoutPanelSettings.Controls.Add(lblThreshold, 2, 0);
            tableLayoutPanelSettings.Controls.Add(numThreshold, 3, 0);
            tableLayoutPanelSettings.Dock = DockStyle.Fill;
            tableLayoutPanelSettings.Location = new Point(10, 8);
            tableLayoutPanelSettings.Name = "tableLayoutPanelSettings";
            tableLayoutPanelSettings.RowCount = 1;
            tableLayoutPanelSettings.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanelSettings.Size = new Size(1004, 34);
            tableLayoutPanelSettings.TabIndex = 0;
            // 
            // lblFileLabel
            // 
            lblFileLabel.Anchor = AnchorStyles.Left;
            lblFileLabel.AutoSize = true;
            lblFileLabel.Location = new Point(3, 9);
            lblFileLabel.Name = "lblFileLabel";
            lblFileLabel.Size = new Size(39, 15);
            lblFileLabel.TabIndex = 0;
            lblFileLabel.Text = "Файл:";
            // 
            // txtFilePath
            // 
            txtFilePath.Anchor = AnchorStyles.Left;
            txtFilePath.BackColor = Color.White;
            txtFilePath.BorderStyle = BorderStyle.FixedSingle;
            txtFilePath.Enabled = false;
            txtFilePath.ForeColor = Color.Gray;
            txtFilePath.Location = new Point(50, 5);
            txtFilePath.Margin = new Padding(5, 0, 5, 0);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(789, 23);
            txtFilePath.TabIndex = 1;
            txtFilePath.Text = "Файл не выбран";
            // 
            // lblThreshold
            // 
            lblThreshold.Anchor = AnchorStyles.Right;
            lblThreshold.AutoSize = true;
            lblThreshold.Location = new Point(874, 9);
            lblThreshold.Margin = new Padding(10, 0, 5, 0);
            lblThreshold.Name = "lblThreshold";
            lblThreshold.Size = new Size(45, 15);
            lblThreshold.TabIndex = 2;
            lblThreshold.Text = "Порог:";
            // 
            // numThreshold
            // 
            numThreshold.Anchor = AnchorStyles.Right;
            numThreshold.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            numThreshold.Location = new Point(927, 5);
            numThreshold.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numThreshold.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            numThreshold.Name = "numThreshold";
            numThreshold.Size = new Size(74, 23);
            numThreshold.TabIndex = 3;
            numThreshold.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, progressBar });
            statusStrip1.Location = new Point(0, 526);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1024, 22);
            statusStrip1.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1009, 17);
            lblStatus.Spring = true;
            lblStatus.Text = "Готов к работе";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(200, 18);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Visible = false;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabOverview);
            tabControl.Controls.Add(tabIPs);
            tabControl.Controls.Add(tabPages);
            tabControl.Controls.Add(tabErrors);
            tabControl.Controls.Add(tabSecurity);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1024, 442);
            tabControl.TabIndex = 0;
            // 
            // tabOverview
            // 
            tabOverview.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tabOverview.Location = new Point(4, 24);
            tabOverview.Name = "tabOverview";
            tabOverview.Padding = new Padding(3);
            tabOverview.Size = new Size(1016, 414);
            tabOverview.TabIndex = 0;
            tabOverview.Text = "📊 Обзор";
            tabOverview.UseVisualStyleBackColor = true;
            // 
            // tabIPs
            // 
            tabIPs.Location = new Point(4, 24);
            tabIPs.Name = "tabIPs";
            tabIPs.Padding = new Padding(3);
            tabIPs.Size = new Size(1016, 414);
            tabIPs.TabIndex = 1;
            tabIPs.Text = "IP адреса";
            tabIPs.UseVisualStyleBackColor = true;
            // 
            // tabPages
            // 
            tabPages.Location = new Point(4, 24);
            tabPages.Name = "tabPages";
            tabPages.Padding = new Padding(3);
            tabPages.Size = new Size(1016, 414);
            tabPages.TabIndex = 2;
            tabPages.Text = "Страницы";
            tabPages.UseVisualStyleBackColor = true;
            // 
            // tabErrors
            // 
            tabErrors.Location = new Point(4, 24);
            tabErrors.Name = "tabErrors";
            tabErrors.Padding = new Padding(3);
            tabErrors.Size = new Size(1016, 414);
            tabErrors.TabIndex = 3;
            tabErrors.Text = "⚠️ Ошибки";
            tabErrors.UseVisualStyleBackColor = true;
            // 
            // tabSecurity
            // 
            tabSecurity.Location = new Point(4, 24);
            tabSecurity.Name = "tabSecurity";
            tabSecurity.Padding = new Padding(3);
            tabSecurity.Size = new Size(1016, 414);
            tabSecurity.TabIndex = 4;
            tabSecurity.Text = "🔒 Безопасность";
            tabSecurity.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            ClientSize = new Size(1024, 548);
            Controls.Add(statusStrip1);
            Controls.Add(mainContentPanel);
            Controls.Add(panelSettings);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(800, 500);
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Log Analyzer - Анализ логов веб-сайта";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            mainContentPanel.ResumeLayout(false);
            panelSettings.ResumeLayout(false);
            tableLayoutPanelSettings.ResumeLayout(false);
            tableLayoutPanelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numThreshold).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // === МЕНЮ ===
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem openSubMenuItem;
        private ToolStripMenuItem exportSubMenuItem;
        private ToolStripSeparator separator1;
        private ToolStripMenuItem exitSubMenuItem;

        // === TOOLSTRIP ===
        private ToolStrip toolStrip1;
        private ToolStripButton btnOpenTool;
        private ToolStripButton btnAnalyzeTool;
        private ToolStripButton btnExportTool;

        // === КОНТЕЙНЕРЫ ===
        private Panel mainContentPanel;          // ← для контента (растягивается)
        private Panel panelSettings;
        private TableLayoutPanel tableLayoutPanelSettings;  // ← адаптивная сетка

        // === НАСТРОЙКИ ===
        private Label lblFileLabel;
        private TextBox txtFilePath;             // ← теперь растягивается!
        private Label lblThreshold;
        private NumericUpDown numThreshold;

        // === STATUS ===
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripProgressBar progressBar;

        // === DIALOGS ===
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem helpMenu;
        private TabControl tabControl;
        private TabPage tabOverview;
        private TabPage tabIPs;
        private TabPage tabPages;
        private TabPage tabErrors;
        private TabPage tabSecurity;
    }
}