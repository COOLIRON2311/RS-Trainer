﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS_Trainer;

namespace RS_Trainer.RS07
{
    class RS07ControlSum : State
    {
        protected override void Load()
        {
            Random r = new Random();
            string c;
            if (form.CompareKey(false))
                c = form.radiodata.CheckSum;
            else
                c = ((Math.Abs(r.Next()) + 100) % 1000).ToString();
            form.SetTextLine1("Контрольная", 1);
            form.SetTextLine2($"сумма: {c}", 2);
            base.Load();
        }

        public RS07ControlSum(Form1 form) : base(form)
        {
            Load();
        }

        public override void Yes()
        {
            form.currentState = new RS07GroupMenuState(form);
        }

        public override void No()
        {
            form.currentState = new RS07GroupMenuState(form);
        }
    }
}
