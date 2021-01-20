using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 밥_머먹지
{
    class Food : ICloneable
    {
        public string Name
        {
            get;
            set;
        }

        public List<string> TagList
        {
            get;
            set;
        }

        public Food(string name)
        {
            Name = name;
            TagList = new List<string>();
        }
        public void addTag(string tag)
        {
            this.TagList.Add(tag);
        }
        public object Clone()
        {
            Food food = new Food(Name);
            foreach(string tag in this.TagList)
            {
                food.addTag(tag);
            }
            return food;
        }
    }
}
