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
        #endregion
        public override void Manage(IManagable imngbl)
        {
            imngbl.DoWork();
            var mngbl = imngbl as Employee;
            if (mngbl != null)
            {
                mngbl.Salary -= 100;
            }
        }

        public SalaryAddition CreateSalaryAddition()
        {
            return new SalaryAddition();
        }

        #region Employee abstract methods override
        protected override void Say(string whatToSay)
        {
            Say("BigBoss", whatToSay);
        }

        public override void Talk(Employee ee)
        {
            if (this.Position == ee.Position && ee != null)
            {
                if (ee is BigBoss)
                {
                    this.Say(string.Format("Здравствуйте, {0} - {1}!", ee.Name, ee.ToString()));                 
                }
                else if (ee is IManagable)
                {
                    this.Say(string.Format("Работать, {0} - {1}!", ee.Name, ee.ToString()));
                }
            }
        }
        #endregion
    }
}
