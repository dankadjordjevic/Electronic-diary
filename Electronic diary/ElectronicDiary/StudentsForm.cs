using BusinessLayer;
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ElectronicDiary
{
    public partial class StudentsForm : Form
    {
        private StudentBusiness studentBusiness;

        private string[] arrClass = new string[] {"I razred", "II razred", "III razred", "IV razred", "V razred",
                "VI razred", "VII razred", "VIII razred", "I godina srednje", "II godina srednje",
                "III godina srednje", "IV godina srednje"};

        public StudentsForm()
        {
            InitializeComponent();
            IStudentRepository studentRepository = new StudentRepository();
            this.studentBusiness = new StudentBusiness(studentRepository);
            comboBox1.DataSource = arrClass;
            comboBox1.SelectedIndex = 0;
        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            List<Student> lista = this.studentBusiness.GetAllStudents();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["GetSetId"].HeaderText = "Personal Id";
            dataGridView1.Columns["GetSetJustifiedAbscence"].HeaderText = "Justified Abscence";
            dataGridView1.Columns["GetSetUnjustifiedAbscence"].HeaderText = "Unjustified Abscence";
            dataGridView1.Columns["GetSetFirstName"].HeaderText = "First Name";
            dataGridView1.Columns["GetSetLastName"].HeaderText = "Last Name";
            dataGridView1.Columns["GetSetClass"].HeaderText = "Class";
            dataGridView1.Columns["GetSetDateOfBirth"].HeaderText = "Date of Birth";
        }

        public void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrWhiteSpace(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrWhiteSpace(textBox5.Text) ||
                String.IsNullOrEmpty(comboBox1.Text) || String.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Please insert all fields!");
            }
            else
            {
                List<Student> StudentList = this.studentBusiness.GetAllStudentById(textBox1.Text);
                Student obj = new Student();
                foreach (Student s1 in StudentList)
                {
                    obj = s1;
                }
                if (!Regex.Match(textBox1.Text, @"^\d{13}$").Success)
                {
                    MessageBox.Show("Personal Id field needs to be 13 digits number!");
                    textBox1.Focus();
                    return;
                }
                if (!String.IsNullOrEmpty(obj.GetSetId))
                {
                    MessageBox.Show("Personal Id already exists!");
                    textBox1.Focus();
                    return;
                }
                if (((!Regex.Match(textBox4.Text, @"^\d+$").Success)) || ((!Regex.Match(textBox5.Text, @"^\d+$").Success)))
                {
                    MessageBox.Show("Abscences fileds must be numbers!");
                    textBox1.Focus();
                    return;
                }
                if (Convert.ToInt32(textBox4.Text) < 0 || Convert.ToInt32(textBox5.Text) < 0)
                {
                    MessageBox.Show("Must be non negative value!");
                    textBox1.Focus();
                    return;
                }
                Student s = new Student();
                s.GetSetId = textBox1.Text;
                s.GetSetFirstName = textBox2.Text;
                s.GetSetLastName = textBox3.Text;
                s.GetSetDateOfBirth = dateTimePicker1.Value;
                s.GetSetClass = comboBox1.SelectedItem.ToString();
                s.GetSetJustifiedAbscence = Convert.ToInt32(textBox4.Text);
                s.GetSetUnjustifiedAbscence = Convert.ToInt32(textBox5.Text);
                this.studentBusiness.InsertStudent(s);
                MessageBox.Show("Successfully inserted!");
                FillDataGrid();
                ClearFields();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Student s = new Student();
            Object id = dataGridView1.CurrentRow.Cells[0].Value;
            List<Student> objList = this.studentBusiness.GetAllStudentById(id.ToString());
            foreach (Student obj in objList)
            {
                textBox1.Text = obj.GetSetId;
                textBox2.Text = obj.GetSetFirstName;
                textBox3.Text = obj.GetSetLastName;
                dateTimePicker1.Value = obj.GetSetDateOfBirth;
                comboBox1.SelectedIndex = Array.IndexOf(arrClass, obj.GetSetClass);
                textBox4.Text = obj.GetSetJustifiedAbscence.ToString();
                textBox5.Text = obj.GetSetUnjustifiedAbscence.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrWhiteSpace(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrWhiteSpace(textBox5.Text) ||
                String.IsNullOrEmpty(comboBox1.Text) || String.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Please insert all fields!");
            }
            else
            {
                if (!Regex.Match(textBox1.Text, @"^\d{13}$").Success)
                {
                    MessageBox.Show("Personal Id field needs to be 13 digits number!");
                    textBox1.Focus();
                    return;
                }
                if (((!Regex.Match(textBox4.Text, @"^\d+$").Success)) || ((!Regex.Match(textBox5.Text, @"^\d+$").Success)))
                {
                    MessageBox.Show("Abscences fileds must be numbers!");
                    textBox1.Focus();
                    return;
                }
                if (Convert.ToInt32(textBox4.Text) < 0 || Convert.ToInt32(textBox5.Text) < 0)
                {
                    MessageBox.Show("Must be non negative value!");
                    textBox1.Focus();
                    return;
                }
                Student s = new Student();
                s.GetSetId = textBox1.Text;
                s.GetSetFirstName = textBox2.Text;
                s.GetSetLastName = textBox3.Text;
                s.GetSetDateOfBirth = dateTimePicker1.Value;
                s.GetSetClass = comboBox1.SelectedItem.ToString();
                s.GetSetJustifiedAbscence = Convert.ToInt32(textBox4.Text);
                s.GetSetUnjustifiedAbscence = Convert.ToInt32(textBox5.Text);
                this.studentBusiness.UpdateStudent(s);
                MessageBox.Show("Successfully updated!");
                FillDataGrid();
                ClearFields();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please provide an Personal Id!");
            }
            else
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete?",
                                     "Confirm Delete!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    Student s = new Student();
                    s.GetSetId = textBox1.Text;
                    this.studentBusiness.DeleteStudent(s);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}