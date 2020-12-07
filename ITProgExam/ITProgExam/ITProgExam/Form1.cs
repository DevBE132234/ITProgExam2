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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MethCalls.InitializeDB();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtCompName.Enabled = false;
            txtPosition.Enabled = false;
            cmbStartedMonth.Enabled = false;
            cmbStartedYear.Enabled = false;
            cmbEndedMonth.Enabled = false;
            cmbEndedYear.Enabled = false;
        }

        private void btnSubmitProf_Click(object sender, EventArgs e)
        {

            if ((!txtCompName.Text.Equals(String.Empty) && !txtPosition.Text.Equals(String.Empty) && !cmbStartedMonth.Text.Equals(String.Empty) && !cmbStartedYear.Text.Equals(String.Empty) && !chkPresent.Checked) || (chkPresent.Checked))
            {
                int WorkID = Int32.Parse(txtID.Text.ToString());

                string startedDate = cmbStartedMonth.Text + "-" + cmbStartedYear.Text;
                string endedDate = "";

                if (chkPresent.Checked == true)
                {
                    endedDate = "Present";
                }
                else if (!chkPresent.Checked)
                {
                    endedDate = cmbEndedMonth.Text + "-" + cmbEndedYear.Text;
                }

                string workQuery = "INSERT INTO itprogtest.workexperience (ID,CompanyName,Position,DateStarted,DateEnded) VALUES ('" + WorkID.ToString() + "','" + this.txtCompName.Text + "','" + this.txtPosition.Text + "','" + startedDate + "','" + endedDate + "');";

                try
                {
                    Varcalls.dbConn.Open();
                    MySqlCommand cmd = new MySqlCommand(workQuery, Varcalls.dbConn);
                    MySqlDataReader reader;

                    //MessageBox.Show("Work Experience was Saved");

                    reader = cmd.ExecuteReader();

                    ClearWork();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Varcalls.dbConn.Close();
            }

            if(txtID.Text.Equals(String.Empty) || txtFirstName.Text.Equals(String.Empty) || txtMiddleName.Text.Equals(String.Empty) || txtLastName.Text.Equals(String.Empty) || txtAddress.Text.Equals(String.Empty) || cmbMonth.Text.Equals(String.Empty) || cmbDay.Text.Equals(String.Empty) || cmbYear.Text.Equals(String.Empty) || cmbEducation.Text.Equals(String.Empty))
            {
                MessageBox.Show("Fill up all Information", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else{

            int ID = Int32.Parse(txtID.Text);

            string birthDate = cmbMonth.Text + "/" + cmbDay.Text + "/" + cmbYear.Text;
            string EducationAtt = cmbEducation.Text;

            string insQuery = "INSERT INTO itprogtest.personaldetails (ID,FirstName,MiddleName,LastName,Birthdate,Address,EducationalAttainment) VALUES ('" + ID + "','" + this.txtFirstName.Text + "','" + this.txtMiddleName.Text + "','" + this.txtLastName.Text + "','" + birthDate + "','" + this.txtAddress.Text + "','" + EducationAtt + "');";

            try
            {
                Varcalls.dbConn.Open();
                MySqlCommand cmd = new MySqlCommand(insQuery, Varcalls.dbConn);
                MySqlDataReader reader;

                MessageBox.Show("Profile was Saved");

                reader = cmd.ExecuteReader();

                ClearPersonalInfo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Varcalls.dbConn.Close();

            }

            
        }

        private void btnGenerateID_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            Varcalls.randID = rnd.Next(10000);

            string searchIDQuery = "SELECT * FROM itprogtest.personaldetails WHERE ID = '" + Varcalls.randID.ToString() + "'";

            try
            {

                MySqlCommand cmd = new MySqlCommand(searchIDQuery,Varcalls.dbConn);

                MySqlDataReader rdr;
                Varcalls.dbConn.Open();
                rdr = cmd.ExecuteReader();

                int count = 0;

                while(rdr.Read())
                {

                    count = count + 1;

                }

                if(count >= 1)
                {
                    Varcalls.randID = rnd.Next(10000);
                }
                else
                {
                    txtID.Text = Varcalls.randID.ToString();
                }

                enabledField();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Varcalls.dbConn.Close();
        }

        public void ClearPersonalInfo()
        {

            txtID.Text = String.Empty;
            txtFirstName.Text = String.Empty;
            txtMiddleName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtAddress.Text = String.Empty;
            cmbMonth.SelectedIndex = -1;
            cmbDay.SelectedIndex = -1;
            cmbYear.SelectedIndex = -1;
            cmbEducation.SelectedIndex = -1;
            txtCompName.Text = String.Empty;
            txtPosition.Text = String.Empty;
            cmbStartedMonth.SelectedIndex = -1;
            cmbStartedYear.SelectedIndex = -1;
            cmbEndedMonth.SelectedIndex = -1;
            cmbEndedYear.SelectedIndex = -1;
        }

        public void ClearWork()
        {
            txtCompName.Text = String.Empty;
            txtPosition.Text = String.Empty;
            cmbStartedMonth.SelectedIndex = -1;
            cmbStartedYear.SelectedIndex = -1;
            cmbEndedMonth.SelectedIndex = -1;
            cmbEndedYear.SelectedIndex = -1;
        }

        public void enabledField()
        {
            if (!txtID.Text.Equals(String.Empty))
            {
                txtCompName.Enabled = true;
                txtPosition.Enabled = true;
                cmbStartedMonth.Enabled = true;
                cmbStartedYear.Enabled = true;
                cmbEndedMonth.Enabled = true;
                cmbEndedYear.Enabled = true;
           }else
            {
                txtCompName.Enabled = false;
                txtPosition.Enabled = false;
                cmbStartedMonth.Enabled = false;
                cmbStartedYear.Enabled = false;
                cmbEndedMonth.Enabled = false;
                cmbEndedYear.Enabled = false;
            }
        }

        private void btnAddWE_Click(object sender, EventArgs e)
        {
            if (txtCompName.Text.Equals(String.Empty) || txtPosition.Text.Equals(String.Empty) || cmbStartedMonth.Text.Equals(String.Empty) || cmbStartedYear.Text.Equals(String.Empty) && cmbEndedMonth.Text.Equals(String.Empty) && cmbEndedYear.Text.Equals(String.Empty) && !chkPresent.Checked)
            {
                MessageBox.Show("Fill up all Information", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!txtID.Text.Equals(String.Empty))
                {
                    int WorkID = Int32.Parse(txtID.Text);

                    string startedDate = cmbStartedMonth.Text + "-" + cmbStartedYear.Text;
                    string endedDate = "";

                    if (chkPresent.Checked == true)
                    {
                        endedDate = "Present";
                    }
                    else if(!chkPresent.Checked)
                    {
                        endedDate = cmbEndedMonth.Text + "-" + cmbEndedYear.Text;
                    }

                    string workQuery = "INSERT INTO itprogtest.workexperience (ID,CompanyName,Position,DateStarted,DateEnded) VALUES ('" + WorkID.ToString() + "','" + this.txtCompName.Text + "','" + this.txtPosition.Text + "','"+startedDate+"','"+endedDate+"');";

                    try
                    {
                        Varcalls.dbConn.Open();
                        MySqlCommand cmd = new MySqlCommand(workQuery, Varcalls.dbConn);
                        MySqlDataReader reader;

                        MessageBox.Show("Work Experience was Saved");

                        reader = cmd.ExecuteReader();

                        ClearWork();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    Varcalls.dbConn.Close();
                }
            }
        }

        private void chkPresent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPresent.Checked)
            {
                cmbEndedMonth.Enabled = false;
                cmbEndedYear.Enabled = false;
                cmbEndedMonth.Text = String.Empty;
                cmbEndedYear.Text = String.Empty;
            }
            else if (!chkPresent.Checked)
            {
                cmbEndedMonth.Enabled = true;
                cmbEndedYear.Enabled = true;
            }
        }

        private void btnViewRecords_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            this.Hide();
            
            f2.ShowDialog();
            this.Close();
        }
    }
}
