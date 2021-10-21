namespace lesson12
{
    public class MessageWriter : IMessageWriter
    {
        private readonly LoggerWriter _writer;

        public MessageWriter(LoggerWriter writer)
        {
            _writer = writer;
        }

        public void Write(string message)
        {
            _writer.Write(message);
        }
    }
}