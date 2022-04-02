using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer.RS07
{
    class RS07RDMenuState : MenuState
    {
        String action;
        int stage;

        protected override void Load()
        {
            variants = new List<String>(3);
            variants.Add("Частота");
            variants.Add("Ключ");
            variants.Add("Адрес");
            
            base.Load();
        }
        public RS07RDMenuState(Form1 form, String action) : base(form)
        {
            this.action = action;
            stage = 0;
            Load();
        }

        async public override void Yes()
        {
            switch (action)
            {
                case "change":
                    switch (currentVariant)
                    {
                        case 0:
                            //Частота
                            form.currentState = new RS07FreqMenuState(form);
                            break;
                        case 1:
                            //Ключ
                            form.currentState = new RS07GroupMenuState(form);
                            break;
                        case 2:
                            //Адрес
                            form.currentState = new RS07AddressInputState(form, action, 3, 4);
                            break;
                        default:
                            break;
                    }
                    break;
                case "send":                
                    switch (stage)
                    {
                        case 0:
                            switch (currentVariant)
                            {
                                case 0:
                                    //Частота
                                    if (form.rs07freqs.Any(x => x.Contains("-")))
                                    {
                                        stage = 1;
                                        form.SetText("Частота ", "отсутствует", 2, 1);
                                        await Task.Delay(1000);
                                        form.SetText("Произвести", "набор ?", 2, 3);
                                    }
                                    else
                                    {
                                        stage = 11;
                                        form.CompareFreq();
                                        form.SetText("Произвести", "выдачу РД?", 2, 2);
                                    }
                                    break;
                                case 1:
                                    //Ключ;
                                    if (form.rs07Groups.Any(x => x.Contains("-")))
                                    {
                                        stage = 1;
                                        form.SetText("Ключ ", "отсутствует", 2, 1);
                                        await Task.Delay(1000);
                                        form.SetText("Произвести", "набор ?", 2, 3);
                                    }
                                    else
                                    {
                                        stage = 11;
                                        form.CompareKey();
                                        form.SetText("Произвести", "выдачу РД?", 2, 2);
                                    }
                                    break;
                                case 2:
                                    //Адрес
                                    form.currentState = new RS07AddressInputState(form, "send", 3, 4);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 1:
                            stage = -1;
                            form.currentState = new RS07RDMenuState(form, "change");
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
            if(action == "change")
            {
                form.currentState = new RS07SaveChangesState(form);
            }
            else form.currentState = new RS07MenuState(form);
        }
    }
}
