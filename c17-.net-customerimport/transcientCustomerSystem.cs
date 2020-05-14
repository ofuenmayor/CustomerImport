using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tenpines.advancetdd
{
    public class transcientCustomerSystem : ICustomerSystem
    {
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void EndTransaction()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(string identificationType, string identificationNumber)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public void SaveCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
