using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using System.Text.RegularExpressions;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotExperiments
{

    class Program
    {
        MessageHandler messageHandler = new MessageHandler();
        static ITelegramBotClient bot = new TelegramBotClient("5030358824:AAGj-FAbXZ8-7zsO7OWnM3T7DFjk3qgpKL4");

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            Console.WriteLine("Hello");
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                Console.WriteLine("Hello world");



            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            await Task.Run(() => Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception)));
        }
      
        public static class Params
        {
            public static int param1;
            public static string param2;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);
            Params.param1 = 100;
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            
            bot.StartReceiving(HandleUpdateAsync,HandleErrorAsync,receiverOptions,cancellationToken);
            Console.ReadLine();
        }


    }
}