using InterfaceLibrary.Interfaces;
using InterfaceLibrary.Interfaces.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TerrariumGame.Infrastructure;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Tests.InfrastructureTests
{
    [TestClass]
    public class GameObjectsListTest
    {
        private static IGameObjectsList goList;
        private static IGameObject gameObject1, gameObject2, gameObject3;

        [ClassInitialize]
        public static void GameObjectsListClassInitialize(TestContext testContext)
        {
            Debug.WriteLine("Test items initializing starts...");
            goList = new GameObjectsList();
            gameObject1 = new SalaryAddition(1, 1);
            gameObject2 = new SalaryAddition(2, 2);
            gameObject3 = new SalaryAddition(3, 3);

            bool debugIsNotNullflag = goList != null
                && gameObject1 != null
                && gameObject2 != null
                && gameObject3 != null;

            Debug.WriteLineIf(debugIsNotNullflag, "Test items initializing complete...");
            Debug.WriteLineIf(!debugIsNotNullflag, "Test items are null...");
        }

        [TestInitialize]
        public void GameObjectsListTestInitialize()
        {           
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            goList.Add(gameObject3);          

            bool debugIsContainsFlag = goList.Contains(gameObject1)
                && goList.Contains(gameObject2)
                && goList.Contains(gameObject3);

            Debug.WriteLineIf(debugIsContainsFlag, "Test items added to list...");
            Debug.WriteLineIf(!debugIsContainsFlag, "Add() method doesn't work right");
        }

        [TestCleanup]
        public void GameObjectListTestCleanUp()
        {
            goList.Clear();
            Debug.WriteLine("GameObjectsList is empty");
        }
               
        /// <summary>
        ///     Test for First property. 
        ///     Returs first item in the list.
        /// </summary>
        /// 
        [TestMethod]
        public void First_GetFirstItem_FirstItemReturned()
        {
            // arrange          
            var expectedGameObject = gameObject1;

            // act
            var actualFirstGameObject = goList.First;

            // assert
            Assert.AreSame(expectedGameObject, actualFirstGameObject);
        }

        /// <summary>
        ///     Test for Add() method.
        ///     Returns the last item in the list.
        /// </summary>
        [TestMethod]
        public void Add_NewItemAddedToList_LastItemReturned()
        {
            // arrange        
            IGameObject expectedNewGameObject = new SalaryAddition();

            // act
            goList.Add(expectedNewGameObject);
            var actualGameObject = goList.Last;

            // assert
            Assert.AreSame(expectedNewGameObject, actualGameObject);
        }

        /// <summary>
        ///     Test for Clear() method that removes all elements.
        ///     Returns new added item.
        /// </summary>
        [TestMethod]
        public void Clear_DeleteAllItems_NewFirstItemReturned()
        {
            // arrange
            IGameObject newGameItem = new SalaryAddition();

            // act
            goList.Clear();
            goList.Add(newGameItem);
            var actualGameObject = goList.First;

            // assert
            Assert.AreSame(newGameItem, actualGameObject);
        }

        [TestMethod]
        public void Clear_DeleteAllItems_NewLastItemReturned()
        {
            // arrange
            IGameObject newGameItem = new SalaryAddition();

            // act
            goList.Clear();
            goList.Add(newGameItem);
            var actualGameObject = goList.Last;

            // assert
            Assert.AreSame(newGameItem, actualGameObject);
        }

        /// <summary>
        ///     Test for Contains() method. 
        ///     Returns true.
        /// </summary>
        [TestMethod]
        public void Contains_FindsItem_ReturnsTrue()
        {
            // arrange
            var contained = gameObject1;

            // act
            bool result = goList.Contains(contained);

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        ///     Test for Contains() method. 
        ///     Returns false.
        /// </summary>
        [TestMethod]
        public void Contains_FindsItem_ReturnsFalse()
        {
            // arrange
            IGameObject notContained = new SalaryAddition();

            // act
            bool result = goList.Contains(notContained);

            // assert
            Assert.IsFalse(result);
        }

        #region CopyTo(IGameObject[] array) method
        /// <summary>
        ///     Test for CopyTo(IGameObject[] array) method. 
        ///     Returns true, if array has all item 
        ///     that contained in the GameObjectList.
        /// </summary>
        [TestMethod]
        public void CopyTo_CopyItemsToArray_FirstInArrayReturned()
        {
            // arrange
            IGameObject[] goArr = new IGameObject[5];

            // act
            goList.CopyTo(goArr);

            // assert
            Assert.AreSame(goArr[0], goList.First);
        }

        [TestMethod]
        public void CopyTo_CopyItemsToArray_SecondInArrayReturned()
        {
            // arrange
            IGameObject[] goArr = new IGameObject[5];

            // act
            goList.CopyTo(goArr);

            // assert
            Assert.AreSame(goArr[1], goList[1]);
        }

        [TestMethod]
        public void CopyTo_CopyItemsToArray_ThirdInArrayReturned()
        {
            // arrange
            IGameObject[] goArr = new IGameObject[5];

            // act
            goList.CopyTo(goArr);

            // assert
            Assert.AreSame(goArr[2], goList.Last);
        }
        #endregion

        #region CopyTo(IGameObject[] array, int arrayIndex) method
        /// <summary>
        ///     Test for CopyTo(IGameObject[] array, int arrayIndex) method. 
        ///     Returns true, if array has all item on certain indexes
        ///     that contained in the GameObjectList.
        /// </summary>
        [TestMethod]
        public void CopyToWithArrayIndexParam_CopyItemsToArray_FirstInArrayReturned()
        {
            // arrange
            IGameObject[] goArr = new IGameObject[5];

            // act
            goList.CopyTo(goArr, 2);

            // assert
            Assert.AreSame(goArr[2], goList.First);
        }

        [TestMethod]
        public void CopyToWithArrayIndexParam_CopyItemsToArray_SecondInArrayReturned()
        {
            // arrange
            IGameObject[] goArr = new IGameObject[5];

            // act
            goList.CopyTo(goArr, 2);

            // assert
            Assert.AreSame(goArr[3], goList[1]); 
        }

        [TestMethod]
        public void CopyToWithArrayIndexParam_CopyItemsToArray_ThirdInArrayReturned()
        {
            // arrange
            IGameObject[] goArr = new IGameObject[5];

            // act
            goList.CopyTo(goArr, 2);

            // assert
            Assert.AreSame(goArr[4], goList[2]);
        }
        #endregion

        #region CopyTo(int index, IGameObject[] array, int arrayIndex, int count) method

        /// <summary>
        ///     Test for CopyTo(int index, IGameObject[] array,
        ///     int arrayIndex, int count) method. 
        ///     Returns true, if array has all item on certain indexes
        ///     that contained in the GameObjectList.
        /// </summary>
        [TestMethod]
        public void CopyToWithArrayIndexAndCountAndIndex_CopyItemsToArray_NothingInArrayReturned()
        {
            // arrange
            IGameObject[] goArr = new IGameObject[5];

            // act
            goList.CopyTo(1, goArr, 2, 2);

            // assert
            Assert.AreNotSame(goArr[1], goList[0]);           
        }

        [TestMethod]
        public void CopyToWithArrayIndexAndCountAndIndex_CopyItemsToArray_SecondInArrayReturned()
        {
            // arrange
            IGameObject[] goArr = new IGameObject[5];

            // act
            goList.CopyTo(1, goArr, 2, 2);

            // assert
            Assert.AreSame(goArr[2], goList[1]);
        }

        [TestMethod]
        public void CopyToWithArrayIndexAndCountAndIndex_CopyItemsToArray_ThirdInArrayReturned()
        {
            // arrange
            IGameObject[] goArr = new IGameObject[5];

            // act
            goList.CopyTo(1, goArr, 2, 2);

            // assert
            Assert.AreSame(goArr[3], goList[2]);
        }

        #endregion

        /// <summary>
        ///     Test for IndexOf() method.
        ///     Returns -1.
        /// </summary>     
        [TestMethod]
        public void IndexOf_NotFindsItemAndReturnsIndex_Negative1Returned()
        {
            // arrange
            IGameObject notContained = new SalaryAddition();

            // act
            int result = goList.IndexOf(notContained);

            // assert
            Assert.AreEqual(-1, result);
        }

        /// <summary>
        ///     Test for Remove(IGameObject item) method.
        ///     Returns true.
        /// </summary>
        [TestMethod]
        public void Remove_RemoveItemByRef_ReturnsTrue()
        {
            // arrange
            IGameObject removeGameObject = new SalaryAddition();

            // act
            goList.Add(removeGameObject);
            bool result = goList.Remove(removeGameObject);

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        ///     Test for Remove(IGameObject item) method.
        ///     Returns false.
        /// </summary>
        [TestMethod]
        public void Remove_RemoveItemByRef_ReturnsFalse()
        {
            // arrange
            IGameObject notContained = new SalaryAddition();

            // act
            bool result = goList.Remove(notContained);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Count_ReturnsItemsCount_3Returned()
        {
            // arrange

            // act
            int actualCountValue = goList.Count;

            // assert
            Assert.AreEqual(3, actualCountValue);
        }

        [TestMethod]
        public void ToList_CopyAllItemsToNewList_ItemsInListReturned()
        {
            // arrange

            // act
            var list = goList.ToList();

            // assert
            Assert.AreSame(list[0], goList[0]);
            Assert.AreSame(list[1], goList[1]);
            Assert.AreSame(list[2], goList[2]);
        }

        /// <summary>
        ///     Test for IndexOf() method.
        ///     Returns second item's index 1.
        /// </summary>
        [TestMethod]
        public void IndexOf_FindsItemAndReturnsIndex_1Returned()
        {
            // arrange
            foreach (var el in goList)
            {
                Debug.WriteLine(goList.IndexOf(el));
            }
            // act
            int result = goList.IndexOf(gameObject2);

            // assert
            Assert.AreEqual(1, result);
        }        
    }
}
