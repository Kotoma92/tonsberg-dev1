using Moq;
using NUnit.Framework;

namespace OnyxTestApp.Models
{
    public interface IStreamWriter
    {
        void WriteLine(string value);
    }

    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }

    public class Logger
    {
        private readonly IStreamWriter _writer;
        private readonly IDateTimeProvider _dateTimeProvider;

        public Logger(IStreamWriter writer, IDateTimeProvider dateTimeProvider)
        {
            _writer = writer;
            _dateTimeProvider = dateTimeProvider;

            Log("Logger initialized");
        }

        public void Log(string str)
        {
            _writer.WriteLine(string.Format("[{0:dd.MM.yy HH:mm:ss}] {1}", _dateTimeProvider.Now, str));
        }

    }

    public class LoggerTests
    {
        [Test]
        public void Log_PrefixesInputStringWithDateTime()
        {
            var mockWriter = new Mock<IStreamWriter>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            mockDateTimeProvider.Setup(d => d.Now).Returns(new DateTime(2023, 11, 12, 13, 13, 35));

            var logger = new Logger(mockWriter.Object, mockDateTimeProvider.Object);

            logger.Log("Test message");

            mockWriter.Verify(w => w.WriteLine(It.Is<string>(s => s.StartsWith("[12.11.23 13:13:35]"))));
        }
    }



}
