using BeautySalon.BLL.Models;
using BeautySalon.TG.Handlers.MessageHandlers;
using BeautySalon.TG;
using BeautySalon.TG.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using BeautySalon.BLL.Models.InputModels;
using Telegram.Bot;
using System.Reflection;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Net.Mime.MediaTypeNames;

namespace BeuatySalon.TG.States.MyRecordsState
{
    public class UpdateIntervalState : AbstractState
    {
        public UpdateIntervalState(int shiftId,int orderId) 
        {
            ShiftId = shiftId;
            OrderId = orderId;
        }
        public override async void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            IntervalsHanlder intervalsHanlder = new IntervalsHanlder();
            ShiftIdInputModel model = new ShiftIdInputModel()
            {
                Id = ShiftId,
            };


            List<IntervalsIdTitleStartTimeOutputModel> _intervals = intervalsHanlder.GetFreeIntervalsOnCurrentShiftId(model);

            List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();

            List<InlineKeyboardButton[]> buttonsRows = _intervals.Select(
                (IntervalsIdTitleStartTimeOutputModel interval) =>
                {
                    InlineKeyboardButton button = InlineKeyboardButton.WithCallbackData(text: $"{interval.Title}, {interval.StartTime}", callbackData: interval.Id.ToString());
                    InlineKeyboardButton[] row = [button];

                    return row;
                }
            ).ToList();
            InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttonsRows);
            await  SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                      chatId: update.CallbackQuery.From.Id,
                      text: $"Время",
                      replyMarkup: inlineKeyboard,
                      cancellationToken: cancellationToken
                   );
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.CallbackQuery.Data != "вернуться в главное меню")
            {
                int intervalId = int.Parse(update.CallbackQuery.Data);
                
                UpdateOrderClientByIdInputModel updateOrderClientByIdInputModel = new UpdateOrderClientByIdInputModel
                {
                    Id = this.OrderId,
                    IntervalId = intervalId,
                };
                
                new OrderHandler().UpdateOrderTimeForClientById(updateOrderClientByIdInputModel);

                return new StartState();
            }

            return new StartState();
        }
    }
}
