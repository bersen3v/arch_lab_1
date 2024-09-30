using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arch_lab_1
{
    public partial class Main : Form
    {
        int selectedIndex = 0;
        Logic logic = Logic.GetInstance();
        public Main()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.Show();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            logic.RemoveStudent(selectedIndex);
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            ChangeStudent changeStudent = new ChangeStudent();
            changeStudent.Show();
        }

        private void ShowAsListButton_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void ShowAsHistButton_Click(object sender, EventArgs e)
        {
            Hist hist = new Hist();
            hist.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = listBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logic.CreateRandomStudents(10);
        }

        public void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (Student student in logic.Students)
            {
                listBox1.Items.Add($"{student.Name} {student.Speciality} {student.Group}");
            }
        }
    }
}
