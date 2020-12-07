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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            MethCalls.InitializeDB();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            txtID.Text = Varcalls.UpdateID.ToString();
            txtFirstName.Text = Varcalls.UpdateFirstName;
            txtMiddleName.Text = Varcalls.UpdateMiddleName;
            txtLastName.Text = Varcalls.UpdateLastName;
            cmbDay.Text = Varcalls.UpdateBirthDay;
            cmbMonth.Text = Varcalls.UpdateBirthMonth;
            cmbYear.Text = Varcalls.UpdateBirthYear;
            txtAddress.Text = Varcalls.UpdateAddress;
        }

        private void btnwback_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();

            this.Hide();
            fr2.ShowDialog();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Birth = cmbMonth.Text + "/" + cmbDay.Text + "/" + cmbYear.Text;
            string educ = cmbEducation.Text;


            string UpdateInfoQuery = "update itprogtest.personaldetails set FirstName = '"+this.txtFirstName.Text+"',MiddleName='"+this.txtMiddleName.Text+"',LastName='"+this.txtLastName.Text+"',Birthdate='"+Birth+"',Address='"+this.txtAddress.Text+"',EducationalAttainment ='"+educ+"' WHERE ID = '"+this.txtID.Text+"';";

            string UpdateInfoQuery2 = "update itprogtest.personaldetails set FirstName = '" + this.txtFirstName.Text + "',MiddleName='" + this.txtMiddleName.Text + "',LastName='" + this.txtLastName.Text + "',Address='" + this.txtAddress.Text + "' WHERE ID = '" + this.txtID.Text + "';";

            if (cmbDay.SelectedIndex > -1 && cmbMonth.SelectedIndex > -1 && cmbYear.SelectedIndex > -1 && cmbEducation.SelectedIndex > -1)
            {
                try
                {
                    MySqlCommand MyCommand2 = new MySqlCommand(UpdateInfoQuery, Varcalls.dbConn);
                    MySqlDataReader MyReader2;
                    Varcalls.dbConn.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Data Updated");
                    while (MyReader2.Read())
                    {
                    }
                    Varcalls.dbConn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmbDay.SelectedIndex < 0 && cmbMonth.SelectedIndex < 0 && cmbYear.SelectedIndex < 0 && cmbEducation.SelectedIndex < 0)
            {
                try
                {
                    MySqlCommand MyCommand2 = new MySqlCommand(UpdateInfoQuery2, Varcalls.dbConn);
                    MySqlDataReader MyReader2;
                    Varcalls.dbConn.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Data Updated");
                    while (MyReader2.Read())
                    {
                    }
                    Varcalls.dbConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please complete the information", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
