using InterfaceLibrary.Interfaces;
using InterfaceLibrary.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.Models
{
    abstract class GameObject : IGameObject
    {
        #region Fields
        #region IMovable
        public abstract char Icon { get; }

        public Point Position { get; set; }

        public virtual void Move(Point p)
        {
            Position = p;
        }
        #endregion

        #region IAlivable
        public abstract bool IsAlive { get; }
        #endregion

        #region IGameObject
        public State State { get; set; }
        #endregion
        #endregion
        #region Ctor
        public GameObject()
        {
            State = State.InGame;
        }

        public GameObject(int x, int y) : this()
        {
            Position = new Point(x, y);
        }
        #endregion
    }
}
