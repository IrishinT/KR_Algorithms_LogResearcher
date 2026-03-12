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
            System.Windows.Forms.DataVisualization.Charting.ChartArea trafficChartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series trafficSeries = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea statusCodesChartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend statusCodesLegend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series statusCodesSeries = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            tabControl = new TabControl();
            tabOverview = new TabPage();
            overviewLayout = new TableLayoutPanel();
            panelCards = new TableLayoutPanel();
            chartTraffic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            statsPanel = new TableLayoutPanel();
            lblTopIPs = new Label();
            dgvTopIPs = new DataGridView();
            colIP = new DataGridViewTextBoxColumn();
            colIpCount = new DataGridViewTextBoxColumn();
            colIpPercent = new DataGridViewTextBoxColumn();
            lblStatusCodes = new Label();
            tabIPs = new TabPage();
            tabPages = new TabPage();
            tabErrors = new TabPage();
            tabSecurity = new TabPage();
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
            chartStatusCodes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            mainContentPanel.SuspendLayout();
            tabControl.SuspendLayout();
            tabOverview.SuspendLayout();
            overviewLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartTraffic).BeginInit();
            statsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopIPs).BeginInit();
            panelSettings.SuspendLayout();
            tableLayoutPanelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numThreshold).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartStatusCodes).BeginInit();
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
            tabOverview.Controls.Add(overviewLayout);
            tabOverview.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tabOverview.Location = new Point(4, 24);
            tabOverview.Name = "tabOverview";
            tabOverview.Padding = new Padding(3);
            tabOverview.Size = new Size(1016, 414);
            tabOverview.TabIndex = 0;
            tabOverview.Text = "📊 Обзор";
            tabOverview.UseVisualStyleBackColor = true;
            // 
            // overviewLayout
            // 
            overviewLayout.ColumnCount = 1;
            overviewLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            overviewLayout.Controls.Add(panelCards, 0, 0);
            overviewLayout.Controls.Add(chartTraffic, 0, 1);
            overviewLayout.Controls.Add(statsPanel, 0, 2);
            overviewLayout.Dock = DockStyle.Fill;
            overviewLayout.Location = new Point(3, 3);
            overviewLayout.Name = "overviewLayout";
            overviewLayout.RowCount = 3;
            overviewLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            overviewLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            overviewLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            overviewLayout.Size = new Size(1010, 408);
            overviewLayout.TabIndex = 0;
            // 
            // panelCards
            // 
            panelCards.ColumnCount = 4;
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelCards.Dock = DockStyle.Fill;
            panelCards.Location = new Point(3, 3);
            panelCards.Name = "panelCards";
            panelCards.RowCount = 1;
            panelCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelCards.Size = new Size(1004, 94);
            panelCards.TabIndex = 0;
            // 
            // chartTraffic
            // 
            chartTraffic.BorderlineColor = Color.FromArgb(200, 200, 200);
            chartTraffic.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            trafficChartArea.AxisX.Interval = 3D;
            trafficChartArea.AxisX.Title = "Время (часы)";
            trafficChartArea.AxisY.Title = "Запросов";
            trafficChartArea.Name = "MainArea";
            chartTraffic.ChartAreas.Add(trafficChartArea);
            chartTraffic.Dock = DockStyle.Fill;
            chartTraffic.Location = new Point(3, 103);
            chartTraffic.Name = "chartTraffic";
            trafficSeries.BorderWidth = 2;
            trafficSeries.ChartArea = "MainArea";
            trafficSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            trafficSeries.Color = Color.FromArgb(0, 102, 204);
            trafficSeries.Name = "Трафик";
            chartTraffic.Series.Add(trafficSeries);
            chartTraffic.Size = new Size(1004, 163);
            chartTraffic.TabIndex = 1;
            // 
            // statsPanel
            // 
            statsPanel.ColumnCount = 2;
            statsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            statsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            statsPanel.Controls.Add(lblTopIPs, 0, 0);
            statsPanel.Controls.Add(dgvTopIPs, 0, 1);
            statsPanel.Controls.Add(lblStatusCodes, 1, 0);
            statsPanel.Controls.Add(chartStatusCodes, 1, 1);
            statsPanel.Dock = DockStyle.Fill;
            statsPanel.Location = new Point(3, 272);
            statsPanel.Name = "statsPanel";
            statsPanel.RowCount = 2;
            statsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            statsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            statsPanel.Size = new Size(1004, 133);
            statsPanel.TabIndex = 2;
            // 
            // lblTopIPs
            // 
            lblTopIPs.AutoSize = true;
            lblTopIPs.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTopIPs.Location = new Point(3, 0);
            lblTopIPs.Name = "lblTopIPs";
            lblTopIPs.Size = new Size(87, 15);
            lblTopIPs.TabIndex = 0;
            lblTopIPs.Text = "Топ IP адресов";
            // 
            // dgvTopIPs
            // 
            dgvTopIPs.AllowUserToAddRows = false;
            dgvTopIPs.AllowUserToDeleteRows = false;
            dgvTopIPs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopIPs.BackgroundColor = Color.White;
            dgvTopIPs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopIPs.Columns.AddRange(new DataGridViewColumn[] { colIP, colIpCount, colIpPercent });
            dgvTopIPs.Dock = DockStyle.Fill;
            dgvTopIPs.Location = new Point(3, 22);
            dgvTopIPs.Name = "dgvTopIPs";
            dgvTopIPs.ReadOnly = true;
            dgvTopIPs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopIPs.Size = new Size(596, 108);
            dgvTopIPs.TabIndex = 1;
            // 
            // colIP
            // 
            colIP.HeaderText = "IP адрес";
            colIP.Name = "colIP";
            colIP.ReadOnly = true;
            // 
            // colIpCount
            // 
            colIpCount.HeaderText = "Запросов";
            colIpCount.Name = "colIpCount";
            colIpCount.ReadOnly = true;
            // 
            // colIpPercent
            // 
            colIpPercent.HeaderText = "%";
            colIpPercent.Name = "colIpPercent";
            colIpPercent.ReadOnly = true;
            // 
            // lblStatusCodes
            // 
            lblStatusCodes.AutoSize = true;
            lblStatusCodes.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblStatusCodes.Location = new Point(605, 0);
            lblStatusCodes.Name = "lblStatusCodes";
            lblStatusCodes.Size = new Size(74, 15);
            lblStatusCodes.TabIndex = 2;
            lblStatusCodes.Text = "Коды ответа";
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
            // chartStatusCodes
            // 
            chartStatusCodes.Dock = DockStyle.Fill;
            chartStatusCodes.BackColor = Color.White;
            chartStatusCodes.BorderlineColor = Color.FromArgb(200, 200, 200);
            chartStatusCodes.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartStatusCodes.BorderlineWidth = 1;

            statusCodesChartArea.Name = "statusCodesChartArea";
            chartStatusCodes.ChartAreas.Add(statusCodesChartArea);
            statusCodesLegend.Name = "Legend1";
            chartStatusCodes.Legends.Add(statusCodesLegend);
            chartStatusCodes.Location = new Point(605, 22);
            chartStatusCodes.Name = "chartStatusCodes";
            statusCodesSeries.ChartArea = "statusCodesChartArea";
            statusCodesSeries["PieLabelStyle"] = "Outside";
            statusCodesSeries["PieLineColor"] = "Black";
            statusCodesSeries.Name = "Коды";
            chartStatusCodes.Series.Add(statusCodesSeries);
            chartStatusCodes.Size = new Size(300, 108);
            chartStatusCodes.TabIndex = 3;
            chartStatusCodes.Text = "chart1";
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
            tabControl.ResumeLayout(false);
            tabOverview.ResumeLayout(false);
            overviewLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartTraffic).EndInit();
            statsPanel.ResumeLayout(false);
            statsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopIPs).EndInit();
            panelSettings.ResumeLayout(false);
            tableLayoutPanelSettings.ResumeLayout(false);
            tableLayoutPanelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numThreshold).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartStatusCodes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel CreateStatCard(string title, string value, Color color)
        {
            var panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Padding = new Padding(10);
            panel.Margin = new Padding(3);

            var lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblTitle.ForeColor = Color.FromArgb(80, 80, 80);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(10, 10);
            lblTitle.Dock = DockStyle.Top;

            var lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblValue.ForeColor = color;
            lblValue.AutoSize = true;
            lblValue.Location = new Point(10, 35);
            lblValue.Dock = DockStyle.Top;

            panel.Controls.Add(lblValue);
            panel.Controls.Add(lblTitle);

            return panel;
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
        private TableLayoutPanel overviewLayout;
        private TableLayoutPanel panelCards;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTraffic;
        private TableLayoutPanel statsPanel;
        private Label lblTopIPs;
        private DataGridView dgvTopIPs;
        private DataGridViewTextBoxColumn colIP;
        private DataGridViewTextBoxColumn colIpCount;
        private DataGridViewTextBoxColumn colIpPercent;
        private Label lblStatusCodes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatusCodes;
    }
}