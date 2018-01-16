using InterfaceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using TerrariumGame.Infrastructure;
using TerrariumGame.Models.NotAlive;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            GameObjectsList goL = new GameObjectsList();
            SalaryAddition sa1 = new SalaryAddition();
            SalaryAddition sa2 = new SalaryAddition();
            SalaryAddition sa3 = new SalaryAddition();
            SalaryAddition sa4 = new SalaryAddition();
            SalaryAddition sa5 = new SalaryAddition();

            goL.Add(sa1);
            goL.Add(sa2);
            goL.Add(sa3);
            goL.Add(sa4);
            goL.Add(sa5);

            Console.WriteLine(goL.First.Data);
            

            Console.WriteLine(goL.IsReadOnly);

            List<int> myList = new List<int>();
            myList.Add(2);
            Console.WriteLine(myList[0]);

            Console.WriteLine("DONE!!!");
            Console.ReadKey(true);
        }
    }
}
