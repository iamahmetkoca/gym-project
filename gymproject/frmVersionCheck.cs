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
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace gymproject
{
    public partial class frmVersionCheck : KryptonForm
    {
        public frmVersionCheck()
        {
            InitializeComponent();
        }
        public string usernameoremail;
        sqlconnectiongym bgl = new sqlconnectiongym();
        private void frmVersionCheck_Load(object sender, EventArgs e)
        {
            lblUsernameorEmail.Text = usernameoremail;
            ProgressBar1.Value= 0;

            SqlCommand cmd = new SqlCommand("Select * from tbl_Admin where admin_username=@p1",bgl.connection());
            cmd.Parameters.AddWithValue("@p1",lblUsernameorEmail.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblRoleControl.Text = dr[6].ToString();
            }


            SqlCommand cmd1 = new SqlCommand("Select * from tbl_Personal where personal_username=@p2", bgl.connection());
            cmd1.Parameters.AddWithValue("@p2", lblUsernameorEmail.Text);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                lblRoleControl.Text = dr1[6].ToString();
            }


            SqlCommand cmd2 = new SqlCommand("Select * from tbl_Member where member_email=@p3", bgl.connection());
            cmd2.Parameters.AddWithValue("@p3", lblUsernameorEmail.Text);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                lblRoleControl.Text = dr2[20].ToString();
            }




            bgl.connection().Close();
        } 

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar1.Value += 4;


                
                if(lblRoleControl.Text == "admin" && ProgressBar1.Value==100)
                {
                    timer1.Enabled = false;
                    frmAdminMembership fr = new frmAdminMembership();
                    fr.username= lblUsernameorEmail.Text;
                    fr.Show();
                    this.Hide();
                }
                if(lblRoleControl.Text == "personal" && ProgressBar1.Value == 100)
                {
                    timer1.Enabled = false;
                    frmPersonalMembership fr = new frmPersonalMembership();
                    fr.username = lblUsernameorEmail.Text;
                    fr.Show();
                    this.Hide();
                }
                if(lblRoleControl.Text == "member" && ProgressBar1.Value == 100)
                {
                    timer1.Enabled = false;
                     frmMemberTraining fr = new frmMemberTraining();
                    fr.email = lblUsernameorEmail.Text;
                    fr.Show();
                    this.Hide();
                }
            
        }
    }
}
