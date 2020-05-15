﻿using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;

namespace com.tenpines.advancetdd
{
    public class PersistCustomerSystem : ICustomerSystem
    {
        private ISession Session { get; }
        private ITransaction _transaction;

        public PersistCustomerSystem()
        {
            Session = NewConnection();
        }

        private ISession NewConnection()
        {
            var storeConfiguration = new StoreConfiguration();
            var configuration = Fluently.Configure()
                .Database(MsSqlCeConfiguration.Standard.ShowSql().ConnectionString("Data Source=CustomerImport.sdf"))
                .Mappings(m => m.AutoMappings.Add(AutoMap
                    .AssemblyOf<Customer>(storeConfiguration)
                    .Override<Customer>(map => map.HasMany(x => x.Addresses).Cascade.All())));

            var sessionFactory = configuration.BuildSessionFactory();
            new SchemaExport(configuration.BuildConfiguration()).Execute(true, true, false);

            return sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void EndTransaction()
        {
            _transaction.Commit();
        }

        public void Close()
        {
            Session.Close();
            Session.Dispose();
        }

        public Customer GetCustomer(string identificationType, string identificationNumber)
        {
            return this.Session
                .CreateCriteria(typeof(Customer))
                .Add(Restrictions.Eq("IdentificationType", identificationType))
                .Add(Restrictions.Eq("IdentificationNumber", identificationNumber))
                .List<Customer>()
                .Single();
        }

        public IList<Customer> GetCustomers()
        {
            return this.Session.CreateCriteria(typeof(Customer)).List<Customer>();
        }

        public void SaveCustomer(Customer customer)
        {
            this.Session.Persist(customer);
        }
    }
}