using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RS05ChangeRDMenuState : MenuState
    {
        protected override void Load()
        {
            variants = new List<String>(2);
            variants.Add("Ключ");
            variants.Add("Адрес");
            
            base.Load();
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
                    form.currentState = new RS05KeyMenuState(form);
                    break;
                case 1:
                    //Адрес
                    form.currentState = new RS05AdressState(form,3,4);
                    break;
                default:
                    break;
            }
        }

        async public override void No()
        {
            form.currentState = new RS05SaveChangesState(form);
        }
    }
}
