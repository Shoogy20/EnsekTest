using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ensek.Domain;

namespace Ensek.Web.Business
{
   public  interface IImportMeterReadings
   {
        /// <summary>
        /// Imports data from a given source
        /// </summary>
        /// <returns></returns>
        List<RawMeterReading> Import();

        /// <summary>
        /// Validates imported data
        /// </summary>
        /// <param name="rawMeterReadings"></param>
        /// <returns></returns>
        List<MeterReading> Validate(List<RawMeterReading> rawMeterReadings);
   }
}
