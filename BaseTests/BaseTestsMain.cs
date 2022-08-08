//модульный тест

using Base;

namespace BaseTests
{
    [TestClass]
    public class BaseTestsMain
    {
        [TestMethod]
        public void TestMethod1()
        {
            int expected = 3;
            var classMain = new ClassMain(4, "Unit", 10);
            int actual = classMain.countBuild;
            Assert.AreEqual(expected, actual, 0.001, "BuildCount not correctly"); //сравниваем полученное значение с требуемым
        }
    }
}