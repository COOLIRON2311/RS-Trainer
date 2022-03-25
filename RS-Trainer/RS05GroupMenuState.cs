using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RS05GroupMenuState : MenuState
    {
        readonly int numberofGroups = 7;
        int key;
        protected new void Load()
        {
            variants = new List<string>(numberofGroups);
            for (int i = 0; i <= numberofGroups; i++)
            {
                variants.Add("Группа " + i);
            }

            variants.Add("Контр сум");

            base.Load();
        }

        public RS05GroupMenuState(Form1 form, int keyNum) : base(form)
        {
            key = keyNum;
            Load();
        }

        public override void Yes()
        {
            if (base.currentVariant == 8)
                form.currentState = new RS05ControlSum(form, key);
            else
                form.currentState = new RS05GroupInputState(form,6,3, key, base.currentVariant);
        }

        public override void No()
        {
            form.currentState = new RS05KeyMenuState(form);
        }
    }
}
