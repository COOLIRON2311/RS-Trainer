using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer.RS07
{
    class RS07FreqMenuState : MenuState
    {
        readonly int numberofFreqs = 6;
        protected override void Load()
        {
            variants = new List<string>(numberofFreqs);
            for (int i = 0; i < numberofFreqs; i++)
            {
                variants.Add((i + 1) + " частота");
            }
            base.Load();
        }
        public RS07FreqMenuState(Form1 form) : base(form)
        {
            Load();
        }

        public override void Yes()
        {
            form.currentState = new RS07FreqInputState(form, base.currentVariant);
        }

        public override void No()
        {
            form.currentState = new RS07RDMenuState(form, "change");
        }
    }
}
