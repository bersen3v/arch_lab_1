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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace arch_lab_1
{
    public partial class ChangeStudent : Form
    {
        public static IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
        static ILogic logic = ninjectKernel.Get<ILogic>();
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
            var students = logic.GetStudentsAsMap();
            logic.UpdateStudent(int.Parse(students[students.Keys.ToList()[comboBox1.SelectedIndex]]["id"]), textBox1.Text, textBox2.Text, textBox3.Text);
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var students = logic.GetStudentsAsMap();
            textBox1.Text = students[students.Keys.ToList()[comboBox1.SelectedIndex]]["name"];
            textBox2.Text = students[students.Keys.ToList()[comboBox1.SelectedIndex]]["speciality"];
            textBox3.Text = students[students.Keys.ToList()[comboBox1.SelectedIndex]]["group"];
        }
    }
}
