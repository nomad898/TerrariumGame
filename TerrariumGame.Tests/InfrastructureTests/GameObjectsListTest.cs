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
            IGameObject expectedGameObject = new SalaryAddition();
            goList.Add(expectedGameObject);
            
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
            IGameObjectsList goList = FillGameObjectList();
            IGameObject newGameObject = new SalaryAddition();
            
            // act
            goList.Add(newGameObject);
            var actualGameObject = goList.Last;

            // assert
            Assert.AreSame(newGameObject, actualGameObject);
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
            var actualGameObject = goList.First;
        
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
            IGameObjectsList goList = new GameObjectsList();
            IGameObject contained = new SalaryAddition();             

            // act
            goList.Add(contained);
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
            IGameObjectsList goList = new GameObjectsList();
            IGameObject notContained = new SalaryAddition();

            // act
            bool result = goList.Contains(notContained);

            // assert
            Assert.IsFalse(result);
        }


        /// <summary>
        ///     Test for CopyTo(IGameObject[] array) method. 
        ///     Returns true, if array has all item 
        ///     that contained in the GameObjectList.
        /// </summary>
        [TestMethod]
        public void CopyTo_CopyItemsToArray_ItemsInArrayReturned()
        {
            // arrange
            IGameObjectsList goList = FillGameObjectList();
            IGameObject[] goArr = new IGameObject[5];

            // act
            goList.CopyTo(goArr);

            // assert
            Assert.AreSame(goArr[0], goList[0]);
            Assert.AreSame(goArr[1], goList[1]);
            Assert.AreSame(goArr[2], goList[2]);
        }

        /// <summary>
        ///     Test for CopyTo(IGameObject[] array, int arrayIndex) method. 
        ///     Returns true, if array has all item on certain indexes
        ///     that contained in the GameObjectList.
        /// </summary>
        [TestMethod] 
        public void CopyToWithArrayIndexParam_CopyItemsToArray_ItemsInArrayReturned()
        {
            // arrange
            IGameObjectsList goList = FillGameObjectList();
            IGameObject[] goArr = new IGameObject[5];

            // act
            goList.CopyTo(goArr, 2);
           
            // assert
            Assert.AreSame(goArr[2], goList[0]);
            Assert.AreSame(goArr[3], goList[1]);
            Assert.AreSame(goArr[4], goList[2]);
        }

        /// <summary>
        ///     Test for CopyTo(int index, IGameObject[] array,
        ///     int arrayIndex, int count) method. 
        ///     Returns true, if array has all item on certain indexes
        ///     that contained in the GameObjectList.
        /// </summary>
        [TestMethod]
        public void CopyToWithArrayIndexAndCountAndIndex_CopyItemsToArray_ItemsInArrayReturned()
        {
            // arrange
            IGameObjectsList goList = FillGameObjectList();
            IGameObject[] goArr = new IGameObject[5];

            // act
            goList.CopyTo(1, goArr, 2, 2);

            // assert
            Assert.AreNotSame(goArr[1], goList[0]);
            Assert.AreSame(goArr[2], goList[1]);
            Assert.AreSame(goArr[3], goList[2]);           
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
            
            // act
            goList.Add(gameObject1);
            goList.Add(gameObject2);
            int result = goList.IndexOf(gameObject2);
            
            // assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        ///     Test for IndexOf() method.
        ///     Returns -1.
        /// </summary>     
        [TestMethod]        
        public void IndexOf_NotFindsItemAndReturnsIndex_Negative1Returned()
        {
            // arrange
            IGameObjectsList goList = FillGameObjectList();
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
            IGameObjectsList goList = new GameObjectsList();
            IGameObject gameObject = new SalaryAddition();
            
            // act
            goList.Add(gameObject);
            bool result = goList.Remove(gameObject);

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
            IGameObjectsList goList = FillGameObjectList();
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
            IGameObjectsList goList = FillGameObjectList();
           
            // act
            int actualCountValue = goList.Count;

            // assert
            Assert.AreEqual(3, actualCountValue);
        }

        [TestMethod]
        public void ToList_CopyAllItemsToNewList_ItemsInListReturned()
        {
            // arrange
            IGameObjectsList goList = FillGameObjectList();

            // act
            var list = goList.ToList();

            // assert
            Assert.AreSame(list[0], goList[0]);
            Assert.AreSame(list[1], goList[1]);
            Assert.AreSame(list[2], goList[2]);
        }
    }
}
