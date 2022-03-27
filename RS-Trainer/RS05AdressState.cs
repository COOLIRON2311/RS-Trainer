using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RS05AdressState : InputState
    {
        protected override void Load()
        {
            form.SetText("Адр ключа", form._rs05address, 2, base.offset);
            form.line2[4].Font = form.myFontUL;
            base.Load();
        }
    
        public RS05AdressState(Form1 form,int cell, int offset) : base(form,cell,offset)
        {
            currentDigit = 0;
            Load();
        }

        public override void Yes()
        {
            base.Yes();
            form._rs05address = base.GetInputText();
            form.currentState = new RS05ChangeRDMenuState(form);
        }

        public override void No()
        {
            base.No();
            form.currentState = new RS05ChangeRDMenuState(form);
           
        }
    }
}
