using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer
{
    class RS05ClearData : State
    {
        public async void Load()
        {
            form.SetTextLine1("РД будут", 3);
            form.SetTextLine2("стёрты",4);
            await Task.Delay(1000);
            form.SetTextLine1("Продолжить?", 1);
            form.SetTextLine2("");
        }

        public async void CanceErase()
        {
            form.SetTextLine1("изменение", 2);
            form.SetTextLine2("отклонено", 2);
            await Task.Delay(1000);
            form.currentState = new SelectRSTypeState(form);
        }

        public async void EraseData()
        {
            form.SetTextLine1("Идёт", 4);
            form.SetTextLine2("стирание",2);
            await Task.Delay(1000);

            form.rs05adress = "000";

            for (int i = 0; i < form.keyGroups.Count; i++)
                for (int j = 0; j < form.keyGroups[i].Count; j++)
                    form.keyGroups[i][j] = "000000";

            form.SetTextLine1("стирание", 2);
            form.SetTextLine2("завершено", 2);
            await Task.Delay(1000);
            form.currentState = new SelectRSTypeState(form);
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
