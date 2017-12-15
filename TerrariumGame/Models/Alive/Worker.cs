using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models.Alive
{
    class Worker : Employee, IManagable
    {
        public override char Icon { get { return 'W'; } }

        public int DoneWork { get; set; }

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
            DoneWork++;
        }

        public void DoWork(Work work)
        {
            // TO DO Исправить
            work.Position = new Point();
            DoneWork++;
        }

        public void DoWork(Work work, Point position)
        {
            work.Position = position;
            DoneWork++;
        }

        public override void Talk(Employee ee)
        {
            if (ee != null)
            {
                if (ee is Worker)
                {
                    this.Say(string.Format("Привет! {0}", ee.Name));
                }
                else if (ee is IManage)
                {
                    this.Say(string.Format("Здравствуйте! {0}", ee.Name));
                }
                else
                {
                    this.Say(string.Format("Здравствуйте! {0}", ee.Name));
                }
            }
        }
    }
}
