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

        public List<List<String>> keyGroups;

        int inputPtr = 0;
        public String currentPassword = "00000000";

        public List<Label> line1;
        public List<Label> line2;
        public Font myFont;
        public Font myFontUL;
        public String rs05adress;

        public State currentState;

        public void InitializeLines()
        {
            line1 = new List<Label>(12);
            line2 = new List<Label>(12);

            for (int i = 0; i < 12; ++i)
            {
                line1.Add(new Label());
                line2.Add(new Label());

                line1[i].Location = new System.Drawing.Point(76 + i * 14, 151);
                line1[i].Name = "line1[" + i + "]";
                line1[i].Size = new System.Drawing.Size(13, 27);
                line1[i].BackColor = Color.FromArgb(80, 83, 83, 91);
                line1[i].TextAlign = ContentAlignment.BottomCenter;
                line1[i].Font = myFont;

                this.Controls.Add(line1[i]);

                line2[i].Location = new System.Drawing.Point(76 + i * 14, 180);
                line2[i].Name = "line2[" + i + "]";
                line2[i].Size = new System.Drawing.Size(13, 27);
                line2[i].BackColor = Color.FromArgb(80, 83, 83, 91);
                line2[i].TextAlign = ContentAlignment.BottomCenter;
                line2[i].Font = myFont;

                this.Controls.Add(line2[i]);
            }
        }

        public void SetTextLine1(String text, int offset = 0)
        {
            if (offset < 0) offset = 0;
            for(int i = 0; i < 12; ++i)
            {
                if (offset > i || i - offset >= text.Length) line1[i].Text = "";
                else line1[i].Text = text.Substring(i - offset, 1);
            }
        }

        public void SetTextLine2(String text, int offset = 0)
        {
            if (offset < 0) offset = 0;
            for (int i = 0; i < 12; ++i)
            {
                if (offset > i || i - offset >= text.Length) line2[i].Text = "";
                else line2[i].Text = text.Substring(i - offset, 1);
            }
        }

        public void SetText(String line1, String line2, int offset1 = 0, int offset2 = 0)
        {
            SetTextLine1(line1, offset1);
            SetTextLine2(line2, offset2);
        }

        public void LoadPhone()
        {
            SetText("Диагностика", "устройства", 1, 1);
            Thread.Sleep(1000);
            SetText("Устройство", "исправно", 1, 2);
            Thread.Sleep(1000);
            SetText("Пульт", "записи", 4, 3);
            Thread.Sleep(1000);
            SetText("Выберите", "режим", 2, 3);
            Thread.Sleep(1000);
            LoadMenu();
        }

        async public void LoadMenu()
        {
            //Timer timer = new System.Timers.Timer(1000);
            SetText("Диагностика", "устройства", 1, 1);
            await Task.Delay(1000);
            SetText("Устройство", "исправно", 1, 2);
            await Task.Delay(1000);
            SetText("Пульт", "записи", 4, 3);
            await Task.Delay(1000);
            SetText("Выберите", "режим", 2, 3);
            await Task.Delay(1000);
            currentState = new RS05KeyMenuState(this);
        }

        public void InitializeRadioData()
        {
            rs05adress = "000";

            keyGroups = new List<List<String>>();

            for (int i = 0; i < 3; i++)
            {
                keyGroups.Add(new List<String>());

                for (int j = 0; j < 8; j++)
                    keyGroups[i].Add("000000");
            }
        }
        public Form1()
        {
            myFont = new System.Drawing.Font("SimSun-ExtB", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            myFontUL = new System.Drawing.Font("SimSun-ExtB", 17.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            InitializeLines();
            InitializeComponent();
            InitializeRadioData();

            currentState = new State(this);
            LoadMenu();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentState.RightDown();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            currentState.Yes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentState.Digit(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentState.Digit(2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentState.Digit(3);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentState.Digit(4);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentState.Digit(5);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentState.Digit(6);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            currentState.Digit(7);
        }

        private void button11_Click(object sender, EventArgs e)
        {

            currentState.Digit(8);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            currentState.Digit(9);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            currentState.Digit(0);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentState.LeftUp();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentState.F();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            currentState.No();
        }
    }
}
