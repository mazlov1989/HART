using HART.Messages;

namespace HART.EventsArgs
{
    public class ResponseEventArgs : EventArgs
    {
        public Response Response { get; }

        public List<byte> BinaryResponse { get; }

        public ResponseEventArgs(Response response)
        {
            Response = response;
        }

        public ResponseEventArgs(IEnumerable<byte> response)
        {
            BinaryResponse = new List<byte>(response);
        }
    }
}
