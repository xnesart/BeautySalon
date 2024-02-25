using BeautySalon.TG;
using BeautySalon.TG.States;
using BeautySalon.TG.States.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.States.AdminStates.Services.AddServices;

public class AddPriceState : AbstractState
{
    public AddPriceState(string title, int typeId, string duration)
    {
        Title = title;
        TypeId = typeId;
        Duration = duration;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {

        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться к выбору услуги",
                    callbackData: "вернуться к выбору услуги"),
            },
        });
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat.Id,
            "Назначьте цену услуги:",
            replyMarkup: inlineKeyboard);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Message != null)
        {
            if (update.Message.Text != null)
            {
                decimal price = decimal.Parse(update.Message.Text);
                return new AddFinalState(Title, TypeId, Duration, price);
            }
        }
        else
        {
            if (update.CallbackQuery.Data == "вернуться к выбору услуги")
            {
                if (TypeId == 1)
                {
                    return new MakeUpForModifyState(TypeId, Password);
                }

                if (TypeId == 2)
                {
                    return new HaircutForModifyState(TypeId, Password);
                }

                if (TypeId == 3)
                {
                    return new ColoringForModifyState(TypeId, Password);
                }

                if (TypeId == 4)
                {
                    return new StylingForModifyState(TypeId, Password);
                }
            }
        }

        return new StartState();
    }
}