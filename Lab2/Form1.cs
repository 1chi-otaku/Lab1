using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lab2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person person = new Person(maskedTextBox2.Text, maskedTextBox3.Text, maskedTextBox4.Text, maskedTextBox1.Text);
            person.AddToListBox(listBox1);
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBox1.Items.Remove(listBox1.Items[listBox1.SelectedIndex]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("list.txt",false);
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                writer.WriteLine(listBox1.Items[i].ToString());
            }
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            writer.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("list.txt");
            listBox1.Items.Clear();
            while (reader.Peek() >= 0)
            {
                listBox1.Items.Add (reader.ReadLine());
            }
            reader.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream stream = new FileStream("data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(ListBox.ObjectCollection));
            serializer.Serialize(stream, listBox1.Items);
            stream.Close();

            button5.Enabled = true;
            button2.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("data.xml");
            var list =  xdoc.GetElementsByTagName("anyType");

            listBox1.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                listBox1.Items.Add(list[i].InnerText);
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Person() { }
        public Person(string name, string surname, string email, string phone)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }
        public void AddToListBox(ListBox listbox)
        {
            listbox.Items.Add(Name + " " + Surname + " " + Email + " " + Phone);
        }
    }
}
