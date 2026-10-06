namespace ProgressVisualizer
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // =========================================================
        // ЭЛЕМЕНТЫ ФОРМЫ
        // =========================================================

        private Label lblTitle;

        private SplitContainer mainSplit;

        private Panel leftPanel;
        private Label lblCharts;
        private TextBox txtSearch;
        private ListBox lstCharts;

        private FlowLayoutPanel chartButtons;
        private Button btnCreateChart;
        private Button btnEditChart;
        private Button btnDeleteChart;

        private Panel rightPanel;
        private Panel chartInfo;

        private Label lblChartName;
        private Label lblChartDescription;

        private Panel pnlChart;
        private Label lblPlotPlaceholder;

        private Panel pointsPanel;
        private Label lblPoints;

        private DataGridView dgvPoints;

        private FlowLayoutPanel pointButtons;
        private Button btnAddPoint;
        private Button btnEditPoint;
        private Button btnDeletePoint;

        /// <summary>
        /// Освобождение используемых ресурсов.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {   
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм

        /// <summary>
        /// Требуемый метод для поддержки конструктора.
        /// Не изменяйте содержимое данного метода
        /// с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // =====================================================
            // ФОРМА
            // =====================================================

            this.SuspendLayout();

            this.Text = "Визуализатор прогресса";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.ClientSize =
                new System.Drawing.Size(1200, 750);

            this.MinimumSize =
                new System.Drawing.Size(1000, 650);

            this.BackColor =
                System.Drawing.Color.White;

            // =====================================================
            // ЗАГОЛОВОК
            // =====================================================

            lblTitle = new Label();

            lblTitle.Text = "Визуализатор прогресса";

            lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                18F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            lblTitle.Dock =
                System.Windows.Forms.DockStyle.Top;

            lblTitle.Height = 55;

            lblTitle.Padding =
                new System.Windows.Forms.Padding(
                    15, 10, 0, 0);

            // =====================================================
            // ОСНОВНОЙ SPLIT CONTAINER
            // =====================================================

            mainSplit = new SplitContainer();

            mainSplit.Dock =
                System.Windows.Forms.DockStyle.Fill;

            mainSplit.Orientation =
                System.Windows.Forms.Orientation.Vertical;

            mainSplit.SplitterDistance = 250;

            mainSplit.FixedPanel =
                System.Windows.Forms.FixedPanel.Panel1;

            // =====================================================
            // ЛЕВАЯ ПАНЕЛЬ
            // =====================================================

            leftPanel = new Panel();

            leftPanel.Dock =
                System.Windows.Forms.DockStyle.Fill;

            leftPanel.Padding =
                new System.Windows.Forms.Padding(10);

            // -----------------------------------------------------
            // Заголовок "Мои графики"
            // -----------------------------------------------------

            lblCharts = new Label();

            lblCharts.Text = "Мои графики";

            lblCharts.Font = new System.Drawing.Font(
                "Segoe UI",
                12F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            lblCharts.Dock =
                System.Windows.Forms.DockStyle.Top;

            lblCharts.Height = 30;

            // -----------------------------------------------------
            // Поиск
            // -----------------------------------------------------

            txtSearch = new TextBox();

            txtSearch.Dock =
                System.Windows.Forms.DockStyle.Top;

            txtSearch.Height = 30;

            txtSearch.PlaceholderText =
                "Поиск графика...";

            txtSearch.TextChanged +=
                new System.EventHandler(
                    TxtSearch_TextChanged);

            // -----------------------------------------------------
            // Список графиков
            // -----------------------------------------------------

            lstCharts = new ListBox();

            lstCharts.Dock =
                System.Windows.Forms.DockStyle.Fill;

            lstCharts.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            lstCharts.SelectedIndexChanged +=
                new System.EventHandler(
                    LstCharts_SelectedIndexChanged);

            // -----------------------------------------------------
            // Кнопки графиков
            // -----------------------------------------------------

            chartButtons = new FlowLayoutPanel();

            chartButtons.Dock =
                System.Windows.Forms.DockStyle.Bottom;

            chartButtons.Height = 120;

            chartButtons.FlowDirection =
                System.Windows.Forms.FlowDirection.TopDown;

            chartButtons.WrapContents = false;

            // -----------------------------------------------------
            // Создать
            // -----------------------------------------------------

            btnCreateChart = new Button();

            btnCreateChart.Text = "Создать";

            btnCreateChart.Width = 210;
            btnCreateChart.Height = 30;

            btnCreateChart.Click +=
                new System.EventHandler(
                    BtnCreateChart_Click);

            // -----------------------------------------------------
            // Изменить
            // -----------------------------------------------------

            btnEditChart = new Button();

            btnEditChart.Text = "Изменить";

            btnEditChart.Width = 210;
            btnEditChart.Height = 30;

            btnEditChart.Click +=
                new System.EventHandler(
                    BtnEditChart_Click);

            // -----------------------------------------------------
            // Удалить
            // -----------------------------------------------------

            btnDeleteChart = new Button();

            btnDeleteChart.Text = "Удалить";

            btnDeleteChart.Width = 210;
            btnDeleteChart.Height = 30;

            btnDeleteChart.Click +=
                new System.EventHandler(
                    BtnDeleteChart_Click);

            // =====================================================
            // ПРАВАЯ ПАНЕЛЬ
            // =====================================================

            rightPanel = new Panel();

            rightPanel.Dock =
                System.Windows.Forms.DockStyle.Fill;

            rightPanel.Padding =
                new System.Windows.Forms.Padding(10);

            // =====================================================
            // ИНФОРМАЦИЯ О ГРАФИКЕ
            // =====================================================

            chartInfo = new Panel();

            chartInfo.Dock =
                System.Windows.Forms.DockStyle.Top;

            chartInfo.Height = 70;

            // -----------------------------------------------------
            // Название графика
            // -----------------------------------------------------

            lblChartName = new Label();

            lblChartName.Text =
                "График не выбран";

            lblChartName.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            lblChartName.Dock =
                System.Windows.Forms.DockStyle.Top;

            lblChartName.Height = 30;

            // -----------------------------------------------------
            // Описание
            // -----------------------------------------------------

            lblChartDescription = new Label();

            lblChartDescription.Text = "";

            lblChartDescription.Dock =
                System.Windows.Forms.DockStyle.Fill;

            // =====================================================
            // ОБЛАСТЬ ГРАФИКА
            // =====================================================

            pnlChart = new Panel();

            pnlChart.Dock =
                System.Windows.Forms.DockStyle.Fill;

            pnlChart.BackColor =
                System.Drawing.Color.WhiteSmoke;

            pnlChart.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            // -----------------------------------------------------
            // Текст-заглушка
            // -----------------------------------------------------

            lblPlotPlaceholder = new Label();

            lblPlotPlaceholder.Text =
                "Здесь будет график ScottPlot";

            lblPlotPlaceholder.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point);

            lblPlotPlaceholder.AutoSize = true;

            lblPlotPlaceholder.Location =
                new System.Drawing.Point(30, 30);

            // =====================================================
            // ПАНЕЛЬ ТОЧЕК
            // =====================================================

            pointsPanel = new Panel();

            pointsPanel.Dock =
                System.Windows.Forms.DockStyle.Bottom;

            pointsPanel.Height = 220;

            // -----------------------------------------------------
            // Заголовок
            // -----------------------------------------------------

            lblPoints = new Label();

            lblPoints.Text = "Данные графика";

            lblPoints.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            lblPoints.Dock =
                System.Windows.Forms.DockStyle.Top;

            lblPoints.Height = 30;

            // -----------------------------------------------------
            // Таблица точек
            // -----------------------------------------------------

            dgvPoints = new DataGridView();

            dgvPoints.Dock =
                System.Windows.Forms.DockStyle.Fill;

            dgvPoints.AllowUserToAddRows = false;
            dgvPoints.AllowUserToDeleteRows = false;

            dgvPoints.ReadOnly = true;

            dgvPoints.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvPoints.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPoints.MultiSelect = false;

            dgvPoints.RowHeadersVisible = false;

            // -----------------------------------------------------
            // Столбцы X и Y
            // -----------------------------------------------------

            DataGridViewTextBoxColumn colX =
                new DataGridViewTextBoxColumn();

            colX.Name = "XValue";
            colX.HeaderText = "X";
            colX.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn colY =
                new DataGridViewTextBoxColumn();

            colY.Name = "YValue";
            colY.HeaderText = "Y";
            colY.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dgvPoints.Columns.Add(colX);
            dgvPoints.Columns.Add(colY);

            // =====================================================
            // КНОПКИ ТОЧЕК
            // =====================================================

            pointButtons = new FlowLayoutPanel();

            pointButtons.Dock =
                System.Windows.Forms.DockStyle.Bottom;

            pointButtons.Height = 40;

            pointButtons.FlowDirection =
                System.Windows.Forms.FlowDirection.LeftToRight;

            pointButtons.WrapContents = false;

            // -----------------------------------------------------
            // Добавить
            // -----------------------------------------------------

            btnAddPoint = new Button();

            btnAddPoint.Text = "Добавить";

            btnAddPoint.Width = 100;
            btnAddPoint.Height = 30;

            btnAddPoint.Click +=
                new System.EventHandler(
                    BtnAddPoint_Click);

            // -----------------------------------------------------
            // Изменить
            // -----------------------------------------------------

            btnEditPoint = new Button();

            btnEditPoint.Text = "Изменить";

            btnEditPoint.Width = 100;
            btnEditPoint.Height = 30;

            btnEditPoint.Click +=
                new System.EventHandler(
                    BtnEditPoint_Click);

            // -----------------------------------------------------
            // Удалить
            // -----------------------------------------------------

            btnDeletePoint = new Button();

            btnDeletePoint.Text = "Удалить";

            btnDeletePoint.Width = 100;
            btnDeletePoint.Height = 30;

            btnDeletePoint.Click +=
                new System.EventHandler(
                    BtnDeletePoint_Click);

            // =====================================================
            // ДОБАВЛЕНИЕ КОНТРОЛОВ
            // =====================================================

            // Кнопки графиков
            chartButtons.Controls.Add(btnCreateChart);
            chartButtons.Controls.Add(btnEditChart);
            chartButtons.Controls.Add(btnDeleteChart);

            // Левая панель
            leftPanel.Controls.Add(lstCharts);
            leftPanel.Controls.Add(txtSearch);
            leftPanel.Controls.Add(lblCharts);
            leftPanel.Controls.Add(chartButtons);

            // Информация о графике
            chartInfo.Controls.Add(lblChartDescription);
            chartInfo.Controls.Add(lblChartName);

            // Область графика
            pnlChart.Controls.Add(lblPlotPlaceholder);

            // Кнопки точек
            pointButtons.Controls.Add(btnAddPoint);
            pointButtons.Controls.Add(btnEditPoint);
            pointButtons.Controls.Add(btnDeletePoint);

            // Панель точек
            pointsPanel.Controls.Add(dgvPoints);
            pointsPanel.Controls.Add(lblPoints);
            pointsPanel.Controls.Add(pointButtons);

            // Правая панель
            rightPanel.Controls.Add(pnlChart);
            rightPanel.Controls.Add(chartInfo);
            rightPanel.Controls.Add(pointsPanel);

            // SplitContainer
            mainSplit.Panel1.Controls.Add(leftPanel);
            mainSplit.Panel2.Controls.Add(rightPanel);

            // Форма
            this.Controls.Add(mainSplit);
            this.Controls.Add(lblTitle);

            this.ResumeLayout(false);
        }

        #endregion
    }
}