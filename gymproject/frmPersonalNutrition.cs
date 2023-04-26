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
    public partial class frmPersonalNutrition : KryptonForm
    {
        public frmPersonalNutrition()
        {
            InitializeComponent();
        }
        public string usernamepersonalnutrition;
        sqlconnectiongym bgl = new sqlconnectiongym();

        public void DataRefresh()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select member_id,member_name,member_surname,member_breakfast,member_lunch,member_dinner,member_snacks From tbl_Member", bgl.connection());
            DataSet ds = new DataSet();
            da.Fill(ds, "member");
            kryptonDataGridView1.DataSource = ds.Tables[0];

            txtMemberid.Text = "";
            txtBreakfast.Text = "";
            txtLunch.Text = "";
            txtDinner.Text = "";
            txtSnacks.Text = "";
            txtBreakfast.Focus();
        }
        private void frmPersonalNutrition_Load(object sender, EventArgs e)
        {
            lblUsername.Text = usernamepersonalnutrition;

            SqlDataAdapter da = new SqlDataAdapter("Select member_id,member_name,member_surname,member_breakfast,member_lunch,member_dinner,member_snacks From tbl_Member", bgl.connection());
            DataSet ds = new DataSet();
            da.Fill(ds, "member");
            kryptonDataGridView1.DataSource = ds.Tables[0];

            bgl.connection().Close();

            kryptonDataGridView1.Columns[0].HeaderText = "Number";
            kryptonDataGridView1.Columns[1].HeaderText = "Name";
            kryptonDataGridView1.Columns[2].HeaderText = "Surname";
            kryptonDataGridView1.Columns[3].HeaderText = "Breakfast";
            kryptonDataGridView1.Columns[4].HeaderText = "Lunch";
            kryptonDataGridView1.Columns[5].HeaderText = "Dinner";
            kryptonDataGridView1.Columns[6].HeaderText = "Snacks";
        }

        private void kryptonDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = kryptonDataGridView1.SelectedCells[0].RowIndex;
            txtMemberid.Text = kryptonDataGridView1.Rows[selected].Cells[0].Value.ToString();
            txtBreakfast.Text = kryptonDataGridView1.Rows[selected].Cells[3].Value.ToString();
            txtLunch.Text = kryptonDataGridView1.Rows[selected].Cells[4].Value.ToString();
            txtDinner.Text = kryptonDataGridView1.Rows[selected].Cells[5].Value.ToString();
            txtSnacks.Text = kryptonDataGridView1.Rows[selected].Cells[6].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmdupdate = new SqlCommand("Update tbl_Member set member_breakfast=@p1,member_lunch=@p2,member_dinner=@p3,member_snacks=@p4 where member_id=@p5", bgl.connection());
            cmdupdate.Parameters.AddWithValue("@p1", txtBreakfast.Text);
            cmdupdate.Parameters.AddWithValue("@p2", txtLunch.Text);
            cmdupdate.Parameters.AddWithValue("@p3", txtDinner.Text);
            cmdupdate.Parameters.AddWithValue("@p4", txtSnacks.Text);
            cmdupdate.Parameters.AddWithValue("@p5", txtMemberid.Text);
            DialogResult result1 = MessageBox.Show("Are you sure you want to change the nutrition program?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
