using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;

namespace TerrariumGame.Models
{
    abstract class GameObject : IMovable, IAlivable
    {
        public abstract char Icon { get; }

        public abstract bool IsAlive { get; }

        public virtual Point Position { get; set; }

        public GameObject()
        {

        }

        public GameObject(int x, int y)
        {
            Position = new Point(x, y);
        }

        public virtual void Move(Point p)
        {
            Position = p;
        }

    }
}
