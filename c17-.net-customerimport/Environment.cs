using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tenpines.advancetdd
{
    public abstract class Environment
    {
        public static Environment Current()
        {
            if (DevelopmentEnvironment.IsCurrent())
            {
                return new DevelopmentEnvironment();
            }
            else
            {
                return new IntegrationEnvironment();
            }
        }

        public abstract ICustomerSystem GetCustomerSystem();

        public abstract ISupplierSystem GetSupplierSystem();

    }

    public interface ISupplierSystem
    {
    }
}
