
namespace RS_Trainer
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RSBox = new System.Windows.Forms.PictureBox();
            this.MTGBox = new System.Windows.Forms.PictureBox();
            this.mtgb = new System.Windows.Forms.Button();
            this.antb = new System.Windows.Forms.Button();
            this.callb = new System.Windows.Forms.Button();
            this.tangentb = new System.Windows.Forms.Button();
            this.Off = new System.Windows.Forms.RadioButton();
            this.On = new System.Windows.Forms.RadioButton();
            this.mode = new System.Windows.Forms.Label();
            this.mode_left = new System.Windows.Forms.Button();
            this.mode_right = new System.Windows.Forms.Button();
            this.chn_left = new System.Windows.Forms.Button();
            this.channel = new System.Windows.Forms.Label();
            this.chn_right = new System.Windows.Forms.Button();
            this.normativ = new System.Windows.Forms.CheckedListBox();
            this.power = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RSBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTGBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.power)).BeginInit();
            this.SuspendLayout();
            // 
            // RSBox
            // 
            this.RSBox.BackColor = System.Drawing.Color.Transparent;
            this.RSBox.BackgroundImage = global::RS_Trainer.Properties.Resources.S1;
            this.RSBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RSBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RSBox.Image = global::RS_Trainer.Properties.Resources.S1;
            this.RSBox.Location = new System.Drawing.Point(370, 220);
            this.RSBox.Name = "RSBox";
            this.RSBox.Size = new System.Drawing.Size(880, 441);
            this.RSBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RSBox.TabIndex = 0;
            this.RSBox.TabStop = false;
            // 
            // MTGBox
            // 
            this.MTGBox.Image = global::RS_Trainer.Properties.Resources.PUMTG;
            this.MTGBox.Location = new System.Drawing.Point(12, 12);
            this.MTGBox.Name = "MTGBox";
            this.MTGBox.Size = new System.Drawing.Size(352, 649);
            this.MTGBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MTGBox.TabIndex = 1;
            this.MTGBox.TabStop = false;
            // 
            // mtgb
            // 
            this.mtgb.AllowDrop = true;
            this.mtgb.BackColor = System.Drawing.Color.Transparent;
            this.mtgb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mtgb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mtgb.Location = new System.Drawing.Point(501, 340);
            this.mtgb.Name = "mtgb";
            this.mtgb.Size = new System.Drawing.Size(43, 43);
            this.mtgb.TabIndex = 2;
            this.mtgb.UseVisualStyleBackColor = false;
            this.mtgb.Click += new System.EventHandler(this.mtg_Click);
            // 
            // antb
            // 
            this.antb.BackColor = System.Drawing.Color.Transparent;
            this.antb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.antb.Location = new System.Drawing.Point(1101, 492);
            this.antb.Name = "antb";
            this.antb.Size = new System.Drawing.Size(46, 47);
            this.antb.TabIndex = 3;
            this.antb.UseVisualStyleBackColor = false;
            this.antb.Click += new System.EventHandler(this.ant_Click);
            // 
            // callb
            // 
            this.callb.BackColor = System.Drawing.Color.Transparent;
            this.callb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.callb.Location = new System.Drawing.Point(105, 177);
            this.callb.Name = "callb";
            this.callb.Size = new System.Drawing.Size(10, 31);
            this.callb.TabIndex = 4;
            this.callb.UseVisualStyleBackColor = false;
            this.callb.Click += new System.EventHandler(this.callb_Click);
            // 
            // tangentb
            // 
            this.tangentb.BackColor = System.Drawing.Color.Transparent;
            this.tangentb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tangentb.Location = new System.Drawing.Point(236, 198);
            this.tangentb.Name = "tangentb";
            this.tangentb.Size = new System.Drawing.Size(23, 197);
            this.tangentb.TabIndex = 5;
            this.tangentb.UseVisualStyleBackColor = false;
            this.tangentb.Click += new System.EventHandler(this.tangentb_Click);
            // 
            // Off
            // 
            this.Off.AutoSize = true;
            this.Off.Checked = true;
            this.Off.Location = new System.Drawing.Point(1023, 597);
            this.Off.Name = "Off";
            this.Off.Size = new System.Drawing.Size(49, 19);
            this.Off.TabIndex = 6;
            this.Off.TabStop = true;
            this.Off.Text = "ПИТ";
            this.Off.UseVisualStyleBackColor = true;
            this.Off.CheckedChanged += new System.EventHandler(this.Off_CheckedChanged);
            // 
            // On
            // 
            this.On.AutoSize = true;
            this.On.Location = new System.Drawing.Point(1089, 597);
            this.On.Name = "On";
            this.On.Size = new System.Drawing.Size(47, 19);
            this.On.TabIndex = 7;
            this.On.Text = "ВКЛ";
            this.On.UseVisualStyleBackColor = true;
            this.On.CheckedChanged += new System.EventHandler(this.On_CheckedChanged);
            // 
            // mode
            // 
            this.mode.AutoSize = true;
            this.mode.Location = new System.Drawing.Point(682, 602);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(30, 15);
            this.mode.TabIndex = 11;
            this.mode.Text = "ТЛФ";
            // 
            // mode_left
            // 
            this.mode_left.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mode_left.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mode_left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mode_left.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mode_left.Location = new System.Drawing.Point(642, 597);
            this.mode_left.Name = "mode_left";
            this.mode_left.Size = new System.Drawing.Size(34, 30);
            this.mode_left.TabIndex = 12;
            this.mode_left.Text = "<-";
            this.mode_left.UseVisualStyleBackColor = true;
            this.mode_left.Click += new System.EventHandler(this.mode_left_Click);
            // 
            // mode_right
            // 
            this.mode_right.Location = new System.Drawing.Point(726, 597);
            this.mode_right.Name = "mode_right";
            this.mode_right.Size = new System.Drawing.Size(34, 30);
            this.mode_right.TabIndex = 13;
            this.mode_right.Text = "->";
            this.mode_right.UseVisualStyleBackColor = true;
            this.mode_right.Click += new System.EventHandler(this.mode_right_Click);
            // 
            // chn_left
            // 
            this.chn_left.Location = new System.Drawing.Point(868, 597);
            this.chn_left.Name = "chn_left";
            this.chn_left.Size = new System.Drawing.Size(34, 30);
            this.chn_left.TabIndex = 14;
            this.chn_left.Text = "<-";
            this.chn_left.UseVisualStyleBackColor = true;
            this.chn_left.Click += new System.EventHandler(this.chn_left_Click);
            // 
            // channel
            // 
            this.channel.AutoSize = true;
            this.channel.Location = new System.Drawing.Point(908, 602);
            this.channel.Name = "channel";
            this.channel.Size = new System.Drawing.Size(24, 15);
            this.channel.TabIndex = 15;
            this.channel.Text = "С 1";
            // 
            // chn_right
            // 
            this.chn_right.Location = new System.Drawing.Point(944, 597);
            this.chn_right.Name = "chn_right";
            this.chn_right.Size = new System.Drawing.Size(34, 30);
            this.chn_right.TabIndex = 16;
            this.chn_right.Text = "->";
            this.chn_right.UseVisualStyleBackColor = true;
            this.chn_right.Click += new System.EventHandler(this.chn_right_Click);
            // 
            // normativ
            // 
            this.normativ.FormattingEnabled = true;
            this.normativ.Location = new System.Drawing.Point(370, 12);
            this.normativ.Name = "normativ";
            this.normativ.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.normativ.Size = new System.Drawing.Size(652, 202);
            this.normativ.TabIndex = 18;
            // 
            // power
            // 
            this.power.BackColor = System.Drawing.Color.Transparent;
            this.power.Image = global::RS_Trainer.Properties.Resources.light;
            this.power.Location = new System.Drawing.Point(837, 446);
            this.power.Name = "power";
            this.power.Size = new System.Drawing.Size(19, 20);
            this.power.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.power.TabIndex = 19;
            this.power.TabStop = false;
            this.power.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.power);
            this.Controls.Add(this.normativ);
            this.Controls.Add(this.chn_right);
            this.Controls.Add(this.channel);
            this.Controls.Add(this.chn_left);
            this.Controls.Add(this.mode_right);
            this.Controls.Add(this.mode_left);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.On);
            this.Controls.Add(this.Off);
            this.Controls.Add(this.tangentb);
            this.Controls.Add(this.callb);
            this.Controls.Add(this.antb);
            this.Controls.Add(this.mtgb);
            this.Controls.Add(this.MTGBox);
            this.Controls.Add(this.RSBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Р-168-5УН(1)";
            ((System.ComponentModel.ISupportInitialize)(this.RSBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTGBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.power)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox RSBox;
        private System.Windows.Forms.PictureBox MTGBox;
        private System.Windows.Forms.Button mtgb;
        private System.Windows.Forms.Button antb;
        private System.Windows.Forms.Button callb;
        private System.Windows.Forms.Button tangentb;
        private System.Windows.Forms.RadioButton Off;
        private System.Windows.Forms.RadioButton On;
        private System.Windows.Forms.Label mode;
        private System.Windows.Forms.Button mode_left;
        private System.Windows.Forms.Button mode_right;
        private System.Windows.Forms.Button chn_left;
        private System.Windows.Forms.Label channel;
        private System.Windows.Forms.Button chn_right;
        private System.Windows.Forms.CheckedListBox normativ;
        private System.Windows.Forms.PictureBox power;
    }
}