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
    public partial class HomePage : Form
    {
        Student _student;
        public HomePage(Student student)
        {
            InitializeComponent();
            _student = student;
        }
        String Connection = "Data Source=DESKTOP-NDM7TFA\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True;";
        static int hour, minute, second;

        static double TimeAllSecondes =100;
        private void btnColor_Click(object sender, EventArgs e)
        {

            SetColor(_student.Id);
        }

        private void SetColor(int studentId)
        {

            colorDialog.ShowDialog();
            this.BackColor = Color.FromArgb(colorDialog.Color.ToArgb());
            SqlConnection connect = new SqlConnection(Connection);
            connect.Open();
            SqlCommand cmd = new SqlCommand("StudentPageColorSet", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", studentId);
            cmd.Parameters.AddWithValue("Color", colorDialog.Color.ToArgb().ToString());
            cmd.ExecuteNonQuery();
            connect.Close();



        }



        private void HomePage_Load(object sender, EventArgs e)
        {
            this.Text = lblUserName.Text = _student.Name;
            this.BackColor = Color.FromArgb(Convert.ToInt32(_student.Color));

            StudentList(_student.Id);

            tmrCountDown.Start();
            this.Left = _student.Left;
            this.Top = _student.Top;


        }




        private void StudentList(int studentId)
        {

            
            SqlConnection connect = new SqlConnection(Connection);
            connect.Open();
            SqlCommand command = new SqlCommand("StudentList", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("Id", studentId);


            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            lstStudentView.Items.Add("Name          : "+_student.Name);
            lstStudentView.Items.Add("Email           : "+_student.Email);
            lstStudentView.Items.Add("Maths          : "+_student.Maths);
            lstStudentView.Items.Add("English        : "+_student.English);
            lstStudentView.Items.Add("Malayalam  : "+_student.Malayalam);
           

            connect.Close();



        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HomePage_MouseHover(object sender, EventArgs e)
        {
            tmrCountDown.Start();
        }

        private void lstStudentView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowPositionUpdate(this.Left, this.Top, _student.Id);
        }
        private void WindowPositionUpdate(int left,int top,int studentId)
        {
            SqlConnection connect = new SqlConnection(Connection);
            connect.Open();
            SqlCommand command = new SqlCommand("UpdateWindowPosition", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("Id", studentId);
            command.Parameters.AddWithValue("Left", left);
            command.Parameters.AddWithValue("Top", top);
            command.ExecuteNonQuery();
            connect.Close();



        }
        private void tmrCountDown_Tick(object sender, EventArgs e)
        {
          
            if (TimeAllSecondes > 0)
            {
                TimeAllSecondes = TimeAllSecondes - 1;
            }

            TimeSpan time_Span = TimeSpan.FromSeconds(TimeAllSecondes);
            hour = time_Span.Hours;
            minute = time_Span.Minutes;
            second = time_Span.Seconds;

            lblMinute.Text= "  " + hour + ":" + minute + ":" + second;
            if(second==0)
            {
                this.Close();
            }
            lblMinute.Visible = false;
        }

        private void HomePage_MouseMove(object sender, MouseEventArgs e)
        {
           
        }
    }
}
