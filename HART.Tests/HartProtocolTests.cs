using HART.Connectors;
using HART.Messages;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Threading;

namespace HART.Tests
{
    [TestClass]
    public class HartProtocolTests
    {
        private HartProtocol hart;
        private readonly Queue<Response> response = new Queue<Response>();

        [TestMethod]
        public void ConnectTest()
        {
            const int portNumber = 6; // Номер COM-порта.
            const int numberOfRepeats = 3; // Количество повторов запроса команды для теста получения серии ответов..

            // Перед началом теста, необходимо убетиться, что COM-порт доступен и не занят. Иначе тест выполнять не имеет смысла.
            if (!SerialPortAdapter.IsPortAccessible(portNumber))
                Assert.Inconclusive();

            var connector = new SerialPortAdapter(portNumber);
            hart = new HartProtocol(connector, true, FrameFormats.Short);

            connector.DataReceived += NewData;

            var request = new Request(false, 0)
            {
                Preamble = 5,
                Command = 3
            };

            hart.Connect();
            Thread.Sleep(1000);
            Assert.IsTrue(hart.IsConnected);

            for (var i = 1; i <= numberOfRepeats; i++)
            {
                hart.Request(request);
                Thread.Sleep(1000);
            }

            hart.Disconnect();
            Assert.IsFalse(hart.IsConnected);
            Assert.IsTrue(hart.Messages.Count == 0);
            Assert.IsTrue(response.Count == numberOfRepeats);
        }

        private void NewData() => response.Enqueue(hart.Messages.Dequeue());

        [TestMethod]
        public void ShortAddressTest()
        {
            Assert.IsTrue(Request.SetAddress(true, 3)[0]==131);
            Assert.IsTrue(Request.SetAddress(true, 15)[0] == 143);
            Assert.IsTrue(Request.SetAddress(true, 8)[0] == 136);
            Assert.IsTrue(Request.SetAddress(false, 2)[0] == 2);
            Assert.IsTrue(Request.SetAddress(false, 9)[0] == 9);
            Assert.IsTrue(Request.SetAddress(false, 13)[0] == 13);
        }
    }
}
