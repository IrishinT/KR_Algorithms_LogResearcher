using Controllers;
using Models;
using System.Reflection.Metadata;
using System.Windows.Forms.DataVisualization.Charting;

namespace KR_Algorithms_LogResearcher
{
    public partial class MainMenu : Form
    {
        private LogController _logController = new LogController();
        private List<IPStatistics> _currentIPStats = new List<IPStatistics>();
        private List<PageStatistics> _currentPageStats = new List<PageStatistics>();
        private List<LogEntry> _currentErrors = new List<LogEntry>();

        public MainMenu()
        {
            InitializeComponent();
            InitializeStatCards();

            btnOpenTool.Click += BtnOpenTool_Click;
            btnAnalyzeTool.Click += btnAnalyzeTool_Click;

            openSubMenuItem.Click += BtnOpenTool_Click;  // Переиспользуем логику
            exitSubMenuItem.Click += ExitSubMenuItem_Click;
            helpMenu.Click += HelpMenu_Click;

            // Поиск
            txtSearchIP.TextChanged += TxtSearchIP_TextChanged;
            txtSearchPage.TextChanged += TxtSearchPage_TextChanged;
            txtSearchError.TextChanged += TxtSearchError_TextChanged;

            // Экспорт в таблицах
            btnExportCSV.Click += BtnExportCSV_Click;
            btnExportPages.Click += BtnExportPages_Click;
            btnExportErrors.Click += BtnExportErrors_Click;

            // Порог
            numThreshold.ValueChanged += NumThreshold_ValueChanged;
        }

        private void InitializeStatCards()
        {
            panelCards.Controls.Clear();
            panelCards.ColumnStyles.Clear();
            panelCards.RowStyles.Clear();

            panelCards.ColumnCount = 4;
            panelCards.RowCount = 1;

            for (int i = 0; i < 4; i++)
                panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var cardTotal = CreateStatCard("Всего запросов", "0", Color.FromArgb(0, 102, 204), "cardTotal");
            var cardUnique = CreateStatCard("Уникальные IP", "0", Color.FromArgb(0, 153, 76), "cardUnique");
            var cardErrors = CreateStatCard("Ошибки (4xx/5xx)", "0", Color.FromArgb(204, 0, 0), "cardErrors");
            var cardSuspicious = CreateStatCard("Подозрительные", "0", Color.FromArgb(255, 153, 0), "cardSuspicious");

            panelCards.Controls.Add(cardTotal, 0, 0);
            panelCards.Controls.Add(cardUnique, 1, 0);
            panelCards.Controls.Add(cardErrors, 2, 0);
            panelCards.Controls.Add(cardSuspicious, 3, 0);
        }

        private void UpdateStatCards()
        {
            UpdateCardValue("cardTotal", _logController.TotalRequests.ToString("N0"));
            UpdateCardValue("cardUnique", _logController.UniqueIPs.ToString("N0"));
            UpdateCardValue("cardErrors", _logController.TotalErrors.ToString("N0"));
            UpdateCardValue("cardSuspicious", _logController.SuspiciousIPs.ToString("N0"));
        }

