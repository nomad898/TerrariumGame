﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models.Alive
{
    class Boss : Employee, IManage, IManagable
    {
        public override char Icon { get { return 'B'; } }

        public int DoneWork { get; private set; }

        public Boss() : base()
        {
            DoneWork = 0;
        }

        public Boss(int x, int y) : base(x, y) 
        {
            DoneWork = 0;
        }

        public Boss(string name, int x, int y) : base(name, x, y)
        {
            DoneWork = 0;
        }

        public void DoWork()
        {
            DoneWork++;
        }

        public virtual void Manage(IManagable imngbl)
        {
            if (imngbl is Worker)
            {
                imngbl.DoWork();
                (imngbl as Employee).Salary -= 100;
            }
        }     

        public override void Talk(Employee ee)
        {
            if (ee is Worker)
            {
                this.Say(string.Format("Работать! {0}", ee.Name));
            }            
            else
            {
                this.Say(string.Format("Здравствуйте! {0}", ee.Name));
            }
        }
    }
}
