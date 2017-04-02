using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SmashStats
{
    public partial class MainForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public MainForm()
        {
            InitializeComponent();
            //Initialize();

        }

        public void LoadView (UserControl view, DockStyle dockStyle)
        {
            view.Dock = dockStyle;
            this.Controls.Add(view);
        }

        public void RemoveView (UserControl view)
        {
            this.Controls.Remove(view);
        }

        private void MainForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                Console.WriteLine("mousedown");
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        /*void Initialize()
        {
            InitDataView();
            //CreateYears();
            List<string> dates = new List<string>();
            GetYears();
            SQLiteConnection connection = new SQLiteConnection("Data Source=Resources/melee.sqlite;Version=3;");
            connection.Open();
            
            string sql = "SELECT tournament_name, tournament_date FROM Tournament";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                dataGridView1.Rows.Add(reader["tournament_name"], reader["tournament_date"]);
                //dates.Add((string)reader["date"]);
            }

            connection.Close();

            /*foreach (string date in dates)
            {
                DateTime newDate = DateTime.Parse(date);
                Console.WriteLine(newDate);
            }*/
        /*}

        List<DateTime> GetYears()
        {
            List<DateTime> years = new List<DateTime>();

            return years;
        }

        void InitDataView ()
        {
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tournament" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Date" });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int year = int.Parse(comboBox1.SelectedItem.ToString());
            Console.WriteLine(year);
            SQLiteConnection connection = new SQLiteConnection("Data Source=Resources/melee.sqlite;Version=3;");
            connection.Open();

            // string sql = String.Format("SELECT tournament_name, tournament_date FROM Tournament WHERE strftime('%y', tournament_date) = {0};", year);
            string sql = String.Format("SELECT tournament_name, tournament_date FROM TOURNAMENT WHERE CAST(strftime('%Y', tournament_date) AS integer) = {0}", year);
            //string sql = String.Format("SELECT tournament_name, strftime('%Y', tournament_date) as date");
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                dataGridView1.Rows.Add(reader["tournament_name"], reader["tournament_date"]);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }*/
    }
}
