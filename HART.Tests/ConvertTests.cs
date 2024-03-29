using HART.Helper;
using HART.Reference;

using Newtonsoft.Json.Linq;

namespace HART.Tests
{
    [TestClass]
    public class ConvertTests
    {
        [TestMethod]
        public void FromByteToStringTest()
        {
            var source = new List<byte> { 4, 222, 48, 194, 8, 32, 64, 244, 201, 80, 147, 206, 21, 40, 32, 130, 8, 32, 15, 3, 122 };

            var bTag = source.GetRange(0, 6);
            var bDescription = source.GetRange(6, 12);

            const string expectedTag = "AM800";
            const string expectedDescription = "POSITIONER";

            var actualTag = Convert.FromByte<string>(bTag.ToArray());
            var actualDescription = Convert.FromByte<string>(bDescription.ToArray());

            Assert.AreEqual(expectedTag, actualTag);
            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [TestMethod]
        public void FromByteToIntTest()
        {
            const int expected = int.MaxValue;
            var actual = Convert.FromByte<int>(Convert.ToByte(expected));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnitGetShortNameTest()
        {
            var unit = Unit�odes.DegreesCelsius;
            var expected = "�C";
            var actual = unit.GetShortName();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnitGetGroupNameTest()
        {
            var unit = Unit�odes.DegreesCelsius;
            var expected = "�����������";
            var actual = unit.GetGroupName();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnitGetFullNameTest()
        {
            var unit = Unit�odes.DegreesCelsius;
            var expected = "�������� �������";
            var actual = unit.GetFullName();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BitmaskTest()
        {
            var mask = new Bitmask(2);
            mask.SetFlag(true, 0);
            mask.SetFlag(true, 1);
            mask.SetFlag(true, 2);
            var result = mask.Get();

            short expected = 7;
            var actual = BitConverter.ToInt16(result, 0);
            Assert.AreEqual(expected, actual);
        }
    }
}