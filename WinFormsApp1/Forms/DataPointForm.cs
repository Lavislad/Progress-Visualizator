using System;
using System.Globalization;
using System.Windows.Forms;
using ProgressVisualizer.Models;

namespace ProgressVisualizer.Forms
{
    public partial class DataPointForm : Form
    {
        private readonly Chart chart;

        private DataPoint? point;

        public DataPoint? ResultPoint { get; private set; }

        // =========================================================
        // СОЗДАНИЕ ТОЧКИ
        // =========================================================

        public DataPointForm(Chart chart)
        {
            InitializeComponent();

            this.chart = chart;

            txtXValue.Text = chart.XAxisName;
            txtYValue.Text = chart.YAxisName;

            ConfigureXAxis();
        }

        // =========================================================
        // РЕДАКТИРОВАНИЕ ТОЧКИ
        // =========================================================

        public DataPointForm(
     Chart chart,
     DataPoint point)
        {
            InitializeComponent();

            this.chart = chart;
            this.point = point;

            txtXValue.Text = chart.XAxisName;
            txtYValue.Text = chart.YAxisName;

            ConfigureXAxis();

            txtYValue.Text =
                point.YValue.ToString(
                    CultureInfo.InvariantCulture);

            if (chart.XAxisType == "Date")
            {
                if (DateTime.TryParse(
                    point.XValue,
                    out DateTime date))
                {
                    dtpXValue.Value = date;
                }
            }
            else
            {
                txtXValue.Text = point.XValue;
            }
        }

        private void ConfigureXAxis()
        {
            if (chart.XAxisType == "Date")
            {
                txtXValue.Visible = false;
                dtpXValue.Visible = true;
            }
            else
            {
                txtXValue.Visible = true;
                dtpXValue.Visible = false;
            }
        }

        // =========================================================
        // СОХРАНЕНИЕ
        // =========================================================

        private void BtnSave_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateInput())
                return;

            if (point == null)
            {
                point = new DataPoint
                {
                    ChartId = chart.Id
                };
            }

            string xValue;

            if (chart.XAxisType == "Date")
            {
                xValue = dtpXValue.Value
                    .ToString("yyyy-MM-dd");
            }
            else
            {
                xValue = txtXValue.Text.Trim();

                if (string.IsNullOrWhiteSpace(xValue))
                {
                    MessageBox.Show(
                        "Введите значение X.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            string yText = txtYValue.Text.Trim().Replace(',', '.');

            if (!double.TryParse(
                yText,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double yValue))
            {
                MessageBox.Show(
                    "Введите корректное числовое значение Y.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (point == null)
            {
                point = new DataPoint();
            }

            point.ChartId = chart.Id;
            point.XValue = xValue;
            point.YValue = yValue;

            ResultPoint = point;

            DialogResult = DialogResult.OK;
            Close();
        }

        // =========================================================
        // ОТМЕНА
        // =========================================================

        private void BtnCancel_Click(
            object sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        // =========================================================
        // ПРОВЕРКА
        // =========================================================

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(
                txtXValue.Text))
            {
                MessageBox.Show(
                    "Введите значение X.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtXValue.Focus();

                return false;
            }

            string yText =
                txtYValue.Text.Trim()
                    .Replace(',', '.');

            if (!double.TryParse(
                yText,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double y))
            {
                MessageBox.Show(
                    "Введите корректное числовое значение Y.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtYValue.Focus();

                return false;
            }

            return true;
        }
    }
}