using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensek.Domain;
using Microsoft.EntityFrameworkCore;


namespace Ensek.Data.Repositories
{
    public class MeterReadingRepository: IMeterReadingRepository
    {
        private readonly EnsekContext _context;
        public MeterReadingRepository(EnsekContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a single MeterReading record to db
        /// </summary>
        /// <param name="meterReading"></param>
        public void Add(MeterReading meterReading)
        {
            _context.Add(meterReading);
            _context.SaveChanges();


        }
        /// <summary>
        /// Returns all meter readings from the db
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MeterReading> GetAll()
        {
            return _context.MeterReadings.OrderBy(m => m.AccountId);
        }

        /// <summary>
        /// Inserts multiple meter readings into db
        /// </summary>
        /// <param name="meterReadings"></param>
        /// <returns></returns>
        public int BulkInsert(IList<MeterReading> meterReadings)
        {
            _context.MeterReadings.AddRange(meterReadings);
            int noRecordsAdded = _context.SaveChanges();
            return noRecordsAdded;
        }
    }
}
