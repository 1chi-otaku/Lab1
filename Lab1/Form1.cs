using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "0/1000";
            progressBar1.Minimum= 0;
            progressBar1.Maximum= 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("text.txt");
            textBox1.Text = reader.ReadToEnd();
            reader.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1000)
                progressBar1.Value = 1000;
            else
                progressBar1.Value = textBox1.Text.Length;

            label1.Text = textBox1.Text.Length.ToString() + "/" + progressBar1.Maximum.ToString();
        }
    }
}
