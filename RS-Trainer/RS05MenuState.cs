using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RS05MenuState : MenuState
    {
        protected override void Load()
        {
            variants = new List<String>(3);
            variants.Add("Выдача РД");
            variants.Add("Измен  РД");
            variants.Add("Стир   РД");

            base.Load();
        }
        public RS05MenuState(Form1 form) :base(form)
        {
            Load();
        }

        async public override void Yes()
        {
            switch (currentVariant)
            {
                case 0:
                    //Выдача
                    //form.currentState = new RS05SendRDState(form);
                    break;
                case 1:
                    //Изменение
                    form.SetText("Выберите", "действие:", 2, 2);
                    await Task.Delay(1000);

                    form.currentState = new RS05ChangeRDMenuState(form);
                    break;
                case 2:
                    form.currentState = new RS05ClearData(form);
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
