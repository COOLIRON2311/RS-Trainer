using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer.RS07
{
    class RS07AddressInputState : InputState
    {
        String action;
        int stage;

        protected override void Load()
        {
            form.SetText("Адр ключа", form._rs07address, 2, base.offset);
            form.line2[4].Font = form.myFontUL;
            base.Load();
        }
    
        public RS07AddressInputState(Form1 form, String action, int cell, int offset) : base(form,cell,offset)
        {
            this.action = action;
            currentDigit = 0;
            stage = 0;
            Load();
        }

        async public override void Yes()
        {
            base.Yes();
            switch (action)
            {
                case "change":
                    form._rs07address = base.GetInputText();
                    form.currentState = new RS07RDMenuState(form, action);
                    break;
                case "send":
                    switch (stage)
                    {
                        case 0:
                            stage = 1;
                            form._rs07address = GetInputText();
                            form.CompareAddress();
                            form.SetText("Произвести", "выдачу РД?", 2, 2);
                            break;
                        case 1:
                            stage = 2;
                            form.SetText("Готов к", "передаче", 2, 2);
                            break;
                        case 2:
                            stage = 3;
                            form.SetText("РД", "переданы", 5, 3);
                            await Task.Delay(1000);

                            form.SetText("Выберите", "тип РД", 2, 3);
                            await Task.Delay(1000);

                            form.currentState = new RS07RDMenuState(form, "send");

                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }          
        }

        public override void No()
        {
            base.No();
            form.currentState = new RS07RDMenuState(form, action);
           
        }
    }
}
