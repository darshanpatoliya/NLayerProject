using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class SalesmanBO
    {
        private string _nameOfSalesman;
        private string _cityOfSalesman;
        private decimal _commissionOfSalesman;

        //Declaring, getting and setting variables
        public string NameOfSalesman
        {
            get { return _nameOfSalesman;}
            set { _nameOfSalesman = value;}
        }
        public string CityOfSalesman
        {
            get { return _cityOfSalesman;}
            set { _cityOfSalesman = value;}
        }
        public decimal CommissionOfSalesman
        {
            get { return _commissionOfSalesman;}
            set { _commissionOfSalesman = value;}
        }
    }
}
