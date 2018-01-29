using InterfaceLibrary.Interfaces;
using InterfaceLibrary.Interfaces.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Infrastructure;
using TerrariumGame.Models;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Tests.InfrastructureTests
{
    [TestClass]
    public class GameObjectsListTests
    {
        [TestMethod]
        public void First_GetFirstItem_FirstItemReturned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();
            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);

            // assert
            Assert.AreEqual(gameObject1, goList.First);
        }
        
        [TestMethod]
        public void Add_NewItemAddedToList_NewItemReturned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();
            IGameObject newGameObject = new SalaryAddition();

            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);
            goList.Add(newGameObject);

            // assert
            Assert.AreEqual(newGameObject, goList.Last);
        }

        [TestMethod]
        public void Clear_DeleteAllItems_NewItemReturned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();
            IGameObject newGameItem = new SalaryAddition();
           
            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);
            goList.Clear();
            goList.Add(newGameItem);
        
            // assert
            Assert.AreEqual(newGameItem, goList.First);
        }

        [TestMethod]
        public void Contains_FindsItem_TrueReturned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject contained = new SalaryAddition();
            IGameObject notContained = new SalaryAddition();
            bool isContainsTrue = false;      
            bool isContainsFalse = false;
            bool expectedTrue = true;
            bool expectedFalse = false;
            // act
            goList.Add(contained);
            isContainsTrue = goList.Contains(contained);
            isContainsFalse = goList.Contains(notContained);
            // assert
            Assert.AreEqual(expectedTrue, isContainsTrue);
            Assert.AreEqual(expectedFalse, isContainsFalse);
        }

        [TestMethod]
        public void CopyTo_CopyItemsToArray_TrueReturned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject[] goArr = new IGameObject[5];
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();
            bool expectedTrue = true;
            bool actual = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;

            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);
            goList.CopyTo(goArr);
            flag1 = goArr[0] == goList[0];
            flag2 = goArr[1] == goList[1];
            flag3 = goArr[2] == goList[2];
            if (flag1 == flag2 == flag3 == true)
            {
                actual = true;
            }
            // assert
            Assert.AreEqual(expectedTrue, actual);
        }

        [TestMethod] 
        public void CopyToWithArrayIndexParam_CopyItemsToArray_TrueReturned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject[] goArr = new IGameObject[5];
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();
            bool expectedTrue = true;
            bool actual = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;

            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);
            goList.CopyTo(goArr, 2);
            flag1 = goArr[2] == goList[0];
            flag2 = goArr[3] == goList[1];
            flag3 = goArr[4] == goList[2];
            if (flag1 == flag2 == flag3 == true)
            {
                actual = true;
            }
            // assert
            Assert.AreEqual(expectedTrue, actual);
        }

        [TestMethod]
        public void CopyToWithArrayIndexAndCountAndIndex_CopyItemsToArray_TrueReturned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject[] goArr = new IGameObject[5];
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();
            bool expectedTrue = true;
            bool actual = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;

            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);
            goList.CopyTo(1, goArr, 2, 2);
            flag1 = goArr[2] == goList[1];
            flag2 = goArr[3] == goList[2];
            if (flag1 == flag2 == true)
            {
                actual = true;
            }
            // assert
            Assert.AreEqual(expectedTrue, actual);
        }

        [TestMethod]
        public void IndexOf_FindsItemAndReturnsIndex_1Returned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();           
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();
            IGameObject notContained = new SalaryAddition();
            int index, notIndex;
            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);
            index = goList.IndexOf(gameObject2);
            notIndex = goList.IndexOf(notContained);
            // assert
            Assert.AreEqual(1, index);
            Assert.AreEqual(-1, notContained);
        }

        [TestMethod]
        public void Remove_RemoveItemByRef_TrueReturned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();
            IGameObject notContained = new SalaryAddition();
            bool expected = false;
            bool actual;
            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);
            actual = goList.Remove(gameObject1);
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
