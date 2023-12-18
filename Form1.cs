using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Lab
{
    public partial class FrmClubRegistration : Form
    {
        //declare the following variables and datatypes
        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentID;

        //Refresh Button
        private void button3_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        //Update Button
        private void button2_Click(object sender, EventArgs e)
        {
            FrmUpdateMember form = new FrmUpdateMember();
            form.ShowDialog();
        }

       
        //Register Button
        private void button1_Click(object sender, EventArgs e)
        {
            clubRegistrationQuery.RegisterStudent(RegistrationID(),int.Parse
            (textBox1.Text), textBox3.Text, textBox4.Text, textBox2.Text, int.Parse(textBox5.Text),
            comboBox2.SelectedItem.ToString(), comboBox1.SelectedItem.ToString());
        }



        
        //create method named RefreshListOfClubMembers
        public void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }

        //create a method named RegistrationID
        public int RegistrationID()
        {
            return count++;
        }


        public FrmClubRegistration()
        {
            InitializeComponent();
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            //initializing...
            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();
        }
    }
}
