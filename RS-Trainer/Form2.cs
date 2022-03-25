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
        public static bool MTG_Attached {get; private set;}
        public static bool ANT_Attached { get; private set; }
        public Form2()
        {
            InitializeComponent();
            //mtg.BackColor = Color.Transparent;
            //mtg.ForeColor = Color.Transparent;
            MTG_Attached = false;
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
    }
}
