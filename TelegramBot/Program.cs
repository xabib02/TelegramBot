using System;
using Telegram.Bot;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Requests;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("5960376344:AAEwMu-9sHwcKGB_oBQgTAW6bj7CmONxygo");
            client.StartReceiving(update, Error);
            Console.ReadLine();
        }

        async static Task update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text != null)
            {
                 Console.WriteLine($"{message.Chat.FirstName} | {message.Text}");

                if (message.Text.ToLower().Contains("привет"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "тебя привествует чат общалка");
                    return;
                }

                if (message.Text.ToLower().Contains("что ты умеешь"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "я умею от фотошопит фотография \n ещё могу скинуть пранк голосувую с голосами девушки");
                    return;
                }

                if (message.Text.ToLower().Contains("как дела"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "нормално а у вас");
                    return;
                }
                if (message.Text.ToLower().Contains("мне скучно"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "я могу посоветовать вам несколько интересных \n YouTube \n Instagram \n TikTok \n Linnkedin \n или же прогуляетесь во чистому воздуху");
                    return;
                }
                if (message.Text.ToLower().Contains("мало денег"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "я могу посоветовать не сколько путей что бы у вас было финассовое сосстояние \n перое поставтье перед собой цель \n второе не сомневайтесь в нём \n третие стремитесь к нему не смотря не к чему \n эти три вещи помогут вашем проблемам");
                    return;
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "таких комманд у меня в базе не существуеть \n комманды: \n привет \n как дела \n мне скучно \n мне скучно \n мало денег \n что ты умеешь");
                    return;
                }
            }
            //birinchi null

            if (message.Photo != null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "нормалное фото но отправка мне документом");
                return;
            }

            if (message.Photo != null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "подождите: это обычно занимаеть 30 - 35 секундь");

                var fileId = update.Message.Photo.Last().FileId;
                var fileInfo = await botClient.GetFileAsync(fileId);
                var filePath = fileInfo.FilePath;


                return;
            }

        }

        async static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}