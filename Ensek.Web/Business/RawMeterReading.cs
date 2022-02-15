using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ensek.Web.Business
{
    public class RawMeterReading
    {
        public String AccountId { get; set; }
        public String MeterReadingDateTime { get; set; }

        public String MeterReadValue { get; set; }
    }
}
