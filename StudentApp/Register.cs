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
        String Connection = DatabaseConnection.Connection;
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
            MessageBox.Show(txtPassword.Text, "Your Password is :");
            txtEmail.Text = txtEnglish.Text = txtMalayalam.Text = txtMaths.Text = txtName.Text = txtPassword.Text = txtUserName.Text = "";
            
            Login login = new Login();
            login.Show();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            int r, k;
            int passwordLength = 6;
            string password = "";
            char[] upperCase = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] lowerCase = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            int[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Random rRandom = new Random();



            for (int i = 0; i < passwordLength; i++)
            {
                r = rRandom.Next(3);

                if (r == 0)
                {
                    k = rRandom.Next(0, 25);
                    password += upperCase[k];
                }

                else if (r == 1)
                {
                    k = rRandom.Next(0, 25);
                    password += lowerCase[k];
                }

                else if (r == 2)
                {
                    k = rRandom.Next(0, 9);
                    password += numbers[k];
                }

            }

            txtPassword.Text = password;


           
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            
        }
    }
    
}
