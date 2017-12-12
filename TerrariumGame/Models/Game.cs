using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariumGame.Infrastructure;
using TerrariumGame.Infrastructure.Factory;
using TerrariumGame.Interfaces;
using TerrariumGame.Models.Alive;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models
{
    // TO DO Переписать
    class Game
    {
        private bool gameIsRunning = true;
        private int mapHeightValue = 15;
        private int mapWidthValue = 15;
        MapManipulator mapManipulator = new MapManipulator();
        Dice dice;
        ICollection<GameObject> aliveObjects = new List<GameObject>();
        ICollection<GameObject> notAliveObjects = new List<GameObject>();

        public void Run()
        {
            Map map = new Map(mapHeightValue, mapWidthValue);
            mapManipulator.Init(map);
            mapManipulator.ShowMap(map);
            dice = new Dice(map);
            while (gameIsRunning)
            {
                Play(map);
                mapManipulator.SetObjects(map);
                mapManipulator.ShowMap(map);
                Thread.Sleep(1000);
            }
        }

        private void Play(Map map)
        {
            Random random = new Random();
            foreach (var obj in map.GameObjects)
            {
                if (obj.IsAlive)
                {
                    dice.ChangeObjectPosition(obj);
                    aliveObjects.Add(obj);
                }
                else
                {
                    notAliveObjects.Add(obj);
                }
            }

            foreach (var aliveObj in aliveObjects)
            {
                foreach (var aliveO in aliveObjects)
                {
                    if (ReferenceEquals(aliveObj, aliveO))
                    {
                        continue;
                    }
                    else
                    {
                        if (aliveObj is IManage
                            && aliveO is IManagable
                            && aliveObj.Position == aliveO.Position)
                        {
                            if ((aliveObj is BigBoss && aliveO is Boss) || ( aliveO is Worker))
                            {
                                Console.SetCursorPosition(50, 0);
                                (aliveObj as BigBoss).Talk((aliveO as Employee));                          
                            }
                        }
                    }
                }
            }
        }
    }
}
