using BusinessLayer;
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ElectronicDiary
{
    public partial class StudentsGDP : Form
    {
        private RatingBusiness ratingBusiness;

        public StudentsGDP()
        {
            InitializeComponent();
            IRatingRepository ratingRepository = new RatingRepository();
            this.ratingBusiness = new RatingBusiness(ratingRepository);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please insert data!");
                textBox1.Focus();
                return;
            }
            if (!Regex.Match(textBox1.Text, @"^\d{13}$").Success)
            {
                MessageBox.Show("Personal Id field needs to be 13 digits number!");
                textBox1.Focus();
                return;
            }
            List<Rating> lista = this.ratingBusiness.GetAllRatingsAVG(textBox1.Text);
            if (lista.Count > 0)
            {
                dataGridView1.DataSource = lista;
                setGridHeaders();
            }
            else
            {
                MessageBox.Show("No student with provided personal Id!");
                textBox1.Focus();
                return;
            }
        }

        public void setGridHeaders()
        {
            dataGridView1.Columns.Remove("GetSetId");
            dataGridView1.Columns.Remove("GetSetMark");
            dataGridView1.Columns["GetSetJustified"].HeaderText = "Justified Abscences";
            dataGridView1.Columns["GetSetUnjustified"].HeaderText = "Unjustified Abscences";
            dataGridView1.Columns.Remove("GetSetStudentId");
            dataGridView1.Columns["GetSetClass"].HeaderText = "Class";
            dataGridView1.Columns.Remove("GetSetCourseId");
            dataGridView1.Columns.Remove("GetSetDateOfRate");
            dataGridView1.Columns["GetSetDateOfBirth"].HeaderText = "Date of Birth";
            dataGridView1.Columns.Remove("GetSetNameOfTeacher");
            dataGridView1.Columns["GetSetFirstStudentName"].HeaderText = "Student Name";
            dataGridView1.Columns["GetSetLastStudentName"].HeaderText = "Student Surname";
            dataGridView1.Columns.Remove("GetSetCourseName");
            dataGridView1.Columns["GetSetAvg"].HeaderText = "GDP";
        }
    }
}