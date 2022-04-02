using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer.RS07
{
    class RS07MenuState : MenuState
    {
        protected override void Load()
        {
            variants = new List<String>(3);
            variants.Add("Выдача РД");
            variants.Add("Измен  РД");
            variants.Add("Стир   РД");

            base.Load();
        }
        public RS07MenuState(Form1 form) :base(form)
        {
            Load();
        }

        async public override void Yes()
        {
            switch (currentVariant)
            {
                case 0:
                    //Выдача
                    form.SetText("Выберите", "тип РД", 2, 3);
                    await Task.Delay(1000);

                    form.currentState = new RS07RDMenuState(form, "send");
                    break;
                case 1:
                    //Изменение
                    form.SetText("Выберите", "тип РД", 2, 3);
                    await Task.Delay(1000);

                    form.currentState = new RS07RDMenuState(form, "change");
                    break;
                case 2:
                    form.currentState = new RS07ClearData(form);
                    break;
                default:
                    break;
            }
        }

        public override void No()
        {
            form.currentState = new SelectRSTypeState(form);
        }
    }
}
