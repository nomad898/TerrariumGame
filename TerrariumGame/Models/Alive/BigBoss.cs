using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models.Alive
{
    class BigBoss : Boss
    {
        public override char Icon { get { return 'K'; } }

        public BigBoss() : base()
        {

        }

        public BigBoss(int x, int y) : base(x, y)
        {
        }

        public SalaryAddition CreateSalaryAddition()
        {
            return new SalaryAddition();
        }

        public override void Talk(Employee ee)
        {
            if (ee is IManagable)
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
