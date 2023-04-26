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
    public partial class frmPersonalSettings : KryptonForm
    {
        public frmPersonalSettings()
        {
            InitializeComponent();
        }
        public string usernamepersonalsettings;
        sqlconnectiongym bgl = new sqlconnectiongym();
        private void frmPersonalSettings_Load(object sender, EventArgs e)
        {
            lblUsername.Text = usernamepersonalsettings;

            SqlCommand cmd = new SqlCommand("Select * from tbl_Personal where personal_username=@p1", bgl.connection());
            cmd.Parameters.AddWithValue("@p1", lblUsername.Text);
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

        private void btnAppSettingsSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmdsave = new SqlCommand("Update tbl_Personal set personal_name=@p1,personal_surname=@p2,personal_username=@p3,personal_email=@p4,personal_password=@p5 where personal_username=@p6", bgl.connection());
            cmdsave.Parameters.AddWithValue("@p6", lblUsername.Text);
            cmdsave.Parameters.AddWithValue("@p1", txtAppSettingsName.Text);
            cmdsave.Parameters.AddWithValue("@p2", txtAppSettingsSurname.Text);
            cmdsave.Parameters.AddWithValue("@p3", txtAppSettingsUsername.Text);
            cmdsave.Parameters.AddWithValue("@p4", txtAppSettingsEmail.Text);
            cmdsave.Parameters.AddWithValue("@p5", txtAppSettingsPassword.Text);
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

        private void btnPersonalMembership_Click(object sender, EventArgs e)
        {
            frmPersonalMembership fr = new frmPersonalMembership();
            fr.username = lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnPersonalBody_Click(object sender, EventArgs e)
        {
            frmPersonalBody fr = new frmPersonalBody();
            fr.usernamepersonalbody = lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnPersonalNutrition_Click(object sender, EventArgs e)
        {
            frmPersonalNutrition fr = new frmPersonalNutrition();
            fr.usernamepersonalnutrition = lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnPersonalTraining_Click(object sender, EventArgs e)
        {
            frmPersonalTraining fr = new frmPersonalTraining();
            fr.usernamepersonaltraining = lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnPersonalSettings_Click(object sender, EventArgs e)
        {
            frmPersonalSettings fr = new frmPersonalSettings();
            fr.usernamepersonalsettings = lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnPersonalExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
