﻿using BusinessLogic;
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
    public partial class AddStudent : Form
    {
        Logic logic = Logic.GetInstance();
        public AddStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logic.AddStudent(textBox1.Text, textBox2.Text, textBox3.Text);
            this.Close();
        }
    }
}