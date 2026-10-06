namespace ProgressVisualizer.Forms
{
    partial class ChartForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;

        private Label lblName;
        private TextBox txtName;

        private Label lblDescription;
        private TextBox txtDescription;

        private GroupBox grpXAxis;

        private Label lblXAxisName;
        private TextBox txtXAxisName;

        private Label lblXAxisType;
        private ComboBox cmbXAxisType;

        private GroupBox grpYAxis;

        private Label lblYAxisName;
        private TextBox txtYAxisName;

        private Label lblYAxisUnit;
        private TextBox txtYAxisUnit;

        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components =
                new System.ComponentModel.Container();

            // =====================================================
            // FORM
            // =====================================================

            this.SuspendLayout();

            this.Text = "Создание графика";

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.ClientSize =
                new System.Drawing.Size(600, 600);

            this.MinimumSize =
                new System.Drawing.Size(600, 600);

            this.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            this.MaximizeBox = false;

            // =====================================================
            // ЗАГОЛОВОК
            // =====================================================

            lblTitle = new Label();

            lblTitle.Text =
                "Параметры графика";

            lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    16F,
                    System.Drawing.FontStyle.Bold);

            lblTitle.Location =
                new System.Drawing.Point(25, 20);

            lblTitle.Size =
                new System.Drawing.Size(500, 35);

            // =====================================================
            // НАЗВАНИЕ
            // =====================================================

            lblName = new Label();

            lblName.Text =
                "Название графика:";

            lblName.Location =
                new System.Drawing.Point(25, 75);

            lblName.Size =
                new System.Drawing.Size(200, 25);

            txtName = new TextBox();

            txtName.Location =
                new System.Drawing.Point(25, 100);

            txtName.Size =
                new System.Drawing.Size(530, 30);

            // =====================================================
            // ОПИСАНИЕ
            // =====================================================

            lblDescription = new Label();

            lblDescription.Text =
                "Описание:";

            lblDescription.Location =
                new System.Drawing.Point(25, 140);

            lblDescription.Size =
                new System.Drawing.Size(200, 25);

            txtDescription = new TextBox();

            txtDescription.Location =
                new System.Drawing.Point(25, 165);

            txtDescription.Size =
                new System.Drawing.Size(530, 70);

            txtDescription.Multiline = true;

            txtDescription.ScrollBars =
                ScrollBars.Vertical;

            // =====================================================
            // X AXIS
            // =====================================================

            grpXAxis = new GroupBox();

            grpXAxis.Text =
                "Ось X";

            grpXAxis.Location =
                new System.Drawing.Point(25, 255);

            grpXAxis.Size =
                new System.Drawing.Size(530, 120);

            // Название X
            lblXAxisName = new Label();

            lblXAxisName.Text =
                "Название:";

            lblXAxisName.Location =
                new System.Drawing.Point(15, 30);

            lblXAxisName.Size =
                new System.Drawing.Size(100, 25);

            txtXAxisName = new TextBox();

            txtXAxisName.Location =
                new System.Drawing.Point(120, 27);

            txtXAxisName.Size =
                new System.Drawing.Size(380, 30);

            // Тип X
            lblXAxisType = new Label();

            lblXAxisType.Text =
                "Тип данных:";

            lblXAxisType.Location =
                new System.Drawing.Point(15, 70);

            lblXAxisType.Size =
                new System.Drawing.Size(100, 25);

            cmbXAxisType = new ComboBox();

            cmbXAxisType.Location =
                new System.Drawing.Point(120, 67);

            cmbXAxisType.Size =
                new System.Drawing.Size(200, 30);

            cmbXAxisType.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbXAxisType.Items.Add("Number");
            cmbXAxisType.Items.Add("Text");
            cmbXAxisType.Items.Add("Date");

            cmbXAxisType.SelectedIndex = 0;

            // =====================================================
            // Y AXIS
            // =====================================================

            grpYAxis = new GroupBox();

            grpYAxis.Text =
                "Ось Y";

            grpYAxis.Location =
                new System.Drawing.Point(25, 390);

            grpYAxis.Size =
                new System.Drawing.Size(530, 120);

            // Название Y
            lblYAxisName = new Label();

            lblYAxisName.Text =
                "Название:";

            lblYAxisName.Location =
                new System.Drawing.Point(15, 30);

            lblYAxisName.Size =
                new System.Drawing.Size(100, 25);

            txtYAxisName = new TextBox();

            txtYAxisName.Location =
                new System.Drawing.Point(120, 27);

            txtYAxisName.Size =
                new System.Drawing.Size(380, 30);

            // Единица Y
            lblYAxisUnit = new Label();

            lblYAxisUnit.Text =
                "Единица:";

            lblYAxisUnit.Location =
                new System.Drawing.Point(15, 70);

            lblYAxisUnit.Size =
                new System.Drawing.Size(100, 25);

            txtYAxisUnit = new TextBox();

            txtYAxisUnit.Location =
                new System.Drawing.Point(120, 67);

            txtYAxisUnit.Size =
                new System.Drawing.Size(200, 30);

            // =====================================================
            // КНОПКИ
            // =====================================================

            btnSave = new Button();

            btnSave.Text =
                "Сохранить";

            btnSave.Location =
                new System.Drawing.Point(350, 530);

            btnSave.Size =
                new System.Drawing.Size(100, 35);

            btnSave.DialogResult =
                DialogResult.None;

            btnSave.Click +=
                new System.EventHandler(
                    BtnSave_Click);

            btnCancel = new Button();

            btnCancel.Text =
                "Отмена";

            btnCancel.Location =
                new System.Drawing.Point(455, 530);

            btnCancel.Size =
                new System.Drawing.Size(100, 35);

            btnCancel.Click +=
                new System.EventHandler(
                    BtnCancel_Click);

            // =====================================================
            // ДОБАВЛЕНИЕ CONTROLS
            // =====================================================

            grpXAxis.Controls.Add(
                lblXAxisName);

            grpXAxis.Controls.Add(
                txtXAxisName);

            grpXAxis.Controls.Add(
                lblXAxisType);

            grpXAxis.Controls.Add(
                cmbXAxisType);

            grpYAxis.Controls.Add(
                lblYAxisName);

            grpYAxis.Controls.Add(
                txtYAxisName);

            grpYAxis.Controls.Add(
                lblYAxisUnit);

            grpYAxis.Controls.Add(
                txtYAxisUnit);

            this.Controls.Add(lblTitle);

            this.Controls.Add(lblName);
            this.Controls.Add(txtName);

            this.Controls.Add(lblDescription);
            this.Controls.Add(txtDescription);

            this.Controls.Add(grpXAxis);
            this.Controls.Add(grpYAxis);

            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}