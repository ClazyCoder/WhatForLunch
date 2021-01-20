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
    public partial class FoodForm : Form
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
        public FoodForm()
        {
            InitializeComponent();
            TagList = new List<string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            FoodName = textBox1.Text.TrimEnd(' ');
            if (radioButton1.Checked)
                TagList.Add("외식");
            else
                TagList.Add("배달");
            foreach(object item in listBox1.Items)
            {
                string tag = item as string;
                TagList.Add(tag);
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tag = textBox2.Text.TrimEnd(' ');
            if ( tag != "" && !listBox1.Items.Contains(tag))
                listBox1.Items.Add(textBox2.Text);
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button3_Click(new object(),new EventArgs());
            }
        }
    }
}
