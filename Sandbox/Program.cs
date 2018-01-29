using DataBaseLibrary.EFContext;
using DataBaseLibrary.Entities;
using DataBaseLibrary.Repositories;
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
                Position = new InterfaceLibrary.UtilityModels.Point(2, 2),
                State = InterfaceLibrary.UtilityModels.State.Deleted
            };
            SalaryAddition sa3 = new SalaryAddition
            {
                Position = new InterfaceLibrary.UtilityModels.Point(3, 3)
            };
            SalaryAddition sa4 = new SalaryAddition
            {
                Position = new InterfaceLibrary.UtilityModels.Point(4, 4)
            };
            SalaryAddition sa5 = new SalaryAddition
            {
                Position = new InterfaceLibrary.UtilityModels.Point(5, 5)
            };
            SalaryAddition sa6 = new SalaryAddition
            {
                Position = new InterfaceLibrary.UtilityModels.Point(6, 6)
            };
            goL.Add(sa0);
            goL.Add(sa1);
            goL.Add(sa2);
            goL.Add(sa3);
            goL.Add(sa4);
            goL.Add(sa5);



            //IGameObject[] array = new IGameObject[10];
                      

            //goL.CopyTo(array);

            //goL.CopyTo(0, array, 4, 6);
            //int x = 0;
            //foreach (var el in array)
            //{

            //    if (el != null)
            //    {
            //        Console.Write(x.ToString() + "  " + el.Position.X);
            //    }
            //    else
            //    {
            //        Console.Write(x.ToString());
            //    }
            //    Console.WriteLine();
            //    x++;
            //}


            //List<string> dinosaurs = new List<string>();



            //dinosaurs.Add("Tyrannosaurus");
            //dinosaurs.Add("Amargasaurus");
            //dinosaurs.Add("Mamenchisaurus");
            //dinosaurs.Add("Brachiosaurus");
            //dinosaurs.Add("Compsognathus");

            //Console.WriteLine();
            //foreach (string dinosaur in dinosaurs)
            //{
            //    Console.WriteLine(dinosaur);
            //}

            //// Declare an array with 15 elements.
            //string[] array = new string[15];

            //dinosaurs.CopyTo(array);
            //dinosaurs.CopyTo(array, 12);
            //dinosaurs.CopyTo(2, array, 12, 3);

            //Console.WriteLine("\nContents of the array:");
            //foreach (string dinosaur in array)
            //{
            //    Console.WriteLine(dinosaur);
            //}


            Console.WriteLine("DONE!!!");
            Console.ReadKey(true);
        }
       
    }
}
