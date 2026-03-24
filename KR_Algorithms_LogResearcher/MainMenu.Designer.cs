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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            menuStrip1 = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            openSubMenuItem = new ToolStripMenuItem();
            separator1 = new ToolStripSeparator();
            exitSubMenuItem = new ToolStripMenuItem();
            helpMenu = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            btnOpenTool = new ToolStripButton();
            btnAnalyzeTool = new ToolStripButton();
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
            chartStatusCodes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tabIPs = new TabPage();
            ipPanel = new TableLayoutPanel();
            searchExportPanel = new TableLayoutPanel();
            txtSearchIP = new TextBox();
            btnExportCSV = new Button();
            dgvIPAddresses = new DataGridView();
            colIPAddress = new DataGridViewTextBoxColumn();
            colRequests = new DataGridViewTextBoxColumn();
            colPercent = new DataGridViewTextBoxColumn();
            colFirstSeen = new DataGridViewTextBoxColumn();
            colLastSeen = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            tabPages = new TabPage();
            pagesPanel = new TableLayoutPanel();
            pagesSearchPanel = new TableLayoutPanel();
            txtSearchPage = new TextBox();
            btnExportPages = new Button();
            dgvPages = new DataGridView();
            colPageUrl = new DataGridViewTextBoxColumn();
            colPageRequests = new DataGridViewTextBoxColumn();
            colPagePercent = new DataGridViewTextBoxColumn();
            colPageFirst = new DataGridViewTextBoxColumn();
            colPageLast = new DataGridViewTextBoxColumn();
            colPageStatus = new DataGridViewTextBoxColumn();
            tabErrors = new TabPage();
            errorsPanel = new TableLayoutPanel();
            errorsSearchPanel = new TableLayoutPanel();
            txtSearchError = new TextBox();
            btnExportErrors = new Button();
            dgvErrors = new DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colErrorUrl = new DataGridViewTextBoxColumn();
            colErrorCode = new DataGridViewTextBoxColumn();
            colIPError = new DataGridViewTextBoxColumn();
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
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            mainContentPanel.SuspendLayout();
            tabControl.SuspendLayout();
            tabOverview.SuspendLayout();
            overviewLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartTraffic).BeginInit();
            statsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopIPs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartStatusCodes).BeginInit();
            tabIPs.SuspendLayout();
            ipPanel.SuspendLayout();
            searchExportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIPAddresses).BeginInit();
            tabPages.SuspendLayout();
            pagesPanel.SuspendLayout();
            pagesSearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPages).BeginInit();
            tabErrors.SuspendLayout();
            errorsPanel.SuspendLayout();
            errorsSearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvErrors).BeginInit();
            panelSettings.SuspendLayout();
            tableLayoutPanelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numThreshold).BeginInit();
            statusStrip1.SuspendLayout();
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
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { openSubMenuItem, separator1, exitSubMenuItem });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(48, 20);
            fileMenu.Text = "&Файл";
            // 
            // openSubMenuItem
            // 
            openSubMenuItem.Name = "openSubMenuItem";
            openSubMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openSubMenuItem.Size = new Size(180, 22);
            openSubMenuItem.Text = "&Открыть...";
            // 
            // separator1
            // 
            separator1.Name = "separator1";
            separator1.Size = new Size(177, 6);
            // 
            // exitSubMenuItem
            // 
            exitSubMenuItem.Name = "exitSubMenuItem";
            exitSubMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitSubMenuItem.Size = new Size(180, 22);
            exitSubMenuItem.Text = "В&ыход";
            // 
            // helpMenu
            // 
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(65, 20);
            helpMenu.Text = "Справка";
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnOpenTool, btnAnalyzeTool });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1024, 29);
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
            btnOpenTool.Size = new Size(93, 29);
            btnOpenTool.Text = "📂 Открыть";
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
            btnAnalyzeTool.Size = new Size(97, 29);
            btnAnalyzeTool.Text = "▶ Анализ";
            // 
            // mainContentPanel
            // 
            mainContentPanel.BackColor = Color.White;
            mainContentPanel.Controls.Add(tabControl);
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(0, 103);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(1024, 445);
            mainContentPanel.TabIndex = 1;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabOverview);
            tabControl.Controls.Add(tabIPs);
            tabControl.Controls.Add(tabPages);
            tabControl.Controls.Add(tabErrors);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1024, 445);
            tabControl.TabIndex = 0;
            // 
            // tabOverview
            // 
            tabOverview.Controls.Add(overviewLayout);
            tabOverview.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tabOverview.Location = new Point(4, 24);
            tabOverview.Name = "tabOverview";
            tabOverview.Padding = new Padding(3);
            tabOverview.Size = new Size(1016, 417);
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
            overviewLayout.Size = new Size(1010, 411);
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
            chartArea1.AxisX.Interval = 3D;
            chartArea1.AxisX.Title = "Время (часы)";
            chartArea1.AxisY.Title = "Запросов";
            chartArea1.Name = "MainArea";
            chartTraffic.ChartAreas.Add(chartArea1);
            chartTraffic.Dock = DockStyle.Fill;
            chartTraffic.Location = new Point(3, 103);
            chartTraffic.Name = "chartTraffic";
            series1.BorderWidth = 2;
            series1.ChartArea = "MainArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = Color.FromArgb(0, 102, 204);
            series1.Name = "Трафик";
            chartTraffic.Series.Add(series1);
            chartTraffic.Size = new Size(1004, 165);
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
            statsPanel.Location = new Point(3, 274);
            statsPanel.Name = "statsPanel";
            statsPanel.RowCount = 2;
            statsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            statsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            statsPanel.Size = new Size(1004, 134);
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
            dgvTopIPs.BorderStyle = BorderStyle.None;
            dgvTopIPs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTopIPs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTopIPs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopIPs.Columns.AddRange(new DataGridViewColumn[] { colIP, colIpCount, colIpPercent });
            dgvTopIPs.Dock = DockStyle.Fill;
            dgvTopIPs.EnableHeadersVisualStyles = false;
            dgvTopIPs.GridColor = Color.FromArgb(230, 230, 230);
            dgvTopIPs.Location = new Point(3, 23);
            dgvTopIPs.Name = "dgvTopIPs";
            dgvTopIPs.ReadOnly = true;
            dgvTopIPs.RowHeadersVisible = false;
            dgvTopIPs.RowTemplate.Height = 30;
            dgvTopIPs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopIPs.Size = new Size(596, 108);
            dgvTopIPs.TabIndex = 1;
            dgvTopIPs.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 245);
            dgvTopIPs.DefaultCellStyle.SelectionForeColor = Color.Black;
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
            // chartStatusCodes
            // 
            chartStatusCodes.BorderlineColor = Color.FromArgb(200, 200, 200);
            chartStatusCodes.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "statusCodesChartArea";
            chartStatusCodes.ChartAreas.Add(chartArea2);
            chartStatusCodes.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartStatusCodes.Legends.Add(legend1);
            chartStatusCodes.Location = new Point(605, 23);
            chartStatusCodes.Name = "chartStatusCodes";
            series2.ChartArea = "statusCodesChartArea";
            series2.Legend = "Legend1";
            series2.Name = "Коды";
            chartStatusCodes.Series.Add(series2);
            chartStatusCodes.Size = new Size(396, 108);
            chartStatusCodes.TabIndex = 3;
            chartStatusCodes.Text = "chart1";
            // 
            // tabIPs
            // 
            tabIPs.Controls.Add(ipPanel);
            tabIPs.Location = new Point(4, 24);
            tabIPs.Name = "tabIPs";
            tabIPs.Padding = new Padding(3);
            tabIPs.Size = new Size(1016, 414);
            tabIPs.TabIndex = 1;
            tabIPs.Text = "🔍 IP адреса";
            tabIPs.UseVisualStyleBackColor = true;
            // 
            // ipPanel
            // 
            ipPanel.ColumnCount = 1;
            ipPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ipPanel.Controls.Add(searchExportPanel, 0, 0);
            ipPanel.Controls.Add(dgvIPAddresses, 0, 2);
            ipPanel.Dock = DockStyle.Fill;
            ipPanel.Location = new Point(3, 3);
            ipPanel.Name = "ipPanel";
            ipPanel.RowCount = 4;
            ipPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            ipPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            ipPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ipPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            ipPanel.Size = new Size(1010, 408);
            ipPanel.TabIndex = 0;
            // 
            // searchExportPanel
            // 
            searchExportPanel.ColumnCount = 2;
            searchExportPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchExportPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            searchExportPanel.Controls.Add(txtSearchIP, 0, 0);
            searchExportPanel.Controls.Add(btnExportCSV, 1, 0);
            searchExportPanel.Dock = DockStyle.Fill;
            searchExportPanel.Location = new Point(3, 3);
            searchExportPanel.Name = "searchExportPanel";
            searchExportPanel.RowCount = 1;
            searchExportPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            searchExportPanel.Size = new Size(1004, 34);
            searchExportPanel.TabIndex = 0;
            // 
            // txtSearchIP
            // 
            txtSearchIP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearchIP.Font = new Font("Segoe UI", 10F);
            txtSearchIP.Location = new Point(3, 4);
            txtSearchIP.Margin = new Padding(3, 0, 3, 0);
            txtSearchIP.Name = "txtSearchIP";
            txtSearchIP.PlaceholderText = "🔍 Введите IP для поиска...";
            txtSearchIP.Size = new Size(878, 25);
            txtSearchIP.TabIndex = 0;
            // 
            // btnExportCSV
            // 
            btnExportCSV.Anchor = AnchorStyles.Right;
            btnExportCSV.BackColor = Color.White;
            btnExportCSV.Cursor = Cursors.Hand;
            btnExportCSV.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnExportCSV.FlatStyle = FlatStyle.Flat;
            btnExportCSV.Font = new Font("Segoe UI", 9F);
            btnExportCSV.Location = new Point(887, 2);
            btnExportCSV.Margin = new Padding(3, 0, 0, 0);
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new Size(117, 30);
            btnExportCSV.TabIndex = 2;
            btnExportCSV.Text = "📥 Экспорт CSV";
            btnExportCSV.UseVisualStyleBackColor = false;
            // 
            // dgvIPAddresses
            // 
            dgvIPAddresses.AllowUserToAddRows = false;
            dgvIPAddresses.AllowUserToDeleteRows = false;
            dgvIPAddresses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIPAddresses.BackgroundColor = Color.White;
            dgvIPAddresses.BorderStyle = BorderStyle.None;
            dgvIPAddresses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvIPAddresses.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvIPAddresses.ColumnHeadersHeight = 40;
            dgvIPAddresses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvIPAddresses.Columns.AddRange(new DataGridViewColumn[] { colIPAddress, colRequests, colPercent, colFirstSeen, colLastSeen, colStatus });
            dgvIPAddresses.Dock = DockStyle.Fill;
            dgvIPAddresses.EnableHeadersVisualStyles = false;
            dgvIPAddresses.GridColor = Color.FromArgb(230, 230, 230);
            dgvIPAddresses.Location = new Point(3, 53);
            dgvIPAddresses.Name = "dgvIPAddresses";
            dgvIPAddresses.ReadOnly = true;
            dgvIPAddresses.RowHeadersVisible = false;
            dgvIPAddresses.RowTemplate.Height = 35;
            dgvIPAddresses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIPAddresses.Size = new Size(1004, 312);
            dgvIPAddresses.TabIndex = 1;
            dgvIPAddresses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 245);
            dgvIPAddresses.DefaultCellStyle.SelectionForeColor = Color.Black;
            // 
            // colIPAddress
            // 
            colIPAddress.HeaderText = "IP адрес";
            colIPAddress.Name = "colIPAddress";
            colIPAddress.ReadOnly = true;
            // 
            // colRequests
            // 
            colRequests.HeaderText = "Запросов";
            colRequests.Name = "colRequests";
            colRequests.ReadOnly = true;
            // 
            // colPercent
            // 
            colPercent.HeaderText = "%";
            colPercent.Name = "colPercent";
            colPercent.ReadOnly = true;
            // 
            // colFirstSeen
            // 
            colFirstSeen.HeaderText = "Первый";
            colFirstSeen.Name = "colFirstSeen";
            colFirstSeen.ReadOnly = true;
            // 
            // colLastSeen
            // 
            colLastSeen.HeaderText = "Последний";
            colLastSeen.Name = "colLastSeen";
            colLastSeen.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Статус";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // tabPages
            // 
            tabPages.Controls.Add(pagesPanel);
            tabPages.Location = new Point(4, 24);
            tabPages.Name = "tabPages";
            tabPages.Padding = new Padding(3);
            tabPages.Size = new Size(1016, 414);
            tabPages.TabIndex = 2;
            tabPages.Text = "📄 Страницы";
            tabPages.UseVisualStyleBackColor = true;
            // 
            // pagesPanel
            // 
            pagesPanel.ColumnCount = 1;
            pagesPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pagesPanel.Controls.Add(pagesSearchPanel, 0, 0);
            pagesPanel.Controls.Add(dgvPages, 0, 2);
            pagesPanel.Dock = DockStyle.Fill;
            pagesPanel.Location = new Point(3, 3);
            pagesPanel.Name = "pagesPanel";
            pagesPanel.RowCount = 4;
            pagesPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            pagesPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pagesPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pagesPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            pagesPanel.Size = new Size(1010, 408);
            pagesPanel.TabIndex = 0;
            // 
            // pagesSearchPanel
            // 
            pagesSearchPanel.ColumnCount = 2;
            pagesSearchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pagesSearchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            pagesSearchPanel.Controls.Add(txtSearchPage, 0, 0);
            pagesSearchPanel.Controls.Add(btnExportPages, 1, 0);
            pagesSearchPanel.Dock = DockStyle.Fill;
            pagesSearchPanel.Location = new Point(3, 3);
            pagesSearchPanel.Name = "pagesSearchPanel";
            pagesSearchPanel.RowCount = 1;
            pagesSearchPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pagesSearchPanel.Size = new Size(1004, 34);
            pagesSearchPanel.TabIndex = 0;
            // 
            // txtSearchPage
            // 
            txtSearchPage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearchPage.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtSearchPage.Location = new Point(3, 4);
            txtSearchPage.Name = "txtSearchPage";
            txtSearchPage.PlaceholderText = "🔍 Введите страницу для поиска...";
            txtSearchPage.Size = new Size(878, 26);
            txtSearchPage.TabIndex = 0;
            // 
            // btnExportPages
            // 
            btnExportPages.Anchor = AnchorStyles.Right;
            btnExportPages.BackColor = Color.White;
            btnExportPages.Cursor = Cursors.Hand;
            btnExportPages.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnExportPages.FlatStyle = FlatStyle.Flat;
            btnExportPages.Font = new Font("Segoe UI", 9F);
            btnExportPages.Location = new Point(887, 3);
            btnExportPages.Name = "btnExportPages";
            btnExportPages.Size = new Size(114, 28);
            btnExportPages.TabIndex = 2;
            btnExportPages.Text = "📥 Экспорт CSV";
            btnExportPages.UseVisualStyleBackColor = false;
            // 
            // dgvPages
            // 
            dgvPages.AllowUserToAddRows = false;
            dgvPages.AllowUserToDeleteRows = false;
            dgvPages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPages.BackgroundColor = Color.White;
            dgvPages.BorderStyle = BorderStyle.None;
            dgvPages.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPages.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPages.ColumnHeadersHeight = 40;
            dgvPages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPages.Columns.AddRange(new DataGridViewColumn[] { colPageUrl, colPageRequests, colPagePercent, colPageFirst, colPageLast, colPageStatus });
            dgvPages.Dock = DockStyle.Fill;
            dgvPages.EnableHeadersVisualStyles = false;
            dgvPages.GridColor = Color.FromArgb(230, 230, 230);
            dgvPages.Location = new Point(3, 50);
            dgvPages.Margin = new Padding(3, 0, 3, 0);
            dgvPages.Name = "dgvPages";
            dgvPages.ReadOnly = true;
            dgvPages.RowHeadersVisible = false;
            dgvPages.RowTemplate.Height = 35;
            dgvPages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPages.Size = new Size(1004, 318);
            dgvPages.TabIndex = 1;
            dgvPages.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 245);
            dgvPages.DefaultCellStyle.SelectionForeColor = Color.Black;
            // 
            // colPageUrl
            // 
            colPageUrl.HeaderText = "Страница";
            colPageUrl.Name = "colPageUrl";
            colPageUrl.ReadOnly = true;
            // 
            // colPageRequests
            // 
            colPageRequests.HeaderText = "Запросов";
            colPageRequests.Name = "colPageRequests";
            colPageRequests.ReadOnly = true;
            // 
            // colPagePercent
            // 
            colPagePercent.HeaderText = "%";
            colPagePercent.Name = "colPagePercent";
            colPagePercent.ReadOnly = true;
            // 
            // colPageFirst
            // 
            colPageFirst.HeaderText = "Первый";
            colPageFirst.Name = "colPageFirst";
            colPageFirst.ReadOnly = true;
            // 
            // colPageLast
            // 
            colPageLast.HeaderText = "Последний";
            colPageLast.Name = "colPageLast";
            colPageLast.ReadOnly = true;
            // 
            // colPageStatus
            // 
            colPageStatus.HeaderText = "Статус";
            colPageStatus.Name = "colPageStatus";
            colPageStatus.ReadOnly = true;
            // 
            // tabErrors
            // 
            tabErrors.Controls.Add(errorsPanel);
            tabErrors.Location = new Point(4, 24);
            tabErrors.Name = "tabErrors";
            tabErrors.Padding = new Padding(3);
            tabErrors.Size = new Size(1016, 414);
            tabErrors.TabIndex = 3;
            tabErrors.Text = "⚠️ Ошибки";
            tabErrors.UseVisualStyleBackColor = true;
            // 
            // errorsPanel
            // 
            errorsPanel.ColumnCount = 1;
            errorsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            errorsPanel.Controls.Add(errorsSearchPanel, 0, 0);
            errorsPanel.Controls.Add(dgvErrors, 0, 2);
            errorsPanel.Dock = DockStyle.Fill;
            errorsPanel.Location = new Point(3, 3);
            errorsPanel.Name = "errorsPanel";
            errorsPanel.RowCount = 4;
            errorsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            errorsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            errorsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            errorsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            errorsPanel.Size = new Size(1010, 408);
            errorsPanel.TabIndex = 1;
            // 
            // errorsSearchPanel
            // 
            errorsSearchPanel.ColumnCount = 2;
            errorsSearchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            errorsSearchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            errorsSearchPanel.Controls.Add(txtSearchError, 0, 0);
            errorsSearchPanel.Controls.Add(btnExportErrors, 1, 0);
            errorsSearchPanel.Dock = DockStyle.Fill;
            errorsSearchPanel.Location = new Point(3, 3);
            errorsSearchPanel.Name = "errorsSearchPanel";
            errorsSearchPanel.RowCount = 1;
            errorsSearchPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            errorsSearchPanel.Size = new Size(1004, 34);
            errorsSearchPanel.TabIndex = 0;
            // 
            // txtSearchError
            // 
            txtSearchError.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearchError.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtSearchError.Location = new Point(3, 4);
            txtSearchError.Name = "txtSearchError";
            txtSearchError.PlaceholderText = "🔍 Введите страницу для поиска";
            txtSearchError.Size = new Size(878, 26);
            txtSearchError.TabIndex = 0;
            // 
            // btnExportErrors
            // 
            btnExportErrors.Anchor = AnchorStyles.Right;
            btnExportErrors.BackColor = Color.White;
            btnExportErrors.Cursor = Cursors.Hand;
            btnExportErrors.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnExportErrors.FlatStyle = FlatStyle.Flat;
            btnExportErrors.Font = new Font("Segoe UI", 9F);
            btnExportErrors.Location = new Point(887, 3);
            btnExportErrors.Name = "btnExportErrors";
            btnExportErrors.Size = new Size(114, 28);
            btnExportErrors.TabIndex = 2;
            btnExportErrors.Text = "📥 Экспорт CSV";
            btnExportErrors.UseVisualStyleBackColor = false;
            // 
            // dgvErrors
            // 
            dgvErrors.AllowUserToAddRows = false;
            dgvErrors.AllowUserToDeleteRows = false;
            dgvErrors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvErrors.BackgroundColor = Color.White;
            dgvErrors.BorderStyle = BorderStyle.None;
            dgvErrors.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvErrors.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvErrors.ColumnHeadersHeight = 40;
            dgvErrors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvErrors.Columns.AddRange(new DataGridViewColumn[] { colTime, colErrorUrl, colErrorCode, colIPError });
            dgvErrors.Dock = DockStyle.Fill;
            dgvErrors.EnableHeadersVisualStyles = false;
            dgvErrors.GridColor = Color.FromArgb(230, 230, 230);
            dgvErrors.Location = new Point(3, 50);
            dgvErrors.Margin = new Padding(3, 0, 3, 0);
            dgvErrors.Name = "dgvErrors";
            dgvErrors.ReadOnly = true;
            dgvErrors.RowHeadersVisible = false;
            dgvErrors.RowTemplate.Height = 35;
            dgvErrors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvErrors.Size = new Size(1004, 318);
            dgvErrors.TabIndex = 1;
            // 
            // colTime
            // 
            colTime.HeaderText = "Время";
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            // 
            // colErrorUrl
            // 
            colErrorUrl.HeaderText = "Страница";
            colErrorUrl.Name = "colErrorUrl";
            colErrorUrl.ReadOnly = true;
            // 
            // colErrorCode
            // 
            colErrorCode.HeaderText = "Код";
            colErrorCode.Name = "colErrorCode";
            colErrorCode.ReadOnly = true;
            // 
            // colIPError
            // 
            colIPError.HeaderText = "IP адрес";
            colIPError.Name = "colIPError";
            colIPError.ReadOnly = true;
            // 
            // panelSettings
            // 
            panelSettings.BackColor = Color.FromArgb(250, 250, 250);
            panelSettings.Controls.Add(tableLayoutPanelSettings);
            panelSettings.Dock = DockStyle.Top;
            panelSettings.Location = new Point(0, 53);
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
            ((System.ComponentModel.ISupportInitialize)chartStatusCodes).EndInit();
            tabIPs.ResumeLayout(false);
            ipPanel.ResumeLayout(false);
            searchExportPanel.ResumeLayout(false);
            searchExportPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIPAddresses).EndInit();
            tabPages.ResumeLayout(false);
            pagesPanel.ResumeLayout(false);
            pagesSearchPanel.ResumeLayout(false);
            pagesSearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPages).EndInit();
            tabErrors.ResumeLayout(false);
            errorsPanel.ResumeLayout(false);
            errorsSearchPanel.ResumeLayout(false);
            errorsSearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvErrors).EndInit();
            panelSettings.ResumeLayout(false);
            tableLayoutPanelSettings.ResumeLayout(false);
            tableLayoutPanelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numThreshold).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
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
        private TableLayoutPanel ipPanel;
        private TableLayoutPanel searchExportPanel;
        private TextBox txtSearchIP;
        private Button btnExportCSV;
        private DataGridView dgvIPAddresses;
        private DataGridViewTextBoxColumn colIPAddress;
        private DataGridViewTextBoxColumn colRequests;
        private DataGridViewTextBoxColumn colPercent;
        private DataGridViewTextBoxColumn colFirstSeen;
        private DataGridViewTextBoxColumn colLastSeen;
        private DataGridViewTextBoxColumn colStatus;
        private TableLayoutPanel pagesPanel;
        private TableLayoutPanel pagesSearchPanel;
        private TextBox txtSearchPage;
        private Button btnExportPages;
        private DataGridView dgvPages;
        private DataGridViewTextBoxColumn colPageUrl;
        private DataGridViewTextBoxColumn colPageRequests;
        private DataGridViewTextBoxColumn colPagePercent;
        private DataGridViewTextBoxColumn colPageFirst;
        private DataGridViewTextBoxColumn colPageLast;
        private DataGridViewTextBoxColumn colPageStatus;
        private TableLayoutPanel errorsPanel;
        private TableLayoutPanel errorsSearchPanel;
        private TextBox txtSearchError;
        private Button btnExportErrors;
        private DataGridView dgvErrors;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colErrorUrl;
        private DataGridViewTextBoxColumn colErrorCode;
        private DataGridViewTextBoxColumn colErrorMessage;
        private DataGridViewTextBoxColumn colIPError;
    }
}