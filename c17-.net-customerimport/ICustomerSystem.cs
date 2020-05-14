using System.Collections.Generic;

namespace com.tenpines.advancetdd
{
    public interface ICustomerSystem
    {
        void BeginTransaction();
        void EndTransaction();
        void Close();
        Customer GetCustomer(string identificationType, string identificationNumber);
        IList<Customer> GetCustomers();
        void SaveCustomer(Customer customer);
    }
}