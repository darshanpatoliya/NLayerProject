using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CustomerBL
    {
        public int InsertNewCustomer(CustomerBO customer)
        {
            int result = 0;
            CustomerDA dataAccessOfCustomer = new CustomerDA();
            result = dataAccessOfCustomer.InsertCustomer(customer);

            return result;
        }
    }
}
