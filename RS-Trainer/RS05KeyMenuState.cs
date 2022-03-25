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

        protected new void Load()
        {
            variants = new List<string>(numberOfKeys);
            for(int i = 1; i <= numberOfKeys; i++)
            {
                variants.Add("Ключ " + i);
            }

            base.Load();
        }

        public RS05KeyMenuState(Form1 form) : base(form)
        {
            Load();
        }

        public override void Yes()
        {
            form.currentState = new RSO5GroupMenuState(form,base.currentVariant);
        }
    }
}
