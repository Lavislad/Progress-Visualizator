using ProgressVisualizer.Data;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DBManager db = new DBManager("progress.db");

            using var connection = db.GetConnection();
        }
    }
}
