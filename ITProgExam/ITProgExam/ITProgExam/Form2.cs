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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            MethCalls.InitializeDB();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string showRecordsQuery = "Select * From itprogtest.personaldetails;";

            MySqlCommand MyCommand2 = new MySqlCommand(showRecordsQuery, Varcalls.dbConn);

            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = MyCommand2;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            dtRecords.DataSource = dTable;
        }

        private void btnViewWork_Click(object sender, EventArgs e)
        {
            if (dtRecords.SelectedCells.Count > 0)
            {

                Varcalls.SelectedWorkID = Int32.Parse(dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[0].Value.ToString());


                Form3 f3 = new Form3();

                this.Hide();
                f3.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a row", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dtRecords_SelectionChanged(object sender, EventArgs e)
        {
            char d;
            char m;
            char y;
            int mcount = 0;
            int ycount = 0;

            Varcalls.UpdateID = Int32.Parse(dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            Varcalls.UpdateFirstName = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            Varcalls.UpdateMiddleName = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
            Varcalls.UpdateLastName = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
            for (int i = 0; i < dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[4].Value.ToString().Length; i++ )
            {
                d = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[4].Value.ToString()[i];

                if(!d.Equals("/"))
                {
                    Varcalls.UpdateBirthDay = Varcalls.UpdateBirthDay + d;
                }
                else if (d.Equals("/"))
                {
                    break;
                }
            }

            for (int i = 0; i < dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[4].Value.ToString().Length; i++)
            {
                m = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[4].Value.ToString()[i];

                if (m.Equals("/"))
                {
                    mcount++;
                }

                if (mcount == 1)
                {
                    Varcalls.UpdateBirthMonth = Varcalls.UpdateBirthMonth + m;
                }
                else if (mcount == 2)
                {
                    break;
                }
            }

            for (int i = 0; i < dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[4].Value.ToString().Length; i++)
            {
                y = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[4].Value.ToString()[i];

                if (y.Equals("/"))
                {
                    ycount++;
                }

                if (ycount == 2)
                {
                    Varcalls.UpdateBirthMonth = Varcalls.UpdateBirthMonth + y;
                }
            }

            Varcalls.UpdateAddress = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[5].Value.ToString();
            
            
            //txtCompName.Text = dtWorkRecords.Rows[dtWorkRecords.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            //txtPosition.Text = dtWorkRecords.Rows[dtWorkRecords.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
            //cmbStartedMonth.Text = dtWorkRecords.Rows[dtWorkRecords.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
            //cmbStartedYear.Text = dtWorkRecords.Rows[dtWorkRecords.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dtRecords.SelectedCells.Count > 0)
            {
                
                char d;
                char m;
                char y;
                int dcount = 0;
                int mcount = 0;
                int ycount = 0;

                Varcalls.UpdateID = Int32.Parse(dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                Varcalls.UpdateFirstName = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                Varcalls.UpdateMiddleName = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
                Varcalls.UpdateLastName = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[3].Value.ToString();

                for (int i = 0; i < dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[4].Value.ToString().Length; i++)
                {
                    m = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[4].Value.ToString()[i];

                    if (m.Equals('/'))
                    {
                       
                        mcount = mcount + 1;
                    }

                    if (mcount == 0)
                    {
                        Varcalls.UpdateBirthMonth = Varcalls.UpdateBirthMonth + m;
                        if (mcount == 1)
                        {
                            break;
                        }
                    }
                    
                }

                for (int i = 0; i < dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[4].Value.ToString().Length; i++)
                {
                    d = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[4].Value.ToString()[i];

                    if (d.Equals('/'))
                    {
                        dcount++;
                    }

                    if (mcount == 1)
                    {
                        Varcalls.UpdateBirthDay = Varcalls.UpdateBirthDay + d;
                    }
                    if (dcount == 2)
                    {
                        break;
                    }
                }
                 

                for (int i = 0; i < dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[4].Value.ToString().Length; i++)
                {
                    y = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[4].Value.ToString()[i];

                    if (y.Equals('/'))
                    {
                        ycount++;
                    }

                    if (ycount >= 2)
                    {
                        Varcalls.UpdateBirthMonth = Varcalls.UpdateBirthMonth + y;
                    }
                }

                Varcalls.UpdateAddress = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[5].Value.ToString();
                Varcalls.UpdateEducation = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[6].Value.ToString();


                //MessageBox.Show(Varcalls.UpdateBirthDay);

                Form4 fr4 = new Form4();

                this.Hide();
                fr4.ShowDialog();
                this.Close();
            
            }
            else
            {
                MessageBox.Show("Please select a row", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string DeleteID = dtRecords.Rows[dtRecords.SelectedCells[0].RowIndex].Cells[0].Value.ToString();

            string Query = "delete from itprogtest.personaldetails where ID='" + DeleteID + "';";
            
            MySqlCommand MyCommand2 = new MySqlCommand(Query, Varcalls.dbConn);
            MySqlDataReader MyReader2;
            Varcalls.dbConn.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data Deleted");

            while (MyReader2.Read())
            {

            }
            Varcalls.dbConn.Close();

            refreshDT();
        }

        public void refreshDT()
        {
            string showRecordsQuery = "Select * From itprogtest.personaldetails;";

            MySqlCommand MyCommand2 = new MySqlCommand(showRecordsQuery, Varcalls.dbConn);

            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = MyCommand2;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            dtRecords.DataSource = dTable;
        }

            
    }
}
