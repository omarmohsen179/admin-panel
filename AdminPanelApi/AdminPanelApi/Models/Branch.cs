using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string CountryEn { get; set; }
        public string CityEn { get; set; }
        public string AddressEn { get; set; }
        public IEnumerable<Number> Numbers { get; set; }
        public bool Active { get; set; }
    }
}
