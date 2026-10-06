using ProgressVisualizer.Models;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProgressVisualizer.Forms
{
    public partial class ChartForm : Form
    {
        // График, который редактируем.
        // null означает создание нового графика.
        private Chart? chart;

        public Chart? ResultChart { get; private set; }

        // Создание нового графика
        public ChartForm()
        {
            InitializeComponent();

            chart = null;

            cmbXAxisType.SelectedIndex = 0;
        }

        // Редактирование существующего графика
        public ChartForm(Chart chart)
        {
            InitializeComponent();

            this.chart = chart;

            LoadChartData();
        }

        // =========================================================
        // ЗАГРУЗКА ДАННЫХ ГРАФИКА
        // =========================================================

        private void LoadChartData()
        {
            if (chart == null)
                return;

            txtName.Text = chart.Name;
            txtDescription.Text = chart.Description;

            txtXAxisName.Text = chart.XAxisName;

            if (chart.XAxisType == "Text")
                cmbXAxisType.SelectedIndex = 1;
            else
                cmbXAxisType.SelectedIndex = 0;

            txtYAxisName.Text = chart.YAxisName;
            txtYAxisUnit.Text = chart.YAxisUnit;
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

            if (chart == null)
            {
                // Создание нового графика
                chart = new Chart
                {
                    CreatedDate = DateTime.Now
                };
            }

            chart.Name = txtName.Text.Trim();

            chart.Description =
                txtDescription.Text.Trim();

            chart.XAxisName =
                txtXAxisName.Text.Trim();

            chart.XAxisType =
                cmbXAxisType.SelectedItem.ToString();

            chart.YAxisName =
                txtYAxisName.Text.Trim();

            chart.YAxisUnit =
                txtYAxisUnit.Text.Trim();

            ResultChart = chart;

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
            DialogResult = DialogResult.Cancel;

            Close();
        }

        // =========================================================
        // ПРОВЕРКА ДАННЫХ
        // =========================================================

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(
                    "Введите название графика.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtName.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtXAxisName.Text))
            {
                MessageBox.Show(
                    "Введите название оси X.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtXAxisName.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtYAxisName.Text))
            {
                MessageBox.Show(
                    "Введите название оси Y.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtYAxisName.Focus();

                return false;
            }

            if (cmbXAxisType.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Выберите тип оси X.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbXAxisType.Focus();

                return false;
            }

            return true;
        }
    }
}