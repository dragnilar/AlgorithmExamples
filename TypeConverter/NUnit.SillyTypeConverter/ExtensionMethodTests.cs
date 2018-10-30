using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using SillyTypeConverter;

namespace NUnit.SillyTypeConverter
{
    [TestFixture]
    public class ExtensionMethodTests
    {
        [Test]
        public void NotNullTests()
        {
            try
            {
                var bogus = new Faker();

                object conversionDummy = bogus.Random.Int();
                var randomInt = conversionDummy.ConvertTo<int?>();

                conversionDummy = bogus.Random.String();
                var randomString = conversionDummy.ConvertTo<string>();

                conversionDummy = bogus.Random.Decimal();
                var randomDecimal = conversionDummy.ConvertTo<decimal?>();

                conversionDummy = bogus.Random.Bool();
                var randomBool = conversionDummy.ConvertTo<bool?>();

                conversionDummy = bogus.Random.Long();
                var randomLong = conversionDummy.ConvertTo<long?>();

                conversionDummy = bogus.Random.Guid();
                var randomGuid = conversionDummy.ConvertTo<Guid?>();

                Assert.True(randomInt != default);
                Assert.True(randomString != default);
                Assert.True(randomDecimal != default);
                Assert.True(randomBool != default);
                Assert.True(randomLong != default);
                Assert.True(randomGuid != default);
                Console.WriteLine("(づ｡◕‿‿◕｡)づ ALL TESTS PASSED! HOORAY! (｡◕‿‿◕｡)");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail("An exception occurred, the whole stupid test failed. (╯°□°）╯︵ ┻━┻");
            }
        }

        [Test]
        public void TestConvertToDestProp()
        {
            try
            {
                var testVariable = new TestClass();

                var bogus = new Faker();

                object boxedInt = bogus.Random.Int();

                object boxedString = bogus.Random.String();

                object boxedDecimal = bogus.Random.Decimal();

                object boxedLong = bogus.Random.Long();

                //For the sake of the test, we will use true since bool is false by default. Bogus may make it false, which will be misleading.

                object boxedBool = true; 

                ConvertBoxedVariablesUsingToDestinationProp(testVariable, boxedBool, boxedString, boxedDecimal, boxedInt, boxedLong);

                Assert.True(testVariable.TestBool == (bool)boxedBool);
                Assert.True(testVariable.TestDecimal == (decimal)boxedDecimal);
                Assert.True(testVariable.TestLong == (long)boxedLong);
                Assert.True(testVariable.TestInt == (int)boxedInt);
                Assert.True(testVariable.TestString == (string)boxedString);
                Console.WriteLine("(づ｡◕‿‿◕｡)づ ALL TESTS PASSED! HOORAY! (｡◕‿‿◕｡)");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail("An exception occurred, the whole stupid test failed. (╯°□°）╯︵ ┻━┻");
            }

        }

        private static void ConvertBoxedVariablesUsingToDestinationProp(TestClass testVariable, object boxedBool,
            object boxedString, object boxedDecimal, object boxedInt, object boxedLong)
        {
            testVariable.TestBool = boxedBool.ConvertToDestinationProperty(testVariable, nameof(testVariable.TestBool));
            testVariable.TestString = boxedString.ConvertToDestinationProperty(testVariable, nameof(testVariable.TestString));
            testVariable.TestDecimal =
                boxedDecimal.ConvertToDestinationProperty(testVariable, nameof(testVariable.TestDecimal));
            testVariable.TestInt = boxedInt.ConvertToDestinationProperty(testVariable, nameof(testVariable.TestInt));
            testVariable.TestLong = boxedLong.ConvertToDestinationProperty(testVariable, nameof(testVariable.TestLong));
        }

        public class TestClass
        {
            public int TestInt { get; set; }
            public string TestString { get; set; }
            public decimal TestDecimal { get; set; }
            public long TestLong { get; set; }
            public bool TestBool { get; set; }
        }

    }
}
