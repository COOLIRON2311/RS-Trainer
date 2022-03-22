using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    public class State
    {
        protected Form1 form;

        public State(Form1 form)
        {
            this.form = form;
        }
        public virtual void LeftUp()
        {

        }

        public virtual void F()
        {

        }
        public virtual void RightDown()
        {

        }

        public virtual void Digit(int n)
        {

        }
        public virtual void Yes()
        {

        }

        public virtual void No()
        {

        }
    }
}
