using BeautySalon.BLL.Models.Output_Models;
using BeautySalon.TG;
using BeautySalon.TG.States;
using BeuatySalon.TG.Handlers.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;


namespace BeuatySalon.TG.States.MasterState
{
    public class MastersNotesState : AbstractState
    {
        List<GetAllOrdersOnTodayForMasterOutputModel> onTodayForMasterOutputModels { get; set; }


        public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            OrderHandler orderHandler = new OrderHandler();

            List<GetAllOrdersOnTodayForMasterOutputModel> model = orderHandler.GetAllOrdersOnTodayForMasters();

            this.onTodayForMasterOutputModels = model;

            string text = "Ваши записи:\n";

            foreach (GetAllOrdersOnTodayForMasterOutputModel order in model)
            {
                text += $"{order.Client.Name},{order.Orders.Date}.\n";
            }

            
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                chatId: update.CallbackQuery.From.Id,
                text: text,
                cancellationToken: cancellationToken
            );
        }
        public override AbstractState ReceiveMessage(Update update)
        {
            throw new NotImplementedException();
        }
    }
    
}
       

