using InterfaceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.Models.NotAlive
{
    class Work : NotAlive, IWork
    {
        public override bool IsAlive
        {
            get
            {
                return false;
            }
        }

        public override char Icon { get { return '*'; } }

        public Work(): base() { }

        public Work(int x, int y) : base(x, y) { }

        public override string ToString()
        {
            return string.Format("Icon {0} | ", this.Icon);
        }
    }
}
