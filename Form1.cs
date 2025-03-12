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

namespace pr14_3_5_karamov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreateQueue_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Queue<int> queue = new Queue<int>();
            int n = Convert.ToInt32(numericUpDown1.Value);
            for (int i = 1; i <= n; i++)
            {
                queue.Enqueue(i);
            }
            for (int i = 1; i <= n; i++)
            {
                listBox1.Items.Add(queue.Dequeue());
            }
        }

        private void buttonReadFile_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Queue<string> queue = new Queue<string>();
            string[] persons = File.ReadAllLines("file.txt");
            for (int i = 0; i < persons.Length; i++)
            {
                string text = persons[i];
                string[] findAge = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (Convert.ToInt32(findAge[3]) <= 40)
                {
                    queue.Enqueue(text);
                }
            }
            for (int i = 0; i < persons.Length; i++)
            {
                string text = persons[i];
                string[] findAge = text.Split(' ');
                if (Convert.ToInt32(findAge[3]) > 40)
                {
                    queue.Enqueue(text);
                }
            }
            for (int i = 0; i < persons.Length; i++)
            {
                listBox2.Items.Add(queue.Dequeue());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            Queue<string> queue = new Queue<string>();
            string[] persons1 = File.ReadAllLines("file2.txt");
            string[] persons2 = File.ReadAllLines("file3.txt");
            List<(string FullName, int Age, int Weight)> persons = new List<(string, int, int)>();
            for (int i = 0; i < persons1.Length; i++)
            {
                string text = persons1[i];
                string[] findAge = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = $"{findAge[0]} {findAge[1]} {findAge[2]}";
                persons.Add((name, Convert.ToInt16(findAge[3]), Convert.ToInt16(findAge[4])));
            }
            for (int i = 0; i < persons2.Length; i++)
            {
                string text = persons2[i];
                string[] findAge = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = $"{findAge[0]} {findAge[1]} {findAge[2]}";
                persons.Add((name, Convert.ToInt16(findAge[3]), Convert.ToInt16(findAge[4])));
            }
            persons = persons.OrderBy(p => p.Age).ToList();
            char currentGroup = '\0';
            foreach (var person in persons)
            {
                char groupKey = person.FullName[0];
                if (groupKey != currentGroup)
                {
                    currentGroup = groupKey;
                    queue.Enqueue($"Группа {currentGroup}:");
                }
                queue.Enqueue($"{person.FullName}, Возраст: {person.Age}, Вес: {person.Weight}");
            }
            int lenght = queue.Count;
            for (int i = 0; i < lenght; i++)
            {
                listBox3.Items.Add(queue.Dequeue());
            }
        }
    }
}
