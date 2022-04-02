using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer.RS07
{
    class RS07GroupInputState : InputState
    {
        int group;
        protected override void Load()
        {
            form.SetText("Группа " + group, form._rs07Groups[group], 2, base.offset);
            form.line2[base.offset].Font = form.myFontUL;
            base.Load();
        }

        public RS07GroupInputState(Form1 form,int cell, int offset, int groupNum) : base(form, cell, offset)
        {
            group = groupNum;
            currentDigit = 0;
            Load();
        }

        public override void Digit(int n)
        {
            base.Digit(n);
            base.RightDown();
        }

        public override void Yes()
        {
            String buf = base.GetInputText();
            if (!buf.Contains("-"))
            {
                base.Yes();
                form._rs07Groups[group] = buf;
                form.currentState = new RS07GroupMenuState(form);
            }
        }

        public override void No()
        {
            base.No();
            form.currentState = new RS07GroupMenuState(form);
        }
    }
}
