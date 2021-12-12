using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.Models
{
    public class Number
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }

        public int BranchId { get; set; }
        [JsonIgnore]
        public Branch Branch { get; set; }
    }
}
