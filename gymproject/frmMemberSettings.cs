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

namespace gymproject
{
    public partial class frmMemberSettings : Form
    {
        public frmMemberSettings()
        {
            InitializeComponent();
        }
        public string emailmembersettings;
        sqlconnectiongym bgl = new sqlconnectiongym();
        private void frmMemberSettings_Load(object sender, EventArgs e)
        {
            lblEmail.Text = emailmembersettings;

            SqlCommand cmd = new SqlCommand("Select * from tbl_Member where member_email=@p1", bgl.connection());
            cmd.Parameters.AddWithValue("@p1", lblEmail.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtAppSettingsid.Text = dr[0].ToString();
                txtAppSettingsName.Text = dr[1].ToString();
                txtAppSettingsSurname.Text = dr[2].ToString();
                txtAppSettingsEmail.Text = dr[3].ToString();
                txtAppSettingsPassword.Text = dr[5].ToString();
            }
        }

        private void btnAppSettingsSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmdsave = new SqlCommand("Update tbl_Member set member_name=@p1,member_surname=@p2,member_email=@p3,member_password=@p4 where member_email=@p5", bgl.connection());
            cmdsave.Parameters.AddWithValue("@p5", lblEmail.Text);
            cmdsave.Parameters.AddWithValue("@p1", txtAppSettingsName.Text);
            cmdsave.Parameters.AddWithValue("@p2", txtAppSettingsSurname.Text);
            cmdsave.Parameters.AddWithValue("@p3", txtAppSettingsEmail.Text);
            cmdsave.Parameters.AddWithValue("@p4", txtAppSettingsPassword.Text);
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

        private void btnMemberTraining_Click(object sender, EventArgs e)
        {
            frmMemberTraining fr = new frmMemberTraining();
            fr.email = lblEmail.Text;
            fr.Show();
            this.Hide();
        }

        private void btnMemberBody_Click(object sender, EventArgs e)
        {
            frmMemberBody fr = new frmMemberBody();
            fr.emailmemberbody = lblEmail.Text;
            fr.Show();
            this.Hide();
        }

        private void btnMemberNutrition_Click(object sender, EventArgs e)
        {
            frmMemberNutrition fr = new frmMemberNutrition();
            fr.emailmembernutrition = lblEmail.Text;
            fr.Show();
            this.Hide();
        }

        private void btnMemberSettings_Click(object sender, EventArgs e)
        {
            frmMemberSettings fr = new frmMemberSettings();
            fr.emailmembersettings = lblEmail.Text;
            fr.Show();
            this.Hide();
        }

        private void btnMemberExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
