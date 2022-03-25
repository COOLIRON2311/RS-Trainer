using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RS05GroupInputState : InputState
    {
        int currentDigit;
        int group;
        int key;
        async public new void Load()
        {
            form.SetText("Группа "+group, form.keyGroups[key][group], 2, base.offset);
            form.line2[base.offset].Font = form.myFontUL;
        }

        public RS05GroupInputState(Form1 form,int cell, int offset, int keyNum,int groupNum) : base(form, cell, offset)
        {
            group = groupNum;
            key = keyNum;
            Load();
            currentDigit = 0;
        }

        public override void Digit(int n)
        {
            base.Digit(n);
            base.RightDown();
        }

        public override void Yes()
        {
            base.Yes();
            form.keyGroups[key][group] = base.GetInputText();
            form.currentState = new RS05GroupMenuState(form);
        }

        public override void No()
        {
            base.No();
            form.currentState = new RS05GroupMenuState(form);
        }
    }
}
