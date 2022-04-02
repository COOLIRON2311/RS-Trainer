using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class ExtendedInputState : State
    {
        public int currentDigit;
        protected int cellNum;
        protected int offset;
        protected int spaceOffset;

        System.Windows.Forms.Label GetCurrentLabel()
            => form.line2[currentDigit + offset + (currentDigit >= spaceOffset ? 1 : 0)];
        
        public String GetInputText()
        {
            StringBuilder tempString = new StringBuilder();

            for (int i = offset; i < cellNum + offset; i++)
                tempString.Append(form.line2[i + (i - offset < spaceOffset ? 0 : 1)].Text);

            return tempString.ToString();
        }

        public ExtendedInputState(Form1 form, int cellNum, int offset, int spaceOffset) : base(form)
        {
            this.cellNum = cellNum;
            this.offset = offset;
            currentDigit = 0;
            this.spaceOffset = spaceOffset;
        }

        public void SetChar(int n)
        {
            GetCurrentLabel().Text = n.ToString();
        }

        public override void Digit(int n)
        {
            base.Digit(n);
            if (n > -1 && n < 10)
            {
                SetChar(n);
            }
        }

        public override void LeftUp()
        {
            base.LeftUp();
            if (currentDigit != 0) currentDigit--;
            for (int i = offset; i < cellNum + offset; i++)
                form.line2[i].Font = form.myFont;
            GetCurrentLabel().Font = form.myFontUL;
        }

        public override void RightDown()
        {
            base.RightDown();
            if (currentDigit < cellNum - 1) currentDigit++;
            for (int i = offset; i < cellNum + offset; i++)
                form.line2[i].Font = form.myFont;
            GetCurrentLabel().Font = form.myFontUL;
        }

        public override void Yes()
        {
            GetCurrentLabel().Font = form.myFont;
        }

        public override void No()
        {
            GetCurrentLabel().Font = form.myFont;
        }
    }
}
