namespace KR_Algorithms_LogResearcher
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

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
    }
}
