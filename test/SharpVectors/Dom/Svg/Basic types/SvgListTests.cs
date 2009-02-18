using System;

using NUnit.Framework;
using SharpVectors.Dom.Svg;

using SharpVectors.Dom;

namespace SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces
{
	[TestFixture]
	public class SvgListTests
	{
        #region Fields
        protected SvgList list;
        #endregion

        #region SetUp
        [SetUp]
        public void SetUp()
        {
            list = makeList();
        }
        #endregion

        #region Tests
        [Test]
        public void TestConstructor()
        {
            // make sure we can create an SvgList...if not something's really wrong
            Assert.IsTrue(list != null);
        }

        [Test]
        public void TestNewListSize()
        {
            // make sure a new list is empty
            Assert.AreEqual(list.NumberOfItems, 0);
        }

        [Test]
        public void TestInitializeSize()
        {
            // make sure an initialized list has one item
            list.Initialize( makeItem() );
            Assert.AreEqual(list.NumberOfItems, 1);
        }

        [Test]
        public void TestInitializeReturnValue()
        {
            // make sure initialize returns object used in initialize call
            object o1 = makeItem();
            object result;

            result = list.Initialize(o1);
            Assert.AreSame(o1, result);
        }
        
        [Test]
        public void TestInitializeGetItem()
        {
            // make sure initialized list's first item is item used in initialize call
            object o1 = makeItem();

            list.Initialize(o1);
            Assert.AreSame(o1, list.GetItem(0));
        }

        [Test]
        public void TestAppendItemSize()
        {
            // make sure new list with one call to appendItem has correct number of items
            list.AppendItem( makeItem() );
            Assert.AreEqual(list.NumberOfItems, 1);
            list.AppendItem( makeItem() );
            Assert.AreEqual(list.NumberOfItems, 2);
            list.AppendItem( makeItem() );
            Assert.AreEqual(list.NumberOfItems, 3);
        }

        [Test]
        public void TestAppendItemReturnValue()
        {
            // make sure appendItem returns item used in appendItem call
            object o1 = makeItem();
            object result;

            result = list.AppendItem(o1);
            Assert.AreSame(o1, result);
        }

        [Test]
        public void TestAppendItemGetItem()
        {
            // make sure empty list's first item is item used in appendItem call
            object o1 = makeItem();
            object o2 = makeItem();
            object o3 = makeItem();

            list.AppendItem(o1);
            list.AppendItem(o2);
            list.AppendItem(o3);
            Assert.AreSame(o1, list.GetItem(0));
            Assert.AreSame(o2, list.GetItem(1));
            Assert.AreSame(o3, list.GetItem(2));
        }

        [Test]
        [ExpectedException(typeof(DomException))]
        public void TestGetItemTooSmall()
        {
            // make sure empty list's first item is item used in appendItem call
            list.GetItem(0);
        }

        [Test]
        [ExpectedException(typeof(DomException))]
        public void TestGetItemTooBig()
        {
            // make sure empty list's first item is item used in appendItem call
            object o1 = makeItem();
            object o2 = makeItem();

            list.AppendItem(o1);
            list.AppendItem(o2);
            list.GetItem(2);
        }

        [Test]
        public void TestGetItem()
        {
            // make sure empty list's first item is item used in appendItem call
            object o1 = makeItem();
            object o2 = makeItem();
            object o3 = makeItem();

            list.AppendItem(o1);
            list.AppendItem(o2);
            list.AppendItem(o3);
            Assert.AreSame(o1, list.GetItem(0));
            Assert.AreSame(o2, list.GetItem(1));
            Assert.AreSame(o3, list.GetItem(2));
        }

        [Test]
        public void TestClearSize()
        {
            // make sure a cleared list is empty
            list.AppendItem( makeItem() );
            list.AppendItem( makeItem() );
            list.AppendItem( makeItem() );
            Assert.AreEqual(3, list.NumberOfItems);

            list.Clear();
            Assert.AreEqual(0, list.NumberOfItems);
        }

        [Test]
        [ExpectedException(typeof(DomException))]
        public void TestInsertItemBeforeTooSmall()
        {
            // make sure empty list's first item is item used in appendItem call
            object o1 = makeItem();

            list.InsertItemBefore(o1, 0);
        }

        [Test]
        [ExpectedException(typeof(DomException))]
        public void TestInsertItemBeforeTooBig()
        {
            // make sure empty list's first item is item used in appendItem call
            object o1 = makeItem();

            list.InsertItemBefore(o1, 2);
        }

        [Test]
        public void TestInsertItemBeforeReturnValue()
        {
            // make sure empty list's first item is item used in appendItem call
            object o1 = makeItem();
            object o2 = makeItem();
            object result;

            list.AppendItem(o1);
            result = list.InsertItemBefore(o2, 0);
            Assert.AreSame(result, o2);
        }

