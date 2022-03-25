using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RSO5GroupMenuState : MenuState
    {
        readonly int numberOfKeys = 7;
        int key;
        protected new void Load()
        {
            variants = new List<string>(numberOfKeys);
            for (int i = 0; i <= numberOfKeys; i++)
            {
                variants.Add("Группа " + i);
            }

            variants.Add("Контр сум");

            base.Load();
        }

        public RSO5GroupMenuState(Form1 form, int keyNum) : base(form)
        {
            key = keyNum;
            Load();
        }

        public override void Yes()
        {
            form.currentState = new RS05GroupInputState(form,6,3, key, base.currentVariant);
        }
    }
}
