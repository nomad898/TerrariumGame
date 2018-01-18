using InterfaceLibrary.Interfaces;
using InterfaceLibrary.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models.Alive
{
    class Boss : Employee, IBoss
    {
        #region Fields
        public override char Icon { get { return 'B'; } }
               
        #endregion
        #region Ctor
        public Boss() : base()
        {
        }

        public Boss(int x, int y) : base(x, y)
        {
        }

        public Boss(string name, int x, int y) : base(name, x, y)
        {
        }

        public Boss(string name, decimal salary, int x, int y) : base(name, salary, x, y)
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

        public void DoWork()
        {
            DoneWork++;
        }

        // TODO: Code repetition
        public void DoWork(IWork work)
        {
            work.State = State.Deleted;
            DoneWork++;
        }
        #endregion
        #region IManage
        public virtual void Manage(IManagable imngbl)
        {
            if (imngbl is Worker)
            {
                imngbl.DoWork();
                (imngbl as Employee).Salary -= 100;
            }
        }
        #endregion
        #region Employee abstract methods override
        protected override string Say(string whatToSay)
        {
            return Say("Boss", whatToSay);
        }

        public override string Talk(IEmployee ee)
        {
            if (ee is IWorker)
            {
                return this.Say(string.Format("Работать, {0} - {1}!", ee.Name, ee.ToString()));
            }
            else if (ee is IManage)
            {
               return  this.Say(string.Format("Здравствуйте, {0} - {1}!", ee.Name, ee.ToString()));
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
