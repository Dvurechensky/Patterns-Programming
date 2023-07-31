namespace Base.UserLibrary.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        public TestContext TestContextInstance
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        private UserManagerMsTest manager = new UserManagerMsTest();

        /// <summary>
        /// DataSource - ����������� ��������� ������
        /// 1 �������� - ��� ����������
        /// 2 �������� - ������ ����������� ��� ���� � �����
        /// 3 �������� - ��� ������� ��� �������� XML
        /// 4 �������� - ��� ���������� ������ � ������� �� ��������� ������
        /// </summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TestData.xml",
            "User",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void AddDataTest()
        {
            string userId = Convert.ToString(TestContextInstance.DataRow["Row1"]);
        }
    }
}