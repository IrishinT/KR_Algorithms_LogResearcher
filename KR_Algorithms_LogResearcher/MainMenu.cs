namespace KR_Algorithms_LogResearcher
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();


            // Карточка 1: Всего запросов
            var cardTotal = CreateStatCard("Всего запросов", "0", Color.FromArgb(0, 102, 204));
            // Карточка 2: Уникальные IP
            var cardUnique = CreateStatCard("Уникальные IP", "0", Color.FromArgb(0, 153, 76));
            // Карточка 3: Ошибки
            var cardErrors = CreateStatCard("Ошибки (4xx/5xx)", "0", Color.FromArgb(204, 0, 0));
            // Карточка 4: Подозрительные
            var cardSuspicious = CreateStatCard("Подозрительные", "0", Color.FromArgb(255, 153, 0));

            panelCards.Controls.Add(cardTotal, 0, 0);
            panelCards.Controls.Add(cardUnique, 1, 0);
            panelCards.Controls.Add(cardErrors, 2, 0);
            panelCards.Controls.Add(cardSuspicious, 3, 0);

            txtFilePath.DeselectAll();  // ← Убираем выделение
            txtFilePath.Select(0, 0);   // ← Сбрасываем курсор в начало
        }

        // === ОТКРЫТИЕ ФАЙЛА ===
        private void openSubMenuItem_Click(object sender, EventArgs e) => OpenFile();
        private void btnOpenTool_Click(object sender, EventArgs e) => OpenFile();

        private void OpenFile()
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
                MessageBox.Show($"Ошибка открытия файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === АНАЛИЗ ===
        private void btnAnalyzeTool_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text) || !File.Exists(txtFilePath.Text))
            {
                MessageBox.Show("Сначала выберите корректный файл!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                lblStatus.Text = "Анализ...";
                progressBar.Visible = true;
                progressBar.Style = ProgressBarStyle.Marquee;
                btnAnalyzeTool.Enabled = false;
                btnOpenTool.Enabled = false;

                // TODO: Здесь будет реальный анализ
                // Для теста — имитация
                System.Threading.Thread.Sleep(500);

                // После завершения
                btnExportTool.Enabled = true;
                lblStatus.Text = "Анализ завершён";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка анализа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Ошибка";
            }
            finally
            {
                progressBar.Visible = false;
                btnAnalyzeTool.Enabled = true;
                btnOpenTool.Enabled = true;
            }
        }

        // === ЭКСПОРТ ===
        private void btnExportTool_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Реальный экспорт
                    MessageBox.Show($"Отчет сохранен: {saveFileDialog1.FileName}", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = "Отчет экспортирован";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === ВЫХОД ===
        private void exitSubMenuItem_Click(object sender, EventArgs e) => this.Close();

        private void helpMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Как работать с программой:\n\n" +
                "1. Нажмите кнопку «Открыть» или выберите Файл → Открыть\n" +
                "2. Выберите файл лога (*.log, *.txt)\n" +
                "3. При необходимости измените порог (запросов/мин)\n" +
                "4. Нажмите кнопку «Анализ»\n" +
                "5. После завершения нажмите «Экспорт» для сохранения отчёта\n\n" +
                "Горячие клавиши:\n" +
                "Ctrl+O — Открыть файл\n" +
                "Alt+F4 — Выход",
                "Справка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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

    }
}
