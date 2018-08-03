using InterfaceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models.Alive
{
    class BigBoss : Boss, IBigBoss
    {
        #region Fields
        public override char Icon { get { return 'K'; } }
        #endregion
        #region Ctor
        public BigBoss()
        {

        }

        public BigBoss(int x, int y) : base(x, y)
        {
        }

        public BigBoss(string name, int x, int y)
            : base(name, x, y)
        {
        }

        public BigBoss(string name, decimal salary, int x, int y)
           : base(name, salary, x, y)
        {
        }

        public new void DoWork()
        {
            throw new NotSupportedException();
        }


        #endregion
        public override void Manage(IManagable imngbl)
        {
            imngbl.DoWork();
            var mngbl = imngbl as IEmployee;
            if (mngbl != null)
            {
                mngbl.Salary -= 100;
            }
        }
                
        public ISalaryAddition CreateSalaryAddition()
        {
            return new SalaryAddition(this.Position.X, this.Position.Y, new Random().Next(200, 500));
        }

        public override void TakeSalaryAddition(ISalaryAddition salary)
        {

        }

        #region Employee abstract methods override
        protected override string Say(string whatToSay)
        {
            return Say("BigBoss", whatToSay);
        }

        public override string Talk(IEmployee ee)
        {
            if (ee is IBigBoss)
            {
                return this.Say(string.Format("Hello, {0} - {1}!", ee.Name, ee.ToString()));
            }
            else if (ee is IManagable)
            {
                return this.Say(string.Format("Back to work, {0} - {1}!", ee.Name, ee.ToString()));
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
