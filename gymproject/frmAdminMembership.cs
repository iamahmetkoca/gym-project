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
    public partial class frmAdminMembership : KryptonForm
    {
        public  frmAdminMembership()
        {
            InitializeComponent();
        }
        public string username;
        sqlconnectiongym bgl = new sqlconnectiongym();
        
        public void DataRefresh()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select member_id,member_name,member_surname,member_email,member_password From tbl_Member", bgl.connection());
            DataSet ds = new DataSet();
            da.Fill(ds, "member");
            kryptonDataGridView1.DataSource = ds.Tables[0];

            txtMemberid.Text = "";
            txtMemberName.Text = "";
            txtMemberSurname.Text = "";
            txtMemberEmail.Text = "";
            txtMemberPassword.Text = "";
            txtMemberName.Focus();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            
            lblUsername.Text = username;


            SqlDataAdapter da = new SqlDataAdapter("Select member_id,member_name,member_surname,member_email,member_password From tbl_Member", bgl.connection());
            DataSet ds = new DataSet();
            da.Fill(ds, "member");
            kryptonDataGridView1.DataSource = ds.Tables[0];

            bgl.connection().Close();

            kryptonDataGridView1.Columns[0].HeaderText = "Number";
            kryptonDataGridView1.Columns[1].HeaderText = "Name";
            kryptonDataGridView1.Columns[2].HeaderText = "Surname";
            kryptonDataGridView1.Columns[3].HeaderText = "Email";
            kryptonDataGridView1.Columns[4].HeaderText = "Password";

        }

        private void btnMembershipTransaction_Click(object sender, EventArgs e)
        {
            frmAdminMembership fr = new frmAdminMembership();
            fr.username = lblUsername.Text;
            fr.Show();
            this.Hide();
        }

        private void btnCreateAnnouncement_Click(object sender, EventArgs e)
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

        private void btnPersonalTransactions_Click(object sender, EventArgs e)
        {
            frmAdminPersonal fr = new frmAdminPersonal();
            fr.usernamepersonal= lblUsername.Text;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblWelcomeMsg_Click(object sender, EventArgs e)
        {

        }
        
        private void btnMemberAdd_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmdadd = new SqlCommand("Insert into tbl_Member (member_name,member_surname,member_email,member_password) values (@p1,@p2,@p3,@p4)",bgl.connection());
            cmdadd.Parameters.AddWithValue("@p1", txtMemberName.Text);
            cmdadd.Parameters.AddWithValue("@p2", txtMemberSurname.Text);
            cmdadd.Parameters.AddWithValue("@p3",txtMemberEmail.Text); 
            cmdadd.Parameters.AddWithValue("@p4",txtMemberPassword.Text);
            cmdadd.ExecuteNonQuery();
            MessageBox.Show("Member successfully added","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            DataRefresh();
            bgl.connection().Close();
        }

        private void btnMemberUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmdupdate = new SqlCommand("Update tbl_Member set member_name=@p1,member_surname=@p2,member_email=@p3,member_password=@p4 where member_id=@p5",bgl.connection());
            cmdupdate.Parameters.AddWithValue("@p1",txtMemberName.Text);
            cmdupdate.Parameters.AddWithValue("@p2", txtMemberSurname.Text);
            cmdupdate.Parameters.AddWithValue("@p3", txtMemberEmail.Text);
            cmdupdate.Parameters.AddWithValue("@p4", txtMemberPassword.Text);
            cmdupdate.Parameters.AddWithValue("@p5", txtMemberid.Text);
            DialogResult result1 = MessageBox.Show("Are you sure the member information will be updated?", "Information", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
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

        private void btnMemberDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmddelete = new SqlCommand("Delete from tbl_Member where member_id=@p1",bgl.connection());
            cmddelete.Parameters.AddWithValue("@p1",txtMemberid.Text);
            DialogResult result1 = MessageBox.Show("Are you sure the member will be deleted?", "Information", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
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
            txtMemberid.Text = kryptonDataGridView1.Rows[selected].Cells[0].Value.ToString();
            txtMemberName.Text = kryptonDataGridView1.Rows[selected].Cells[1].Value.ToString();
            txtMemberSurname.Text = kryptonDataGridView1.Rows[selected].Cells[2].Value.ToString();
            txtMemberEmail.Text = kryptonDataGridView1.Rows[selected].Cells[3].Value.ToString();
            txtMemberPassword.Text = kryptonDataGridView1.Rows[selected].Cells[4].Value.ToString();
        }
    }
}
