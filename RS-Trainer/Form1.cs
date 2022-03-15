using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS_Trainer
{
    public partial class Form1 : Form
    {
        int currentStage = 0;
        int currentVariant = 0;
        List<List<String>> variants;

        void setText()
        {
            var lines = textBox1.Lines;
            lines[0] = ">" + variants[currentStage][currentVariant] + "<";
            lines[1] = variants[currentStage][(currentVariant + 1) % variants[currentStage].Count];
            textBox1.Clear();
            textBox1.Lines = lines;
        }

        public Form1()
        {
            InitializeComponent();
            variants = new List<List<String>>();
            variants.Add(new List<String>());
            variants[0].Add("Работа");
            variants[0].Add("Настройки");
            variants[0].Add("Тест");
            setText();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentVariant += 1;
            currentVariant %= variants[0].Count;
            setText();
        }
    }
}
