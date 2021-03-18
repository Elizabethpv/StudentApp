using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentApp
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        String Connection = "Data Source=DESKTOP-NDM7TFA\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True;";
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            SqlConnection connect = new SqlConnection(Connection);
            connect.Open();
            SqlCommand cmd = new SqlCommand("StudentRegister", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Name",txtName.Text);
            cmd.Parameters.AddWithValue("Email",txtEmail.Text);
            cmd.Parameters.AddWithValue("Maths",txtMaths.Text);
            cmd.Parameters.AddWithValue("English",txtEnglish.Text);
            cmd.Parameters.AddWithValue("Malayalam",txtMalayalam.Text);
            cmd.Parameters.AddWithValue("UserName",txtUserName.Text);
            cmd.Parameters.AddWithValue("Password",txtPassword.Text);
            cmd.Parameters.AddWithValue("Left", this.Left);
            cmd.Parameters.AddWithValue("Top", this.Top);
            cmd.ExecuteNonQuery();         
            connect.Close();
            txtEmail.Text = txtEnglish.Text = txtMalayalam.Text = txtMaths.Text = txtName.Text = txtPassword.Text = txtUserName.Text = "";
            Login login = new Login();
            login.Show();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            
        }
    }
}
