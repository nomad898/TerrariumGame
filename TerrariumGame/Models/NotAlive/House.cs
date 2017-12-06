using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
