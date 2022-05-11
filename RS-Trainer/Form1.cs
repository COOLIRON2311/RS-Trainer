using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace RS_Trainer
{
    public partial class Form1 : Form
    {
        public List<List<string>> rs05keyGroups;
        public List<List<string>> _rs05keyGroups;
        public string rs05address;
        public string _rs05address;

        public List<string> rs07Groups;
        public List<string> _rs07Groups;
        public List<string> rs07freqs;
        public List<string> _rs07freqs;
        public string rs07address;
        public string _rs07address;

        public string currentPassword = "00000000";
        public bool[] data_sent;

        public List<Label> line1;
        public List<Label> line2;
        public Font myFont;
        public Font myFontUL;

        public State currentState;
        public Dictionary<Type, int> variants = new Dictionary<Type, int>();
        public RadioData radiodata;
        public Form2 form2;
        public bool force_close;
        // public SoundPlayer beeper;
        private Thread beeper;

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

        public void SetTextLine1(string text, int offset = 0)
        {
            if (offset < 0) offset = 0;
            for(int i = 0; i < 12; ++i)
            {
                if (offset > i || i - offset >= text.Length) line1[i].Text = "";
                else line1[i].Text = text.Substring(i - offset, 1);
            }
        }

        public void SetTextLine2(string text, int offset = 0)
        {
            if (offset < 0) offset = 0;
            for (int i = 0; i < 12; ++i)
            {
                if (offset > i || i - offset >= text.Length) line2[i].Text = "";
                else line2[i].Text = text.Substring(i - offset, 1);
            }
        }

        public void SetText(string line1, string line2, int offset1 = 0, int offset2 = 0)
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
            Hide();
        }

        public void InitializeRS05RadioData()
        {
            rs05address = "001";
            _rs05address = "001";

            rs05keyGroups = new List<List<string>>();
            _rs05keyGroups = new List<List<string>>();

            for (int i = 0; i < 3; i++)
            {
                rs05keyGroups.Add(new List<string>());
                _rs05keyGroups.Add(new List<string>());

                for (int j = 0; j < 8; j++)
                {
                    rs05keyGroups[i].Add("------"); //000000  ------
                    _rs05keyGroups[i].Add("------");
                }
            }
        }

        public void InitializeRS07RadioData()
        {
            rs07address = "001";
            _rs07address = "001";
            data_sent = new bool[3];

            rs07Groups = new List<string>();
            _rs07Groups = new List<string>();

            rs07freqs = new List<string>();
            _rs07freqs = new List<string>();

            for (int i = 0; i < 8; i++)
            {
                rs07Groups.Add("------");
                _rs07Groups.Add("------");
            }
            for (int i = 0; i < 6; i++)
            {
                rs07freqs.Add("-----0");
                _rs07freqs.Add("-----0");
            }
        }

        public void InitializeRadioData()
        {
            InitializeRS05RadioData();
            InitializeRS07RadioData();
        }

        public Form1()
        {
            force_close = false;
            myFont = new Font("SimSun-ExtB", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            myFontUL = new Font("SimSun-ExtB", 12, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            InitializeLines();
            InitializeComponent();
            InitializeRadioData();
            //LoadRadioDataFromFile("rd.txt");
            radiodata = new RadioData("rdata.txt");
            // beeper = new SoundPlayer(Properties.Resources.beep);

            currentState = new State(this);
            LoadMenu();
            form2 = new Form2(this);
            form2.Show();
        }

        private void beep()
        {
            if (beeper == null || !beeper.IsAlive)
            {
                beeper = new Thread(() => Console.Beep(2600, 180));
                beeper.Start();
            }
            // Task.Run(() => beeper.Play());
            // Task.Run(() => Console.Beep(2600, 180));
            // Console.Beep(2600, 180);
            // beeper.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.RightDown();
                currentState.ready = true;
                beep();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Yes();
                currentState.ready = true;
                beep();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(1);
                currentState.ready = true;
                beep();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(2);
                currentState.ready = true;
                beep();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(3);
                currentState.ready = true;
                beep();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(4);
                currentState.ready = true;
                beep();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(5);
                currentState.ready = true;
                beep();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(6);
                currentState.ready = true;
                beep();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(7);
                currentState.ready = true;
                beep();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(8);
                currentState.ready = true;
                beep();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(9);
                currentState.ready = true;
                beep();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.Digit(0);
                currentState.ready = true;
                beep();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.LeftUp();
                currentState.ready = true;
                beep();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.F();
                currentState.ready = true;
                beep();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (currentState.ready && currentState.loaded)
            {
                currentState.ready = false;
                currentState.No();
                currentState.ready = true;
                beep();
            }
        }

        public bool CompareAddress(bool alert = true)
        {
            bool r = radiodata.Address.Equals(_rs07address);
            if (!r && alert)
                MessageBox.Show("Адрес введен неверно", "Ошибка", MessageBoxButtons.OK);
            return r;
        }

        public bool CompareKey(bool alert = true)
        {
            bool r = radiodata.Key.Zip(_rs07Groups).All(x => x.First.Equals(x.Second));
            if (!r && alert)
                MessageBox.Show("Ключ введен неверно", "Ошибка", MessageBoxButtons.OK);
            return r;
        }

        public bool CompareFreq(bool alert = true)
        {
            bool r = radiodata.Freq.Zip(_rs07freqs).All(x => x.First.Equals(x.Second));
            if (!r && alert)
                MessageBox.Show("Частоты введены неверно", "Ошибка", MessageBoxButtons.OK);
            return r;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!force_close)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
