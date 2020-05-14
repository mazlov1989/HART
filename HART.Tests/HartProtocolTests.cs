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
            hart = new HartProtocol(connector);

            connector.DataReceived += NewData;

            var request = new Request(false, 0)
            {
                Preamble = 5,
                Command = 0
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
    }
}
