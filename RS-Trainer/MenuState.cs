using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class MenuState : State
    {
        List<String> variants;
        int currentVariant;
        public MenuState(Form1 form) : base(form)
        {
            //▸◂
            variants = new List<String>(3);
            variants.Add("Работа");
            variants.Add("Настройки");
            variants.Add("Тест");

            currentVariant = 0;
            form.SetText("▸" + variants[currentVariant] + "◂", variants[(currentVariant + 1) % variants.Count], 1, 2);
        }
        public override void LeftUp()
        {
            base.LeftUp();
            currentVariant = (currentVariant + 4) % variants.Count;
            form.SetText("▸" + variants[currentVariant] + "◂", variants[(currentVariant + 1) % variants.Count], 1, 2);
        }

        public override void RightDown()
        {
            base.RightDown();
            currentVariant = (currentVariant + 1) % variants.Count;
            form.SetText("▸" + variants[currentVariant] + "◂", variants[(currentVariant + 1) % variants.Count], 1, 2);
        }

        public override void Yes()
        {
            base.Yes();
        }

        public override void No()
        {
            base.No();
        }
    }
}
