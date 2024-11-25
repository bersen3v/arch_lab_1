using BusinessLogic;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace arch_lab_1
{
    public partial class Main : Form
    {
        int selectedIndex = 0;

        public static IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
        static ILogic logic = ninjectKernel.Get<ILogic>();

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
            Dictionary<int, Dictionary<string, string>> students = logic.GetStudentsAsMap();
            if (selectedIndex >= 0 && selectedIndex < students.Count)
            {
                logic.RemoveStudent(students.Keys.ToList()[selectedIndex]);
            }
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
            Dictionary<int, Dictionary<string, string>> students = logic.GetStudentsAsMap();
            foreach (int student in students.Keys)
            {
                listBox1.Items.Add($"{students[student]["id"]} {students[student]["name"]} {students[student]["speciality"]} {students[student]["group"]}");
            }
        }
    }
}
