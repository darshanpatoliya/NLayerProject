using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderBO
    {
        private SqlMoney _purchaseAmountOfOrder;
        private DateTime _dateOfOrder;
        private int _idOfCustomer;
        private int _idOfSalesman;

        public SqlMoney PurchaseAmountOfOrder
        {
            get { return _purchaseAmountOfOrder; }
            set { _purchaseAmountOfOrder = value; }
        }
        public DateTime DateOfOrder
        {
            get { return _dateOfOrder; }
            set { _dateOfOrder = value; }
        }
        public int IdOfCustomer
        {
            get { return _idOfCustomer; }
            set { _idOfCustomer = value; }
        }
        public int IdOfSalesman
        {
            get { return _idOfSalesman; }
            set { _idOfSalesman = value; }
        }
    }
}
