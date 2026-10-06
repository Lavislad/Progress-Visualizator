using ProgressVisualizer.Data;
using ProgressVisualizer.Models;
using ProgressVisualizer.Forms;
using System.Collections.Generic;
using ProgressVisualizer.Visualization;
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
        private ChartRenderer chartRenderer;

        public MainForm()
        {
            InitializeComponent();

            string databasePath = Path.Combine(Application.StartupPath,"progress.db");

            db = new DBManager(databasePath);
            chartRepository = new ChartRepository(db);
            dataPointRepository = new DataPointRepository(db);
            chartRenderer = new ChartRenderer();

            LoadCharts();
        }

        private void LoadCharts()
        {
            lstCharts.Items.Clear();

            string searchText = txtSearch.Text.Trim();

            List<Chart> charts = chartRepository.Search(searchText);

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

            chartRenderer.Draw(
                formsPlot,
                chart,
                points);
        }

        private void TxtSearch_TextChanged(
    object sender,
    EventArgs e)
        {
            LoadCharts();
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
                    "Сначала выберите график.",
                    "Изменение графика",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            Chart chart = (Chart)lstCharts.SelectedItem;

            using ChartForm form = new ChartForm(chart);

            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            Chart? updatedChart = form.ResultChart;

            if (updatedChart == null)
                return;

            updatedChart.Id = chart.Id;

            chartRepository.Update(updatedChart);

            LoadCharts();

            SelectChartById(updatedChart.Id);
        }

        private void SelectChartById(int chartId)
        {
            for (int i = 0; i < lstCharts.Items.Count; i++)
            {
                Chart chart = (Chart)lstCharts.Items[i];

                if (chart.Id == chartId)
                {
                    lstCharts.SelectedIndex = i;
                    return;
                }
            }
        }

        private void BtnDeleteChart_Click(
    object sender,
    EventArgs e)
        {
            if (lstCharts.SelectedItem == null)
            {
                MessageBox.Show(
                    "Сначала выберите график.",
                    "Удаление графика",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            Chart chart = (Chart)lstCharts.SelectedItem;

            DialogResult result = MessageBox.Show(
                $"Удалить график \"{chart.Name}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            chartRepository.Delete(chart.Id);

            LoadCharts();

            dgvPoints.Rows.Clear();

            formsPlot.Plot.Clear();
            formsPlot.Refresh();

            lblChartName.Text = "График не выбран";
            lblChartDescription.Text = "";
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