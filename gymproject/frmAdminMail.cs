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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Data.Common;
using System.Xml.Linq;
using System.Net.Http;

namespace gymproject
{
    public partial class frmAdminMail : KryptonForm
    {
        public frmAdminMail()
        {
            InitializeComponent();
        }
        public string usernamemail;
        sqlconnectiongym bgl = new sqlconnectiongym();
        private void frmAdminMail_Load(object sender, EventArgs e)
        {
            lblUsername.Text = usernamemail;
        }

        private void btnMembership_Click(object sender, EventArgs e)
        {
            frmAdminMembership fr = new frmAdminMembership();
            fr.username = lblUsername.Text;
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
            fr.usernamemail= lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnPersonalTransaction_Click(object sender, EventArgs e)
        {
            frmAdminPersonal fr = new frmAdminPersonal();
            fr.usernamepersonal = lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnAppSettings_Click(object sender, EventArgs e)
        {
            frmAdminSettings frm = new frmAdminSettings();
            frm.usernameappsettings = lblUsername.Text;
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string from, subject, body;
        private void rbAllMembers_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            from = "test@ahmetkoca.com.tr";
            subject = txtSubject.Text;
            body = txtMailContent.Text;
            SqlCommand cmd = new SqlCommand("Select member_email from tbl_Member", bgl.connection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MailMessage mail = new MailMessage(from, reader["member_email"].ToString(), subject, body);
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential("test@ahmetkoca.com.tr", "password");
                smtp.Port = 587;
                smtp.Host = "mail.ahmetkoca.com.tr";
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }

        private void rbRules_CheckedChanged(object sender, EventArgs e)
        {
            if(rbRules.Checked)
            {
                txtSubject.Text = "UltraMax GYM Rules;";
                txtMailContent.Text = "Wear appropriate workout clothes and footwear.\r\nAlways use a towel to wipe down equipment after use.\r\nPut weights back in their proper place when finished.\r\nAvoid using equipment that you are not familiar with or have not been trained to use.\r\nRespect others' personal space and equipment.\r\nUse headphones when listening to music or watching videos.\r\nFollow the gym's rules and regulations.\r\nStay hydrated and take breaks as needed.\r\nDo not monopolize equipment for long periods of time.\r\nBe mindful of noise levels and avoid excessive grunting or yelling.";
            }
        }

        private void rbMotivationalMsg3_CheckedChanged(object sender, EventArgs e)
        {
            txtMailContent.Text = "Believe you can and you're halfway there.";
        }

        private void rbMotiationalMsg1_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMotiationalMsg1.Checked)
            {
                txtMailContent.Text = "The only bad workout is the one that didn't happen";
            }
        }

        private void rbMotivationalMsg2_CheckedChanged(object sender, EventArgs e)
        {
            txtMailContent.Text = "The pain you feel today will be the strength you feel tomorrow.";
        }
    }
}
