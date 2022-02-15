using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ensek.Data.Repositories;
using Ensek.Domain;
using Microsoft.AspNetCore.Mvc;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Ensek.Web.Business;


namespace Ensek.Web.Controllers
{
    public class MeterReadingController : ControllerBase
    {
        private readonly IMeterReadingRepository _meterReadingRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IImportMeterReadings _importMeterReadings;

        public MeterReadingController(IMeterReadingRepository meterReadingRepository, IAccountRepository accountRepository, IImportMeterReadings importMeterReadings)
        {
            _meterReadingRepository = meterReadingRepository;
            _accountRepository = accountRepository;
            _importMeterReadings = importMeterReadings;
        }

        /// <summary>
        /// End point for uploading a meter reading file
        /// </summary>
        /// <param name="meterReading"></param>
        [Route("meter-reading-uploads")]
        [HttpPost]
        public JsonResult Meter_Reading_Uploads(MeterReading meterReading)
        {
            
            //import data and return raw data
           List<RawMeterReading> rawMeterReadings = _importMeterReadings.Import();

            //return validated data
            if (rawMeterReadings != null)
            {
                List<MeterReading> validatedMeterReadings = _importMeterReadings.Validate(rawMeterReadings);

                if (validatedMeterReadings != null)
                {
                    int noRecordsAdded = _meterReadingRepository.BulkInsert(validatedMeterReadings);

                    string output = noRecordsAdded + " record(s) added. " + (rawMeterReadings.Count() - noRecordsAdded) + " record(s) rejected";

                    return new JsonResult(output);
                }
                else
                    return new JsonResult("Error");
            }
            else
                return new JsonResult("Error");
        }

    }
}
   