        private void UpdateCardValue(string cardName, string value)
        {
            foreach (Control control in panelCards.Controls)
            {
                if (control is Panel panel && panel.Name == cardName)
                {
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl is Label label && label.Font.Size == 20F)
                        {
                            label.Text = value;
                            break;
                        }
                    }
                    break;
                }
            }
        }

        // === ОТКРЫТИЕ ФАЙЛА ===
        private void BtnOpenTool_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog1.FileName;
                    txtFilePath.ForeColor = Color.Black;
                    btnAnalyzeTool.Enabled = true;
                    lblStatus.Text = $"Файл: {Path.GetFileName(openFileDialog1.FileName)}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === ВЫХОД ===
        private void ExitSubMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Завершить работу?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // === СПРАВКА ===
        private void HelpMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Log Analyzer v1.0\n\n" +
                "1. Нажмите «Открыть» и выберите файл лога (.log, .txt)\n" +
                "2. При необходимости измените порог подозрительных запросов\n" +
                "3. Нажмите «Анализ» для обработки\n" +
                "4. Результаты доступны во вкладках: Обзор, IP, Страницы, Ошибки\n" +
                "5. Используйте поиск и экспорт CSV для работы с данными\n\n" +
                "Горячие клавиши:\n" +
                "Ctrl+O — Открыть файл\n" +
                "Alt+F4 — Выход",
                "Справка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void NumThreshold_ValueChanged(object sender, EventArgs e)
        {
            _logController.SuspiciousThreshold = (int)numThreshold.Value;
            if (_logController.TotalRequests > 0)
            {
                _logController.CalculateStatistics();
                UpdateStatCards();
                LoadIPData(_logController.IPStats);
            }
        }

        private void btnAnalyzeTool_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text) || !File.Exists(txtFilePath.Text))
            {
                MessageBox.Show("Сначала выберите файл!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                lblStatus.Text = "Анализ...";
                progressBar.Visible = true;
                progressBar.Value = 0;
                btnAnalyzeTool.Enabled = false;
                Application.DoEvents();

                _logController.ParseFile(txtFilePath.Text);

                // Обновляем карточки
                UpdateStatCards();

                // График трафика
                chartTraffic.Series["Трафик"].Points.Clear();
                foreach (var item in _logController.HourlyTraffic)
                {
                    chartTraffic.Series["Трафик"].Points.AddXY(item.Key.ToOADate(), item.Value);
                }

                chartTraffic.ChartAreas[0].AxisX.LabelStyle.Format = "HH:00";
                chartTraffic.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Hours;
                chartTraffic.ChartAreas[0].AxisX.Interval = 1;

                // Топ IP
                dgvTopIPs.Rows.Clear();
                foreach (var ip in _logController.IPStats.Take(10))
                    dgvTopIPs.Rows.Add(ip.IP, ip.RequestCount.ToString("N0"), $"{ip.Percentage:F1}%");

                // Круговая диаграмма статусов
                chartStatusCodes.Series["Коды"].Points.Clear();

                foreach (var code in _logController.StatusCodeStats)
                {
                    chartStatusCodes.Series["Коды"].Points.AddXY(code.Key.ToString(), code.Value);
                }

                chartStatusCodes.Series["Коды"].ChartType = SeriesChartType.Pie;
                chartStatusCodes.Series["Коды"].IsValueShownAsLabel = true;         // показывать значения
                chartStatusCodes.Series["Коды"].LabelFormat = "N0";                 // формат чисел
                chartStatusCodes.Series["Коды"]["PieLabelStyle"] = "Outside";       // подписи снаружи
                chartStatusCodes.Series["Коды"]["PieLineColor"] = "Black";          // линии к подписям
                chartStatusCodes.Legends["Legend1"].Enabled = true;                 // легенда




                // Сохраняем данные для поиска
                _currentIPStats = _logController.IPStats;
                _currentPageStats = _logController.PageStats;
                _currentErrors = _logController.Errors;

                // Загружаем таблицы
                LoadIPData(_currentIPStats);
                LoadPagesData(_currentPageStats);
                LoadErrorsData(_currentErrors);

                lblStatus.Text = $"Готово! Обработано {_logController.TotalRequests:N0} записей";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Ошибка анализа";
            }
            finally
            {
                progressBar.Visible = false;
                btnAnalyzeTool.Enabled = true;
            }
        }



        private void LoadIPData(List<IPStatistics> stats)
        {
            dgvIPAddresses.Rows.Clear();
            foreach (var ip in stats)
            {
                var status = ip.IsSuspicious ? "🔴 Подозр." : "🟢 Норма";

                var row = dgvIPAddresses.Rows.Add(
                    ip.IP,                                    // IP адрес
                    ip.RequestCount.ToString("N0"),          // Запросов
                    $"{ip.Percentage:F1}%",                  // %
                    ip.FirstSeen.ToString("HH:mm"),          // Первый
                    ip.LastSeen.ToString("HH:mm"),           // Последний
                    status                                    // Статус
                );

                if (ip.IsSuspicious)
                    dgvIPAddresses.Rows[row].DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240);
            }
        }

        private void LoadPagesData(List<PageStatistics> stats)
        {
            dgvPages.Rows.Clear();
            foreach (var page in stats)
            {
                var status = page.ErrorCount > 0 ? "⚠️ С ошибками" : "✅ OK";

                var row = dgvPages.Rows.Add(
                    page.Url.Length > 50 ? page.Url.Substring(0, 47) + "..." : page.Url,  // Страница
                    page.RequestCount.ToString("N0"),          // Запросов
                    $"{page.Percentage:F1}%",                    // %
                    page.FirstSeen.ToString("HH:mm"),          // Первый
                    page.LastSeen.ToString("HH:mm"),           // Последний
                    status                                     // Статус
                );

                if (page.ErrorCount > 0)
                    dgvPages.Rows[row].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 220);
            }
        }

        private void LoadErrorsData(List<LogEntry> errors)
        {
            dgvErrors.Rows.Clear();
            foreach (var error in errors.Take(500))
            {
                dgvErrors.Rows.Add(
                    error.Timestamp.ToString("HH:mm:ss"),     // Время
                    error.Url.Length > 40 ? error.Url.Substring(0, 37) + "..." : error.Url,  // Страница
                    error.StatusCode,                         // Код
                    error.IP                                  // IP адрес
                );
            }
        }

        // === ПОИСК ===
        private void TxtSearchIP_TextChanged(object sender, EventArgs e)
        {
            var filtered = _logController.SearchIPs(txtSearchIP.Text);
            LoadIPData(filtered);
        }

        private void TxtSearchPage_TextChanged(object sender, EventArgs e)
        {
            var filtered = _logController.SearchPages(txtSearchPage.Text);
            LoadPagesData(filtered);
        }

        private void TxtSearchError_TextChanged(object sender, EventArgs e)
        {
            var filtered = _logController.SearchErrors(txtSearchError.Text);
            LoadErrorsData(filtered);
        }

        private void BtnExportCSV_Click(object sender, EventArgs e)
        {
            ExportData(ExportType.IP, "IP_адреса.csv");
        }

        private void BtnExportPages_Click(object sender, EventArgs e)
        {
            ExportData(ExportType.Pages, "Страницы.csv");
        }

        private void BtnExportErrors_Click(object sender, EventArgs e)
        {
            ExportData(ExportType.Errors, "Ошибки.csv");
        }

        private void ExportData(ExportType type, string defaultName)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "CSV файлы|*.csv",
                FileName = defaultName
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logController.ExportToCSV(dialog.FileName, type);
                    MessageBox.Show("Экспорт выполнен успешно!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Panel CreateStatCard(string title, string value, Color color, string name)
        {
            var panel = new Panel
            {
                Name = name,
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
                Margin = new Padding(3)
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(80, 80, 80),
                AutoSize = true,
                Location = new Point(10, 10),
                Dock = DockStyle.Top
            };

            var lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = color,
                AutoSize = true,
                Location = new Point(10, 35),
                Dock = DockStyle.Top
            };

            panel.Controls.Add(lblValue);
            panel.Controls.Add(lblTitle);
            return panel;
        }
    }
}