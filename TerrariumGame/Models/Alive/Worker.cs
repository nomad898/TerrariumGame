using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;

namespace TerrariumGame.Models.Alive
{
    class Worker : Employee, IManagable
    {
        public override char Icon { get { return 'W'; } }

        public int DoneWork { get; private set; }

        public Worker() : base()
        {
            DoneWork = 0;
        }

        public Worker(int x, int y) : base(x, y)
        {
            DoneWork = 0;
        }

        public Worker(string name, int x, int y) : base(name, x, y)
        {
            DoneWork = 0;
        }

        public void DoWork()
        {
            this.Salary -= 100;
        }

        public override void Talk(Employee ee)
        {
            if (ee is Worker)
            {
                this.Say("Привет!");
            }
            else
            {
                this.Say("Здравствуйте!");
            }
        }
    }
}
