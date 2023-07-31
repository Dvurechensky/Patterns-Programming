using Base;

namespace BaseTests;

/// <summary>
/// ��������� ����
/// ����������������:
/// ����� �������� ����������� �������� ������ ������-���� �������
/// �������� ������ ������� �� ����������� � ������ �������
/// �������� ����� - �������� ������ �� ������
/// </summary>
[TestClass]
public class TestsMain
{
    /// <summary>
    /// ���������� ��������� ������ ���������� �����
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        // arrange
        int expected = 3;

        // act 
        var classMain = new ClassMain(4, "Unit", 10);
        int actual = classMain.countBuild;

        // assert
        Assert.AreEqual(expected, actual, 0.001, "BuildCount not correctly");   //���������� ���������� �������� � ���������
    }
}