using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using SillyTypeConverter;

namespace NUnit.SillyTypeConverter
{
    [TestFixture]
    public class TestClass
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
                Console.WriteLine("(づ｡◕‿‿◕｡)づ ALL TESTS PASSED! (｡◕‿‿◕｡)");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Assert.True(false, "An exception occurred, the whole stupid test failed. (╯°□°）╯︵ ┻━┻");
            }
        }
    }
}
