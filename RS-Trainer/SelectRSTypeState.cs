using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class SelectRSTypeState : State
    {
        int currentDigit;
        async protected override void Load()
        {
            form.SetText("Выберите", "тип Р-168:", 2, 2);
            await Task.Delay(1000);

            form.SetText("тип Р-168:", "01", 2, 5);
            
            form.line2[6].Font = form.myFontUL;
            base.Load();
        }

        public void SetType(int n)
        {
            form.line2[currentDigit + 5].Text = n.ToString();
        }

        public SelectRSTypeState(Form1 form) : base(form)
        {
            currentDigit = 1;
            Load();
        }

        public override void Digit(int n)
        {
            base.Digit(n);
            base.Digit(n);
            if (n > -1 && n < 10)
            {
                SetType(n);
            }
        }

        public override void LeftUp()
        {
            base.LeftUp();
            if (currentDigit == 1) currentDigit = 0;
            form.line2[5].Font = form.myFontUL;
            form.line2[6].Font = form.myFont;
        }

        public override void RightDown()
        {
            base.RightDown();
            if (currentDigit == 0) currentDigit = 1;
            form.line2[5].Font = form.myFont;
            form.line2[6].Font = form.myFontUL;
        }

        async public override void Yes()
        {

            switch (form.line2[5].Text + form.line2[6].Text)
            {
                case "05":

                    form.SetText("Выберите", "действие:", 2, 2);
                    await Task.Delay(1000);

                    form.line2[currentDigit + 5].Font = form.myFont;
                    form.currentState = new RS05MenuState(form);
                    break;
                default:
                    break;
            }
        }

        public override void No()
        {
            base.No();
            form.currentState = new RCMenuState(form);
            form.line2[currentDigit + 5].Font = form.myFont; 
        }
    }
}
