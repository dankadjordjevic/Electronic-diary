using BusinessLayer;
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ElectronicDiary
{
    public partial class RatingsForm : Form
    {
        private RatingBusiness ratingBusiness;
        private StudentBusiness studentBusiness;
        private CourseBusiness courseBusiness;
        private List<Course> courseList;
        private List<Student> studentList;

        public RatingsForm()
        {
            InitializeComponent();
            IRatingRepository ratingRepository = new RatingRepository();
            IStudentRepository studentRepository = new StudentRepository();
            ICourseRepository courseRepository = new CourseRepository();
            this.ratingBusiness = new RatingBusiness(ratingRepository);
            this.studentBusiness = new StudentBusiness(studentRepository);
            this.courseBusiness = new CourseBusiness(courseRepository);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrWhiteSpace(textBox3.Text) ||
               String.IsNullOrEmpty(comboBox1.Text) || String.IsNullOrWhiteSpace(comboBox1.Text) ||
               String.IsNullOrEmpty(comboBox2.Text) || String.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Please insert all fields!");
            }
            else
            {
                if (((!Regex.Match(textBox2.Text, @"^\d+$").Success)))
                {
                    MessageBox.Show("Mark must be number!");
                    textBox2.Focus();
                    return;
                }
                if (Convert.ToInt32(textBox2.Text) > 5 || Convert.ToInt32(textBox2.Text) < 1)
                {
                    MessageBox.Show("Mark must be between 1 and 5!");
                    textBox2.Focus();
                    return;
                }
                Rating r = new Rating();
                r.GetSetDateOfRate = dateTimePicker1.Value;
                r.GetSetMark = Convert.ToInt32(textBox2.Text);
                r.GetSetNameOfTeacher = textBox3.Text;
                r.GetSetStudentId = Convert.ToString(Regex.Match(comboBox1.SelectedItem.ToString(), @"\d+").Value);
                r.GetSetCourseId = int.Parse(Regex.Match(comboBox2.SelectedItem.ToString(), @"\d+").Value);
                this.ratingBusiness.InsertRating(r);
                MessageBox.Show("Successfully inserted!");
                FillDataGrid();
                ClearFields();
            }
        }

        public void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void RatingsForm_Load(object sender, EventArgs e)
        {
            FillDataGrid();
            initCheckboxes();
        }

        public void FillDataGrid()
        {
            List<Rating> lista = this.ratingBusiness.GetAllRatings();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns.Remove("GetSetStudentId");
            dataGridView1.Columns.Remove("GetSetCourseId");
            dataGridView1.Columns["GetSetId"].HeaderText = "Id";
            dataGridView1.Columns["GetSetMark"].HeaderText = "Mark";
            dataGridView1.Columns["GetSetDateOfRate"].HeaderText = "Date of Rating";
            dataGridView1.Columns["GetSetNameOfTeacher"].HeaderText = "Teacher";
            dataGridView1.Columns["GetSetFirstStudentName"].HeaderText = "Student Name";
            dataGridView1.Columns["GetSetLastStudentName"].HeaderText = "Student Surname";
            dataGridView1.Columns["GetSetCourseName"].HeaderText = "Course Name";
            dataGridView1.Columns.Remove("GetSetJustified");
            dataGridView1.Columns.Remove("GetSetUnjustified");
            dataGridView1.Columns.Remove("GetSetClass");
            dataGridView1.Columns.Remove("GetSetDateOfBirth");
            dataGridView1.Columns.Remove("GetSetAvg");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Rating r = new Rating();
            Object id = dataGridView1.CurrentRow.Cells[0].Value;
            List<Rating> objList = this.ratingBusiness.GetAllRatingById(Convert.ToInt32(id));
            foreach (Rating obj in objList)
            {
                textBox1.Text = Convert.ToString(obj.GetSetId);
                dateTimePicker1.Value = obj.GetSetDateOfRate;
                textBox2.Text = Convert.ToString(obj.GetSetMark);
                textBox3.Text = obj.GetSetNameOfTeacher;
            }
        }

        public void initCheckboxes()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            studentList = this.studentBusiness.GetAllStudents();
            foreach (Student s in studentList)
            {
                comboBox1.Items.Add($"{s.GetSetFirstName} {s.GetSetLastName} ({s.GetSetId})");
            }
            courseList = this.courseBusiness.GetAllCourses();
            foreach (Course c in courseList)
            {
                comboBox2.Items.Add($"{c.GetSetName} ({c.GetSetId})");
            }
            comboBox1.SelectedIndex = 0;
            NewMethod();
        }

        private void NewMethod()
        {

            comboBox2.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrWhiteSpace(textBox3.Text) ||
              String.IsNullOrEmpty(comboBox1.Text) || String.IsNullOrWhiteSpace(comboBox1.Text) ||
              String.IsNullOrEmpty(comboBox2.Text) || String.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Please insert all fields!");
            }
            else
            {
                if (((!Regex.Match(textBox2.Text, @"^\d+$").Success)))
                {
                    MessageBox.Show("Mark must be number!");
                    textBox2.Focus();
                    return;
                }
                if (Convert.ToInt32(textBox2.Text) > 5 || Convert.ToInt32(textBox2.Text) < 1)
                {
                    MessageBox.Show("Mark must be between 1 and 5!");
                    textBox2.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please choose a rating!");
                    textBox1.Focus();
                    return;
                }
                Rating r = new Rating();
                r.GetSetId = Convert.ToInt32(textBox1.Text);
                r.GetSetDateOfRate = dateTimePicker1.Value;
                r.GetSetMark = Convert.ToInt32(textBox2.Text);
                r.GetSetNameOfTeacher = textBox3.Text;
                r.GetSetStudentId = Convert.ToString(Regex.Match(comboBox1.SelectedItem.ToString(), @"\d+").Value);
                r.GetSetCourseId = int.Parse(Regex.Match(comboBox2.SelectedItem.ToString(), @"\d+").Value);
                this.ratingBusiness.UpdateRating(r);
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
                    Rating r = new Rating();
                    r.GetSetId = Convert.ToInt32(textBox1.Text);
                    this.ratingBusiness.DeleteRating(r);
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