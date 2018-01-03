﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
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
            return new SalaryAddition();
        }

        #region Employee abstract methods override
        protected override string Say(string whatToSay)
        {
            return Say("BigBoss", whatToSay);
        }

        public override string Talk(IEmployee ee)
        {
            if (ee is BigBoss)
            {
                return this.Say(string.Format("Здравствуйте, {0} - {1}!", ee.Name, ee.ToString()));
            }
            else if (ee is IManagable)
            {
                return this.Say(string.Format("Работать, {0} - {1}!", ee.Name, ee.ToString()));
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
