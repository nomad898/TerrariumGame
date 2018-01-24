using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary.Interfaces;

namespace TerrariumGame.Models.NotAlive
{
    public class SalaryAddition : NotAlive, ISalaryAddition
    {
        public override bool IsAlive
        {
            get
            {
                return false;
            }
        }

        public override char Icon { get { return '$'; } }

        private decimal amount;

        public decimal Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value < 0)
                {
                    amount = 0;
                }
                else
                {
                    amount = value;
                }
            }
        }
        
        public SalaryAddition() : base() { }

        public SalaryAddition(int x, int y) : base(x, y) { }

        public SalaryAddition(int x, int y, decimal amount) : base(x, y)
        {
            this.amount = amount;
        }

        public override string ToString()
        {
            return string.Format("Icon: {0} | ", this.Icon);
        }
    }
}
