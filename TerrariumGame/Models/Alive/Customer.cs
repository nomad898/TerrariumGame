using InterfaceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models.Alive
{
    class Customer : GameObject, ICustomer
    {
        public override bool IsAlive
        {
            get
            {
                return true;
            }
        }

        public override char Icon { get { return 'C'; } }

        public Customer() : base() { }

        public Customer(int x, int y) : base(x, y) { }

        #region Methods
        public void Manage(IManagable imngbl)
        {
            imngbl.DoWork();
        }

        public IWork CreateWork()
        {
            return new Work(this.Position.X, this.Position.Y);
        }

        public override string ToString()
        {
            return string.Format("Icon {0} | ", this.Icon);
        }
        #endregion
    }
}
