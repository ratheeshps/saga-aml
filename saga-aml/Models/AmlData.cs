using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmlService.Models
{
    public class AmlData
    {
        [Key]
        public Guid TrackID { get; set; }
        public string CustomerName { get; set; }
        public string CountryName { get; set; }
        public string AmlStatus { get; set; }
        public Guid RemitterID { get; set; }
    }
}
