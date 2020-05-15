using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tenpines.advancetdd
{
    public class DevelopmentEnvironment : Environment
    {
        public override ICustomerSystem GetCustomerSystem()
        {
            return new TranscientCustomerSystem();
        }

        public static bool IsCurrent()
        {
            return Properties.Settings.Default.Environment == "Desarrollo";
        }
    }
}
