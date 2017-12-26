using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;

namespace TerrariumGame.Models.Alive
{
    abstract class Employee : GameObject
    {
        #region Fields
        public decimal Salary { get; set; }

        public string Name { get; set; }

        public bool Mood { get; set; }
        
        #region IAlivable
        public override bool IsAlive
        {
            get
            {
                return true;
            }
        }
        #endregion
        #endregion
        #region Ctor
        public Employee() : base()
        {
            
        }

        public Employee(int x, int y) : base(x, y) { }

        public Employee(string name, int x, int y) : base(x, y)
        {
            Name = name;
        }
        #endregion
        #region Methods
        protected abstract void Say(string whatToSay);

        protected virtual void Say(string rank, string whatToSay)
        {
            Console.WriteLine(string.Format("Я {0}, {1}, {2}", this.Name, rank, whatToSay));
        }

        public abstract void Talk(Employee ee);
        #endregion
    }
}
