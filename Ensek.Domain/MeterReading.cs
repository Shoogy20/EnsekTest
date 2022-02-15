using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace Ensek.Domain
{
   public  class MeterReading
   {
     
        //[Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      //  public int Id { get; set; }
        public int AccountId { get; set; }

        public DateTime MeterReadingDate { get; set; }
        public int MeterReadingValue { get; set; }
   }
}
