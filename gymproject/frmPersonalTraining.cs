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
    public partial class frmPersonalTraining : KryptonForm
    {
        public frmPersonalTraining()
        {
            InitializeComponent();
        }

        public string usernamepersonaltraining;
        sqlconnectiongym bgl = new sqlconnectiongym();

        public void DataRefresh()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select member_id,member_name,member_surname,member_breakfast,member_lunch,member_dinner,member_snacks From tbl_Member", bgl.connection());
            DataSet ds = new DataSet();
            da.Fill(ds, "member");
            kryptonDataGridView1.DataSource = ds.Tables[0];

            txtMemberid.Text = "";
            txtChest.Text = "";
            txtBack.Text = "";
            txtArm.Text = "";
            txtShoulder.Text = "";
            txtChest.Focus();
        }
        private void frmPersonalTraining_Load(object sender, EventArgs e)
        {
            lblUsername.Text = usernamepersonaltraining;

            SqlDataAdapter da = new SqlDataAdapter("Select member_id,member_name,member_surname,member_chest,member_back,member_arm,member_shoulder From tbl_Member", bgl.connection());
            DataSet ds = new DataSet();
            da.Fill(ds, "member");
            kryptonDataGridView1.DataSource = ds.Tables[0];

            bgl.connection().Close();

            kryptonDataGridView1.Columns[0].HeaderText = "Number";
            kryptonDataGridView1.Columns[1].HeaderText = "Name";
            kryptonDataGridView1.Columns[2].HeaderText = "Surname";
            kryptonDataGridView1.Columns[3].HeaderText = "Chest";
            kryptonDataGridView1.Columns[4].HeaderText = "Back";
            kryptonDataGridView1.Columns[5].HeaderText = "Arm";
            kryptonDataGridView1.Columns[6].HeaderText = "Shoulder";
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

        private void kryptonDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = kryptonDataGridView1.SelectedCells[0].RowIndex;
            txtMemberid.Text = kryptonDataGridView1.Rows[selected].Cells[0].Value.ToString();
            txtChest.Text = kryptonDataGridView1.Rows[selected].Cells[3].Value.ToString();
            txtBack.Text = kryptonDataGridView1.Rows[selected].Cells[4].Value.ToString();
            txtArm.Text = kryptonDataGridView1.Rows[selected].Cells[5].Value.ToString();
            txtShoulder.Text = kryptonDataGridView1.Rows[selected].Cells[6].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmdupdate = new SqlCommand("Update tbl_Member set member_chest=@p1,member_back=@p2,member_arm=@p3,member_shoulder=@p4 where member_id=@p5", bgl.connection());
            cmdupdate.Parameters.AddWithValue("@p1", txtChest.Text);
            cmdupdate.Parameters.AddWithValue("@p2", txtBack.Text);
            cmdupdate.Parameters.AddWithValue("@p3", txtArm.Text);
            cmdupdate.Parameters.AddWithValue("@p4", txtShoulder.Text);
            cmdupdate.Parameters.AddWithValue("@p5", txtMemberid.Text);
            DialogResult result1 = MessageBox.Show("Are you sure you want to change the training program?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
    }
}
