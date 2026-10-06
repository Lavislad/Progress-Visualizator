namespace ProgressVisualizer.Forms
{
    partial class DataPointForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;

        private Label lblXTitle;
        private TextBox txtXValue;

        private Label lblYTitle;
        private TextBox txtYValue;

        private Button btnSave;
        private Button btnCancel;

        private DateTimePicker dtpXValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
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

            this.Text =
                "Добавление точки";

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.ClientSize =
                new System.Drawing.Size(450, 300);

            this.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // =====================================================
            // TITLE
            // =====================================================

            lblTitle = new Label();

            lblTitle.Text =
                "Данные точки";

            lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    16F,
                    System.Drawing.FontStyle.Bold);

            lblTitle.Location =
                new System.Drawing.Point(25, 20);

            lblTitle.Size =
                new System.Drawing.Size(
                    380,
                    35);

            //
            // dtpXValue
            //

            dtpXValue = new DateTimePicker();

            dtpXValue.Format = DateTimePickerFormat.Short;
            dtpXValue.Location = new Point(150, 70);
            dtpXValue.Size = new Size(250, 27);
            dtpXValue.Visible = false;

            Controls.Add(dtpXValue);

            // =====================================================
            // X
            // =====================================================

            lblXTitle = new Label();

            lblXTitle.Text =
                "Значение X:";

            lblXTitle.Location =
                new System.Drawing.Point(25, 75);

            lblXTitle.Size =
                new System.Drawing.Size(
                    380,
                    25);

            txtXValue = new TextBox();

            txtXValue.Location =
                new System.Drawing.Point(25, 100);

            txtXValue.Size =
                new System.Drawing.Size(
                    380,
                    30);

            // =====================================================
            // Y
            // =====================================================

            lblYTitle = new Label();

            lblYTitle.Text =
                "Значение Y:";

            lblYTitle.Location =
                new System.Drawing.Point(25, 145);

            lblYTitle.Size =
                new System.Drawing.Size(
                    380,
                    25);

            txtYValue = new TextBox();

            txtYValue.Location =
                new System.Drawing.Point(25, 170);

            txtYValue.Size =
                new System.Drawing.Size(
                    380,
                    30);

            // =====================================================
            // SAVE
            // =====================================================

            btnSave = new Button();

            btnSave.Text =
                "Сохранить";

            btnSave.Location =
                new System.Drawing.Point(200, 230);

            btnSave.Size =
                new System.Drawing.Size(
                    100,
                    35);

            btnSave.Click +=
                new System.EventHandler(
                    BtnSave_Click);

            // =====================================================
            // CANCEL
            // =====================================================

            btnCancel = new Button();

            btnCancel.Text =
                "Отмена";

            btnCancel.Location =
                new System.Drawing.Point(305, 230);

            btnCancel.Size =
                new System.Drawing.Size(
                    100,
                    35);

            btnCancel.Click +=
                new System.EventHandler(
                    BtnCancel_Click);

            // =====================================================
            // ADD CONTROLS
            // =====================================================

            this.Controls.Add(lblTitle);

            this.Controls.Add(lblXTitle);
            this.Controls.Add(txtXValue);

            this.Controls.Add(lblYTitle);
            this.Controls.Add(txtYValue);

            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);

            this.AcceptButton =
                btnSave;

            this.CancelButton =
                btnCancel;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}