using ScottPlot.WinForms;

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

        private FormsPlot formsPlot;

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
            lblTitle = new Label();
            mainSplit = new SplitContainer();
            leftPanel = new Panel();
            lstCharts = new ListBox();
            txtSearch = new TextBox();
            lblCharts = new Label();
            chartButtons = new FlowLayoutPanel();
            btnCreateChart = new Button();
            btnEditChart = new Button();
            btnDeleteChart = new Button();
            rightPanel = new Panel();
            pnlChart = new Panel();
            chartInfo = new Panel();
            lblChartDescription = new Label();
            lblChartName = new Label();
            pointsPanel = new Panel();
            dgvPoints = new DataGridView();
            colX = new DataGridViewTextBoxColumn();
            colY = new DataGridViewTextBoxColumn();
            lblPoints = new Label();
            pointButtons = new FlowLayoutPanel();
            btnAddPoint = new Button();
            btnEditPoint = new Button();
            btnDeletePoint = new Button();
            formsPlot = new FormsPlot();
            ((System.ComponentModel.ISupportInitialize)mainSplit).BeginInit();
            mainSplit.Panel1.SuspendLayout();
            mainSplit.Panel2.SuspendLayout();
            mainSplit.SuspendLayout();
            leftPanel.SuspendLayout();
            chartButtons.SuspendLayout();
            rightPanel.SuspendLayout();
            pnlChart.SuspendLayout();
            chartInfo.SuspendLayout();
            pointsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPoints).BeginInit();
            pointButtons.SuspendLayout();
            SuspendLayout();
            //
            // formsPlot
            //
            formsPlot.Dock = DockStyle.Fill;
            pnlChart.Controls.Add(formsPlot);
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(15, 10, 0, 0);
            lblTitle.Size = new Size(1200, 55);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Визуализатор прогресса";
            // 
            // mainSplit
            // 
            mainSplit.Dock = DockStyle.Fill;
            mainSplit.FixedPanel = FixedPanel.Panel1;
            mainSplit.Location = new Point(0, 55);
            mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            mainSplit.Panel1.Controls.Add(leftPanel);
            // 
            // mainSplit.Panel2
            // 
            mainSplit.Panel2.Controls.Add(rightPanel);
            mainSplit.Size = new Size(1200, 695);
            mainSplit.SplitterDistance = 240;
            mainSplit.TabIndex = 0;
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(lstCharts);
            leftPanel.Controls.Add(txtSearch);
            leftPanel.Controls.Add(lblCharts);
            leftPanel.Controls.Add(chartButtons);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(10);
            leftPanel.Size = new Size(240, 695);
            leftPanel.TabIndex = 0;
            // 
            // lstCharts
            // 
            lstCharts.Dock = DockStyle.Fill;
            lstCharts.Font = new Font("Segoe UI", 10F);
            lstCharts.ItemHeight = 17;
            lstCharts.Location = new Point(10, 63);
            lstCharts.Name = "lstCharts";
            lstCharts.Size = new Size(220, 502);
            lstCharts.TabIndex = 0;
            lstCharts.SelectedIndexChanged += LstCharts_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Top;
            txtSearch.Location = new Point(10, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Поиск графика...";
            txtSearch.Size = new Size(220, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // lblCharts
            // 
            lblCharts.Dock = DockStyle.Top;
            lblCharts.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCharts.Location = new Point(10, 10);
            lblCharts.Name = "lblCharts";
            lblCharts.Size = new Size(220, 30);
            lblCharts.TabIndex = 2;
            lblCharts.Text = "Мои графики";
            // 
            // chartButtons
            // 
            chartButtons.Controls.Add(btnCreateChart);
            chartButtons.Controls.Add(btnEditChart);
            chartButtons.Controls.Add(btnDeleteChart);
            chartButtons.Dock = DockStyle.Bottom;
            chartButtons.FlowDirection = FlowDirection.TopDown;
            chartButtons.Location = new Point(10, 565);
            chartButtons.Name = "chartButtons";
            chartButtons.Size = new Size(220, 120);
            chartButtons.TabIndex = 3;
            chartButtons.WrapContents = false;
            // 
            // btnCreateChart
            // 
            btnCreateChart.Location = new Point(3, 3);
            btnCreateChart.Name = "btnCreateChart";
            btnCreateChart.Size = new Size(210, 30);
            btnCreateChart.TabIndex = 0;
            btnCreateChart.Text = "Создать";
            btnCreateChart.Click += BtnCreateChart_Click;
            // 
            // btnEditChart
            // 
            btnEditChart.Location = new Point(3, 39);
            btnEditChart.Name = "btnEditChart";
            btnEditChart.Size = new Size(210, 30);
            btnEditChart.TabIndex = 1;
            btnEditChart.Text = "Изменить";
            btnEditChart.Click += BtnEditChart_Click;
            // 
            // btnDeleteChart
            // 
            btnDeleteChart.Location = new Point(3, 75);
            btnDeleteChart.Name = "btnDeleteChart";
            btnDeleteChart.Size = new Size(210, 30);
            btnDeleteChart.TabIndex = 2;
            btnDeleteChart.Text = "Удалить";
            btnDeleteChart.Click += BtnDeleteChart_Click;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(pnlChart);
            rightPanel.Controls.Add(chartInfo);
            rightPanel.Controls.Add(pointsPanel);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(0, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(10);
            rightPanel.Size = new Size(956, 695);
            rightPanel.TabIndex = 0;
            // 
            // pnlChart
            // 
            pnlChart.BackColor = Color.WhiteSmoke;
            pnlChart.BorderStyle = BorderStyle.FixedSingle;
            pnlChart.Controls.Add(lblPlotPlaceholder);
            pnlChart.Dock = DockStyle.Fill;
            pnlChart.Location = new Point(10, 80);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new Size(936, 385);
            pnlChart.TabIndex = 0;
            // 
            // chartInfo
            // 
            chartInfo.Controls.Add(lblChartDescription);
            chartInfo.Controls.Add(lblChartName);
            chartInfo.Dock = DockStyle.Top;
            chartInfo.Location = new Point(10, 10);
            chartInfo.Name = "chartInfo";
            chartInfo.Size = new Size(936, 70);
            chartInfo.TabIndex = 1;
            // 
            // lblChartDescription
            // 
            lblChartDescription.Dock = DockStyle.Fill;
            lblChartDescription.Location = new Point(0, 30);
            lblChartDescription.Name = "lblChartDescription";
            lblChartDescription.Size = new Size(936, 40);
            lblChartDescription.TabIndex = 0;
            // 
            // lblChartName
            // 
            lblChartName.Dock = DockStyle.Top;
            lblChartName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblChartName.Location = new Point(0, 0);
            lblChartName.Name = "lblChartName";
            lblChartName.Size = new Size(936, 30);
            lblChartName.TabIndex = 1;
            lblChartName.Text = "График не выбран";
            // 
            // pointsPanel
            // 
            pointsPanel.Controls.Add(dgvPoints);
            pointsPanel.Controls.Add(lblPoints);
            pointsPanel.Controls.Add(pointButtons);
            pointsPanel.Dock = DockStyle.Bottom;
            pointsPanel.Location = new Point(10, 465);
            pointsPanel.Name = "pointsPanel";
            pointsPanel.Size = new Size(936, 220);
            pointsPanel.TabIndex = 2;
            // 
            // dgvPoints
            // 
            dgvPoints.AllowUserToAddRows = false;
            dgvPoints.AllowUserToDeleteRows = false;
            dgvPoints.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPoints.Columns.AddRange(new DataGridViewColumn[] { colX, colY });
            dgvPoints.Dock = DockStyle.Fill;
            dgvPoints.Location = new Point(0, 30);
            dgvPoints.MultiSelect = false;
            dgvPoints.Name = "dgvPoints";
            dgvPoints.ReadOnly = true;
            dgvPoints.RowHeadersVisible = false;
            dgvPoints.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPoints.Size = new Size(936, 150);
            dgvPoints.TabIndex = 0;
            // 
            // colX
            // 
            colX.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colX.HeaderText = "X";
            colX.Name = "colX";
            colX.ReadOnly = true;
            // 
            // colY
            // 
            colY.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colY.HeaderText = "Y";
            colY.Name = "colY";
            colY.ReadOnly = true;
            // 
            // lblPoints
            // 
            lblPoints.Dock = DockStyle.Top;
            lblPoints.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPoints.Location = new Point(0, 0);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new Size(936, 30);
            lblPoints.TabIndex = 1;
            lblPoints.Text = "Данные графика";
            // 
            // pointButtons
            // 
            pointButtons.Controls.Add(btnAddPoint);
            pointButtons.Controls.Add(btnEditPoint);
            pointButtons.Controls.Add(btnDeletePoint);
            pointButtons.Dock = DockStyle.Bottom;
            pointButtons.Location = new Point(0, 180);
            pointButtons.Name = "pointButtons";
            pointButtons.Size = new Size(936, 40);
            pointButtons.TabIndex = 2;
            pointButtons.WrapContents = false;
            // 
            // btnAddPoint
            // 
            btnAddPoint.Location = new Point(3, 3);
            btnAddPoint.Name = "btnAddPoint";
            btnAddPoint.Size = new Size(100, 30);
            btnAddPoint.TabIndex = 0;
            btnAddPoint.Text = "Добавить";
            btnAddPoint.Click += BtnAddPoint_Click;
            // 
            // btnEditPoint
            // 
            btnEditPoint.Location = new Point(109, 3);
            btnEditPoint.Name = "btnEditPoint";
            btnEditPoint.Size = new Size(100, 30);
            btnEditPoint.TabIndex = 1;
            btnEditPoint.Text = "Изменить";
            btnEditPoint.Click += BtnEditPoint_Click;
            // 
            // btnDeletePoint
            // 
            btnDeletePoint.Location = new Point(215, 3);
            btnDeletePoint.Name = "btnDeletePoint";
            btnDeletePoint.Size = new Size(100, 30);
            btnDeletePoint.TabIndex = 2;
            btnDeletePoint.Text = "Удалить";
            btnDeletePoint.Click += BtnDeletePoint_Click;
            // 
            // MainForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1200, 750);
            Controls.Add(mainSplit);
            Controls.Add(lblTitle);
            MinimumSize = new Size(1000, 650);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Визуализатор прогресса";
            mainSplit.Panel1.ResumeLayout(false);
            mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainSplit).EndInit();
            mainSplit.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            chartButtons.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            pnlChart.ResumeLayout(false);
            pnlChart.PerformLayout();
            chartInfo.ResumeLayout(false);
            pointsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPoints).EndInit();
            pointButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn colX;
        private DataGridViewTextBoxColumn colY;
    }
}