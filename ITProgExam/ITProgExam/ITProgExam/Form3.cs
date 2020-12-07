using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITProgExam
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            MethCalls.InitializeDB();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string showRecordsQuery = "Select * From itprogtest.workexperience WHERE ID = '"+Varcalls.SelectedWorkID+"';";

            MySqlCommand MyCommand2 = new MySqlCommand(showRecordsQuery, Varcalls.dbConn);

            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = MyCommand2;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            dtWorkRecords.DataSource = dTable;
        }

        private void dtWorkRecords_SelectionChanged(object sender, EventArgs e)
        {
            //txtCompName.Text = dtWorkRecords.Rows[dtWorkRecords.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            //txtPosition.Text = dtWorkRecords.Rows[dtWorkRecords.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
            //cmbStartedMonth.Text = dtWorkRecords.Rows[dtWorkRecords.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
            //cmbStartedYear.Text = dtWorkRecords.Rows[dtWorkRecords.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();

            this.Hide();
            fr2.ShowDialog();
            this.Close();
        }
    }
}
