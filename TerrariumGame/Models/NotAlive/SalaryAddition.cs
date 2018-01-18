using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary.Interfaces;

namespace TerrariumGame.Models.NotAlive
{
    public class SalaryAddition : GameObject, ISalaryAddition
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

        public override string ToString()
        {
            return string.Format("Icon: {0} | ", this.Icon);
        }
    }
}
