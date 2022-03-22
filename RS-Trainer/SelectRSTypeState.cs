using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class SelectRSTypeState : State
    {
        bool ready;
        int currentDigit;
        async public void Load()
        {
            form.SetText("Идёт", "проверка", 4, 2);
            await Task.Delay(1000);
            form.SetText("Выберите", "тип Р-168:", 2, 2);
            await Task.Delay(1000);
            form.SetText("тип Р-168:", "01", 2, 5);
            form.line2[6].Font = form.myFontUL;
            ready = true;
        }

        public void SetType(int n)
        {
            form.line2[currentDigit + 5].Text = n.ToString();
        }

        public SelectRSTypeState(Form1 form) : base(form)
        {
            ready = false;
            currentDigit = 0;
            Load();
        }

        public override void Digit(int n)
        {
            base.Digit(n);
            base.Digit(n);
            if (ready && n > -1 && n < 10)
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

        public override void No()
        {
            base.No();
            if(ready) form.currentState = new MenuState(form);
        }
    }
}
