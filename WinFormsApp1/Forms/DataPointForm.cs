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

            point = null;

            lblXTitle.Text =
                $"{chart.XAxisName}:";

            lblYTitle.Text =
                $"{chart.YAxisName}:";

            Text = "Добавление точки";
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

            txtXValue.Text =
                point.XValue;

            txtYValue.Text =
                point.YValue.ToString(
                    CultureInfo.InvariantCulture);

            lblXTitle.Text =
                $"{chart.XAxisName}:";

            lblYTitle.Text =
                $"{chart.YAxisName}:";

            Text = "Изменение точки";
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

            point.XValue =
                txtXValue.Text.Trim();

            point.YValue =
                double.Parse(
                    txtYValue.Text.Trim(),
                    CultureInfo.InvariantCulture);

            ResultPoint = point;

            DialogResult =
                DialogResult.OK;

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