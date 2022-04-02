using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Trainer.RS05
{
    class RS05SaveChangesState : State
    {
        async protected override void Load()
        {
            form.SetText("Сохранить", "изменение?", 2, 2);
            await Task.Delay(1000);

            base.Load();
        }

        public RS05SaveChangesState(Form1 form) : base(form)
        {
            Load();
        }

        async public override void Yes()
        {
            form.rs05address = form._rs05address;

            for (int j = 0; j < form.rs05keyGroups.Count; j++)
            {
                for (int i = 0; i < form.rs05keyGroups[j].Count; i++)
                {
                    form.rs05keyGroups[j][i] = form._rs05keyGroups[j][i];
                }
            }

            form.SetText("Идёт", "сохранение", 4, 2);
            await Task.Delay(1000);

            form.SetText("сохранение", "завершено", 2, 2);
            await Task.Delay(1000);

            form.currentState = new RS05MenuState(form);
        }

        async public override void No()
        {
            form._rs05address = form.rs05address;
            
            for(int j = 0; j < form.rs05keyGroups.Count; j++)
            {
                for(int i = 0; i < form.rs05keyGroups[j].Count; i++)
                {
                    form._rs05keyGroups[j][i] = form.rs05keyGroups[j][i];
                }
            }

            form.SetText("сохранение", "отменено", 2, 2);
            await Task.Delay(1000);

            form.currentState = new RS05MenuState(form);
        }

    }
}
