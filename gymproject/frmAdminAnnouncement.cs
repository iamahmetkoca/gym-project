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
    public partial class frmAdminAnnouncement : KryptonForm
    {
        public frmAdminAnnouncement()
        {
            InitializeComponent();
        }
        public string usernameannouncement;
        sqlconnectiongym bgl = new sqlconnectiongym();

        public void DataRefresh()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Announcement", bgl.connection());
            DataSet ds = new DataSet();
            da.Fill(ds, "announcement");
            kryptonDataGridView1.DataSource = ds.Tables[0];

            txtAnnouncementid.Text = "";
            txtAnnouncementContent.Text = "";
            txtAnnouncementContent.Focus();
        }
        private void frmAdminAnnouncement_Load(object sender, EventArgs e)
        {
            lblUsername.Text = usernameannouncement;

            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Announcement", bgl.connection());
            DataSet ds = new DataSet();
            da.Fill(ds, "announcement");
            kryptonDataGridView1.DataSource = ds.Tables[0];
            bgl.connection().Close();

            kryptonDataGridView1.Columns[0].HeaderText = "Number";
            kryptonDataGridView1.Columns[1].HeaderText = "Announcement";
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
            frmAdminSettings fr = new frmAdminSettings();
            fr.usernameappsettings = lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnnouncementAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmdadd = new SqlCommand("Insert into tbl_Announcement ( announcement_content) values (@p2)", bgl.connection());
            cmdadd.Parameters.AddWithValue("@p2", txtAnnouncementContent.Text);
            cmdadd.ExecuteNonQuery();
            MessageBox.Show("Announcement created successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataRefresh();
            bgl.connection().Close();
        }

        private void btnAnnouncementDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmddelete = new SqlCommand("Delete from tbl_Announcement where announcement_id=@p1", bgl.connection());
            cmddelete.Parameters.AddWithValue("@p1", txtAnnouncementid.Text);
            DialogResult result1 = MessageBox.Show("Are you sure the announcement will be deleted?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result1 == DialogResult.Yes)
            {
                cmddelete.ExecuteNonQuery();
                DataRefresh();
            }
            else
            {

            }
            bgl.connection().Close();
        }

        private void kryptonDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = kryptonDataGridView1.SelectedCells[0].RowIndex;
            txtAnnouncementid.Text = kryptonDataGridView1.Rows[selected].Cells[0].Value.ToString();
            txtAnnouncementContent.Text = kryptonDataGridView1.Rows[selected].Cells[1].Value.ToString();
        }
    }
}
