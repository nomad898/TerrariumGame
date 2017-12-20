﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;

namespace TerrariumGame.Models
{
    abstract class GameObject : IMovable, IAlivable
    {
        #region IMovable
        public abstract char Icon { get; }

        public virtual Point Position { get; set; }

        public virtual void Move(Point p)
        {
            Position = p;
        }
        #endregion

        #region IAlivable
        public abstract bool IsAlive { get; }
        #endregion

        public GameObject()
        {

        }

        public GameObject(int x, int y)
        {
            Position = new Point(x, y);
        }  
    }
}
