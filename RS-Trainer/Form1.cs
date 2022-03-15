using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS_Trainer
{
    public partial class Form1 : Form
    {
        int currentStage = 0;
        int currentVariant = 0;
        List<List<String>> variants;

        int inputPtr = 0;
        String currentPassword;

        void setTextStage1()
        {
            var lines = textBox1.Lines;
            lines[0] = ">" + variants[currentStage][currentVariant] + "<";
            lines[1] = variants[currentStage][(currentVariant + 1) % variants[currentStage].Count];
            textBox1.Clear();
            textBox1.Lines = lines;
        }

        void setText(String txt)
        {
            textBox1.Clear();
            textBox1.Text = txt;
        }

        void nextInputPassword(Char nxt)
        {
            String line1 = textBox1.Lines[0];
            StringBuilder txt = new StringBuilder(textBox1.Lines[1]);
            if (inputPtr < txt.Length)
            {
                currentPassword += nxt;
                txt[inputPtr] = '*';
                inputPtr += 2;
            }
            textBox1.Lines = new string[] { line1, txt.ToString() };
        }

        public Form1()
        {
            InitializeComponent();
            variants = new List<List<String>>();
            variants.Add(new List<String>());
            variants[0].Add("Работа");
            variants[0].Add("Настройки");
            variants[0].Add("Тест");
            variants.Add(new List<String>());
            setTextStage1();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentStage == 0)
            {
                currentVariant += 1;
                currentVariant %= variants[0].Count;
                setTextStage1();
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (currentStage == 0)
            {
                setText("Доступ закрыт");
                Thread.Sleep(1000);
                setText("Введите пароль");
                Thread.Sleep(1000);
                String[] lines = new string[2];
                lines[0] = "Пароль";
                lines[1] = "_ _ _ _ _ _ _ _";
                textBox1.Clear();
                textBox1.Lines = lines;

                currentStage += 1;
            }
            if (currentStage == 1)
            {
                if (currentPassword == "11111111")
                {
                    currentStage += 1;
                    variants.Add(new List<String>());
                    variants[currentStage].Add("Выдача");
                    variants[currentStage].Add("Изменить");
                    setTextStage1();
                }
                else
                {
                    inputPtr = 0;
                    currentPassword = "";
                    String[] lines = new string[2];
                    lines[0] = "Пароль";
                    lines[1] = "_ _ _ _ _ _ _ _";
                    textBox1.Clear();
                    textBox1.Lines = lines;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentStage == 1)
            {
                nextInputPassword('1');
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (currentStage == 1)
            {
                nextInputPassword('2');
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (currentStage == 1)
            {
                nextInputPassword('3');
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (currentStage == 1)
            {
                nextInputPassword('4');
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (currentStage == 1)
            {
                nextInputPassword('5');
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (currentStage == 1)
            {
                nextInputPassword('6');
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (currentStage == 1)
            {
                nextInputPassword('7');
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (currentStage == 1)
            {
                nextInputPassword('8');
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (currentStage == 1)
            {
                nextInputPassword('9');
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (currentStage == 1)
            {
                nextInputPassword('0');
            }
        }
    }
}
