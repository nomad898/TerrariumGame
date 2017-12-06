using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models.Alive;

namespace TerrariumGame.Models.NotAlive
{
    class House <T> where T : Employee
    {
        private List<T> list;

        public House()
        {
            list = new List<T>();
        }

        public void Add(T t)
        {
            list.Add(t);
        }      
    }
}
