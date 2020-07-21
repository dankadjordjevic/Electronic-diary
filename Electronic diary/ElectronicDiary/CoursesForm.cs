using BusinessLayer;
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ElectronicDiary
{
    public partial class CoursesForm : Form
    {
        private CourseBusiness courseBusiness;

        public CoursesForm()
        {
            InitializeComponent();
            ICourseRepository courseRepository = new CourseRepository();
            this.courseBusiness = new CourseBusiness(courseRepository);
        }

        private void CoursesForm_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            List<Course> lista = this.courseBusiness.GetAllCourses();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["GetSetId"].HeaderText = "Id";
            dataGridView1.Columns["GetSetName"].HeaderText = "Name";
            dataGridView1.Columns["GetSetDescription"].HeaderText = "Description";
        }

        public void ClearFields()
        {
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please insert all fields!");
            }
            else
            {
                Course c = new Course();
                c.GetSetName = textBox2.Text;
                c.GetSetDescription = textBox3.Text;
                this.courseBusiness.InsertCourse(c);
                MessageBox.Show("Successfully inserted!");
                FillDataGrid();
                ClearFields();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Course c = new Course();
            Object id = dataGridView1.CurrentRow.Cells[0].Value;
            int number = Convert.ToInt32(id.ToString());
            List<Course> objList = this.courseBusiness.GetAllCoursesById(number);
            foreach (Course obj in objList)
            {
                textBox1.Text = obj.GetSetId.ToString();
                textBox2.Text = obj.GetSetName;
                textBox3.Text = obj.GetSetDescription;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please insert all fields!");
            }
            else
            {
                if (String.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please choose a course!");
                    return;
                }
                Course c = new Course();
                c.GetSetId = Convert.ToInt32(textBox1.Text);
                c.GetSetName = textBox2.Text;
                c.GetSetDescription = textBox3.Text;
                this.courseBusiness.UpdateCourse(c);
                MessageBox.Show("Successfully updated!");
                FillDataGrid();
                ClearFields();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please provide an Id!");
            }
            else
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete?",
                                     "Confirm Delete!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    Course c = new Course();
                    c.GetSetId = Convert.ToInt32(textBox1.Text);
                    this.courseBusiness.DeleteCourse(c);
                    MessageBox.Show("Successfully deleted!");
                    FillDataGrid();
                    ClearFields();
                }
                else
                {
                    return;
                }
            }
        }
    }
}