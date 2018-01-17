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
            SalaryAddition sa0 = new SalaryAddition
            {
                Position = new InterfaceLibrary.UtilityModels.Point(0, 0)
            };
            SalaryAddition sa1 = new SalaryAddition
            {
                Position = new InterfaceLibrary.UtilityModels.Point(1, 1)
            };
            SalaryAddition sa2 = new SalaryAddition
            {
                Position = new InterfaceLibrary.UtilityModels.Point(2, 2)
            };
            SalaryAddition sa3 = new SalaryAddition
            {
                Position = new InterfaceLibrary.UtilityModels.Point(3, 3)
            };
            //SalaryAddition sa4 = new SalaryAddition
            //{
            //    Position = new InterfaceLibrary.UtilityModels.Point(4, 4)
            //};
            //SalaryAddition sa5 = new SalaryAddition
            //{
            //    Position = new InterfaceLibrary.UtilityModels.Point(5, 5)
            //};
            SalaryAddition sa6 = new SalaryAddition
            {
                Position = new InterfaceLibrary.UtilityModels.Point(6, 6)
            };
            goL.Add(sa0);
            goL.Add(sa1);
            goL.Add(sa2);
            goL.Add(sa3);
            //goL.Add(sa4);
            //goL.Add(sa5);

           
            Console.WriteLine(goL[3].Position.X);
            goL.Remove(sa1);
            goL[2] = sa6;
            Console.WriteLine(goL[2].Position.X);


            foreach (var el in goL)
                Console.WriteLine(el.Position.X);
            Console.WriteLine("DONE!!!");
            Console.ReadKey(true);
        }
    }
}
