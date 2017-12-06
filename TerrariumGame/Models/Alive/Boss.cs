using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models.Alive
{
    class Boss : Employee, IManage, IManagable
    {
        public override char Icon { get { return 'B'; } }

        public int DoneWork { get; private set; }

        public Boss()
        {
            DoneWork = 0;
        }

        public void DoWork()
        {
            this.Salary -= 100;
        }

        public virtual void Manage(IManagable imngbl)
        {
            imngbl.DoWork();
        }     

        public override void Talk(Employee ee)
        {
            if (ee is Worker)
            {
                this.Say("Работать!!!");
            }
            else
            {
                this.Say("Здравствуйте!");
            }
        }
    }
}
