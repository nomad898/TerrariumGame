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
        public static GameObject Create(string name)
        {
            switch (name)
            {
                case "Worker":
                    return new Worker();
                case "Boss":
                    return new Boss();
                case "BigBoss":
                    return new BigBoss();
                case "Work":
                    return new Work();
                case "Salary":
                    return new SalaryAddition();
                default:
                    return null;
            }
        }
    }
}
