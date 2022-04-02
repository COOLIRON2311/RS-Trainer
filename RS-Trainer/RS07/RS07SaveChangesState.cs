using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer.RS07
{
    class RS07SaveChangesState : State
    {
        async protected override void Load()
        {
            form.SetText("Сохранить", "изменение?", 2, 2);
            await Task.Delay(1000);

            base.Load();
        }

        public RS07SaveChangesState(Form1 form) : base(form)
        {
            Load();
        }

        async public override void Yes()
        {
            form.rs07address = form._rs07address;

            for (int i = 0; i < form.rs07Groups.Count; i++)
            {
                form.rs07Groups[i] = form._rs07Groups[i];
            }

            for (int i = 0; i < form.rs07freqs.Count; i++)
            {
                form.rs07freqs[i] = form._rs07freqs[i];
            }

            form.SetText("Идёт", "сохранение", 4, 2);
            await Task.Delay(1000);

            form.SetText("сохранение", "завершено", 2, 2);
            await Task.Delay(1000);

            form.CompareAddress();
            form.CompareKey();
            form.CompareFreq();

            form.currentState = new RS07MenuState(form);
        }

        async public override void No()
        {
            form._rs07address = form.rs07address;
            
            for(int i = 0; i < form.rs07Groups.Count; i++)
            {
                form._rs07Groups[i] = form.rs07Groups[i];
            }

            for (int i = 0; i < form.rs07freqs.Count; i++)
            {
                form._rs07freqs[i] = form.rs07freqs[i];
            }

            form.SetText("сохранение", "отменено", 2, 2);
            await Task.Delay(1000);

            form.currentState = new RS07MenuState(form);
        }

    }
}
