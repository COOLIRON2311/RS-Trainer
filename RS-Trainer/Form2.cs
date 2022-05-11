using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Timers;
using System.Threading.Tasks;
using System.Media;

namespace RS_Trainer
{
    public partial class Form2 : Form
    {
        Form1 form1;
        Form3 form3;
        public bool Powered { get; private set; }
        private string[] channels;
        private string[] modes;
        private int channel_sel;
        private int mode_sel;
        private int callb_pressed;
        public int setup_step;
        public bool MTG_Attached;
        public bool ANT_Attached;

        public readonly int numberOfmButtons = 13;
        private List<Button> modeButtons;
        private List<Point> mbLocations;
        private List<Size> mbSizes;
        
        public readonly int numberOfchButtons = 13;
        private List<Button> channelButtons;
        private List<Point> chbLocations;
        private List<Size> chbSizes;

        private bool alerted;

        private System.Timers.Timer timer;
        private int minutes;
        private int seconds;

        private SoundPlayer sstatic;
        private SoundPlayer erased;

        public int mistakes;

        private void InitializeButtons()
        {
            mbLocations = new List<Point>(numberOfmButtons);
            mbLocations.Add(new Point(612, 575));
            mbLocations.Add(new Point(617, 558));
            mbLocations.Add(new Point(620, 536));
            mbLocations.Add(new Point(619, 512));
            mbLocations.Add(new Point(631, 492));
            mbLocations.Add(new Point(648, 478));
            mbLocations.Add(new Point(683, 476));
            mbLocations.Add(new Point(709, 478));
            mbLocations.Add(new Point(731, 492));
            mbLocations.Add(new Point(740, 513));
            mbLocations.Add(new Point(744, 536));
            mbLocations.Add(new Point(748, 557));
            mbLocations.Add(new Point(749, 575));

            mbSizes = new List<Size>(numberOfmButtons);
            mbSizes.Add(new Size(36, 17));
            mbSizes.Add(new Size(25, 17));
            mbSizes.Add(new Size(23, 17));
            mbSizes.Add(new Size(29, 17));
            mbSizes.Add(new Size(27, 17));
            mbSizes.Add(new Size(34, 17));
            mbSizes.Add(new Size(25, 17));
            mbSizes.Add(new Size(19, 17));
            mbSizes.Add(new Size(22, 17));
            mbSizes.Add(new Size(22, 17));
            mbSizes.Add(new Size(21, 17));
            mbSizes.Add(new Size(20, 17));
            mbSizes.Add(new Size(23, 17));

            modeButtons = new List<Button>(numberOfmButtons);
            for (int i = 0; i < numberOfmButtons; i++)
            {
                modeButtons.Add(new Button());
                modeButtons[i].BackColor = Color.Transparent;
                modeButtons[i].FlatStyle = FlatStyle.Flat;
                modeButtons[i].Location = mbLocations[i];
                modeButtons[i].Name = "mButton" + i;
                modeButtons[i].Size = mbSizes[i];
                modeButtons[i].ForeColor = Color.Transparent;
                modeButtons[i].UseVisualStyleBackColor = false;

                modeButtons[i].FlatAppearance.BorderColor = Color.Green;
                modeButtons[i].FlatAppearance.BorderSize = 0;
                modeButtons[i].FlatAppearance.MouseDownBackColor = Color.Transparent;
                modeButtons[i].FlatAppearance.MouseOverBackColor = Color.Transparent;

                modeButtons[i].Click += new EventHandler(this.modeButton_Click);

                this.Controls.Add(modeButtons[i]);
            }

            chbLocations = new List<Point>(numberOfchButtons);
            chbLocations.Add(new Point(859, 575));
            chbLocations.Add(new Point(860, 558));
            chbLocations.Add(new Point(859, 540));
            chbLocations.Add(new Point(860, 516));
            chbLocations.Add(new Point(873, 497));
            chbLocations.Add(new Point(893, 483));
            chbLocations.Add(new Point(912, 478));
            chbLocations.Add(new Point(936, 483));
            chbLocations.Add(new Point(957, 494));
            chbLocations.Add(new Point(973, 516));
            chbLocations.Add(new Point(979, 539));
            chbLocations.Add(new Point(980, 558));
            chbLocations.Add(new Point(976, 575));


            chbSizes = new List<Size>(numberOfchButtons);
            chbSizes.Add(new Size(15, 15));
            chbSizes.Add(new Size(15, 15));
            chbSizes.Add(new Size(15, 15));
            chbSizes.Add(new Size(15, 15));
            chbSizes.Add(new Size(15, 15));
            chbSizes.Add(new Size(15, 15));
            chbSizes.Add(new Size(20, 15));
            chbSizes.Add(new Size(15, 15));
            chbSizes.Add(new Size(15, 15));
            chbSizes.Add(new Size(15, 15));
            chbSizes.Add(new Size(15, 15));
            chbSizes.Add(new Size(15, 15));
            chbSizes.Add(new Size(15, 15));


            channelButtons = new List<Button>(numberOfchButtons);
            for(int i = 0; i < numberOfchButtons; i++)
            {
                channelButtons.Add(new Button());
                channelButtons[i].BackColor = Color.Transparent;
                channelButtons[i].FlatStyle = FlatStyle.Flat;
                channelButtons[i].Location = chbLocations[i];
                channelButtons[i].Name = "chButton" + i;
                channelButtons[i].Size = chbSizes[i];
                channelButtons[i].ForeColor = Color.Transparent;
                channelButtons[i].UseVisualStyleBackColor = false;
                
                channelButtons[i].FlatAppearance.BorderSize = 0;
                channelButtons[i].FlatAppearance.BorderColor = Color.Green;
                channelButtons[i].FlatAppearance.MouseDownBackColor = Color.Transparent;
                channelButtons[i].FlatAppearance.MouseOverBackColor = Color.Transparent;
                
                channelButtons[i].Click += new EventHandler(this.channelButton_Click);

                this.Controls.Add(channelButtons[i]);
            }
        }

