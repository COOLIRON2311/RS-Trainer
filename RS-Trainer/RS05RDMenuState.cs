using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RS05RDMenuState : MenuState
    {
        String action;

        protected override void Load()
        {
            variants = new List<String>(2);
            variants.Add("Ключ");
            variants.Add("Адрес");
            
            base.Load();
        }
        public RS05RDMenuState(Form1 form, String action) : base(form)
        {
            this.action = action;
            Load();
        }

        public override void Yes()
        {
            switch (currentVariant)
            {
                case 0:
                    //Ключ
                    form.currentState = new RS05KeyMenuState(form, action);
                    break;
                case 1:
                    //Адрес
                    form.currentState = new RS05AddressInputState(form, action, 3, 4);
                    break;
                default:
                    break;
            }
        }

        async public override void No()
        {
            if(action == "change")
            {
                form.currentState = new RS05SaveChangesState(form);
            }
            else form.currentState = new RS05MenuState(form);
        }
    }
}
