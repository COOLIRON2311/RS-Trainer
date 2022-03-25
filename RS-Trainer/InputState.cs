using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class InputState : State
    {
        int currentDigit;
        protected int cellNum;
        protected int offset;

        public String GetInputText()
        {
            StringBuilder tempString = new StringBuilder();

            for (int i = offset; i < cellNum + offset; i++)
                tempString.Append(form.line2[i].Text);

            return tempString.ToString();
        }

        public InputState(Form1 form, int cell, int off) : base(form)
        {
            cellNum = cell;
            offset = off;
            currentDigit = 0;
        }

        public void SetType(int n)
        {
            form.line2[currentDigit + offset].Text = n.ToString();
        }

        public override void Digit(int n)
        {
            base.Digit(n);
            if (n > -1 && n < 10)
            {
                SetType(n);
            }
        }

        public override void LeftUp()
        {
            base.LeftUp();
            if (currentDigit != 0) currentDigit--;
            for (int i = offset; i < cellNum + offset; i++)
                form.line2[i].Font = form.myFont;
            form.line2[currentDigit + offset].Font = form.myFontUL;
        }

        public override void RightDown()
        {
            base.RightDown();
            if (currentDigit < cellNum-1) currentDigit++;
            for (int i = offset; i < cellNum + offset; i++)
                form.line2[i].Font = form.myFont;
            form.line2[currentDigit + offset].Font = form.myFontUL;
        }

        public override void Yes()
        {
            form.line2[currentDigit + offset].Font = form.myFont;
        }

        public override void No()
        {
            form.line2[currentDigit + offset].Font = form.myFont;
        }
    }
}
