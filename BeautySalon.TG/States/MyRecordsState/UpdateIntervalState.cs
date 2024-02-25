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
   
        private List<IntervalsIdTitleStartTimeOutputModel> _intervals { get; set; }

        public UpdateIntervalState(int shiftId,int orderId) 
        {
            ShiftId = shiftId;
            OrderId = orderId;
        }
        public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            IntervalsHanlder intervalsHanlder = new IntervalsHanlder();
            ShiftIdInputModel model = new ShiftIdInputModel()
            {
                Id = ShiftId,
            };

            List<IntervalsIdTitleStartTimeOutputModel> _intervals=intervalsHanlder.GetFreeIntervalsOnCurrentShiftId(model);

            List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
            foreach (IntervalsIdTitleStartTimeOutputModel interval in _intervals)
            {
                List<InlineKeyboardButton[]> buttonsRows = this._intervals.Select(
                       intervals => {
                           InlineKeyboardButton button = InlineKeyboardButton.WithCallbackData(text: $"{interval.Title}, {interval.StartTime}", callbackData: interval.Title.ToString());
                           InlineKeyboardButton[] row = [button];

                           return row;
                       }
                   ).ToList();

                _intervals.Add( interval );
            }
            


        }
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.CallbackQuery.Data != "вернуться в главное меню")
            {
               
                UserHandler userHandler = new UserHandler();
                long chatId = update.CallbackQuery.From.Id;
                int? userId = userHandler.GetUserByChatId(chatId);
                bool isUserRegistered = userId != null;
                if (isUserRegistered == true)
                {
                    int masterIdFromBase = userHandler.GetFreeMasterIdByIntervalId(IntervalId);

                    OrderHandler orderHandler = new OrderHandler();
                    UpdateOrderClientByIdInput updateOrderClientByIdInput = new UpdateOrderClientByIdInput
                    {
                        ClientId = (int)userId,
                        MasterId = masterIdFromBase,
                        Id = this.OrderId,
                        IntervalId = this.IntervalId,
                    };
                    orderHandler.UpdateOrderTimeForClientById(updateOrderClientByIdInput);
                    return new RegistrationOverState();
                }
            }
            return new StartState();
        }

    }
}
