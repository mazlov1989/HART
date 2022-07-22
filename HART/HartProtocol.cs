using HART.Connectors;
using HART.EventsArgs;
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
        public event EventHandler<ResponseEventArgs> NewMessage;

        /// <summary>
        /// Событие появления ошибки связи.
        /// </summary>
        public event EventHandler<string> CommunicationError;

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

            _connector.NewResponse += (_, e) => OnNewResponse(Response.Deserialize(e.BinaryResponse));
            _connector.CommunicationError += OnCommunicationError;
        }

        /// <summary>
        /// Открыть соединение со slave-устройством.
        /// </summary>
        public bool Connect()
        {
            _connector.Connect();

            return IsConnected;
        }

        /// <summary>
        /// Закрыть соединение со slave-устройством.
        /// </summary>
        public bool Disconnect()
        {
            _connector.Disconnect();

            return IsConnected;
        }

        /// <summary>
        /// Отправить запрос.
        /// </summary>
        /// <param name="message">Сообщение-запрос.</param>
        /// <returns>Адрес устройства, которому было отправлено сообщение.</returns>
        public void Request(Request message) => _connector.Request(message.Serialize());

        /// <summary>
        /// Обработчик события <see cref="NewMessage"/>.
        /// </summary>
        /// <param name="response">Ответ.</param>
        private void OnNewResponse(Response response) => NewMessage?.Invoke(this, new ResponseEventArgs(response));

        /// <summary>
        /// Вызывает исполнение делегата <see cref="CommunicationError"/>.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="error">Текст ошибки.</param>
        private void OnCommunicationError(object sender, string error) => CommunicationError?.Invoke(sender, error);
    }
}
