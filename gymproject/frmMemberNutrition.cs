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
    public partial class frmMemberNutrition : KryptonForm
    {
        public frmMemberNutrition()
        {
            InitializeComponent();
        }
        public string emailmembernutrition;
        sqlconnectiongym bgl = new sqlconnectiongym();

        private void frmMemberNutrition_Load(object sender, EventArgs e)
        {
            lblEmail.Text = emailmembernutrition;

            SqlCommand cmd = new SqlCommand("Select member_breakfast,member_lunch,member_dinner,member_snacks from tbl_Member where member_email=@p1", bgl.connection());
            cmd.Parameters.AddWithValue("@p1", lblEmail.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtBreakfast.Text = dr[0].ToString();
                txtLunch.Text = dr[1].ToString();
                txtDinner.Text = dr[2].ToString();
                txtSnacks.Text = dr[3].ToString();
            }
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
