using Ensek.Web.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Ensek.Data.Repositories;
using Ensek.Domain;
using Ensek.Data;
using Moq;

namespace Ensek.UnitTesting
{
    [TestClass]
    public class ValidateTesting
    {
       
        [TestMethod]
        public void Reject_Duplicate_MeterReading()
        {

            List<RawMeterReading> csvMeterReadings = new List<RawMeterReading>();
            csvMeterReadings.Add(new RawMeterReading
            {
                AccountId = "2344",
                MeterReadingDateTime = "22/04/2019  09:24:00",
                MeterReadValue = "1002"
            });

           
            List<MeterReading> meterReadings = new List<MeterReading>();

            meterReadings.Add(new MeterReading
            {
                AccountId = 2344,
                MeterReadingDate = System.DateTime.Parse("22/04/2019 09:24:00"),
                MeterReadingValue = 1002
            });

            List<Account> accounts = new List<Account>();

            accounts.Add(new Account
            {
                    AccountId = 2344,
                    FirstName = "Tommy",
                    LastName = "Test"
            });
            

            var mockMRRepo = new Mock<IMeterReadingRepository>();
            var mockAccountRepo = new Mock<IAccountRepository>();

            mockMRRepo.Setup(x => x.GetAll()).Returns(meterReadings);
            mockAccountRepo.Setup(x => x.GetAll()).Returns(accounts);
            ImportCSVMeterReadings importCSV = new ImportCSVMeterReadings(mockMRRepo.Object,mockAccountRepo.Object);

            IList<MeterReading> newMeterReadings = importCSV.Validate(csvMeterReadings);

            Assert.AreEqual(newMeterReadings.Count, 0);

        }

        [TestMethod]
        public void Reject_Bad_MeterReading()
        {

            List<RawMeterReading> csvMeterReadings = new List<RawMeterReading>();
            csvMeterReadings.Add(new RawMeterReading
            {
                AccountId = "2344",
                MeterReadingDateTime = "22/04/2019  09:24:00",
                MeterReadValue = "Void"
            });


            List<MeterReading> meterReadings = new List<MeterReading>();

            meterReadings.Add(new MeterReading
            {

                AccountId = 2344,
                MeterReadingDate = System.DateTime.Parse("22/04/2019 09:24:00"),
                MeterReadingValue = 1002


            });

            List<Account> accounts = new List<Account>();

            accounts.Add(new Account
            {
                AccountId = 2344,
                FirstName = "Tommy",
                LastName = "Test"
            });


            var mockMRRepo = new Mock<IMeterReadingRepository>();
            var mockAccountRepo = new Mock<IAccountRepository>();

            mockMRRepo.Setup(x => x.GetAll()).Returns(meterReadings);
            mockAccountRepo.Setup(x => x.GetAll()).Returns(accounts);
            ImportCSVMeterReadings importCSV = new ImportCSVMeterReadings(mockMRRepo.Object, mockAccountRepo.Object);

            IList<MeterReading> newMeterReadings = importCSV.Validate(csvMeterReadings);

            Assert.AreEqual(newMeterReadings.Count, 0);

        }

        [TestMethod]
        public void Reject_NonExistent_Account()
        {

            List<RawMeterReading> csvMeterReadings = new List<RawMeterReading>();
            csvMeterReadings.Add(new RawMeterReading
            {
                AccountId = "1111",
                MeterReadingDateTime = "22/04/2019  09:24:00",
                MeterReadValue = "1002"
            });


            List<MeterReading> meterReadings = new List<MeterReading>();

            meterReadings.Add(new MeterReading
            {

                AccountId = 2344,
                MeterReadingDate = System.DateTime.Parse("22/04/2019 09:24:00"),
                MeterReadingValue = 1002


            });

            List<Account> accounts = new List<Account>();

            accounts.Add(new Account
            {
                AccountId = 2344,
                FirstName = "Tommy",
                LastName = "Test"
            });


            var mockMRRepo = new Mock<IMeterReadingRepository>();
            var mockAccountRepo = new Mock<IAccountRepository>();

            mockMRRepo.Setup(x => x.GetAll()).Returns(meterReadings);
            mockAccountRepo.Setup(x => x.GetAll()).Returns(accounts);
            ImportCSVMeterReadings importCSV = new ImportCSVMeterReadings(mockMRRepo.Object, mockAccountRepo.Object);

            IList<MeterReading> newMeterReadings = importCSV.Validate(csvMeterReadings);

            Assert.AreEqual(newMeterReadings.Count, 0);

        }

        [TestMethod]
        public void Reject_TooLarge_MeterReading()
        {

            List<RawMeterReading> csvMeterReadings = new List<RawMeterReading>();
            csvMeterReadings.Add(new RawMeterReading
            {
                AccountId = "2344",
                MeterReadingDateTime = "22/04/2019  09:24:00",
                MeterReadValue = "1000000"
            });


            List<MeterReading> meterReadings = new List<MeterReading>();

            meterReadings.Add(new MeterReading
            {

                AccountId = 2344,
                MeterReadingDate = System.DateTime.Parse("22/04/2019 09:24:00"),
                MeterReadingValue = 1002


            });

            List<Account> accounts = new List<Account>();

            accounts.Add(new Account
            {
                AccountId = 2344,
                FirstName = "Tommy",
                LastName = "Test"
            });


            var mockMRRepo = new Mock<IMeterReadingRepository>();
            var mockAccountRepo = new Mock<IAccountRepository>();

            mockMRRepo.Setup(x => x.GetAll()).Returns(meterReadings);
            mockAccountRepo.Setup(x => x.GetAll()).Returns(accounts);
            ImportCSVMeterReadings importCSV = new ImportCSVMeterReadings(mockMRRepo.Object, mockAccountRepo.Object);

            IList<MeterReading> newMeterReadings = importCSV.Validate(csvMeterReadings);

            Assert.AreEqual(newMeterReadings.Count, 0);

        }

        [TestMethod]
        public void Reject_BadDate()
        {

            List<RawMeterReading> csvMeterReadings = new List<RawMeterReading>();
            csvMeterReadings.Add(new RawMeterReading
            {
                AccountId = "2344",
                MeterReadingDateTime = "22/14/2019  09:24:00",
                MeterReadValue = "1002"
            });


            List<MeterReading> meterReadings = new List<MeterReading>();

            meterReadings.Add(new MeterReading
            {

                AccountId = 2344,
                MeterReadingDate = System.DateTime.Parse("22/04/2019 09:24:00"),
                MeterReadingValue = 1002


            });

            List<Account> accounts = new List<Account>();

            accounts.Add(new Account
            {
                AccountId = 2344,
                FirstName = "Tommy",
                LastName = "Test"
            });


            var mockMRRepo = new Mock<IMeterReadingRepository>();
            var mockAccountRepo = new Mock<IAccountRepository>();

            mockMRRepo.Setup(x => x.GetAll()).Returns(meterReadings);
            mockAccountRepo.Setup(x => x.GetAll()).Returns(accounts);
            ImportCSVMeterReadings importCSV = new ImportCSVMeterReadings(mockMRRepo.Object, mockAccountRepo.Object);

            IList<MeterReading> newMeterReadings = importCSV.Validate(csvMeterReadings);

            Assert.AreEqual(newMeterReadings.Count, 0);

        }


    }
}
