using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SalesmanBL
    {
        public int InsertNewSalesman(SalesmanBO salesman)
        {
            int result = 0;
            SalesmanDA dataAccessOfSalesman = new SalesmanDA();
            result= dataAccessOfSalesman.InsertSalesman(salesman);

            return result;

        }
    }
}
