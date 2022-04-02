using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer.RS07
{
    class RS07GroupMenuState : MenuState
    {
        readonly int numberofGroups = 8;
        protected override void Load()
        {
            variants = new List<string>(numberofGroups);
            for (int i = 0; i < numberofGroups; i++)
            {
                variants.Add("Группа " + i);
            }

            variants.Add("Контр сум");

            base.Load();
        }

        public RS07GroupMenuState(Form1 form) : base(form)
        {
            Load();
        }

        public override void Yes()
        {
            if (base.currentVariant == 8)
                form.currentState = new RS07ControlSum(form);
            else
                form.currentState = new RS07GroupInputState(form, 6, 3, base.currentVariant);
        }

        public override void No()
        {
            form.currentState = new RS07RDMenuState(form, "change");
        }
    }
}
