using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Ensek.Domain;
using Ensek.Data.Repositories;

namespace Ensek.Web.Business
{
    public class ImportCSVMeterReadings: IImportMeterReadings
    {
        private readonly IMeterReadingRepository _meterReadingRepository;
        private readonly IAccountRepository _accountRepository;

        public ImportCSVMeterReadings(IMeterReadingRepository meterReadingRepository, IAccountRepository accountRepository)
        {
            _meterReadingRepository = meterReadingRepository;
            _accountRepository = accountRepository;
        }


        /// <summary>
        /// Method will import readings from a CSV files and return an unvalidated list
        /// </summary>
        /// <returns></returns>
        public List<RawMeterReading> Import()
        {
            
            //retrieve raw meter readings from specified input file
            List<RawMeterReading> csvMeterReadings;
            using (var streamReader = new StreamReader(@"C:\ENSEKExercise\Meter_Reading.csv"))
            { 
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvMeterReadings = csvReader.GetRecords<RawMeterReading>().ToList();

                }
            }

            return csvMeterReadings;
        }

        /// <summary>
        /// Method will validate raw meter readings
        /// </summary>
        /// <param name="rawMeterReadings"></param>
        /// <returns></returns>
        public List<MeterReading> Validate(List<RawMeterReading> rawMeterReadings)
        {
          
            List<MeterReading> meterReadings = new List<MeterReading>();

            //retrieve distinct meter readings
            List<RawMeterReading> distinctMeterReadings = rawMeterReadings.GroupBy(elem => new { elem.AccountId, elem.MeterReadingDateTime, elem.MeterReadValue }).Select(group => group.First()).ToList();

         
            //loop through each record in distinctMeterReadings. If a validation rule is broken then set validReading flag to false
            foreach (var mr in distinctMeterReadings)
            {
                    bool validReading = true;

                    //can meter value be parsed into an int with value no greater than 99999
                    int meterValue;
                    if (Int32.TryParse(mr.MeterReadValue, out meterValue))
                    {
                        if (meterValue > 99999)
                            validReading = false;
                            
                    }
                    else
                    {
                        validReading = false;
                    }

                    //can meter reading date be parsed into a DateTime
                    DateTime dateValue;
                    if (!(DateTime.TryParse(mr.MeterReadingDateTime, out dateValue)))
                    {
                        validReading = false;

                    }

                    //can accountid be parsed into an int does the account exist
                    int accountIdValue;
                    if (Int32.TryParse(mr.AccountId, out accountIdValue))
                    {
                        bool accountFound = _accountRepository.GetAll().Any(a => a.AccountId == accountIdValue);
                        if (!accountFound)
                            validReading = false;      
                    }
                    else
                    {
                        validReading = false;
                    }

                    //check to see if this meter reading already exists in database
                    bool meterReadingFound = _meterReadingRepository.GetAll().Any(m => m.AccountId == accountIdValue && m.MeterReadingValue == meterValue && m.MeterReadingDate == dateValue);
                    if (meterReadingFound)
                    {
                        validReading = false;
                    }

                    //if this is a valid reading then add to valid meter reading list
                    if (validReading)
                    {
                        meterReadings.Add(new MeterReading
                        {
                            AccountId = accountIdValue,
                            MeterReadingDate = dateValue,
                            MeterReadingValue = meterValue
                        });
                        
                    }
            }

            return meterReadings;

        }
    }
}
