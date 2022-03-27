using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RS05KeyMenuState : MenuState
    {
        readonly int numberOfKeys = 3;
        String action;
        int stage;
        protected override void Load()
        {
            variants = new List<string>(numberOfKeys);
            for(int i = 1; i <= numberOfKeys; i++)
            {
                variants.Add("Ключ " + i);
            }

            base.Load();
        }

        public RS05KeyMenuState(Form1 form, String action) : base(form)
        {
            this.action = action;
            stage = 0;
            Load();
        }

        async public override void Yes()
        {
            switch(action)
            {
                case "change":
                    form.currentState = new RS05GroupMenuState(form, base.currentVariant);
                    break;
                case "send":
                    switch (stage)
                    {
                        case 0:
                            if(form._keyGroups[currentVariant].Any(x => x.Contains("-")))
                            {
                                stage = 1;                            
                                form.SetText("Ключ " + (currentVariant + 1), "отсутствует", 2, 1);
                                await Task.Delay(1000);
                                form.SetText("Произвести", "набор ?", 2, 3);
                            }
                            else
                            {
                                stage = 11;
                                form.SetText("Произвести", "выдачу ?", 2, 2);
                            }
                            break;
                        case 1:
                            stage = -1;
                            form.currentState = new RS05RDMenuState(form, "change");
                            break;
                        case 11:
                            stage = 12;
                            form.SetText("Готов к", "передаче", 2, 2);
                            break;
                        case 12:
                            stage = -1;
                            form.SetText("РД", "переданы", 5, 3);
                            await Task.Delay(1000);
                            form.SetText("Выберите", "тип РД", 2, 3);
                            await Task.Delay(1000);
                            form.currentState = new RS05RDMenuState(form, "send");

                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        async public override void No()
        {
            switch(action)
            {
                case "change":
                    form.currentState = new RS05RDMenuState(form, action);
                    break;
                case "send":
                    switch (stage)
                    {
                        case 1:
                        case 11:
                        case 12:
                            stage = -1;
                            form.SetText("Выберите", "тип РД", 2, 3);
                            await Task.Delay(1000);
                            form.currentState = new RS05RDMenuState(form, "send");
                            break;
                        default:
                            break;
                    }
                    break;

            }
        }
    }
}
