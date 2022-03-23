using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RS05MenuState : MenuState
    {
        async public void Load()
        {
            form.SetText("Выберите", "действие:", 2, 2);
            await Task.Delay(1000);

            variants = new List<String>(3);
            variants.Add("Выдача РД");
            variants.Add("Измен  РД");
            variants.Add("Стир   РД");
            
            currentVariant = 0;
            form.SetText(variants[currentVariant], variants[(currentVariant + 1) % variants.Count], 2, 2);
            SetArrows();
        }
        public RS05MenuState(Form1 form, String type) :base(form)
        {
            if(type != "05")
            {
                form.currentState = new SelectRSTypeState(form);
            }
            else
            {
                Load();
            }
        }

        public override void Yes()
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
                    //Стирание
                    //form.currentState = new RS05ClearRDState(form);
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
