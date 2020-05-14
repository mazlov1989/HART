using HART.Messages;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HART.Tests
{
    [TestClass]
    public class MessagesTests
    {
        [TestMethod]
        public void RequestTest()
        {
            var expected = new byte[]
            {
                255, 255,255,
                2,
                0,
                0,
                0,
                2
            };


            var request = new Request(false, 0)
            {
                Preamble = 3,
                Command = 0
            };

            var actual = request.Serialize();

            Assert.IsTrue(expected.IsByteArrayEqual(actual));
        }

        [TestMethod]
        public void ResponseTest()
        {
            var data = new byte[]
            {
                255, 255, 255, 255, 255, 255, 255,         // Преамбула
                6,                                         // Ограничитель
                128,                                       // Адрес
                0,                                         // Номер команды
                14,                                        // Счетчик байтов.
                0, 0,                                      // Код отклика
                254, 254, 150, 8, 5, 78, 4, 1, 0, 0, 0, 0, // Данные
                88                                         // Контрольная сумма
            };

            var response = Response.Deserialize(data);
            var value = response.GetDate<byte[]>();
        }
    }
}
