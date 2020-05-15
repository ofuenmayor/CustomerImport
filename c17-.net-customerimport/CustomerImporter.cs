using System;
using System.Collections.Generic;
using System.IO;

namespace com.tenpines.advancetdd
{
    public class CustomerImporter
    {
        public const string CUSTOMER_IS_NULL_EXCEPTION = "Customer is null.";
        public const string FIELD_AMOUNT_IS_INVALID_EXCEPTION = "Record has invalid amount of fields.";
        public const string RECORD_IS_UNRECOGNIZED_EXCEPTION = "Record is unrecognized.";
        public const string DATABASE_IS_NULL_EXCEPTION = "Database is null.";
        public const string STREAM_READER_IS_NULL_EXCEPTION = "Stream Reader is null.";

        private readonly ICustomerSystem customerSystem;
        private readonly StreamReader _lineReader;
        private string _currentLine;
        private string[] _currentRecord;
        private Customer _newCustomer;

        public CustomerImporter(ICustomerSystem CustomerSystem, StreamReader lineReader)
        {
            customerSystem = CustomerSystem ?? throw new ArgumentException(DATABASE_IS_NULL_EXCEPTION);
            _lineReader = lineReader ?? throw new ArgumentException(STREAM_READER_IS_NULL_EXCEPTION);
        }

        public void Import()
        {
            customerSystem.BeginTransaction();

            InitializeImport();
            while (ReadNextLine())
            {
                CreateRecord();
                ImportRecord();
            }

            customerSystem.EndTransaction();
        }

        protected void ImportRecord()
        {
            if (IsCustomerRecord())
            {
                ImportCustomer();
            }
            else if (IsAddressRecord())
            {
                ImportAddress();
            }
            else
            {
                throw new ArgumentException(RECORD_IS_UNRECOGNIZED_EXCEPTION);
            }
        }

        protected void ImportAddress()
        {
            _ = _newCustomer ?? throw new ArgumentException(CUSTOMER_IS_NULL_EXCEPTION);
            if (_currentRecord.Length != 6)
            {
                throw new ArgumentException(FIELD_AMOUNT_IS_INVALID_EXCEPTION);
            }

            _newCustomer.AddAddress(new Address
            {
                StreetName = _currentRecord[1],
                StreetNumber = int.Parse(_currentRecord[2]),
                Town = _currentRecord[3],
                ZipCode = int.Parse(_currentRecord[4]),
                Province = _currentRecord[5]
            });
        }

        protected void ImportCustomer()
        {
            if (_currentRecord.Length != 5)
            {
                throw new ArgumentException(FIELD_AMOUNT_IS_INVALID_EXCEPTION);
            }

            _newCustomer = new Customer
            {
                FirstName = _currentRecord[1],
                LastName = _currentRecord[2],
                IdentificationType = _currentRecord[3],
                IdentificationNumber = _currentRecord[4]
            };

            customerSystem.SaveCustomer(_newCustomer);
        }

        protected void InitializeImport() =>
            _newCustomer = null;

        protected bool ReadNextLine() =>
            (_currentLine = _lineReader.ReadLine()) != null;

        protected bool IsAddressRecord() =>
            _currentLine.StartsWith("A");

        protected bool IsCustomerRecord() =>
            _currentLine.StartsWith("C");

        protected void CreateRecord() =>
            _currentRecord = _currentLine.Split(',');
    }
}