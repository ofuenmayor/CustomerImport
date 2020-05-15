using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tenpines.advancetdd
{
    public class SupplierImporter : CustomerImporter
    {
        private ISupplierSystem _supplierImporter;

        public SupplierImporter(ICustomerSystem customerSystem, StreamReader lineReader, ISupplierSystem supplierImporter) 
            : base(customerSystem, lineReader)
        {
            _supplierImporter = supplierImporter;
        }
        
    }
}
