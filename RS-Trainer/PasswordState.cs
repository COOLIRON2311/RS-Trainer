using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RS_Trainer
{
    class PasswordState : State
    {
        bool ready;
        StringBuilder password;
        int numberOfDigits;
        String type;
        async private void Load()
        {
            form.SetText("Доступ", "закрыт", 3, 3);
            await Task.Delay(1000);
            form.SetText("Введите", "пароль", 3, 3);
            await Task.Delay(1000);
            form.SetText("пароль", "--------", 3, 2);
            form.line2[2].Font = form.myFontUL;
            ready = true;
        }

        private void SetPassword(int n, int currentDigit)
        {
            form.line2[currentDigit + 2].Text = "*";
            password.Append(n);
            form.line2[2 + currentDigit].Font = form.myFont;
        }


        public PasswordState(Form1 form, String type) : base(form)
        {
            this.type = type;
            ready = false;
            password = new StringBuilder(8);
            numberOfDigits = 0;
            Load();
        }

        public override void Digit(int n)
        {
            base.Digit(n);
            if (ready && numberOfDigits < 8 && n > -1 && n < 10)
            {
                SetPassword(n, numberOfDigits++);
                if(numberOfDigits < 8) form.line2[2 + numberOfDigits].Font = form.myFontUL;
            }
        }

        async public override void Yes()
        {
            base.Yes();
            if(password.ToString().Length == 8)
            {
                if(password.ToString() == form.currentPassword)
                {
                    form.SetText("Идёт", "проверка", 4, 2);
                    await Task.Delay(1000);
                    switch (type)
                    {
                        case "work":
                            form.currentState = new SelectRSTypeState(form);
                            break;
                        case "copyRD":
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    form.line2[numberOfDigits + 2].Font = form.myFont;
                    form.SetText("пароль", "неверен!", 3, 3);
                    await Task.Delay(1000);
                    form.currentState = new PasswordState(form, type);
                }
            }
        }

        public override void No()
        {
            base.No();
            if(ready)
            {
                form.currentState = new RCMenuState(form);
                form.line2[numberOfDigits + 2].Font = form.myFont;
            }
        }
    }
}
