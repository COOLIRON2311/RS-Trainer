using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RCMenuState : MenuState
    {
        protected new void Load()
        {
            variants = new List<String>(4);
            variants.Add("Работа");
            variants.Add("Настройки");
            variants.Add("Тест");
            variants.Add("Копир РД");

            base.Load();
        }
        public RCMenuState(Form1 form) : base(form)
        {
            Load();
        }
        public override void Yes()
        {
            switch (currentVariant)
            {
                case 0:
                    form.currentState = new PasswordState(form, "work");
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    form.currentState = new PasswordState(form, "copyRD");
                    break;
                default:
                    break;
            }
            
        }

        public override void F()
        {
            //to turn off the remote controller
        }
    }
}
