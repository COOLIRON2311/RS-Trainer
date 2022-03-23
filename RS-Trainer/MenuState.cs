using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class MenuState : State
    {
        protected List<String> variants;
        protected int currentVariant;

        protected void SetArrows()
        {
            form.line1[1].Text = "▸";
            form.line1[11].Text = "◂";
        }

        public void Load()
        {
            variants = new List<String>(4);
            variants.Add("Работа");
            variants.Add("Настройки");
            variants.Add("Тест");
            variants.Add("Копир РД");

            currentVariant = 0;
            form.SetText(variants[currentVariant], variants[(currentVariant + 1) % variants.Count], 2, 2);
            SetArrows();
        }
        public MenuState(Form1 form) : base(form)
        {
            Load();
        }
        public override void LeftUp()
        {
            base.LeftUp();
            currentVariant = (currentVariant + variants.Count - 1) % variants.Count;
            form.SetText(variants[currentVariant], variants[(currentVariant + 1) % variants.Count], 2, 2);
            SetArrows();
        }

        public override void RightDown()
        {
            base.RightDown();
            currentVariant = (currentVariant + 1) % variants.Count;
            form.SetText(variants[currentVariant], variants[(currentVariant + 1) % variants.Count], 2, 2);
            SetArrows();
        }

        async public override void Yes()
        {
            base.Yes();
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

        public override void No()
        {
            base.No();
        }
    }
}
