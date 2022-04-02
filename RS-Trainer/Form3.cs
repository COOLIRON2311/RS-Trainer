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
    public partial class Form3 : Form
    {
        public bool force_close;
        public Form3()
        {
            force_close = false;
            InitializeComponent();
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!force_close)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
