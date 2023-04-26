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
using ComponentFactory.Krypton.Toolkit;

namespace gymproject
{
    public partial class frmAdminSettings : KryptonForm
    {
        public frmAdminSettings()
        {
            InitializeComponent();
        }
        public string usernameappsettings;
        sqlconnectiongym bgl = new sqlconnectiongym();
        private void frmAppSettings_Load(object sender, EventArgs e)
        {
            lblUsername.Text= usernameappsettings;
            
            SqlCommand cmd= new SqlCommand("Select * from tbl_Admin where admin_username=@p1",bgl.connection());
            cmd.Parameters.AddWithValue("@p1",lblUsername.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtAppSettingsid.Text = dr[0].ToString();
                txtAppSettingsName.Text = dr[1].ToString();
                txtAppSettingsSurname.Text = dr[2].ToString();
                txtAppSettingsUsername.Text = dr[4].ToString();
                txtAppSettingsEmail.Text = dr[3].ToString();
                txtAppSettingsPassword.Text = dr[5].ToString();
            }
        }

        private void btnMembership_Click(object sender, EventArgs e)
        {
            frmAdminMembership fr = new frmAdminMembership();
            fr.username= lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnAnnouncement_Click(object sender, EventArgs e)
        {
            frmAdminAnnouncement fr = new frmAdminAnnouncement();
            fr.usernameannouncement = lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            frmAdminMail fr = new frmAdminMail();
            fr.usernamemail = lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnPersonalTransaction_Click(object sender, EventArgs e)
        {
            frmAdminPersonal fr= new frmAdminPersonal();
            fr.usernamepersonal = lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnAppSettings_Click(object sender, EventArgs e)
        {
            frmAdminSettings fr = new frmAdminSettings();
            fr.usernameappsettings = lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAppSettingsSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmdsave = new SqlCommand("Update tbl_Admin set admin_name=@p1,admin_surname=@p2,admin_username=@p3,admin_email=@p4,admin_password=@p5 where admin_username=@p6", bgl.connection());
            cmdsave.Parameters.AddWithValue("@p6",lblUsername.Text);
            cmdsave.Parameters.AddWithValue("@p1", txtAppSettingsName.Text);
            cmdsave.Parameters.AddWithValue("@p2", txtAppSettingsSurname.Text);
            cmdsave.Parameters.AddWithValue("@p3", txtAppSettingsUsername.Text);
            cmdsave.Parameters.AddWithValue("@p4", txtAppSettingsEmail.Text);
            cmdsave.Parameters.AddWithValue("@p5",txtAppSettingsPassword.Text);
            DialogResult result1 = MessageBox.Show("Are you sure the profile settings will be updated.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result1 == DialogResult.Yes)
            {
                cmdsave.ExecuteNonQuery();
                Application.Restart();
            }
            else
            {

            }
            bgl.connection().Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
