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

        #region IManagable
        public int DoneWork { get; set; }

        public void DoWork()
        {
            DoneWork++;
        }

        public void DoWork(Work work)
        {
            // TO DO Исправить
            //work.Position = new Point();
            work = null;
            DoneWork++;
        }

        public void DoWork(Work work, Point position)
        {
            work.Position = position;
            DoneWork++;
        }
        #endregion
        #region Employee abstract methods override
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

        public override void Say(string whatToSay)
        {
            Console.WriteLine(string.Format("{0}, {1}, {2}", this.Name, "Рабочий", whatToSay));
        }
        #endregion
    }
}
