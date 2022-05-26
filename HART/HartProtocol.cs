using HART.Connectors;
using HART.Messages;

namespace HART
{
    /// <summary>
    /// Создает и управляет протоколом HART для общения с подключенными slave-устройствами.
    /// </summary>
    public class HartProtocol
    {
        private readonly IConnector _connector;

        /// <summary>
        /// <see langword="true"/>, если связь установлена со вторичным мастером.
        /// </summary>
        public bool IsSecondaryMaster { get; }

        /// <summary>
        /// Формат кадра.
        /// </summary>
        public FrameFormats FrameFormat { get; }

        /// <summary>
        /// Полученные сообщения.
        /// </summary>
        public Queue<Response> Messages = new();

        /// <summary>
        /// Открыто ли соединение со slave-устройством.
        /// </summary>
        public bool IsConnected => _connector.IsConnected;

        /// <summary>
        /// Оповещение о том, что получено новое сообщение от slave-устройства.
        /// </summary>
        public event Action NewMessage;

        /// <summary>
        /// Инициализировать соединение со slave-устройством по HART-протоколу.
        /// </summary>
        /// <param name="connector">Интерфейс обмена данными между устройствами.</param>
        /// <param name="isSecondaryMaster"><see langword="true"/>, если связь установлена со вторичным мастером.</param>
        /// <param name="frameFormat">Формат кадра.</param>
        public HartProtocol(IConnector connector, bool isSecondaryMaster, FrameFormats frameFormat)
        {
            _connector = connector;
            IsSecondaryMaster = isSecondaryMaster;
            FrameFormat = frameFormat;

            _connector.DataReceived += GetNewMessage;
        }

        /// <summary>
        /// Открыть соединение со slave-устройством.
        /// </summary>
        public void Connect() => _connector.Connect();

        /// <summary>
        /// Закрыть соединение со slave-устройством.
        /// </summary>
        public void Disconnect() => _connector.Disconnect();

        /// <summary>
        /// Отправить запрос.
        /// </summary>
        /// <param name="message">Сообщение-запрос.</param>
        /// <returns>Адрес устройства, которому было отправлено сообщение.</returns>
        public void Request(Request message) => _connector.Request(message.Serialize());

        /// <summary>
        /// Получить новое сообщение.
        /// </summary>
        private void GetNewMessage()
        {
            Messages.Enqueue(Response.Deserialize(_connector.Response()));
            NewMessage?.Invoke();
        }
    }
}
