using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariumGame.Infrastructure;
using TerrariumGame.Interfaces;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models.Alive
{
    class Worker : Employee, IManagable
    {
        #region Fields
        public override char Icon { get { return 'W'; } }
        #endregion
        #region Ctor
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
        #endregion
        #region IManagable
        public int DoneWork { get; set; }


        public void DoWork(Work work)
        {
            work.State = State.Deleted;
            DoneWork++;
        }

        public void DoWork()
        {
            DoneWork++;
        }
        #endregion
        #region Employee abstract methods override
        protected override string Say(string whatToSay)
        {
            return Say("Worker", whatToSay);
        }

        public override string Talk(Employee ee)
        {
            if (ee is Worker)
            {
                return this.Say(string.Format("Привет, {0} - {1}!", ee.Name, ee.ToString()));
            }
            else if (ee is IManage)
            {
                return this.Say(string.Format("Здравствуйте, {0}! - {1}!", ee.Name, ee.ToString()));
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
