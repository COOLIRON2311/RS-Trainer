using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer.RS05
{
    class RS05GroupInputState : InputState
    {
        int group;
        int key;
        protected override void Load()
        {
            form.SetText("Группа " + group, form._rs05keyGroups[key][group], 2, base.offset);
            form.line2[base.offset].Font = form.myFontUL;
            base.Load();
        }

        public RS05GroupInputState(Form1 form,int cell, int offset, int keyNum,int groupNum) : base(form, cell, offset)
        {
            group = groupNum;
            key = keyNum;
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
                form._rs05keyGroups[key][group] = buf;
                form.currentState = new RS05GroupMenuState(form, key);
            }
        }

        public override void No()
        {
            base.No();
            form.currentState = new RS05GroupMenuState(form,key);
        }
    }
}
