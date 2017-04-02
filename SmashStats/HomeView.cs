using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmashStats
{
    public partial class HomeView : UserControl
    {
        public HomePresenter Presenter { get; set; }
        private List<Tuple<string, string>> data;
        public List<Tuple<string, string>> Data
        {
            get { return data; }
            set { data = value;
                BaseDataDisplay.Rows.Clear();
                foreach(var dataTuple in data)
                {
                    BaseDataDisplay.Rows.Add(dataTuple.Item1, dataTuple.Item2);
                }
            }
        }
            
        public HomeView()
        {
            InitializeComponent();
        }

        void SetUpBaseDataDisplay()
        {
            BaseDataDisplay.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tournament" });
            BaseDataDisplay.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Date" });
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HomeView_Load(object sender, EventArgs e)
        {
            SetUpBaseDataDisplay();
            Presenter.LoadBaseData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.LoadTournamentsByDate(int.Parse(comboBox1.SelectedItem.ToString()));
        }
    }
}
