using PowerLab.Services.Interfaces;

namespace PowerLab.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
