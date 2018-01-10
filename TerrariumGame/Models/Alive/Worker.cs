using InterfaceLibrary.Interfaces;
using InterfaceLibrary.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariumGame.Infrastructure;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models.Alive
{
    class Worker : Employee, IWorker
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
        }

        public Worker(string name, int x, int y) : base(name, x, y)
        {            
        }

        public Worker(string name, decimal salary, int x, int y) : base(name, salary, x, y)
        {            
        }
        #endregion
        #region IManagable
        private int doneWork = 0;
        public int DoneWork
        {
            get
            {
                return doneWork;
            }
            set
            {
                doneWork = value;
            }
        }
        
        public void DoWork(IWork work)
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

        public override string Talk(IEmployee ee)
        {
            if (ee is IWorker)
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
