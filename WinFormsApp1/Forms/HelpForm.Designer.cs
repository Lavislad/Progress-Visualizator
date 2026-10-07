using System.Drawing;
using System.Windows.Forms;

namespace ProgressVisualizer.Forms
{
    partial class HelpForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private RichTextBox rtbHelp;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            rtbHelp = new RichTextBox();
            btnClose = new Button();

            SuspendLayout();

            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 55;
            lblTitle.Text = "Справка по программе";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Font = new Font(
                "Segoe UI",
                16F,
                FontStyle.Bold);

            // 
            // rtbHelp
            // 
            rtbHelp.Location = new Point(20, 70);
            rtbHelp.Size = new Size(640, 420);
            rtbHelp.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            rtbHelp.ReadOnly = true;
            rtbHelp.BorderStyle = BorderStyle.FixedSingle;
            rtbHelp.BackColor = SystemColors.Window;
            rtbHelp.Font = new Font(
                "Segoe UI",
                10F);

            rtbHelp.Text =
                @"НАЗНАЧЕНИЕ ПРОГРАММЫ

                «Визуализатор прогресса» предназначен для создания,
                хранения, редактирования и визуального представления
                данных о прогрессе пользователя в виде графиков.


                СОЗДАНИЕ ГРАФИКА

                Для создания нового графика нажмите кнопку
                «Создать график».

                В открывшейся форме необходимо указать:
                • название графика;
                • описание;
                • название оси X;
                • тип оси X;
                • название оси Y;
                • единицу измерения оси Y.

                После заполнения данных нажмите «Сохранить».


                ТИПЫ ОСИ X

                Программа поддерживает три типа данных для оси X:

                • Число — используется для числовых значений;
                • Текст — используется для произвольных подписей;
                • Дата — используется для указания дат.

                Значения оси Y всегда должны быть числовыми.


                РАБОТА С ТОЧКАМИ

                После выбора графика в нижней части окна
                отображается таблица его точек.

                Для работы с точками доступны кнопки:

                • «Добавить» — добавить новую точку;
                • «Изменить» — изменить выбранную точку;
                • «Удалить» — удалить выбранную точку.

                После изменения данных график автоматически
                перестраивается.


                ПОИСК ГРАФИКА

                Для поиска сохранённого графика используйте
                поле поиска над списком графиков.

                Поиск выполняется по названию графика.


                РЕДАКТИРОВАНИЕ ГРАФИКА

                Выберите график в списке и нажмите
                «Изменить график».

                После внесения изменений нажмите «Сохранить».


                УДАЛЕНИЕ ГРАФИКА

                Для удаления выберите график и нажмите
                «Удалить график».

                Перед удалением программа запрашивает
                подтверждение операции.


                ПОСТРОЕНИЕ ГРАФИКА

                После выбора графика его данные отображаются
                в виде графика в центральной области программы.

                При добавлении, изменении или удалении точек
                график обновляется автоматически.


                СОХРАНЕНИЕ ДАННЫХ

                Все созданные графики и их точки сохраняются
                в локальной базе данных программы.

                После повторного запуска программы сохранённые
                графики остаются доступными.";
            // 
            // btnClose
            // 
            btnClose.Text = "Закрыть";
            btnClose.Size = new Size(100, 35);
            btnClose.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Right;

            btnClose.Location = new Point(
                560,
                505);

            btnClose.Click += BtnClose_Click;
            // 
            // HelpForm
            // 
            AutoScaleDimensions =
                new SizeF(7F, 15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(680, 560);

            Controls.Add(rtbHelp);
            Controls.Add(btnClose);
            Controls.Add(lblTitle);

            MinimumSize =
                new Size(600, 500);

            StartPosition =
                FormStartPosition.CenterParent;

            Text = "Справка";

            ResumeLayout(false);
        }
    }
}