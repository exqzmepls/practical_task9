using System;
using System.IO;
using ListLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestsForMyLinkedList
    {
        [TestMethod]
        public void TestDesigner1()
        {
            MyLinkedList<string> l = new MyLinkedList<string>();
            bool result = l.Last == l.First && l.First == null && l.Count == 0;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestDesigner2ReverseFalse()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            MyLinkedListNode<string> n = l.First;
            int i = 0;
            bool result = true;
            do
            {
                if (values[i++] != n.Value)
                {
                    result = false;
                    break;
                }
                n = n.Next;
            }
            while (n != l.First);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestDesigner2ReverseTrue()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values, true);
            MyLinkedListNode<string> n = l.First;
            int i = values.Length - 1;
            bool result = true;
            do
            {
                if (values[i--] != n.Value)
                {
                    result = false;
                    break;
                }
                n = n.Next;
            }
            while (n != l.First);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestDesigner2NullRef()
        {
            bool result = true;
            try
            {
                MyLinkedList<string> l = new MyLinkedList<string>(null);
            }
            catch
            {
                result = false;
            }
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void TestDesigner3()
        {
            MyLinkedList<string> l = new MyLinkedList<string>(8);
            MyLinkedListNode<string> n = l.First;
            bool result = l.Count == 8;
            do
            {
                if (n.Value != default)
                {
                    result = false;
                    break;
                }
                n = n.Next;
            }
            while (n != l.First);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestDesigner3BelowZero()
        {
            bool result = true;
            try
            {
                MyLinkedList<string> l = new MyLinkedList<string>(-4);
            }
            catch
            {
                result = false;
            }
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestRemoveTrue()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            bool result = l.Remove("a");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestRemoveFalse()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            bool result = l.Remove("r");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestRemoveNull()
        {
            bool result = true;
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            MyLinkedListNode<string> n = null;
            try
            {
                l.Remove(n);
            }
            catch
            {
                result = false;
            }
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestRemoveNotExisting()
        {
            bool result = true;
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            MyLinkedList<string> l2 = new MyLinkedList<string>(values);
            try
            {
                l.Remove(l2.First);
            }
            catch
            {
                result = false;
            }
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestRemoveFirst()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            l.RemoveFirst();
            bool result = l.First.Value != "a";
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestRemoveLast()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            l.RemoveLast();
            bool result = l.Last.Value != "e";
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestRemoveNode()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            l.Remove(l.First.Next);
            bool result = l.First.Next.Value != "b";
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestContainsTrue()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            bool result = l.Contains("c");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestContainsFalse()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            bool result = l.Contains("r");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestFindLast()
        {
            string[] values = { "a", "c", "c", "d", };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            MyLinkedListNode<string> f = l.FindLast("c");
            Assert.AreEqual(l.First.Next.Next, f);
        }
        [TestMethod]
        public void TestFindLastNull()
        {
            string[] values = { "a", "c", "c", "d", };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            MyLinkedListNode<string> f = l.FindLast("r");
            Assert.AreEqual(null, f);
        }
        [TestMethod]
        public void TestFind()
        {
            string[] values = { "a", "c", "c", "d", };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            MyLinkedListNode<string> f = l.Find("c");
            Assert.AreEqual(l.First.Next, f);
        }
        [TestMethod]
        public void TestFindNull()
        {
            string[] values = { "a", "c", "c", "d", };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            MyLinkedListNode<string> f = l.Find("r");
            Assert.AreEqual(null, f);
        }
        [TestMethod]
        public void TestAddAfterNull()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            bool result = true;
            try
            {
                l.AddAfter(null, "a");
            }
            catch
            {
                result = false;
            }

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void TestAddAfterExisting()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            bool result = true;
            try
            {
                l.AddAfter(l.First, l.Last);
            }
            catch
            {
                result = false;
            }

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void TestAddAfterDoesnotBelong()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            MyLinkedListNode<string> n = new MyLinkedListNode<string>();
            bool result = true;
            try
            {
                l.AddAfter(n, "a");
            }
            catch
            {
                result = false;
            }

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void TestAddBeforeNull()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            bool result = true;
            try
            {
                l.AddBefore(null, "a");
            }
            catch
            {
                result = false;
            }

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void TestAddBeforeExisting()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            bool result = true;
            try
            {
                l.AddBefore(l.First, l.Last);
            }
            catch
            {
                result = false;
            }

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void TestAddBeforeDoesnotBelong()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            MyLinkedListNode<string> n = new MyLinkedListNode<string>();
            bool result = true;
            try
            {
                l.AddBefore(n, "a");
            }
            catch
            {
                result = false;
            }

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestAddNullToEmpty()
        {
            MyLinkedList<string> l = new MyLinkedList<string>(0);
            MyLinkedListNode<string> n = null;
            bool result = true;
            try
            {
                l.AddLast(n);
            }
            catch
            {
                result = false;
            }

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void TestAddExistingToEmpty()
        {
            MyLinkedList<string> l = new MyLinkedList<string>(0);
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l2 = new MyLinkedList<string>(values);
            bool result = true;
            try
            {
                l.AddLast(l2.Last);
            }
            catch
            {
                result = false;
            }

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestAddBeforeFirst()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            l.AddBefore(l.First, "w");
            bool result = l.First.Value == "w";

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestAddBefore()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            l.AddBefore(l.First.Next, "w");
            bool result = l.First.Next.Value == "w";
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestAddAfter()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l = new MyLinkedList<string>(values);
            l.AddAfter(l.First, "w");
            bool result = l.First.Next.Value == "w";
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestReverse()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l1 = new MyLinkedList<string>(values);
            MyLinkedList<string> l2 = l1.Reverse();
            MyLinkedListNode<string> tmp1 = l1.First;
            MyLinkedListNode<string> tmp2 = l2.Last;
            bool result = true;
            do
            {
                if (tmp1.Value != tmp2.Value)
                {
                    result = false;
                    break;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Previous;
            }
            while (tmp2 != l2.Last);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestReverseStatic()
        {
            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l1 = new MyLinkedList<string>(values);
            MyLinkedList<string> l2 = MyLinkedList<string>.Reverse(l1);
            MyLinkedListNode<string> tmp1 = l1.First;
            MyLinkedListNode<string> tmp2 = l2.Last;
            bool result = true;
            do
            {
                if (tmp1.Value != tmp2.Value)
                {
                    result = false;
                    break;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Previous;
            }
            while (tmp2 != l2.Last);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestPrint()
        {
            StreamWriter os = new StreamWriter("output.txt", false);
            Console.SetOut(os);

            string[] values = { "a", "b", "c", "d", "e" };
            MyLinkedList<string> l1 = new MyLinkedList<string>(values);
            l1.Print();

            os.Close();

            bool result;
            using(StreamReader sr = new StreamReader("output.txt"))
            {
                result = sr.ReadLine() == "a b c d e";
            }

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestPrintEmpty()
        {
            StreamWriter os = new StreamWriter("output.txt", false);
            Console.SetOut(os);

            MyLinkedList<string> l1 = new MyLinkedList<string>();
            l1.Print();

            os.Close();

            bool result;
            using (StreamReader sr = new StreamReader("output.txt"))
            {
                result = sr.ReadLine() == "This list is empty.";
            }

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestSetValue()
        {
            MyLinkedListNode<string> node = new MyLinkedListNode<string>();
            node.Value = "abc";

            bool result = node.Value == "abc";

            Assert.AreEqual(true, result);
        }
    }
}
