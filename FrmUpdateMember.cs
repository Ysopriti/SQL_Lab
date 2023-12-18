using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace SQL_Lab
{
    public partial class FrmUpdateMember : Form
    {

        private SqlConnection sqlConnection = new SqlConnection();
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;
        private SqlDataReader sqlReader;

        public DataTable dataTable;
        public BindingSource bindingSource;
        private string connectionString;

        ClubRegistrationQuery clubRegistrationQuery = new ClubRegistrationQuery();


        public FrmUpdateMember()
        {
            InitializeComponent();
            clubRegistrationQuery = new ClubRegistrationQuery();
            connectionString = "Data Source = DESKTOP-GB9TLRK\\SQLEXPRESS; Initial Catalog = ClubDB; Integrated Security = True; Pooling = False";
            sqlConnection = new SqlConnection(connectionString);
            bindingSource = new BindingSource();
            dataTable = new DataTable();
        }
          

        //method in DisplayStudent
        public bool DisplayStudent()
        {
            if (comboBox1 != null)
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("SELECT FirstName, MiddleName, LastName, Age, Gender, Program FROM ClubMembers WHERE CAST(StudentID AS VARCHAR) = '" 
                + comboBox1.Text + "'", sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    textBox2.Text = reader.GetValue(0).ToString();
                    textBox3.Text = reader.GetValue(1).ToString();
                    textBox1.Text = reader.GetValue(2).ToString();
                    textBox4.Text = reader.GetValue(3).ToString();
                    comboBox2.Text = reader.GetValue(4).ToString();
                    comboBox3.Text = reader.GetValue(5).ToString();
                }
                
                sqlConnection.Close();
            }

            return true;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayStudent();
        }


        
        public bool LoadUpdate()
        {
            sqlAdapter = new SqlDataAdapter("SELECT StudentID FROM ClubMembers", sqlConnection);
            dataTable.Clear();
            sqlAdapter.Fill(dataTable);
            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "ClubMembers";
            comboBox1.ValueMember = "StudentId";
            return true;
        }

        //Load Event
        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            LoadUpdate();
        }

        //Button Confirm
        private void button1_Click(object sender, EventArgs e)
        {
            clubRegistrationQuery.UpdateStudent(int.Parse
            (comboBox1.Text), textBox2.Text, textBox3.Text, textBox1.Text, 
            int.Parse(textBox4.Text), comboBox2.Text, comboBox3.Text);
            MessageBox.Show("Successfully Updated!!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
