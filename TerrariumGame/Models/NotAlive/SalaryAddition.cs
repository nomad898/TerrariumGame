using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;

namespace TerrariumGame.Models.NotAlive
{
    class SalaryAddition : GameObject
    {
        public override bool IsAlive
        {
            get
            {
                return false;
            }
        }

        public override char Icon { get { return '$'; } }

        public SalaryAddition() : base() { }

        public SalaryAddition(int x, int y) : base(x, y) { }
    }
}
