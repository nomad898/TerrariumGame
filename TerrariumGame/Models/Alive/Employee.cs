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
        public decimal Salary { get; set; }

        public string Name { get; set; }

        public bool Mood { get; set; }

        public override bool IsAlive
        {
            get
            {
                return true;
            }
        }

        public Employee() : base() { }

        public Employee(int x, int y) : base(x, y) { }

        public void Say(string whatToSay)
        {
            if (this is Worker)
                Console.WriteLine(String.Format("{0}, {1}, {2}", this.Name, "Рабочий", whatToSay));
            else if (this is Boss)
                Console.WriteLine(String.Format("{0}, {1}, {2}", this.Name, "Босс", whatToSay));
            else
                Console.WriteLine(String.Format("{0}, {1}, {2}", this.Name, "Биг Босс", whatToSay));
        }

        public abstract void Talk(Employee ee);
    }
}
