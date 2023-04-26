using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace gymproject
{
    public partial class frmLogin : KryptonForm
    {
        public frmLogin()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }
        sqlconnectiongym bgl = new sqlconnectiongym();
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Admin,tbl_Personal,tbl_Member where admin_username=@p1 and admin_password=@p2 or personal_username=@p3 and personal_password=@p4 or member_email=@p5 and member_password=@p6",bgl.connection());
            cmd.Parameters.AddWithValue("@p1",txtUsername.Text);
            cmd.Parameters.AddWithValue("@p2",txtPassword.Text);
            cmd.Parameters.AddWithValue("@p3", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p4", txtPassword.Text);
            cmd.Parameters.AddWithValue("@p5", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p6", txtPassword.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                frmVersionCheck fr = new frmVersionCheck();
                fr.usernameoremail= txtUsername.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }

            bgl.connection().Close();
        }
    }
}
