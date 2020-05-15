namespace com.tenpines.advancetdd
{
    public class IntegrationEnvironment : Environment
    {
        public override ICustomerSystem GetCustomerSystem()
        {
            return new PersistCustomerSystem();
        }
    }
}