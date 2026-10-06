using ProgressVisualizer.Data;
using ProgressVisualizer.Models;
using ProgressVisualizer.Forms;
using System;
using System.IO;
using System.Windows.Forms;

namespace ProgressVisualizer
{
    public partial class MainForm : Form
    {
        private DBManager db;
        private ChartRepository chartRepository;

        public MainForm()
        {
            InitializeComponent();

            string databasePath = Path.Combine(Application.StartupPath,"progress.db");

            db = new DBManager(databasePath);
            chartRepository = new ChartRepository(db);

            LoadCharts();
        }

        private void LoadCharts()
        {
            lstCharts.Items.Clear();

            List<Chart> charts = chartRepository.GetAll();

            foreach (Chart chart in charts)
            {
                lstCharts.Items.Add(chart);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            // Здесь позже будет поиск графиков через SQLite.
        }

        private void LstCharts_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (lstCharts.SelectedItem == null)
            {
                lblChartName.Text = "График не выбран";
                lblChartDescription.Text = "";
                return;
            }

            string chartName = lstCharts.SelectedItem.ToString();

            lblChartName.Text = chartName;
            lblChartDescription.Text = "Описание графика";

            // Позже здесь будет загрузка данных
            // выбранного графика из SQLite.
        }

        private void BtnCreateChart_Click(object sender, EventArgs e)
        {
            using ChartForm form = new ChartForm();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Chart chart = form.ResultChart;

                if (chart == null)
                    return;

                int id = chartRepository.Add(chart);

                chart.Id = id;

                LoadCharts();

                MessageBox.Show(
                    "График успешно создан.",
                    "Успешно",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void BtnEditChart_Click(
            object sender,
            EventArgs e)
        {
            if (lstCharts.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите график.",
                    "Изменение графика",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "Здесь будет открываться форма редактирования графика.",
                "Изменение графика",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnDeleteChart_Click(
            object sender,
            EventArgs e)
        {
            if (lstCharts.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите график.",
                    "Удаление графика",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Вы действительно хотите удалить выбранный график?",
                "Удаление графика",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                lstCharts.Items.Remove(
                    lstCharts.SelectedItem);

                lblChartName.Text = "График не выбран";
                lblChartDescription.Text = "";

                dgvPoints.Rows.Clear();
            }
        }

        // =========================================================
        // ТОЧКИ
        // =========================================================

        private void BtnAddPoint_Click(
            object sender,
            EventArgs e)
        {
            if (lstCharts.SelectedItem == null)
            {
                MessageBox.Show(
                    "Сначала выберите график.",
                    "Добавление точки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "Здесь будет открываться форма добавления точки.",
                "Добавление точки",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnEditPoint_Click(
            object sender,
            EventArgs e)
        {
            if (dgvPoints.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Выберите точку.",
                    "Изменение точки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "Здесь будет открываться форма изменения точки.",
                "Изменение точки",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnDeletePoint_Click(
            object sender,
            EventArgs e)
        {
            if (dgvPoints.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Выберите точку.",
                    "Удаление точки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Удалить выбранную точку?",
                "Удаление точки",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dgvPoints.Rows.Remove(
                    dgvPoints.SelectedRows[0]);
            }
        }
    }
}