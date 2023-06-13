using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class CustomerBO
    {
        private string _nameOfCustomer;
        private string _cityOfCustomer;
        private int _gradeOfCustomer;
        private int _idOfSalesman;

        public string NameOfCustomer
        {
            get { return _nameOfCustomer; }
            set { _nameOfCustomer = value; }
        }
        public string CityOfCustomer
        {
            get { return _cityOfCustomer; }
            set { _cityOfCustomer = value; }
        }
        public int GradeOfCustomer
        {
            get { return _gradeOfCustomer; }
            set { _gradeOfCustomer = value; }       
        }
        public int IdOfSalesman
        {
            get { return _idOfSalesman; }
            set { _idOfSalesman = value;}
        }
    }
}
