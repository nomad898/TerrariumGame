﻿using InterfaceLibrary.Interfaces;
using InterfaceLibrary.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.Models
{
    public abstract class GameObject : IGameObject
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

        public override string ToString()
        {
            return string.Format("IsAlive: {0} | Icon: {1} | Position: {2} | State: {3} ",
                this.IsAlive, this.Icon, this.Position, this.State);
        }
        #endregion
    }
}
