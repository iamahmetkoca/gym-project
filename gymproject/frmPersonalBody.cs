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
    public partial class frmPersonalBody : KryptonForm
    {
        public frmPersonalBody()
        {
            InitializeComponent();
        }
        public string usernamepersonalbody;
        sqlconnectiongym bgl = new sqlconnectiongym();

        public void DataRefresh()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select member_id,member_name,member_surname,member_measurementdate,member_tall,member_weight,member_chestsize,member_waistsize,member_thigssize From tbl_Member", bgl.connection());
            DataSet ds = new DataSet();
            da.Fill(ds, "body");
            kryptonDataGridView1.DataSource = ds.Tables[0];

            txtMemberid.Text = "";
            txtDate.Text = "";
            txtTall.Text = "";
            txtWeight.Text = "";
            txtChestSize.Text = "";
            txtWaistSize.Text = "";
            txtThigsSize.Text = "";
            txtDate.Focus();
        }
        private void frmPersonalBody_Load(object sender, EventArgs e)
        {
            lblUsername.Text = usernamepersonalbody;

            SqlDataAdapter da = new SqlDataAdapter("Select member_id,member_name,member_surname,member_measurementdate,member_tall,member_weight,member_chestsize,member_waistsize,member_thigssize From tbl_Member", bgl.connection());
            DataSet ds = new DataSet();
            da.Fill(ds, "body");
            kryptonDataGridView1.DataSource = ds.Tables[0];

            bgl.connection().Close();

            kryptonDataGridView1.Columns[0].HeaderText = "Number";
            kryptonDataGridView1.Columns[1].HeaderText = "Name";
            kryptonDataGridView1.Columns[2].HeaderText = "Surname";
            kryptonDataGridView1.Columns[3].HeaderText = "Date";
            kryptonDataGridView1.Columns[4].HeaderText = "Tall";
            kryptonDataGridView1.Columns[5].HeaderText = "Weight";
            kryptonDataGridView1.Columns[6].HeaderText = "Chest";
            kryptonDataGridView1.Columns[7].HeaderText = "Waist";
            kryptonDataGridView1.Columns[8].HeaderText = "Thigs";
        }

        private void kryptonDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = kryptonDataGridView1.SelectedCells[0].RowIndex;
            txtMemberid.Text = kryptonDataGridView1.Rows[selected].Cells[0].Value.ToString();
            txtDate.Text = kryptonDataGridView1.Rows[selected].Cells[3].Value.ToString();
            txtTall.Text = kryptonDataGridView1.Rows[selected].Cells[4].Value.ToString();
            txtWeight.Text = kryptonDataGridView1.Rows[selected].Cells[5].Value.ToString();
            txtChestSize.Text = kryptonDataGridView1.Rows[selected].Cells[6].Value.ToString();
            txtWaistSize.Text = kryptonDataGridView1.Rows[selected].Cells[7].Value.ToString();
            txtThigsSize.Text = kryptonDataGridView1.Rows[selected].Cells[8].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmdupdate = new SqlCommand("Update tbl_Member set member_measurementdate=@p1,member_tall=@p2,member_weight=@p3,member_chestsize=@p4,member_waistsize=@p5,member_thigssize=@p6 where member_id=@p7", bgl.connection());
            cmdupdate.Parameters.AddWithValue("@p1", txtDate.Text);
            cmdupdate.Parameters.AddWithValue("@p2", txtTall.Text);
            cmdupdate.Parameters.AddWithValue("@p3", txtWeight.Text);
            cmdupdate.Parameters.AddWithValue("@p4", txtChestSize.Text);
            cmdupdate.Parameters.AddWithValue("@p5", txtWaistSize.Text);
            cmdupdate.Parameters.AddWithValue("@p6", txtThigsSize.Text);
            cmdupdate.Parameters.AddWithValue("@p7", txtMemberid.Text);
            DialogResult result1 = MessageBox.Show("Are you sure you want to change the body measurement?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
