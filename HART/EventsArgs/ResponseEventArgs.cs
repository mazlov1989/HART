using HART.Messages;

namespace HART.EventsArgs
{
    /// <summary>
    /// Аргументы события появления ответа.
    /// </summary>
    public class ResponseEventArgs : EventArgs
    {
        /// <summary>
        /// Расшифрованный ответ.
        /// </summary>
        public Response Response { get; }

        /// <summary>
        /// Ответ в бинарном виде.
        /// </summary>
        public List<byte> BinaryResponse { get; }

        /// <summary>
        /// Создать новый экземпляр класса <see cref="ResponseEventArgs"/>.
        /// </summary>
        /// <param name="response">Расшифрованный ответ</param>
        public ResponseEventArgs(Response response)
        {
            Response = response;
        }

        /// <summary>
        /// Создать новый экземпляр класса <see cref="ResponseEventArgs"/>.
        /// </summary>
        /// <param name="response">Ответ в бинарном виде</param>
        public ResponseEventArgs(IEnumerable<byte> response)
        {
            BinaryResponse = new List<byte>(response);
        }
    }
}
