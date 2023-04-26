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
    public partial class frmMemberTraining : KryptonForm
    {
        public frmMemberTraining()
        {
            InitializeComponent();
        }
        public string email;
        sqlconnectiongym bgl = new sqlconnectiongym();
        private void frmMemberTraining_Load(object sender, EventArgs e)
        {
            lblEmail.Text = email;

            SqlCommand cmd = new SqlCommand("Select member_chest,member_back,member_arm,member_shoulder from tbl_Member where member_email=@p1", bgl.connection());
            cmd.Parameters.AddWithValue("@p1", lblEmail.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtChest.Text = dr[0].ToString();
                txtBack.Text = dr[1].ToString();
                txtArm.Text = dr[2].ToString();
                txtShoulder.Text = dr[3].ToString();
            }
        }



        private void btnMemberTraining_Click_1(object sender, EventArgs e)
        {
            frmMemberTraining fr = new frmMemberTraining();
            fr.email = lblEmail.Text;
            fr.Show();
            this.Hide();
        }

        private void btnMemberBody_Click_1(object sender, EventArgs e)
        {
            frmMemberBody fr = new frmMemberBody();
            fr.emailmemberbody = lblEmail.Text;
            fr.Show();
            this.Hide();
        }

        private void btnMemberNutrition_Click_1(object sender, EventArgs e)
        {
            frmMemberNutrition fr = new frmMemberNutrition();
            fr.emailmembernutrition = lblEmail.Text;
            fr.Show();
            this.Hide();
        }

        private void btnPersonalSettings_Click(object sender, EventArgs e)
        {
            frmMemberSettings fr = new frmMemberSettings();
            fr.emailmembersettings = lblEmail.Text;
            fr.Show();
            this.Hide();
        }

        private void btnPersonalExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
