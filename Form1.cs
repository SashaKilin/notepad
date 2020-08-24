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

namespace notepad
{
    public partial class Form1 : Form
    {
        private string result;
        private string lines;
        private string result6;

        public Form1()
        {
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Both;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem.Enabled = false;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            result6 = folderBrowserDialog1.SelectedPath + @"\безымянный.txt";

            сохранитьToolStripMenuItem.Enabled = true;

            if (!File.Exists(@result6))
            {
                this.Text = result6 + " - Блокнот";

                using (StreamWriter fw = File.CreateText(@result6))
                {
                    fw.WriteLine(textBox1.Text);
                }

                if (textBox1.Text != "")
                {

                    MessageBox.Show("Вы удачно создали файл и записали в него текст!");
                }
                else
                {
                    MessageBox.Show("Вы удачно создали файл");
                }
            }
            
        }

        private void сохранитьВToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            result = openFileDialog1.FileName;

            using (StreamReader sr = File.OpenText(result))
            {
                this.Text = result + " - Блокнот";

                lines = sr.ReadToEnd();
            }

            using(StreamWriter sw = File.CreateText(result))
            {
                sw.WriteLine(lines);
                sw.WriteLine(textBox1.Text + "\n");
                MessageBox.Show("Вы удачно сохранили текст в выбранный файл!");
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "(*.txt)|*.txt|(*.*)|*.*";
            result6 = openFileDialog1.FileName;

            using (StreamReader sr = File.OpenText(result6))
            {
                this.Text = result6 + " - Блокнот";

                сохранитьToolStripMenuItem.Enabled = true;

                lines = sr.ReadToEnd();
                textBox1.Text = lines;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (StreamWriter sw = File.CreateText(result6))
            {
                sw.WriteLine(textBox1.Text + "\n");
                MessageBox.Show("Вы удачно сохранили текст!");
            }
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.txt)|*.txt";
            openFileDialog1.ShowDialog();
            result = openFileDialog1.FileName;

            using(StreamWriter sw = File.CreateText(result))
            {
                this.Text = result + " - Блокнот";

                sw.WriteLine(textBox1.Text);
            }
        }
    }
}
