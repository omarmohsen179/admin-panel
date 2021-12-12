using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.Models
{
    public class SectionImages
    {        
        public string ImagePath { get; set; }
        public int SectionId { get; set; }
        [JsonIgnore]
        public Section Section { get; set; }
    }
}
