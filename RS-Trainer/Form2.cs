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
    public partial class Form2 : Form
    {
        public bool Powered { get; private set; }
        private string[] channels;
        private string[] modes;
        private int channel_sel;
        private int mode_sel;
        public static bool MTG_Attached {get; private set;}
        public static bool ANT_Attached { get; private set; }
        public Form2()
        {
            InitializeComponent();
            Powered = false;
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
                channels[i+7] = $"ДС {i + 1}";
            }

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
        }

        private void chn_right_Click(object sender, EventArgs e)
        {
            channel_sel = Math.Abs((channel_sel + 1) % 13);
            channel.Text = channels[channel_sel];
        }

        private void chn_left_Click(object sender, EventArgs e)
        {
            if (channel_sel == 0)
                channel_sel = 12;
            else
                channel_sel = Math.Abs((channel_sel - 1) % 13);
            channel.Text = channels[channel_sel];
        }

        private void mode_right_Click(object sender, EventArgs e)
        {
            mode_sel = Math.Abs((mode_sel + 1) % 13);
            mode.Text = modes[mode_sel];
        }

        private void mode_left_Click(object sender, EventArgs e)
        {
            if (mode_sel == 0)
                mode_sel = 12;
            else
                mode_sel = Math.Abs((mode_sel - 1) % 13);
            mode.Text = modes[mode_sel];
        }

        private void Off_CheckedChanged(object sender, EventArgs e)
        {
            Powered = false;
        }

        private void On_CheckedChanged(object sender, EventArgs e)
        {
            Powered = true;
        }
    }
}
