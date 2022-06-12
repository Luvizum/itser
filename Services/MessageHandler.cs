namespace TelegramBotExperiments
{

    class MessageHandler
    {
        private UserMessage message;

        public UserMessage Message { get; set; }

        public MessageHandler()
        {
            Message = new UserMessage();
        }
    }
}