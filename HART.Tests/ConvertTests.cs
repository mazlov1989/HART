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
    }
}