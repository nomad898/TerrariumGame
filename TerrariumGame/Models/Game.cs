﻿using System;
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
    class Game
    {
        public Map Map { get; private set; }
        private bool gameIsRunning = true;
        private const int mapHeightValue = 10;
        private const int mapWidthValue = 10;
        private const int maxHours = 24;
        private int dayCounter = 0;
        private MapManipulator mapManipulator = new MapManipulator();
        private Random random = new Random();
        private Dice dice;

        public void Run()
        {
            Map = new Map(mapHeightValue, mapWidthValue);
            mapManipulator.Init(Map);
            mapManipulator.ShowMap(Map);
            dice = new Dice(Map);
            while (gameIsRunning)
            {
                for (int hour = 0; hour < maxHours; hour++)
                {
                    Play(Map);
                    mapManipulator.SetObjects(Map);
                    mapManipulator.ShowMap(Map);
                    Thread.Sleep(1000);
                }
                dayCounter++;
                Console.Clear();
                Console.SetCursorPosition(Map.Width + 10, 0);
                Console.WriteLine(string.Format("Day Counter:  {0}", dayCounter));

            }
        }

        ICollection<GameObject> aliveObjects = new List<GameObject>();
        ICollection<GameObject> notAliveObjects = new List<GameObject>();
        ICollection<GameObject> deletedNotAliveObjects = new List<GameObject>();

        private void CollectionsClear()
        {
            aliveObjects.Clear();
            notAliveObjects.Clear();
            deletedNotAliveObjects.Clear();
        }
        private void MoveObjects()
        {
            CollectionsClear();
            foreach (var obj in Map.GameObjects)
            {
                if (obj.IsAlive)
                {
                    dice.ChangeObjectPosition(obj);
                    aliveObjects.Add(obj);
                }
                else if (!obj.IsAlive)
                {
                    notAliveObjects.Add(obj);
                }
            }
        }
        private void ClearDeletedObject()
        {
            if (deletedNotAliveObjects.Count > 0)
            {
                foreach (var el in deletedNotAliveObjects)
                {
                    Map.GameObjects.Remove(el);
                }
            }
        }
        private void CollectWork()
        {
            foreach (var alive in aliveObjects)
            {
                if (alive is Worker)
                {
                    foreach (var notAlive in notAliveObjects)
                    {
                        if (alive.Position == notAlive.Position)
                        {
                            deletedNotAliveObjects.Add(notAlive);
                            break;
                        }
                    }
                }
            }
            ClearDeletedObject();
        }
        private void WorkerGreetingLogic(GameObject worker, GameObject aliveObject)
        {
            if (worker is Worker && (worker.Position == aliveObject.Position))
            {
                if (aliveObject is Worker)
                {
                    (worker as Worker).Talk((aliveObject as Worker));
                }
                else if (aliveObject is IManage)
                {
                    (worker as Worker).Talk(aliveObject as Boss);
                }
            }
        }
        private void BossGreetingLogic(GameObject boss, GameObject aliveObject)
        {
            if (boss is Boss
                && boss is IManagable 
                && (boss.Position == aliveObject.Position))
            {
                if (aliveObject is Worker)
                {
                    (boss as Boss).Talk((aliveObject as Worker));
                }
                else if (aliveObject is IManage)
                {
                    if (aliveObject is Boss)
                    {
                        (boss as Boss).Talk(aliveObject as Boss);
                    }
                    else if (aliveObject is BigBoss)
                    {
                        (boss as Boss).Talk(aliveObject as BigBoss);
                    }
                }
            }
        }

        private void GreetAlivePeople()
        {
            foreach (var aliveObject in aliveObjects)
            {
                foreach (var aliveO in aliveObjects)
                {
                    if (!ReferenceEquals(aliveObject, aliveO)
                        && (aliveObject.Position == aliveO.Position))
                    {
                        if (aliveObject is Worker)
                        {
                            WorkerGreetingLogic(aliveObject, aliveO);
                        }
                        else if (aliveObject is Boss)
                        {
                            BossGreetingLogic(aliveObject, aliveO);
                        }
                    }
                }
            }
        }
     
        private void Play(Map map)
        {
            MoveObjects();
            CollectWork();
            GreetAlivePeople();
        }

        //private void Greet<T>(T obj1, T obj2) where T : Employee
        //{

        //}
    }
}
