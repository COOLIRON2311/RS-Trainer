using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RS05MenuState : MenuState
    {
        bool ready;
        async public new void Load()
        {
            ready = false;
            form.SetText("Выберите", "действие:", 2, 2);
            await Task.Delay(1000);

            variants = new List<String>(3);
            variants.Add("Выдача РД");
            variants.Add("Измен  РД");
            variants.Add("Стир   РД");

            base.Load();
            ready = true;
        }
        public RS05MenuState(Form1 form, String type) :base(form)
        {
            switch (type)
            {
                case "05":
                    Load();
                    break;
                default:
                    form.currentState = new SelectRSTypeState(form);
                    break;
            }
        }

        public override void Yes()
        {
            if (ready)
            {
                switch (currentVariant)
                {
                    case 0:
                        //Выдача
                        //form.currentState = new RS05SendRDState(form);
                        break;
                    case 1:
                        //Изменение
                        form.currentState = new RS05ChangeRDMenuState(form);
                        break;
                    case 2:
                        form.currentState = new RS05ClearData(form);
                        break;
                    default:
                        break;
                }
            }
        }

        public override void No()
        {
            if(ready)
            {
                form.currentState = new SelectRSTypeState(form);
            }
        }
    }
}