        private void ChangeParents()
        {
            mtgb.Parent = RSBox;
            mtgb.Location = new Point(130, 120);

            antb.Parent = RSBox;
            antb.Location = new Point(730, 273);

            callb.Parent = MTGBox;
            callb.Location = new Point(92, 165);

            tangentb.Parent = MTGBox;
            tangentb.Location = new Point(220, 190);

            power.Parent = RSBox;
            power.Location = new Point(467, 225);

            for (int i = 0; i < numberOfmButtons; i++)
            {
                modeButtons[i].Parent = RSBox;
                modeButtons[i].Location = new Point(modeButtons[i].Location.X - RSBox.Location.X, modeButtons[i].Location.Y - RSBox.Location.Y);
            }

            for (int i = 0; i < numberOfchButtons; i++)
            {
                channelButtons[i].Parent = RSBox;
                channelButtons[i].Location = new Point(channelButtons[i].Location.X - RSBox.Location.X, channelButtons[i].Location.Y - RSBox.Location.Y);
            }
        }

        public Form2(Form1 parent)
        {
            InitializeButtons();
            InitializeComponent();

            ChangeParents();

            form1 = parent;
            form3 = new Form3();
            timer = new System.Timers.Timer
            {
                Interval = 1000
            };
            timer.Elapsed += OnTimeEvent;

            alerted = false;
            Powered = false;
            callb_pressed = 0;
            setup_step = 0;
            MTG_Attached = false;
            ANT_Attached = false;

            channels = new string[13];
            modes = "СРД ДУ Н ТМ ПШ ТЛФ ЭК 16 9,6 4,8 2,4 1,2 ВД".Split().ToArray();
            channels[6] = "СП";
            for (int i = 0; i < 6; i++)
            {
                channels[i] = $"С {6 - i}";
                channels[i + 7] = $"ДС {i + 1}";
            }

            ChangeChannelSel(5);
            ChangeModeSel(5);

            foreach (var item in new string[] { 
                "Произвести внешний осмотр",
                "Подключить антенну и микрофонно-телефонную гарнитуру",
                "Включить питание радиостанции", 
                "Подготовить радиостанцию к работе в симплексном телефонном режиме с ТМ",
                "  - стереть радиоданные из памяти радиостанции",
                "  - произвести запись радиоданных с пульта ПЗ-М", 
                "  - настроить радиостанцию",
                "  - установить заданный режим работы и номер фиксированной частоты",
                "Проверить управление радиостанцией при помощи МТГ" })
            {
                normativ.Items.Add(item);
            }
            NotifyCheckedListBox(0);
            sstatic = new SoundPlayer(Properties.Resources.sstatic);
            erased = new SoundPlayer(Properties.Resources.erased);
        }

