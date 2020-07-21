using System;
using System.Windows.Forms;

namespace ElectronicDiary
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CoursesForm cf = new CoursesForm();
            cf.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentsForm sf = new StudentsForm();
            sf.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RatingsForm rf = new RatingsForm();
            rf.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StudentsGDP sgdp = new StudentsGDP();
            sgdp.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}