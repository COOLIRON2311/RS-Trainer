using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RS05ChangeRDMenuState : MenuState
    {
        async public void Load()
        {
            form.SetText("Выберите", "действие:", 2, 2);
            await Task.Delay(1000);

            variants = new List<String>(2);
            variants.Add("Ключ");
            variants.Add("Адрес");
            
            currentVariant = 0;
            form.SetText(variants[currentVariant], variants[(currentVariant + 1) % variants.Count], 2, 2);
            SetArrows();
        }
        public RS05ChangeRDMenuState(Form1 form) : base(form)
        {
            Load();
        }

        public override void Yes()
        {
            switch (currentVariant)
            {
                case 0:
                    //Ключ
                    //form.currentState = new RS05KeyMenuState(form);
                    break;
                case 1:
                    //Адрес
                    form.currentState = new RS05AdressState(form);
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
