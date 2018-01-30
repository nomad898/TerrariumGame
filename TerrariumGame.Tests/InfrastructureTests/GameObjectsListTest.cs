using InterfaceLibrary.Interfaces;
using InterfaceLibrary.Interfaces.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerrariumGame.Infrastructure;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Tests.InfrastructureTests
{
    [TestClass]
    public class GameObjectsListTest
    {
        private IGameObjectsList FillGameObjectList()
        {
            IGameObjectsList goList = new GameObjectsList();
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();

            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);

            return goList;
        }

        /// <summary>
        ///     Test for First property. 
        ///     Returs first item in the list.
        /// </summary>
        [TestMethod]
        public void First_GetFirstItem_FirstItemReturned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();

            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);

            var expectedGameObject = gameObject1;

            // act
            var actualFirstGameObject = goList.First;

            // assert
            Assert.AreEqual(expectedGameObject, actualFirstGameObject);
        }
        
        /// <summary>
        ///     Test for Add() method.
        ///     Returns the last item in the list.
        /// </summary>
        [TestMethod]
        public void Add_NewItemAddedToList_LastItemReturned()
        {
            // arrange
            IGameObjectsList goList = FillGameObjectList();

            IGameObject newGameObject = new SalaryAddition();
            
            // act
            goList.Add(newGameObject);

            // assert
            Assert.AreEqual(newGameObject, goList.Last);
        }

        /// <summary>
        ///     Test for Clear() method that removes all elements.
        ///     Returns new added item.
        /// </summary>
        [TestMethod]
        public void Clear_DeleteAllItems_NewFirstItemReturned()
        {
            // arrange
            IGameObjectsList goList = FillGameObjectList();

            IGameObject newGameItem = new SalaryAddition();

            // act
            goList.Clear();
            goList.Add(newGameItem);
        
            // assert
            Assert.AreEqual(newGameItem, goList.First);
        }

        /// <summary>
        ///     Test for Contains() method. 
        ///     Returns true.
        /// </summary>
        [TestMethod]
        public void Contains_FindsItem_TrueReturned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject contained = new SalaryAddition();
            bool isContainsTrue = false;      
            bool expectedTrue = true;

            // act
            goList.Add(contained);
            isContainsTrue = goList.Contains(contained);

            // assert
            Assert.AreEqual(expectedTrue, isContainsTrue);
        }

        /// <summary>
        ///     Test for Contains() method. 
        ///     Returns false.
        /// </summary>
        [TestMethod]
        public void Contains_FindsItem_FalseReturned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject notContained = new SalaryAddition();
            bool isContainsFalse = false;
            bool expectedFalse = false;

            // act
            isContainsFalse = goList.Contains(notContained);

            // assert
            Assert.AreEqual(expectedFalse, isContainsFalse);
        }


        /// <summary>
        ///     Test for CopyTo(IGameObject[] array) method. 
        ///     Returns true, if array has all item 
        ///     that contained in the GameObjectList.
        /// </summary>
        [TestMethod]
        public void CopyTo_CopyItemsToArray_TrueReturned()
        {
            // arrange
            IGameObjectsList goList = FillGameObjectList();
            IGameObject[] goArr = new IGameObject[5];
            bool expectedTrue = true;
            bool actual = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;

            // act
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

        /// <summary>
        ///     Test for CopyTo(IGameObject[] array, int arrayIndex) method. 
        ///     Returns true, if array has all item on certain indexes
        ///     that contained in the GameObjectList.
        /// </summary>
        [TestMethod] 
        public void CopyToWithArrayIndexParam_CopyItemsToArray_TrueReturned()
        {
            // arrange
            IGameObjectsList goList = FillGameObjectList();
            IGameObject[] goArr = new IGameObject[5];
            bool expectedTrue = true;
            bool actual = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;

            // act
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

        /// <summary>
        ///     Test for CopyTo(int index, IGameObject[] array,
        ///     int arrayIndex, int count) method. 
        ///     Returns true, if array has all item on certain indexes
        ///     that contained in the GameObjectList.
        /// </summary>
        [TestMethod]
        public void CopyToWithArrayIndexAndCountAndIndex_CopyItemsToArray_TrueReturned()
        {
            // arrange
            IGameObjectsList goList = FillGameObjectList();
            IGameObject[] goArr = new IGameObject[5];
            bool expectedTrue = true;
            bool actual = false;
            bool flag1 = false;
            bool flag2 = false;
            // act
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

        /// <summary>
        ///     Test for IndexOf() method.
        ///     Returns second item's index 1.
        /// </summary>
        [TestMethod]
        public void IndexOf_FindsItemAndReturnsIndex_1Returned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();           
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            int index, expectedValue = 1;
            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            index = goList.IndexOf(gameObject2);
            // assert
            Assert.AreEqual(expectedValue, index);
        }

        /// <summary>
        ///     Test for IndexOf() method.
        ///     Returns -1.
        /// </summary>     
        [TestMethod]        
        public void IndexOf_NotFindsItemAndReturnsIndex_Negative1Returned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();
            IGameObject notContained = new SalaryAddition();
            int notIndex, expectedValue = -1;

            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);
            notIndex = goList.IndexOf(notContained);

            // assert
            Assert.AreEqual(expectedValue, notIndex);
        }

        /// <summary>
        ///     Test for Remove(IGameObject item) method.
        ///     Returns true.
        /// </summary>
        [TestMethod]
        public void Remove_RemoveItemByRef_TrueReturned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();
            bool expected = true;
            bool actual = false;

            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);
            actual = goList.Remove(gameObject1);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Test for Remove(IGameObject item) method.
        ///     Returns false.
        /// </summary>
        [TestMethod]
        public void Remove_RemoveItemByRef_FalseReturned()
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
            actual = goList.Remove(notContained);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Count_ReturnsItemsCount_3Returned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();
            int actualCountValue, expectedCountValue = 3;

            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);
            actualCountValue = goList.Count;

            // assert
            Assert.AreEqual(expectedCountValue, actualCountValue);
        }

        [TestMethod]
        public void ToList_CopyAllItemsToNewList_TrueReturned()
        {
            // arrange
            IGameObjectsList goList = new GameObjectsList();
            IGameObject gameObject1 = new SalaryAddition();
            IGameObject gameObject2 = new SalaryAddition();
            IGameObject gameObject3 = new SalaryAddition();
            int actualCountValue, expectedCountValue = 3;

            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);
            actualCountValue = goList.Count;

            // assert
            Assert.AreEqual(expectedCountValue, actualCountValue);
        }
    }
}
