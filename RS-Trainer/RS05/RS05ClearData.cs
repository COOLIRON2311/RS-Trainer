using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer.RS05
{
    class RS05ClearData : State
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
            form.currentState = new RS05MenuState(form);
        }

        async private void EraseData()
        {
            form.SetText("Идёт", "стирание", 4, 2);
            await Task.Delay(1000);

            form.InitializeRS05RadioData();

            form.SetText("стирание", "завершено", 2, 2);
            await Task.Delay(1000);
            form.currentState = new RS05MenuState(form);
        }

        public RS05ClearData(Form1 form) : base(form)
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
