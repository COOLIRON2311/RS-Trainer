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
using System.Runtime.InteropServices;

namespace RS_Trainer
{
    public partial class Form1 : Form
    {
        public List<List<String>> keyGroups;
        public List<List<String>> _keyGroups;


        public String rs05address;
        public String _rs05address;

        public String currentPassword = "00000000";

        public List<Label> line1;
        public List<Label> line2;
        public Font myFont;
        public Font myFontUL;

        public State currentState;
        public Dictionary<Type, int> variants = new Dictionary<Type, int>();
        public RadioData radiodata;

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
            currentState = new RCMenuState(this);
        }

        public void InitializeRadioData()
        {
            rs05address = "001"; //001
            _rs05address = "001";

            keyGroups = new List<List<String>>();
            _keyGroups = new List<List<String>>();

            for (int i = 0; i < 3; i++)
            {
                keyGroups.Add(new List<String>());
                _keyGroups.Add(new List<String>());

                for (int j = 0; j < 8; j++)
                {
                    keyGroups[i].Add("------"); //000000  ------
                    _keyGroups[i].Add("------");
                }
            }
        }

        public Form1()
        {
            
            myFont = new Font("SimSun-ExtB", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            myFontUL = new Font("SimSun-ExtB", 12, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            InitializeLines();
            InitializeComponent();
            InitializeRadioData();
            //LoadRadioDataFromFile("rd.txt");
            radiodata = new RadioData("rdata.txt");

            currentState = new State(this);
            LoadMenu();
            Form2 f = new Form2();
            f.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.RightDown();
                currentState.ready = true;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Yes();
                currentState.ready = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(1);
                currentState.ready = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(2);
                currentState.ready = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(3);
                currentState.ready = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(4);
                currentState.ready = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(5);
                currentState.ready = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(6);
                currentState.ready = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(7);
                currentState.ready = true;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(8);
                currentState.ready = true;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(9);
                currentState.ready = true;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(0);
                currentState.ready = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.LeftUp();
                currentState.ready = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.F();
                currentState.ready = true;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.No();
                currentState.ready = true;
            }
        }

        public void CompareAdress()
        {
            if (!radiodata.Adress.Equals(rs05address))
                MessageBox.Show("Адрес введен неверно", "Ошибка", MessageBoxButtons.OK);
        }

        public void CompareKey()
        {
            if (!radiodata.Key.Zip(keyGroups[0]).All(x => x.First.Equals(x.Second)))
                MessageBox.Show("Ключ введен неверно", "Ошибка", MessageBoxButtons.OK);
        }

        public void CompareFreq()
        {
            // TODO
        }
    }
}
