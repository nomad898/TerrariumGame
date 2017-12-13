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
        public override char Icon { get { return 'K'; } }

        public BigBoss() : base()
        {

        }

        public BigBoss(int x, int y) : base(x, y)
        {
        }

        public BigBoss(string name, int x, int y)
            : base(name ,x, y)
        {
        }

        public override void Manage(IManagable imngbl)
        {
            imngbl.DoWork();
            (imngbl as Employee).Salary -= 100;
        }

        public SalaryAddition CreateSalaryAddition()
        {
            return new SalaryAddition();
        }

        public override void Talk(Employee ee)
        {
            if (ee is BigBoss)
            {
                this.Say(string.Format("Здравствуйте! {0}", ee.Name));
            }
            else  if (ee is IManagable)
            {
                this.Say(string.Format("Работать! {0}", ee.Name));
            }           
        }
    }
}
