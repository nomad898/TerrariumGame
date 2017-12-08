using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Models;
using TerrariumGame.Models.Alive;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Infrastructure.Factory
{
    static class GameObjectFactory
    {
        public static GameObject Create(int id)
        {
            switch (id)
            {
                case 1:
                    return new Worker();
                case 2:
                    return new Boss();
                case 3:
                    return new BigBoss();
                case 4:
                    return new Work();
                case 5:
                    return new SalaryAddition();
                default:
                    return null;
            }
        }

        public static GameObject Create(int id, int x, int y)
        {
            switch (id)
            {
                case 1:
                    return new Worker(x, y);
                case 2:
                    return new Boss(x, y);
                case 3:
                    return new BigBoss(x, y);
                case 4:
                    return new Work(x, y);
                case 5:
                    return new SalaryAddition(x, y);
                default:
                    return null;
            }
        }
    }
}
