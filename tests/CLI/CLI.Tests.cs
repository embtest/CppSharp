using CppSharp.Utils;
using NUnit.Framework;
using CLI;

public class CLITests : GeneratorTestFixture
{
    [Test]
    public void TestTypes()
    {
        // Attributed types
        var sum = new Types().AttributedSum(3, 4);
        Assert.That(sum, Is.EqualTo(7));
    }

    [Test]
    public void TestStdString()
    {
        Assert.AreEqual("test_test", new Date(0, 0, 0).TestStdString("test"));
    }

    [Test]
    public void GetEmployeeNameFromOrgTest()
    {
        using (EmployeeOrg org = new EmployeeOrg())
        {
            Assert.AreEqual("Employee", org.Employee.Name);
        }
    }

    [Test]
    public void TestConsumerOfEnumNestedInClass()
    {
        using (NestedEnumConsumer consumer = new NestedEnumConsumer())
        {
            Assert.AreEqual(ClassWithNestedEnum.NestedEnum.E1, consumer.GetPassedEnum(ClassWithNestedEnum.NestedEnum.E1));
        }
    }

    [Test]
    public void TestChangePassedMappedTypeNonConstRefParam()
    {
        using (TestMappedTypeNonConstRefParamConsumer consumer = new TestMappedTypeNonConstRefParamConsumer())
        {
            string val = "Initial";
            consumer.ChangePassedMappedTypeNonConstRefParam(ref val);

            Assert.AreEqual("ChangePassedMappedTypeNonConstRefParam", val);
        }
    }
}