using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 밥_머먹지
{
    public partial class FoodChange : Form
    {
        public string FoodName
        {
            get;
            set;
        }
        public List<string> TagList
        {
            get;
            set;
        }
        public FoodChange()
        {
            InitializeComponent();
        }

        private void FoodChange_Load(object sender, EventArgs e)
        {
            textBox1.Text = FoodName;
            foreach(string tag in TagList)
            {
                listBox1.Items.Add(tag);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tag = textBox2.Text.TrimEnd(' ');
            if (tag != "" && !listBox1.Items.Contains(tag))
                listBox1.Items.Add(textBox2.Text);
            textBox2.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(new object(), new EventArgs());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            FoodName = textBox1.Text.TrimEnd(' ');
            TagList.Clear();
            foreach (object item in listBox1.Items)
            {
                string tag = item as string;
                TagList.Add(tag);
            }
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
