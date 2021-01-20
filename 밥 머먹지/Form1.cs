using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 밥_머먹지
{
    public partial class Form1 : Form
    {
        List<Food> foodList;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foodList = new List<Food>();
            FileInfo fileinfo = new FileInfo("맛집리스트.txt");
            if (fileinfo.Exists)
            {
                using (StreamReader file = new StreamReader("맛집리스트.txt"))
                {
                    while (file.Peek() >= 0)
                    {
                        string readString = file.ReadLine().TrimEnd('\n');
                        string[] foodString = readString.Split('/');
                        string foodName = foodString[0];
                        string foodTags = foodString[1];
                        Food food = new Food(foodName);
                        foreach (string tag in foodTags.Split(','))
                        {
                            food.addTag(tag);
                        }
                        foodList.Add(food);
                    }
                }
            }
            foreach (Food food in foodList)
            {
                foreach (string tag in food.TagList)
                {
                    if (!comboBox1.Items.Contains(tag))
                    {
                        comboBox1.Items.Add(tag);
                    }
                }
                listBox2.Items.Add(food.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            if(!listBox1.Items.Contains(comboBox1.SelectedItem))
            {
                listBox1.Items.Add(comboBox1.SelectedItem);
            }
            updateListBox();
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            updateListBox();
        }

        private void 음식추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FoodForm form = new FoodForm();
            if(form.ShowDialog() == DialogResult.OK)
            {
                Food food = new Food(form.FoodName);
                foreach(string tag in form.TagList)
                {
                    food.addTag(tag);
                }
                if (!foodList.Contains(food))
                {
                    foodList.Add(food);
                }
            }
            updateListBox();
        }
        private void updateListBox()
        {
            listBox2.Items.Clear();
            comboBox1.Items.Clear();
            foreach (Food food in foodList)
            {
                int check = 0;
                foreach (object item in listBox1.Items)
                {
                    if (!food.TagList.Contains(item))
                    {
                        check = 1;
                        break;
                    }
                }
                if (check == 0)
                {
                    listBox2.Items.Add(food.Name);
                }
            }
            foreach (Food food in foodList)
            {
                foreach (string tag in food.TagList)
                {
                    if (!comboBox1.Items.Contains(tag))
                    {
                        comboBox1.Items.Add(tag);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (StreamWriter file = new StreamWriter("맛집리스트.txt"))
            {
                foreach(Food food in foodList)
                {
                    string Line = food.Name + "/";
                    foreach(string tag in food.TagList)
                    {
                        Line += tag + ',';
                    }
                    file.WriteLine(Line.TrimEnd(','));
                }
            }
        }

        private void 음식편집ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listBox2.SelectedIndex != -1)
            {
                string foodName = listBox2.SelectedItem.ToString();
                FoodChange form = new FoodChange();
                Food food;
                foreach (Food f in foodList)
                {
                    if (f.Name == foodName)
                    {
                        food = f.Clone() as Food;
                        foodList.Remove(f);
                        form.TagList = food.TagList;
                        form.FoodName = food.Name;
                        if(form.ShowDialog() == DialogResult.OK)
                        {
                            Food food2 = new Food(form.FoodName);
                            food2.TagList = form.TagList;
                            foodList.Add(food2);
                        }
                        else
                        {
                            foodList.Add(food);
                        }    
                        break;
                    }
                }
                updateListBox();
            }
        }
    }
}