        private string getTimer()
        {
            return string.Format("{0}:{1}", minutes.ToString().PadLeft(2, '0'),
                    seconds.ToString().PadLeft(2, '0'));
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                seconds++;

                if (seconds == 60)
                {
                    seconds = 0;
                    minutes++;
                }
                timerField.Text = getTimer();
            }));
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
            else
                NotifyCheckedListBox(1, false);
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
            else
                NotifyCheckedListBox(1, false);
        }

        private void ChangeModeSel(int newModeSel)
        {
            modeButtons[mode_sel].FlatAppearance.BorderSize = 0;
            mode_sel = newModeSel;
            modeButtons[mode_sel].FlatAppearance.BorderSize = 2;
            mode.Text = modes[mode_sel];
            Setup();
        }
        
        private void ChangeChannelSel(int newChannelSel)
        {
            channelButtons[channel_sel].FlatAppearance.BorderSize = 0;
            channel_sel = newChannelSel;
            channelButtons[channel_sel].FlatAppearance.BorderSize = 2;
            channel.Text = channels[channel_sel];
        }

        private void chn_right_Click(object sender, EventArgs e)
        {
            ChangeChannelSel(Math.Abs((channel_sel + 1) % 13));
            Setup();
        }

        private void chn_left_Click(object sender, EventArgs e)
        {
            if (channel_sel == 0)
                ChangeChannelSel(12);
            else
                ChangeChannelSel(Math.Abs((channel_sel - 1) % 13));
            Setup();
        }

        private void mode_right_Click(object sender, EventArgs e)
        {
            erased.Stop();
            if (Powered)
                sstatic.PlayLooping();
            ChangeModeSel(Math.Abs((mode_sel + 1) % 13));
            Setup();
        }

        private void mode_left_Click(object sender, EventArgs e)
        {
            erased.Stop();
            if (Powered)  
                sstatic.PlayLooping();
            if (mode_sel == 0)
                ChangeModeSel(12);
            else
                ChangeModeSel(Math.Abs((mode_sel - 1) % 13));
            Setup();
        }

        private void Off_CheckedChanged(object sender, EventArgs e)
        {
            Powered = false;
            power.Visible = false;
            NotifyCheckedListBox(2, false);
            sstatic.Stop();
        }

        private void On_CheckedChanged(object sender, EventArgs e)
        {
            Powered = true;
            power.Visible = true;
            NotifyCheckedListBox(2);
            sstatic.PlayLooping();
        }

        private void callb_Click(object sender, EventArgs e)
        {
            callb_pressed = (callb_pressed + 1) % 2;
            if (callb_pressed == 0 && mode.Text == "СРД")
            {
                if (mode.Text.Equals("СРД"))
                    NotifyCheckedListBox(4);
                erased.PlayLooping();
                setup_step++;
            }
        }

        public void NotifyCheckedListBox(int idx, bool val = true)
        {
            int i;
            int j = 0;
            normativ.SetItemChecked(idx, val);
            for (i = 0; i < idx; i++)
            {
                if (!normativ.GetItemChecked(i) && i != 3)
                {
                    if (!alerted)
                    {
                        alerted = true;
                        MessageBox.Show("Нарушен порядок выполнения норматива!", "Ошибка", MessageBoxButtons.OK);
                        mistakes++;
                    }
                }
                else
                    j++;
            }
            if (i == j)
                alerted = false;
        }
        async public void Setup()
        {   
            if (setup_step == 1)
            {
                if (form1.data_sent.All(x => x))
                {
                    NotifyCheckedListBox(5);
                    setup_step++;
                }
            }

            if (setup_step == 2)
            {
                if (mode.Text.Equals("Н"))
                {
                    NotifyCheckedListBox(6);
                    setup_step++;
                    sstatic.Stop();
                    await Task.Delay(2000);
                    sstatic.PlayLooping();
                }
            }
            if (setup_step == 3)
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
            if (setup_step == 4)
            {
                NotifyCheckedListBox(8);
                MessageBox.Show($"Выполнение норматива завершено!\nВремя: {getTimer()}\nОшибок: {mistakes}", "Готов!", MessageBoxButtons.OK);
            }
        }

        private void modeButton_Click(object sender, EventArgs e)
        {
            erased.Stop();
            if (Powered)
                sstatic.PlayLooping();
            ChangeModeSel(modeButtons.IndexOf(sender as Button));
        }

        private void channelButton_Click(object sender, EventArgs e)
        {
            ChangeChannelSel(channelButtons.IndexOf(sender as Button));
        }

        private void startTimer_Click(object sender, EventArgs e)
        {
            minutes = 0;
            seconds = 0;
            timer.Start();
        }

        private void stopTimer_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void radioData_Click(object sender, EventArgs e)
        {
            if (form3.Visible)
            {
                form3.Hide();
                form1.Focus();
            }
            else
            {
                form3.Show();
                form1.Focus();
                form3.Focus();
            }
        }

        private void showremoteb_Click(object sender, EventArgs e)
        {
            if (form1.Visible)
            {
                form1.Hide();
                form3.Focus();
            }
            else
            {
                form1.Show();
                form3.Focus();
                form1.Focus();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.force_close = true;
            form3.force_close = true;
            form1.Close();
            form3.Close();
        }

        public bool RDInput()
        {
            return mode.Text.Equals("ВД");
        }
    }
}
