using System;
using System.Linq;
using System.Windows.Forms;

namespace RS_Trainer
{
    public partial class Form2 : Form
    {
        public bool Powered { get; private set; }
        private string[] channels;
        private string[] modes;
        private int channel_sel;
        private int mode_sel;
        private int callb_pressed;
        public int setup_step;
        public bool MTG_Attached;
        public bool ANT_Attached;
        public Form2()
        {
            InitializeComponent();
            Powered = false;
            callb_pressed = 0;
            setup_step = 0;
            MTG_Attached = false;
            ANT_Attached = false;

            channel_sel = 5;
            mode_sel = 5;

            channels = new string[13];
            modes = "СРД ДУ Н ТМ ПШ ТЛФ ЭК 16 9,6 4,8 2,4 1,2 ВД".Split().ToArray();
            channels[6] = "СП";
            for (int i = 0; i < 6; i++)
            {
                channels[i] = $"С {6 - i}";
                channels[i + 7] = $"ДС {i + 1}";
            }

            foreach (var item in new string[] { "Произвести внешний осмотр", "Подключить антенну и микрофонно-телефонную гарнитуру",
                "Включить питание радиостанции", "Подготовить радиостанцию к работе в симплексном телефонном режиме с ТМ",
                "  - стереть радиоданные из памяти радиостанции", "  - произвести запись радиоданных с пульта ПЗ-М", "  - настроить радиостанцию",
                "  - установить заданный режим работы и номер фиксированной частоты", "Проверить управление радиостанцией при помощи микрофонно-телефонной гарнитуры" })
            {
                normativ.Items.Add(item);
            }
            NotifyCheckedListBox(0);
        }

        private void mtg_Click(object sender, EventArgs e)
        {
            if (MTG_Attached)
            {
                if (ANT_Attached)
                    RSBox.Image = Properties.Resources.S2;
                else
                    RSBox.Image = Properties.Resources.S1;
                MTG_Attached = false;
            }
            else
            {
                if (ANT_Attached)
                    RSBox.Image = Properties.Resources.S3;
                else
                    RSBox.Image = Properties.Resources.S4;
                MTG_Attached = true;
            }
            if (MTG_Attached && ANT_Attached)
                NotifyCheckedListBox(1);
        }

        private void ant_Click(object sender, EventArgs e)
        {
            if (ANT_Attached)
            {
                if (MTG_Attached)
                    RSBox.Image = Properties.Resources.S4;
                else
                    RSBox.Image = Properties.Resources.S1;
                ANT_Attached = false;
            }
            else
            {
                if (MTG_Attached)
                    RSBox.Image = Properties.Resources.S3;
                else
                    RSBox.Image = Properties.Resources.S2;
                ANT_Attached = true;
            }
            if (MTG_Attached && ANT_Attached)
                NotifyCheckedListBox(1);
        }

        private void chn_right_Click(object sender, EventArgs e)
        {
            channel_sel = Math.Abs((channel_sel + 1) % 13);
            channel.Text = channels[channel_sel];
            Setup();
        }

        private void chn_left_Click(object sender, EventArgs e)
        {
            if (channel_sel == 0)
                channel_sel = 12;
            else
                channel_sel = Math.Abs((channel_sel - 1) % 13);
            channel.Text = channels[channel_sel];
            Setup();
        }

        private void mode_right_Click(object sender, EventArgs e)
        {
            mode_sel = Math.Abs((mode_sel + 1) % 13);
            mode.Text = modes[mode_sel];
            Setup();
        }

        private void mode_left_Click(object sender, EventArgs e)
        {
            if (mode_sel == 0)
                mode_sel = 12;
            else
                mode_sel = Math.Abs((mode_sel - 1) % 13);
            mode.Text = modes[mode_sel];
            Setup();
        }

        private void Off_CheckedChanged(object sender, EventArgs e)
        {
            Powered = false;
            NotifyCheckedListBox(2, false);
        }

        private void On_CheckedChanged(object sender, EventArgs e)
        {
            Powered = true;
            NotifyCheckedListBox(2);
        }

        private void callb_Click(object sender, EventArgs e)
        {
            callb_pressed = (callb_pressed + 1) % 2;
            if (callb_pressed == 0 && mode.Text == "СРД")
            {
                if (mode.Text.Equals("СРД"))
                    NotifyCheckedListBox(4);
                setup_step = 3; // TODO: read RD from Remote
            }
        }

        public void NotifyCheckedListBox(int idx, bool val = true)
        {
            normativ.SetItemChecked(idx, val);
        }
        private void Setup()
        {
            if (setup_step == 1)
                NotifyCheckedListBox(5);

            if (setup_step == 3)
            {
                if (mode.Text.Equals("Н"))
                {
                    NotifyCheckedListBox(6);
                    setup_step++;
                }
            }
            if (setup_step == 4)
            {
                if (mode.Text.Equals("ТМ") && channel.Text.Equals("С 1"))
                {
                    NotifyCheckedListBox(7);
                    NotifyCheckedListBox(3);
                    setup_step++;
                }
            }
        }

        private void tangentb_Click(object sender, EventArgs e)
        {
            if (setup_step == 5)
            {
                NotifyCheckedListBox(8);
            }
        }
    }
}
