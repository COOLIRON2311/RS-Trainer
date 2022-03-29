using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    abstract class MenuState : State
    {
        protected List<String> variants;
        protected int currentVariant 
        { 
            get { return form.variants[GetType()]; }
            set { form.variants[GetType()] = value; }
        }

        protected void SetArrows()
        {
            form.line1[1].Text = "▸";
            form.line1[11].Text = "◂";
        }

        protected override void Load()
        {
            if (!form.variants.ContainsKey(GetType()))
            {
                form.variants.Add(GetType(), 0);
            }
            UpdateText();
            base.Load();
        }

        protected void UpdateText()
        {
            form.SetText(variants[currentVariant], variants[(currentVariant + 1) % variants.Count], 2, 2);
            SetArrows();
        }
        public MenuState(Form1 form) : base(form)
        {
            
        }
        public override void LeftUp()
        {
            base.LeftUp();
            currentVariant = (currentVariant + variants.Count - 1) % variants.Count;
            UpdateText();
        }

        public override void RightDown()
        {
            base.RightDown();
            currentVariant = (currentVariant + 1) % variants.Count;
            UpdateText();
        }
    }
}
