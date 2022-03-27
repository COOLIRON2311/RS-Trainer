using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS_Trainer;

namespace RS_Trainer
{
    class RS05ControlSum : State
    {
        int key;

        public void Load()
        {
            Random r = new Random();
            form.SetTextLine1("Контрольная", 1);
            form.SetTextLine2("сумма:" + ((r.Next() + 100) % 1000), 2);
            base.Load();
        }

        public RS05ControlSum(Form1 form, int keyNum) : base(form)
        {
            key = keyNum;
            Load();
        }

        public override void Yes()
        {
            form.currentState = new RS05GroupMenuState(form, key);
        }

        public override void No()
        {
            form.currentState = new RS05GroupMenuState(form, key);
        }
    }
}
