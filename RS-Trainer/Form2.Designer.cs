
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
            ((System.ComponentModel.ISupportInitialize)(this.RSBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTGBox)).BeginInit();
            this.SuspendLayout();
            // 
            // RSBox
            // 
            this.RSBox.Image = global::RS_Trainer.Properties.Resources.S1;
            this.RSBox.Location = new System.Drawing.Point(370, 12);
            this.RSBox.Name = "RSBox";
            this.RSBox.Size = new System.Drawing.Size(880, 649);
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
            this.mtgb.Location = new System.Drawing.Point(502, 238);
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
            this.antb.Location = new System.Drawing.Point(1108, 397);
            this.antb.Name = "antb";
            this.antb.Size = new System.Drawing.Size(32, 29);
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
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.tangentb);
            this.Controls.Add(this.callb);
            this.Controls.Add(this.antb);
            this.Controls.Add(this.mtgb);
            this.Controls.Add(this.MTGBox);
            this.Controls.Add(this.RSBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.RSBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTGBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox RSBox;
        private System.Windows.Forms.PictureBox MTGBox;
        private System.Windows.Forms.Button mtgb;
        private System.Windows.Forms.Button antb;
        private System.Windows.Forms.Button callb;
        private System.Windows.Forms.Button tangentb;
    }
}