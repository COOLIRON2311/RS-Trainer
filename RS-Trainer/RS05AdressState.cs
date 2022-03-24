using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RS05AdressState : State
    {
        int currentDigit;
        async public new void Load()
        {
            form.SetText("Адр ключа", form.rs05adress, 2, 4);
            form.line2[4].Font = form.myFontUL;
        }
    
        public RS05AdressState(Form1 form) : base(form)
        {
            Load();
            currentDigit = 0;
        }

        public void SetType(int n)
        {
            form.line2[currentDigit + 4].Text = n.ToString();
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
            form.line2[4].Font = form.myFont;
            form.line2[5].Font = form.myFont;
            form.line2[6].Font = form.myFont;
            form.line2[currentDigit + 4].Font = form.myFontUL;
        }

        public override void RightDown()
        {
            base.RightDown();
            if (currentDigit < 2) currentDigit++;
            form.line2[4].Font = form.myFont;
            form.line2[5].Font = form.myFont;
            form.line2[6].Font = form.myFont;
            form.line2[currentDigit + 4].Font = form.myFontUL;
        }

        public override void Yes()
        {
            base.Yes();
            form.rs05adress = form.line2[4].Text + form.line2[5].Text + form.line2[6].Text;
            form.currentState = new RS05ChangeRDMenuState(form);
            form.line2[currentDigit + 4].Font = form.myFont;
        }

        public override void No()
        {
            base.No();
            form.currentState = new RS05ChangeRDMenuState(form);
            form.line2[currentDigit + 4].Font = form.myFont;
            
        }
    }
}
