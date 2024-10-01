using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace arch_lab_1
{
    public partial class ChangeStudent : Form
    {
        Logic logic = Logic.GetInstance();
        public ChangeStudent()
        {
            InitializeComponent();
            Dictionary<int, Dictionary<string, string>> students = logic.GetStudentsAsMap();
            foreach (int student in students.Keys)
            {
                comboBox1.Items.Add($"{students[student]["name"]} {students[student]["speciality"]}");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            logic.UpdateStudent(comboBox1.SelectedIndex, textBox1.Text, textBox2.Text, textBox3.Text);
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var students = logic.GetStudentsAsMap();
            textBox1.Text = students[comboBox1.SelectedIndex]["name"];
            textBox2.Text = students[comboBox1.SelectedIndex]["speciality"];
            textBox3.Text = students[comboBox1.SelectedIndex]["group"];
        }
    }
}
