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
    public partial class ChangePassword : Form
    {
        String Connection = DatabaseConnection.Connection;


        Student _student;
        public ChangePassword(Student student)
        {
            InitializeComponent();
            _student = student;
        }
        
        private void btnPasswordChange_Click(object sender, EventArgs e)
        {
            
            SqlConnection connect = new SqlConnection(Connection);
            connect.Open();
            SqlCommand command = new SqlCommand("StudentChangePassword", connect);
            command.CommandType = CommandType.StoredProcedure;

            if (txtNewPassword.Text == txtConfirmPassword.Text)
            {

                command.Parameters.AddWithValue("Id", _student.Id);
                command.Parameters.AddWithValue("Password", txtConfirmPassword.Text);
                MessageBox.Show("Password is changed", "Confirmation");
                txtConfirmPassword.Text = txtNewPassword.Text = "";
            }
            else
            {
                txtConfirmPassword.Text = "";
                lblConfirm.Text = ("Password is did not Match");
                lblConfirm.BackColor = Color.Red;
            }
            connect.Close();

        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
           
        }
        
    }
}
