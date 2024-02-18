using BeautySalon.BLL.Clents;
using BeautySalon.BLL.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeuatySalon.TG.Handlers.MessageHandlers
{
    public class OrderHandler
    {

        public void CreateNewOrder(NewOrderInputModel model)
        {
            OrderClient orderClient = new OrderClient();
            orderClient.CreateNewOrder(model);
        }
    }
}

