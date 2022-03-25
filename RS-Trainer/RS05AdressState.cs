using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RS05AdressState : InputState
    {
        int currentDigit;
        async public new void Load()
        {
            form.SetText("Адр ключа", form.rs05adress, 2, base.offset);
            form.line2[4].Font = form.myFontUL;
        }
    
        public RS05AdressState(Form1 form,int cell, int offset) : base(form,cell,offset)
        {
            Load();
            currentDigit = 0;
        }

        public override void Yes()
        {
            base.Yes();
            form.rs05adress = base.GetInputText();
            form.currentState = new RS05ChangeRDMenuState(form);
        }

        public override void No()
        {
            base.No();
            form.currentState = new RS05ChangeRDMenuState(form);
           
        }
    }
}
