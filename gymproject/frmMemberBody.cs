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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace gymproject
{
    public partial class frmMemberBody : KryptonForm
    {
        public frmMemberBody()
        {
            InitializeComponent();
        }
        double tall, weight,bmi;
        public string emailmemberbody;

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

        sqlconnectiongym bgl = new sqlconnectiongym();
        private void frmMemberBody_Load(object sender, EventArgs e)
        {
            lblEmail.Text = emailmemberbody;

            SqlCommand cmd = new SqlCommand("Select member_measurementdate,member_tall,member_weight,member_chestsize,member_waistsize,member_thigssize from tbl_Member where member_email=@p1", bgl.connection());
            cmd.Parameters.AddWithValue("@p1", lblEmail.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblDate.Text = dr[0].ToString();
                lblTall.Text = dr[1] + " cm".ToString();
                lblWeight1.Text = dr[2].ToString();
                lblTall1.Text = dr[1].ToString();
                lblChest.Text = dr[3]+ " cm".ToString();
                lblWaist.Text = dr[4]+ " cm".ToString();
                lblThigs.Text = dr[5]+ " cm".ToString();
                lblChest1.Text = dr[3]+ " cm".ToString();
                lblWaist1.Text = dr[4]+ " cm".ToString();
                lblThigs1.Text = dr[5]+ " cm".ToString();
            }

            tall = Convert.ToDouble(lblTall1.Text);
            weight = Convert.ToDouble(lblWeight1.Text);
            bmi = weight / (tall * tall);
            lblBmi.Text = bmi.ToString();

            if (bmi < 18)
            {
                lblTextBmi.Text= "Weak";
                lblRecommendation.Text = "Don't be afraid to ask for help. Asking for assistance is not a sign of weakness, but rather a recognition of your limitations and a desire to improve. Focus on your strengths. Everyone has strengths and weaknesses, so concentrate on what you're good at and find ways to utilize those skills in your daily life. Set achievable goals. ";

            }
            else if (bmi >= 18 && bmi < 25)
            {
                lblTextBmi.Text = "Normal";
                lblRecommendation.Text = "Maintain a healthy lifestyle. Regular exercise, balanced nutrition, and adequate sleep are essential components of a healthy lifestyle that can help you maintain your weight and improve your overall health. Be mindful of portion sizes. It's easy to overeat when portions are large, so pay attention to how much you're eating and consider using smaller plates and bowls to help control your portions.";
            }
            else if (bmi >= 25 && bmi < 30)
            {
                lblTextBmi.Text = "Fat";
                lblRecommendation.Text = "Consult a healthcare professional. Speak to a doctor or nutritionist for guidance on a safe and effective weight loss plan tailored to your individual needs. Make gradual changes to your diet and lifestyle. Small changes such as reducing portion sizes, incorporating more fruits and vegetables, and increasing physical activity can lead to significant weight loss over time. Seek support from family and friends.";
            }
            else if (bmi >= 30 && bmi < 35)
            {
                lblTextBmi.Text = "Obese";
                lblRecommendation.Text = "Seek medical attention. Obesity is a serious health condition that can lead to other health issues, so it's important to consult a healthcare professional for guidance on safe and effective weight loss strategies. Focus on gradual and sustainable changes. Losing weight too quickly can be harmful to your health, so aim to make gradual changes to your diet and exercise routine that are sustainable in the long term.";
            }
            else
            {
                lblTextBmi.Text = "Too obese";
                lblRecommendation.Text = "Seek immediate medical attention. Extreme obesity can lead to serious health complications, so it's important to consult a healthcare professional as soon as possible for guidance on safe and effective weight loss strategies. Consider weight loss surgery. For individuals with extreme obesity, weight loss surgery may be a viable option to achieve significant weight loss and improve overall health.";
            }

            lblRecommendation.AutoEllipsis = false;
            lblRecommendation.AutoSize = true;
            lblRecommendation.MaximumSize = new Size(350, 0);
            lblRecommendation.TextAlign = ContentAlignment.TopLeft;

        }
    }
}
