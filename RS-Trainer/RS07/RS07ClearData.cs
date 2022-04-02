using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer.RS07
{
    class RS07ClearData : State
    {
        async protected override void Load()
        {
            form.SetText("РД будут", "стёрты", 3, 4);
            await Task.Delay(1000);
            form.SetText("Продолжить?", "", 1);
            base.Load();
        }

        async private void CanceErase()
        {
            form.SetText("изменение", "отклонено", 2, 2);
            await Task.Delay(1000);
            form.currentState = new RS07MenuState(form);
        }

        async private void EraseData()
        {
            form.SetText("Идёт", "стирание", 4, 2);
            await Task.Delay(1000);

            form.InitializeRS07RadioData();

            form.SetText("стирание", "завершено", 2, 2);
            await Task.Delay(1000);
            form.currentState = new RS07MenuState(form);
        }

        public RS07ClearData(Form1 form) : base(form)
        {
            Load();
        }

        public override void Yes()
        {
            EraseData();
        }

        public override void No()
        {
            CanceErase();
        }
    }
}
