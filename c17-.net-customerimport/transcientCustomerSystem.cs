using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tenpines.advancetdd
{
    public class TranscientCustomerSystem : ICustomerSystem
    {
        public List<Customer> aCustomers = new List<Customer>();
        public void BeginTransaction(){}

        public void EndTransaction(){}

        public void Close(){}

        public Customer GetCustomer(string identificationType, string identificationNumber)
        {
            return aCustomers.Single(
                customer => customer.IdentificationType == identificationType && customer.IdentificationNumber == identificationNumber);
        }

        public IList<Customer> GetCustomers()
        {
            return aCustomers;
        }

        public void SaveCustomer(Customer customer)
        {
           aCustomers.Add(customer);
        }
    }
}
