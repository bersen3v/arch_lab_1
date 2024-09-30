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
    public partial class ChangeStudent : Form
    {
        Logic logic = Logic.GetInstance();
        public ChangeStudent()
        {
            InitializeComponent();
            foreach(Student student in logic.Students)
            {
                comboBox1.Items.Add(student.Name);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            logic.UpdateStudent(comboBox1.SelectedIndex, textBox1.Text, textBox2.Text, textBox3.Text);
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = logic.Students[comboBox1.SelectedIndex].Name;
            textBox2.Text = logic.Students[comboBox1.SelectedIndex].Speciality;
            textBox3.Text = logic.Students[comboBox1.SelectedIndex].Group;
        }
    }
}
