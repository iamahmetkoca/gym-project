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
    public partial class frmAdminPersonal : KryptonForm
    {
        public frmAdminPersonal()
        {
            InitializeComponent();
        }
        public string usernamepersonal;
        sqlconnectiongym bgl = new sqlconnectiongym();

        public void DataRefresh()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Personal", bgl.connection());
            DataSet ds = new DataSet();
            da.Fill(ds, "personal");
            kryptonDataGridView1.DataSource = ds.Tables[0];

            txtPersonalid.Text = "";
            txtPersonalName.Text = "";
            txtPersonalSurname.Text = "";
            txtPersonalUsername.Text = "";
            txtPersonalEmail.Text = "";
            txtPersonalPassword.Text = "";
            txtPersonalName.Focus();
        }
        private void frmPersonal_Load(object sender, EventArgs e)
        {
            lblUsername.Text = usernamepersonal;

            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Personal", bgl.connection());
            DataSet ds = new DataSet();
            da.Fill(ds, "personal");
            kryptonDataGridView1.DataSource = ds.Tables[0];

            bgl.connection().Close();

            kryptonDataGridView1.Columns[0].HeaderText = "Number";
            kryptonDataGridView1.Columns[1].HeaderText = "Name";
            kryptonDataGridView1.Columns[2].HeaderText = "Surname";
            kryptonDataGridView1.Columns[3].HeaderText = "Email";
            kryptonDataGridView1.Columns[4].HeaderText = "Username";
            kryptonDataGridView1.Columns[5].HeaderText = "Password";
            kryptonDataGridView1.Columns[6].HeaderText = "Role";
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

        private void btnPersonalAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmdadd = new SqlCommand("Insert into tbl_Personal (personal_name,personal_surname,personal_username,personal_email,personal_password) values (@p1,@p2,@p3,@p4,@p5)", bgl.connection());
            cmdadd.Parameters.AddWithValue("@p1", txtPersonalName.Text);
            cmdadd.Parameters.AddWithValue("@p2", txtPersonalSurname.Text);
            cmdadd.Parameters.AddWithValue("@p3", txtPersonalUsername.Text);
            cmdadd.Parameters.AddWithValue("@p4", txtPersonalEmail.Text);
            cmdadd.Parameters.AddWithValue("@p5",txtPersonalPassword.Text);
            cmdadd.ExecuteNonQuery();
            MessageBox.Show("Member successfully added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataRefresh();
            bgl.connection().Close();
        }

        private void btnPersonalUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmdupdate = new SqlCommand("Update tbl_Personal set personal_name=@p1,personal_surname=@p2,personal_username=@p3,personal_email=@p4, personal_password=@p5 where personal_id=@p6", bgl.connection());
            cmdupdate.Parameters.AddWithValue("@p1", txtPersonalName.Text);
            cmdupdate.Parameters.AddWithValue("@p2", txtPersonalSurname.Text);
            cmdupdate.Parameters.AddWithValue("@p3", txtPersonalUsername.Text);
            cmdupdate.Parameters.AddWithValue("@p4", txtPersonalEmail.Text);
            cmdupdate.Parameters.AddWithValue("@p5", txtPersonalPassword.Text);
            cmdupdate.Parameters.AddWithValue("@p6",txtPersonalid.Text);
            DialogResult result1 = MessageBox.Show("Are you sure the personal information will be updated?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result1 == DialogResult.Yes)
            {
                cmdupdate.ExecuteNonQuery();
                DataRefresh();
            }
            else
            {

            }
            bgl.connection().Close();
        }

        private void btnPersonalDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmddelete = new SqlCommand("Delete from tbl_Personal where personal_id=@p1", bgl.connection());
            cmddelete.Parameters.AddWithValue("@p1", txtPersonalid.Text);
            DialogResult result1 = MessageBox.Show("Are you sure the member will be deleted?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
            txtPersonalid.Text = kryptonDataGridView1.Rows[selected].Cells[0].Value.ToString();
            txtPersonalName.Text = kryptonDataGridView1.Rows[selected].Cells[1].Value.ToString();
            txtPersonalSurname.Text = kryptonDataGridView1.Rows[selected].Cells[2].Value.ToString();
            txtPersonalUsername.Text = kryptonDataGridView1.Rows[selected].Cells[4].Value.ToString();
            txtPersonalEmail.Text = kryptonDataGridView1.Rows[selected].Cells[3].Value.ToString();
            txtPersonalPassword.Text = kryptonDataGridView1.Rows[selected].Cells[5].Value.ToString();
        }
    }
}
