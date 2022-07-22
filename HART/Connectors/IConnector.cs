using HART.EventsArgs;

namespace HART.Connectors
{
    /// <summary>
    /// Общий интерфейс для реализации подключения к slave-устройствам.
    /// </summary>
    public interface IConnector
    {
        /// <summary>
        /// Открыт ли порт.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Оповещение о том, что сформированно новое сообщение от slave-устройства.
        /// </summary>
        event EventHandler<ResponseEventArgs> NewResponse;

        /// <summary>
        /// Открыть соединение.
        /// </summary>
        void Connect();

        /// <summary>
        /// Закрыть соединение.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Отправить запрос.
        /// </summary>
        /// <param name="buffer">Массив передаваемых данных.</param>
        void Request(byte[] buffer);

        /// <summary>
        /// Событие появления ошибки связи.
        /// </summary>
        event EventHandler<string> CommunicationError;
    }
}