        [Test]
        public void TestInsertItemBeforeGetItem()
        {
            // make sure empty list's first item is item used in appendItem call
            object o1 = makeItem();
            object o2 = makeItem();
            object o3 = makeItem();

            list.AppendItem(o1);
            list.InsertItemBefore(o2, 0);
            Assert.AreSame(o1, list.GetItem(1));
            Assert.AreSame(o2, list.GetItem(0));
            list.InsertItemBefore(o3, 1);
            Assert.AreSame(o1, list.GetItem(2));
            Assert.AreSame(o2, list.GetItem(0));
            Assert.AreSame(o3, list.GetItem(1));
        }

        [Test]
        [ExpectedException(typeof(DomException))]
        public void TestReplaceItemTooSmall()
        {
            object o1 = makeItem();

            list.ReplaceItem(o1, 0);
        }

        [Test]
        [ExpectedException(typeof(DomException))]
        public void TestReplaceItemTooBig()
        {
            object o1 = makeItem();
            object o2 = makeItem();

            list.AppendItem(o1);
            list.ReplaceItem(o2, 1);
        }

        [Test]
        public void TestReplaceItemReturnValue()
        {
            object o1 = makeItem();
            object o2 = makeItem();
            object result;

            list.AppendItem(o1);
            result = list.ReplaceItem(o2, 0);
            Assert.AreSame(result, o2);
        }

        [Test]
        public void TestReplaceItem()
        {
            object o1 = makeItem();
            object o2 = makeItem();
            object o3 = makeItem();

            list.AppendItem(o1);
            list.AppendItem(o2);
            list.ReplaceItem(o3, 1);
            Assert.AreSame(o3, list.GetItem(1));
        }

        [Test]
        [ExpectedException(typeof(DomException))]
        public void TestRemoveItemTooSmall()
        {
            list.RemoveItem(0);
        }

        [Test]
        [ExpectedException(typeof(DomException))]
        public void TestRemoveItemTooBig()
        {
            object o1 = makeItem();
            object o2 = makeItem();

            list.AppendItem(o1);
            list.AppendItem(o2);
            list.RemoveItem(2);
        }

        [Test]
        public void TestRemoveItemReturnValue()
        {
            object o1 = makeItem();
            object o2 = makeItem();
            object result;

            list.AppendItem(o1);
            list.AppendItem(o2);

            result = list.RemoveItem(1);
            Assert.AreSame(result, o2);
        }

        [Test]
        public void TestRemoveItem()
        {
            object o1 = makeItem();
            object o2 = makeItem();
            object o3 = makeItem();

            list.AppendItem(o1);
            list.AppendItem(o2);
            list.AppendItem(o3);

            list.RemoveItem(1);
            Assert.AreEqual(2, list.NumberOfItems);
            Assert.AreSame(o1, list.GetItem(0));
            Assert.AreSame(o3, list.GetItem(1));
        }

        [Test]
        public void TestAppendItemExisting()
        {
            SvgList list2 = makeList();
            object o1 = makeItem();
            object o2 = makeItem();

            list.AppendItem(o1);
            list.AppendItem(o2);

            list2.AppendItem(o1);
            Assert.AreEqual(1, list.NumberOfItems);
            Assert.AreEqual(1, list2.NumberOfItems);
            Assert.AreSame(o2, list.GetItem(0));
            Assert.AreSame(o1, list2.GetItem(0));
        }

        [Test]
        public void TestReplaceItemExisting()
        {
            SvgList list2 = makeList();
            object o1 = makeItem();
            object o2 = makeItem();
            object o3 = makeItem();
            object o4 = makeItem();

            list.AppendItem(o1);
            list.AppendItem(o2);
            list.AppendItem(o3);

            list2.AppendItem(o4);
            list2.ReplaceItem(o2, 0);

            Assert.AreEqual(2, list.NumberOfItems);
            Assert.AreEqual(1, list2.NumberOfItems);
            Assert.AreSame(o1, list.GetItem(0));
            Assert.AreSame(o3, list.GetItem(1));
            Assert.AreSame(o2, list2.GetItem(0));
        }

        [Test]
        public void TestInsertItemExisting()
        {
            SvgList list2 = makeList();
            object o1 = makeItem();
            object o2 = makeItem();
            object o3 = makeItem();
            object o4 = makeItem();

            list.AppendItem(o1);
            list.AppendItem(o2);
            list.AppendItem(o3);

            list2.AppendItem(o4);
            list2.InsertItemBefore(o2, 0);

            Assert.AreEqual(2, list.NumberOfItems);
            Assert.AreEqual(2, list2.NumberOfItems);
            Assert.AreSame(o1, list.GetItem(0));
            Assert.AreSame(o3, list.GetItem(1));
            Assert.AreSame(o2, list2.GetItem(0));
            Assert.AreSame(o4, list2.GetItem(1));
        }

        [Test]
        public void TestEnumerator()
        {
            object[] items = { makeItem(), makeItem(), makeItem() };
            int index = 0;

            list.AppendItem(items[0]);
            list.AppendItem(items[1]);
            list.AppendItem(items[2]);

            foreach ( object item in list )
            {
                Assert.AreSame(items[index], item);
                index++;
            }
        }
        #endregion

        #region Support Methods
        protected virtual SvgList makeList()
        {
            return new SvgList();
        }

        protected virtual object makeItem()
        {
            return new object();
        }
        #endregion
	}
}
