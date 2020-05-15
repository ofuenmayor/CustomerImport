using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using FluentNHibernate.Testing.Values;
using NHibernate.Mapping;
using NHibernate.Util;
using Xunit;

namespace com.tenpines.advancetdd
{
    public class SupplierShould
    {
        /*
         * S,Supplier1,D,123
           NC,Pepe,Sanchez,D,22333444
           EC,D,5456774
           A,San Martin,3322,Olivos,1636,BsAs
           A,Maipu,888,Florida,1122,Buenos Aires
         *
         */

        [Fact]
        public void test01()
        {
            StreamReader stream = new StreamStubBuilder()
                .AddLine("S,Supplier1,D,123").Build();
            ICustomerSystem customerSystem = Environment.Current().GetCustomerSystem();
            ISupplierSystem supplierSystem = Environment.Current().GetSupplierSystem();
            SupplierImporter ASupplierImporter = new SupplierImporter(
                customerSystem,stream, supplierSystem);
            ASupplierImporter.Import();

            Assert.NotEmpty(supplierSystem.GetSuppliers());
        }
    }
}
