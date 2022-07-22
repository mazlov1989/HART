using HART.EventsArgs;
using HART.Messages;

using System.IO.Ports;

namespace HART.Connectors
{
    /// <summary>
    /// Осуществляет возможность подключения к slave-устройству по серийному порту.
    /// </summary>
    public class SerialPortAdapter : IConnector
    {
        private readonly SerialPort _serialPort;
        private readonly List<byte> _newData = new();

        private bool _isPreambleSought;
        private bool _isPreambleFound;
        private bool _isAddressFound;
        private bool _addressIsLong;
        private bool _isCommandFound;
        private bool _commandIsLong;
        private bool _isCounterFound;
        private bool _isDataFound;
        private int _numberOfPreambleBytes;
        private int _numberOfDataBytes;
        private int _numberOfAddressBytes = 5;

        /// <summary>
        /// Открыт ли порт.
        /// </summary>
        public bool IsConnected => _serialPort.IsOpen;

        /// <summary>
        /// Время ожидания в милисекундах для завершения операции чтения.
        /// </summary>
        public int ReadTimeout
        {
            get => _serialPort.ReadTimeout;
            set => _serialPort.ReadTimeout = value;
        }

        /// <summary>
        /// Время ожидания в милисекундах для завершения операции чтения.
        /// </summary>
        public int WriteTimeout
        {
            get => _serialPort.ReadTimeout;
            set => _serialPort.ReadTimeout = value;
        }

        /// <inheritdoc/>
        public event EventHandler<string> CommunicationError;

        /// <summary>
        /// Оповещение о том, что сформированно новое сообщение от slave-устройства.
        /// </summary>
        public event EventHandler<ResponseEventArgs> NewResponse;

        /// <summary>
        /// Создать серийный порт для подключения.
        /// </summary>
        /// <param name="portNumber">Номер порта (цифра после COM, например 1, 2, … Чтобы получилось название порта).</param>
        /// <param name="baudRate">Скорость передачи в бодах.</param>
        /// <param name="parity">Протокол контроля чётности.</param>
        /// <param name="dataBits">Число битов данных.</param>
        /// <param name="stopBits">Число стоповых битов в байте.</param>
        public SerialPortAdapter(int portNumber, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            _serialPort = new SerialPort($"COM{portNumber}", baudRate, parity, dataBits, stopBits)
            {
                NewLine = Environment.NewLine
            };

            _serialPort.DataReceived += DataReceivedHandler;

            ReadTimeout = 1000;
            WriteTimeout = 1000;
        }

        /// <summary>
        /// Создать серийный порт для подключения.
        /// </summary>
        /// <param name="portNumber">Номер порта (цифра после COM, например 1, 2, … Чтобы получилось название порта).</param>
        public SerialPortAdapter(int portNumber) : this(portNumber, 1200, Parity.Odd, 8, StopBits.One)
        {
        }

        /// <summary>
        /// Проверить доступен ли указааный порт ввода/вывода.
        /// </summary>
        /// <param name="portNumber">Номер порта ввода/вывода.</param>
        /// <returns><see langword="true"/>, если порт доступен.</returns>        
        public static bool IsPortAccessible(int portNumber)
        {
            var result = false;
            var portName = $"COM{portNumber}";

            if (SerialPort.GetPortNames().Contains(portName))
            {
                var port = new SerialPort(portName);
                try
                {
                    port.Open();

                    if (port.IsOpen)
                    {
                        result = true;
                        port.Close();
                    }
                }
                catch (Exception)
                {
                    port.Dispose();
                }
            }

            return result;
        }

        /// <summary>
        /// Открыть соединение.
        /// </summary>
        public void Connect() => _serialPort.Open();

        /// <summary>
        /// Закрыть соединение.
        /// </summary>
        public void Disconnect() => _serialPort.Close();

        /// <summary>
        /// Отправить запрос.
        /// </summary>
        /// <param name="buffer">Массив передаваемых данных.</param>
        public void Request(byte[] buffer)
        {
            try
            {
                _serialPort.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                OnCommunicationError(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик события <see cref="SerialPort.DataReceived"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            var count = _serialPort.BytesToRead;
            var buffer = new byte[count];
            _serialPort.Read(buffer, 0, count);

            for (var i = 0; i < count; i++)
            {
                var value = buffer[i];

                if (!_isPreambleFound)
                {
                    if (!_isPreambleSought)
                    {
                        if (value == MessageBase.PreambleSymbol)
                        {
                            _numberOfPreambleBytes++;
                            _isPreambleSought = true;
                            _newData.Add(value);
                        }

                        continue;
                    }

                    if (value == MessageBase.PreambleSymbol)
                    {
                        _numberOfPreambleBytes++;
                        _newData.Add(value);
                        continue;
                    }

                    var isLimiter = value is 0x01 or 0x06 or 0x81 or 0x86;
                    if (_numberOfPreambleBytes >= 2 && isLimiter)
                    {
                        _isPreambleSought = false;
                        _isPreambleFound = true;
                        _addressIsLong = value is 0x86 or 0x81;
                        _newData.Add(value);
                        continue;
                    }

                    _isPreambleSought = false;
                    _isPreambleFound = false;
                    _newData.Clear();
                    ResetStatusMessage();
                    continue;
                }

                if (!_isAddressFound)
                {
                    if (_addressIsLong)
                    {
                        if (_numberOfAddressBytes > 0)
                        {
                            _numberOfAddressBytes--;
                            _newData.Add(value);
                            continue;
                        }

                        _isAddressFound = true;
                    }
                    else
                    {
                        _isAddressFound = true;
                        _newData.Add(value);
                        continue;
                    }
                }

                if (!_isCommandFound)
                {
                    if (!_commandIsLong)
                    {
                        _commandIsLong = value == 254;
                        _isCommandFound = !_commandIsLong;
                        _newData.Add(value);
                        continue;
                    }

                    _isCommandFound = true;
                    _newData.Add(value);
                    continue;
                }

                if (!_isCounterFound)
                {
                    _isCounterFound = true;
                    _numberOfDataBytes = value;
                    _newData.Add(value);
                    continue;
                }

                if (!_isDataFound)
                {
                    if (_numberOfDataBytes > 0)
                    {
                        _numberOfDataBytes--;
                        _newData.Add(value);
                        continue;
                    }

                    _isDataFound = true;
                }

                _newData.Add(value);

                OnDataReceived(_newData);
                ResetStatusMessage();
            }
        }

        /// <summary>
        /// Сбросить флаги, отвечающие за фомирование нового сообщения.
        /// </summary>
        private void ResetStatusMessage()
        {
            _isPreambleSought = false;
            _isPreambleFound = false;
            _isAddressFound = false;
            _addressIsLong = false;
            _isCommandFound = false;
            _commandIsLong = false;
            _isCounterFound = false;
            _isDataFound = false;

            _numberOfPreambleBytes = 0;
            _numberOfDataBytes = 0;
            _numberOfAddressBytes = 5;

            _newData.Clear();
        }

        /// <summary>
        /// Вызывает исполнение делегата <see cref="NewResponse"/>.
        /// </summary>
        /// <param name="data">Полученные данные</param>
        private void OnDataReceived(IEnumerable<byte> data) =>
            NewResponse?.Invoke(this, new ResponseEventArgs(data));

        /// <summary>
        /// Вызывает исполнение делегата <see cref="CommunicationError"/>.
        /// </summary>
        /// <param name="error">Текст ошибки.</param>
        protected void OnCommunicationError(string error) => CommunicationError?.Invoke(this, error);
    }
}
