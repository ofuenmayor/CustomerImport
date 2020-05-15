using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Data;
using Iesi.Collections.Generic;

namespace com.tenpines.advancetdd
{
    public class Supplier
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string IdentificationType { get; set; }
        public virtual string IdentificationNumber { get; set; }
        public virtual IList<Address> Addresses { get; set; }
        public virtual IList<Customer> Customers { get; set; }
    }
}
