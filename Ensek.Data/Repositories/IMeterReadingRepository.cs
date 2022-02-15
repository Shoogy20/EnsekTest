using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensek.Domain;
namespace Ensek.Data.Repositories
{
    public interface IMeterReadingRepository
    {
        /// <summary>
        /// Adds a single meter reading to the db
        /// </summary>
        /// <param name="meterReading"></param>
        void Add(MeterReading meterReading);

        /// <summary>
        /// Retrieves all meter readings from the db
        /// </summary>
        /// <returns></returns>
        IEnumerable<MeterReading> GetAll();

        /// <summary>
        /// Adds multiple meter readings to the db
        /// </summary>
        /// <param name="meterReadings"></param>
        /// <returns></returns>
        int BulkInsert(IList<MeterReading> meterReadings);

    }
}
