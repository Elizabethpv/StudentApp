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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        String Connection = "Data Source=DESKTOP-NDM7TFA\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True;";
        Student student = new Student();

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Student loggedPerson = LoginFunction(txtUserName.Text, txtPassword.Text);
            if(loggedPerson!=null)
            {
                HomePage home = new HomePage(loggedPerson);
                home.Show();
            }


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            
        }

        private Student LoginFunction(String UserName, String Password)
        {
            SqlConnection connect = new SqlConnection(Connection);
            connect.Open();
            SqlCommand command = new SqlCommand("StudentLogin", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("UserName", UserName);
            command.Parameters.AddWithValue("Password", Password);


            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            

            student.Id = Convert.ToInt32(reader["Id"]);
            student.Name = reader["Name"].ToString();
            student.Email = reader["Email"].ToString();
            student.Maths = Convert.ToInt32(reader["Maths"]);
            student.English = Convert.ToInt32(reader["English"]);
            student.Malayalam = Convert.ToInt32(reader["Malayalam"]);
            student.UserName = reader["UserName"].ToString();
            student.Password = reader["Password"].ToString();
            student.Color = reader["Color"].ToString();
            student.Left = Convert.ToInt32(reader["Left"]);
            student.Top = Convert.ToInt32(reader["Top"]);
            return student;
            connect.Close();
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPassword.Checked==true)
            {

                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
