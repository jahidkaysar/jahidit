using Microsoft.VisualStudio.TestTools.UnitTesting;
using ex11;
namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {




            int[] ab = { 5, 4, 88, 22, 11, 2 };
            BubbleSort x = new BubbleSort(ab);
            x.binarySort();
            int[] abc = { 2, 4, 5, 11, 22, 88 };
            CollectionAssert.AreEqual(abc,ab);

        }
     
    }
}
