using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class OrderBL
    {
        public int InsertNewOrder(OrderBO order)
        {
            int result = 0;
            OrderDA dataAccessOfOrder = new OrderDA();
            result = dataAccessOfOrder.InsertOrder(order);

            return result;
        }
    }
}
