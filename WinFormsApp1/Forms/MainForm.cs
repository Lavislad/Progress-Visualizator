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
        private DataPointRepository dataPointRepository;

        public MainForm()
        {
            InitializeComponent();

            string databasePath = Path.Combine(Application.StartupPath,"progress.db");

            db = new DBManager(databasePath);
            chartRepository = new ChartRepository(db);
            dataPointRepository = new DataPointRepository(db);

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

        private void LoadPoints(Chart chart)
        {
            dgvPoints.Rows.Clear();

            List<DataPoint> points =
                dataPointRepository.GetByChartId(
                    chart.Id);

            foreach (DataPoint point in points)
            {
                int rowIndex =
                    dgvPoints.Rows.Add(
                        point.XValue,
                        point.YValue);

                dgvPoints.Rows[rowIndex].Tag =
                    point;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            // Здесь позже будет поиск графиков через SQLite.
        }

        private void LstCharts_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (lstCharts.SelectedItem == null)
                return;

            Chart chart = (Chart)lstCharts.SelectedItem;

            lblChartName.Text = chart.Name;

            lblChartDescription.Text = chart.Description;

            LoadPoints(chart);
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

            Chart chart =
                (Chart)lstCharts.SelectedItem;

            using DataPointForm form =
                new DataPointForm(chart);

            if (form.ShowDialog(this) ==
                DialogResult.OK)
            {
                DataPoint point =
                    form.ResultPoint;

                if (point == null)
                    return;

                int id =
                    dataPointRepository.Add(point);

                point.Id = id;

                LoadPoints(chart);
            }
        }

        private void BtnEditPoint_Click(
    object sender,
    EventArgs e)
        {
            if (dgvPoints.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Выберите точку.",
                    "Изменение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow row =
                dgvPoints.SelectedRows[0];

            DataPoint? point =
                row.Tag as DataPoint;

            if (point == null)
                return;

            Chart chart =
                (Chart)lstCharts.SelectedItem;

            using DataPointForm form =
                new DataPointForm(
                    chart,
                    point);

            if (form.ShowDialog(this) ==
                DialogResult.OK)
            {
                DataPoint? updatedPoint =
                    form.ResultPoint;

                if (updatedPoint == null)
                    return;

                dataPointRepository.Update(
                    updatedPoint);

                LoadPoints(chart);
            }
        }

        private void BtnDeletePoint_Click(
    object sender,
    EventArgs e)
        {
            if (dgvPoints.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Выберите точку.",
                    "Удаление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow row =
                dgvPoints.SelectedRows[0];

            DataPoint? point =
                row.Tag as DataPoint;

            if (point == null)
                return;

            DialogResult result =
                MessageBox.Show(
                    "Удалить выбранную точку?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            dataPointRepository.Delete(
                point.Id);

            Chart chart =
                (Chart)lstCharts.SelectedItem;

            LoadPoints(chart);
        }
    }
}