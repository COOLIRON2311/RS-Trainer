using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer.RS07
{
    class RS07FreqInputState : ExtendedInputState
    {
        int freq;
        protected override void Load()
        {
            form.SetText((freq + 1) + " частота", form._rs07freqs[freq].Substring(0, spaceOffset) + " " + form._rs07freqs[freq].Substring(spaceOffset, cellNum - spaceOffset) + " кГц", 2, base.offset);
            form.line2[base.offset].Font = form.myFontUL;
            base.Load();
        }

        public RS07FreqInputState(Form1 form, int freq) : base(form, 6, 1, 3)
        {
            this.freq = freq;
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
                form._rs07freqs[freq] = buf;
                form.currentState = new RS07FreqMenuState(form);
            }
        }

        public override void No()
        {
            base.No();
            form.currentState = new RS07FreqMenuState(form);
        }

    }
}
