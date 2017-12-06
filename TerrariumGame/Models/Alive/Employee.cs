using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;

namespace TerrariumGame.Models.Alive
{
    abstract class Employee : IMovable
    {

        public decimal Salary { get; set; }

        public string Name { get; set; }

        public bool Mood { get; set; }

        public Point Position { get; set; }

        public bool IsAlive
        {
            get
            {
                return true;
            }
        }

        public void Move(Point p)
        {
            Position = p;
        }

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
